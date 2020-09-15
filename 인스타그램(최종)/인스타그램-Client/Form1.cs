using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ClassLibrary1;

namespace 인스타그램_Client
{
    public partial class Form1 : Form
    {
        private NetworkStream m_networkstream;
        private TcpClient m_client;
        private byte[] sendbuffer = new byte[1024 * 4];
        private byte[] readbuffer = new byte[1024 * 4];
        private bool m_bConnect = false;

        public Join m_join;
        public Login m_login;
        public Search m_search;
        public Profile m_profile;
        public TileType m_tiletype;
        public ListType m_listtype;

        string clientStorage = "C:\\Users\\pminh\\Desktop\\2015726006_Client";
        string profilepath = string.Empty;
        string selectedID = string.Empty;
        int tile_x = 0, tile_y = 0;
        int listimg_x = 0, listimg_y = 50;
        int listtxt_x = 0, listtxt_y = 230;
        int listpro_x = 0, listpro_y = 0;
        int listid_x = 45, listid_y = 0;

        int totalimg_x = 0, totalimg_y = 60;
        int totaltxt_x = 0, totaltxt_y = 320;
        int totalpro_x = 0, totalpro_y = 0;
        int totalid_x = 60, totalid_y = 0;

        public Form1()
        {
            InitializeComponent();
        }

        public void Send()
        {
            m_networkstream.Write(sendbuffer, 0, sendbuffer.Length);
            m_networkstream.Flush();

            for (int i = 0; i < 1024 * 4; i++)
                sendbuffer[i] = 0;
        }

        public void Panel_Show()
        {
            homePanel.Visible = false;
            searchPanel.Visible = false;
            uploadPanel.Visible = false;
            mypagePanel.Visible = false;
            postPanel.Visible = false;
        }

        public void PicBox_Show()
        {
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Panel_Show();
            PicBox_Show();

            DirectoryInfo dir1 = new DirectoryInfo(clientStorage);
            if (!dir1.Exists)
                dir1.Create();

            string d2 = clientStorage + "\\profile";
            DirectoryInfo dir2 = new DirectoryInfo(d2);
            if (!dir2.Exists)
                dir2.Create();

            FileInfo file = new FileInfo("profile_img.jpg");
            file.CopyTo(d2 + "\\기본.jpg", true);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_bConnect)
            {
                m_client.Close();
                m_networkstream.Close();
            }
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if (ipTxt.Text == "" || portTxt.Text == "")
            {
                MessageBox.Show("IP 혹은 Port Number가 입력되지 않았습니다.");
                return;
            }

            m_client = new TcpClient();
            try
            {
                m_client.Connect(ipTxt.Text, int.Parse(portTxt.Text));
            }
            catch
            {
                MessageBox.Show("서버가 시작되지 않았습니다.");
                return;
            }

            m_bConnect = true;
            m_networkstream = m_client.GetStream();

            ipTxt.Enabled = false;
            portTxt.Enabled = false;
            connectBtn.Text = "Disconnect";
            connectBtn.ForeColor = Color.Red;

            idTxt.Enabled = true;
            pwTxt.Enabled = true;
            loginBtn.Enabled = true;
            joinBtn.Enabled = true;
        }

        private void joinBtn_Click(object sender, EventArgs e)
        {
            Join join = new Join();
            join.Type = (int)PacketType.회원가입;
            join.id = idTxt.Text;
            join.pw = pwTxt.Text;
            Packet.Serialize(join).CopyTo(sendbuffer, 0);
            this.Send();

            int nRead = 0;
            try
            {
                nRead = 0;
                nRead = m_networkstream.Read(readbuffer, 0, 1024 * 4);
            }
            catch
            {
                m_bConnect = false;
                m_networkstream = null;
            }

            Packet packet = (Packet)Packet.Deserialize(readbuffer);

            if ((int)packet.Type == (int)PacketType.회원가입)
            {
                m_join = (Join)Packet.Deserialize(readbuffer);

                if (m_join.chk == "중복안됨")
                    MessageBox.Show("회원가입이 정상적으로 완료되었습니다!");
                else if (m_join.chk == "중복됨")
                    MessageBox.Show("이미 사용중인 ID 입니다.");
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (loginBtn.Text == "로그아웃")
            {
                loginBtn.Text = "로그인";
                loginBtn.ForeColor = Color.Black;
                return;
            }

            Login login = new Login();
            login.Type = (int)PacketType.로그인;
            login.id = idTxt.Text;
            login.pw = pwTxt.Text;
            Packet.Serialize(login).CopyTo(sendbuffer, 0);
            this.Send();

            int nRead = 0;
            try
            {
                nRead = 0;
                nRead = m_networkstream.Read(readbuffer, 0, 1024 * 4);
            }
            catch
            {
                m_bConnect = false;
                m_networkstream = null;
            }

            Packet packet = (Packet)Packet.Deserialize(readbuffer);

            if ((int)packet.Type == (int)PacketType.로그인)
            {
                m_login = (Login)Packet.Deserialize(readbuffer);

                if (m_login.chk == "로그인성공")
                {
                    loginBtn.Text = "로그아웃";
                    loginBtn.ForeColor = Color.Red;
                }
                else if (m_login.chk == "로그인실패")
                {
                    MessageBox.Show("ID 또는 PW가 잘못되었습니다.\n 계정이 없다면 회원가입 버튼을 통해 계정을 만드십시오!");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            totalimg_x = 0;
            totalimg_y = 60;
            totaltxt_x = 0;
            totaltxt_y = 320;
            totalpro_x = 0;
            totalpro_y = 0;
            totalid_x = 60;
            totalid_y = 0;

            Panel_Show();
            PicBox_Show();
            homePanel.Visible = true;
            pictureBox1.BackColor = Color.LightSkyBlue;

            string d1 = clientStorage + "\\upload";
            DirectoryInfo dir1 = new DirectoryInfo(d1);
            if (!dir1.Exists)
                dir1.Create();

            // 이미지 파일 개수 세기
            int count = 0;
            foreach (var item in dir1.GetFiles())
            {
                if (item.Extension != ".txt")
                    count += 1;
            }

            // 이미지 파일 이름 배열에 담기
            int imgcount = 0;
            int txtcount = 0;
            string[] imgfilename = new string[count + 1];
            string[] txtfilename = new string[count + 1];
            foreach (var item in dir1.GetFiles())
            {
                if (item.Extension != ".txt")
                {
                    imgcount += 1;
                    imgfilename[imgcount] = item.FullName;
                }
                else
                {
                    txtcount += 1;
                    txtfilename[txtcount] = item.FullName;
                }
            }

            for (int i = count; i > 0; i--)
            {
                // 이미지 파일
                FileStream imgfs = new FileStream(imgfilename[i], FileMode.Open, FileAccess.Read);
                PictureBox imgpb = new PictureBox();
                imgpb.Width = 270;
                imgpb.Height = 250;
                imgpb.Location = new Point(totalimg_x, totalimg_y);
                imgpb.SizeMode = PictureBoxSizeMode.StretchImage;
                imgpb.Image = Image.FromStream(imgfs);
                homePanel.Controls.Add(imgpb);
                imgfs.Close();

                totalimg_y += 380;

                // 텍스트 파일
                TextBox tb = new TextBox();
                tb.Width = 270;
                tb.Height = 50;
                tb.Location = new Point(totaltxt_x, totaltxt_y);
                tb.Multiline = true;
                tb.Text = File.ReadAllText(txtfilename[i]);
                homePanel.Controls.Add(tb);

                totaltxt_y += 380;

                // 프로필 파일
                string str1 = Path.GetFileNameWithoutExtension(imgfilename[i]);
                string[] spl = str1.Split('_');

                FileStream profilefs = new FileStream(clientStorage + "\\profile\\" + spl[1] + "_profile.jpg", FileMode.Open, FileAccess.Read);
                PictureBox profilepb = new PictureBox();
                profilepb.Width = 50;
                profilepb.Height = 50;
                profilepb.Location = new Point(totalpro_x, totalpro_y);
                profilepb.SizeMode = PictureBoxSizeMode.StretchImage;
                profilepb.Image = Image.FromStream(profilefs);
                homePanel.Controls.Add(profilepb);
                profilefs.Close();

                totalpro_y += 380;

                // 계정 텍스트
                Label lb = new Label();
                lb.Text = spl[1];
                lb.Location = new Point(totalid_x, totalid_y);
                homePanel.Controls.Add(lb);

                totalid_y += 380;
            }
        }
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            searchListBox.Items.Clear();

            Panel_Show();
            PicBox_Show();
            searchPanel.Visible = true;
            pictureBox2.BackColor = Color.LightSkyBlue;

            Search search = new Search();
            search.Type = (int)PacketType.계정검색;
            Packet.Serialize(search).CopyTo(sendbuffer, 0);
            this.Send();

            int nRead = 0;
            while (m_bConnect)
            {
                try
                {
                    nRead = 0;
                    nRead = m_networkstream.Read(readbuffer, 0, 1024 * 4);
                }
                catch
                {
                    m_bConnect = false;
                    m_networkstream = null;
                }

                Packet packet = (Packet)Packet.Deserialize(readbuffer);

                if ((int)packet.Type == (int)PacketType.계정검색)
                {
                    m_search = (Search)Packet.Deserialize(readbuffer);

                    if (m_search.id != idTxt.Text)
                        searchListBox.Items.Add(m_search.id);
                    if (m_search.count == 1)
                        break;
                }
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            searchListBox.Items.Clear();

            Search search = new Search();
            search.Type = (int)PacketType.계정검색;
            Packet.Serialize(search).CopyTo(sendbuffer, 0);
            this.Send();

            int nRead = 0;
            while (m_bConnect)
            {
                try
                {
                    nRead = 0;
                    nRead = m_networkstream.Read(readbuffer, 0, 1024 * 4);
                }
                catch
                {
                    m_bConnect = false;
                    m_networkstream = null;
                }

                Packet packet = (Packet)Packet.Deserialize(readbuffer);

                if ((int)packet.Type == (int)PacketType.계정검색)
                {
                    m_search = (Search)Packet.Deserialize(readbuffer);

                    if (m_search.id != idTxt.Text && m_search.id.Contains(searchTxt.Text.ToString()))
                        searchListBox.Items.Add(m_search.id);
                    if (m_search.count == 1)
                        break;
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Panel_Show();
            PicBox_Show();
            uploadPanel.Visible = true;
            pictureBox3.BackColor = Color.LightSkyBlue;
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picPathTxt.Text = ofd.FileName;
                uploadPic.Image = Image.FromFile(ofd.FileName);
                uploadPic.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            if (picPathTxt.Text == "")
            {
                MessageBox.Show("업로드할 사진을 선택하세요.");
                return;
            }

            FileStream fs = new FileStream(picPathTxt.Text, FileMode.Open, FileAccess.Read);
            int fileLength = (int)fs.Length;
            byte[] buffer = new byte[fileLength];
            int count = fileLength / (1024 * 4) + 1;

            Upload upload = new Upload();
            upload.Type = (int)PacketType.게시물업로드;
            upload.id = idTxt.Text;
            upload.ext = Path.GetExtension(picPathTxt.Text);
            upload.size = fileLength;
            upload.sendCount = count;
            upload.txt = uploadTxt.Text;
            Packet.Serialize(upload).CopyTo(sendbuffer, 0);
            this.Send();

            BinaryReader br = new BinaryReader(fs);
            for (int i = 0; i < count; i++)
            {
                buffer = br.ReadBytes(1024 * 4);
                buffer.CopyTo(sendbuffer, 0);
                this.Send();
            }
            br.Close();
            fs.Close();

            string d1 = clientStorage + "\\upload";
            DirectoryInfo dir1 = new DirectoryInfo(d1);
            if (!dir1.Exists)
                dir1.Create();

            int imgfilecount = 0;
            int txtfilecount = 0;
            foreach (var item in dir1.GetFiles())
            {
                if (item.Extension != ".txt")
                    imgfilecount += 1;
                else
                    txtfilecount += 1;
            }

            // 클라이언트 저장소에 이미지 저장
            string imgName = d1 + "\\" + (imgfilecount + 1).ToString() + "_" + idTxt.Text + Path.GetExtension(picPathTxt.Text);
            FileInfo file = new FileInfo(picPathTxt.Text);
            file.CopyTo(imgName, true);

            // 클라이언트 저장소에 텍스트 저장
            string txtName = d1 + "\\" + (txtfilecount + 1).ToString() + "_" + idTxt.Text + ".txt";
            StreamWriter sw = new StreamWriter(txtName);
            sw.Write(uploadTxt.Text);
            sw.Close();

            MessageBox.Show("성공적으로 업로드하였습니다! 마이페이지에서 확인하십시오.");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Panel_Show();
            PicBox_Show();
            mypagePanel.Visible = true;
            pictureBox4.BackColor = Color.LightSkyBlue;

            editBtn.Visible = true;
            profileTxt.Enabled = true;
            selectedID = idTxt.Text;

            Profile profile = new Profile();
            profile.Type = (int)PacketType.프로필정보;
            profile.id = idTxt.Text;
            Packet.Serialize(profile).CopyTo(sendbuffer, 0);
            this.Send();

            int nRead = 0;
            try
            {
                nRead = 0;
                nRead = m_networkstream.Read(readbuffer, 0, 1024 * 4);
            }
            catch
            {
                m_bConnect = false;
                m_networkstream = null;
            }

            Packet packet = (Packet)Packet.Deserialize(readbuffer);

            if ((int)packet.Type == (int)PacketType.프로필정보)
            {
                m_profile = (Profile)Packet.Deserialize(readbuffer);

                postCount.Text = m_profile.count.ToString();
            }

            // 프로필 이미지
            string d1 = clientStorage + "\\profile";
            DirectoryInfo dir1 = new DirectoryInfo(d1);
            if (!dir1.Exists)
                dir1.Create();

            int test = 0;
            string d2 = d1 + "\\" + idTxt.Text + "_profile.jpg";
            foreach (var item in dir1.GetFiles())
            {
                if (item.FullName == d2)
                {
                    test += 1;
                    FileStream fs1 = new FileStream(d2, FileMode.Open, FileAccess.Read);
                    profilePic.Image = Image.FromStream(fs1);
                    fs1.Close();
                    break;
                }
            }
            if (test == 0)
            {
                FileStream fs2 = new FileStream(d1 + "\\기본.jpg", FileMode.Open, FileAccess.Read);
                profilePic.Image = Image.FromStream(fs2);
                fs2.Close();
            }

            // 프로필 텍스트
            FileInfo file = new FileInfo(d1 + "\\" + idTxt.Text + "_profile.txt");
            if (file.Exists)
            {
                StreamReader sr = new StreamReader(d1 + "\\" + idTxt.Text + "_profile.txt");
                profileTxt.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void viewType1_Click(object sender, EventArgs e)
        {
            postPanel.Visible = true;
            postPanel.Controls.Clear();
            tile_x = 0;
            tile_y = 0;

            TileType tiletype = new TileType();
            tiletype.Type = (int)PacketType.바둑판;
            tiletype.id = selectedID;
            Packet.Serialize(tiletype).CopyTo(sendbuffer, 0);
            this.Send();

            int nRead = 0;
            while (m_bConnect)
            {
                try
                {
                    nRead = 0;
                    nRead = m_networkstream.Read(readbuffer, 0, 1024 * 4);
                }
                catch
                {
                    m_bConnect = false;
                    m_networkstream = null;
                }

                Packet packet = (Packet)Packet.Deserialize(readbuffer);

                if ((int)packet.Type == (int)PacketType.바둑판)
                {
                    m_tiletype = (TileType)Packet.Deserialize(readbuffer);

                    if (m_tiletype.postCount == -1)
                        break;
                    else
                    {
                        string d1 = clientStorage + "\\post";
                        DirectoryInfo dir1 = new DirectoryInfo(d1);
                        if (!dir1.Exists)
                            dir1.Create();

                        string d2 = d1 + "\\" + m_tiletype.id;
                        DirectoryInfo dir2 = new DirectoryInfo(d2);
                        if (!dir2.Exists)
                            dir2.Create();

                        string imgName = d2 + "\\" + m_tiletype.postCount.ToString() + m_tiletype.ext;
                        foreach (var item in dir2.GetFiles())
                        {
                            if (item.FullName == imgName)
                                continue;
                        }

                        FileStream fs = new FileStream(imgName, FileMode.Create, FileAccess.Write);
                        BinaryWriter bw = new BinaryWriter(fs);
                        for (int i = 0; i < m_tiletype.sendCount; i++)
                        {
                            int receiveLength = m_networkstream.Read(readbuffer, 0, 1024 * 4);
                            fs.Write(readbuffer, 0, receiveLength);
                        }
                        bw.Close();
                        fs.Close();

                        if (m_tiletype.postCount == 1)
                            break;
                    }
                }
            }

            if (m_tiletype.postCount != 0)
            {
                int imgcount = 0;
                string[] ext = new string[int.Parse(postCount.Text) + 1];
                string _d1 = clientStorage + "\\post\\" + m_tiletype.id;
                DirectoryInfo _dir1 = new DirectoryInfo(_d1);
                foreach (var item in _dir1.GetFiles())
                {
                    if (item.Extension != ".txt")
                    {
                        imgcount += 1;
                        ext[imgcount] = item.Extension;
                    }
                }

                for (int j = imgcount; j > 0; j--)
                {
                    FileStream imgfs = new FileStream(_d1 + "\\" + j.ToString() + ext[j], FileMode.Open, FileAccess.Read);
                    PictureBox imgpb = new PictureBox();
                    imgpb.Width = 80;
                    imgpb.Height = 80;
                    imgpb.Location = new Point(tile_x, tile_y);
                    imgpb.SizeMode = PictureBoxSizeMode.StretchImage;
                    imgpb.Image = Image.FromStream(imgfs);
                    postPanel.Controls.Add(imgpb);
                    imgfs.Close();

                    tile_x += 90;
                    if (tile_x > 200)
                    {
                        tile_x = 0;
                        tile_y += 90;
                    }
                }
            }
        }

        private void viewType2_Click(object sender, EventArgs e)
        {
            postPanel.Visible = true;
            postPanel.Controls.Clear();
            listimg_x = 0;
            listimg_y = 50;
            listtxt_x = 0;
            listtxt_y = 230;
            listpro_x = 0;
            listpro_y = 0;
            listid_x = 45;
            listid_y = 0;

            ListType listtype = new ListType();
            listtype.Type = (int)PacketType.리스트;
            listtype.id = selectedID;
            Packet.Serialize(listtype).CopyTo(sendbuffer, 0);
            this.Send();

            int nRead = 0;
            while (m_bConnect)
            {
                try
                {
                    nRead = 0;
                    nRead = m_networkstream.Read(readbuffer, 0, 1024 * 4);
                }
                catch
                {
                    m_bConnect = false;
                    m_networkstream = null;
                }

                Packet packet = (Packet)Packet.Deserialize(readbuffer);

                if ((int)packet.Type == (int)PacketType.리스트)
                {
                    m_listtype = (ListType)Packet.Deserialize(readbuffer);

                    if (m_listtype.postCount == 0)
                        break;
                    else
                    {
                        string d1 = clientStorage + "\\post\\" + m_listtype.id;
                        DirectoryInfo dir1 = new DirectoryInfo(d1);
                        if (!dir1.Exists)
                            dir1.Create();

                        string imgName = d1 + "\\" + m_listtype.postCount.ToString() + m_listtype.ext;
                        foreach (var item in dir1.GetFiles())
                        {
                            if (item.FullName == imgName)
                                continue;
                        }

                        string txtName = d1 + "\\" + m_listtype.postCount.ToString() + ".txt";
                        StreamWriter sw = new StreamWriter(txtName);
                        sw.Write(m_listtype.txt);
                        sw.Close();

                        FileStream fs = new FileStream(imgName, FileMode.Create, FileAccess.Write);
                        BinaryWriter bw = new BinaryWriter(fs);
                        for (int i = 0; i < m_listtype.sendCount; i++)
                        {
                            int receiveLength = m_networkstream.Read(readbuffer, 0, 1024 * 4);
                            fs.Write(readbuffer, 0, receiveLength);
                        }
                        bw.Close();
                        fs.Close();

                        if (m_listtype.postCount == 1)
                            break;
                    }
                }
            }

            if (m_listtype.postCount != 0)
            {
                int itemcount = 0;
                string[] ext = new string[int.Parse(postCount.Text) + 1];
                string _d1 = clientStorage + "\\post\\" + m_listtype.id;
                DirectoryInfo _dir1 = new DirectoryInfo(_d1);
                foreach (var item in _dir1.GetFiles())
                {
                    if (item.Extension != ".txt")
                    {
                        itemcount += 1;
                        ext[itemcount] = item.Extension;
                    }
                }

                for (int j = itemcount; j > 0; j--)
                {
                    FileStream imgfs = new FileStream(_d1 + "\\" + j.ToString() + ext[j], FileMode.Open, FileAccess.Read);
                    PictureBox imgpb = new PictureBox();
                    imgpb.Width = 230;
                    imgpb.Height = 170;
                    imgpb.Location = new Point(listimg_x, listimg_y);
                    imgpb.SizeMode = PictureBoxSizeMode.StretchImage;
                    imgpb.Image = Image.FromStream(imgfs);
                    postPanel.Controls.Add(imgpb);
                    imgfs.Close();

                    listimg_y += 290;

                    TextBox tb = new TextBox();
                    tb.Width = 230;
                    tb.Height = 50;
                    tb.Location = new Point(listtxt_x, listtxt_y);
                    tb.Multiline = true;
                    tb.Text = File.ReadAllText(_d1 + "\\" + j.ToString() + ".txt");
                    postPanel.Controls.Add(tb);

                    listtxt_y += 290;

                    Label lb = new Label();
                    lb.Text = m_listtype.id;
                    lb.Location = new Point(listid_x, listid_y);
                    postPanel.Controls.Add(lb);

                    listid_y += 290;

                    FileStream profilefs = new FileStream(clientStorage + "\\profile\\" + m_listtype.id + "_profile.jpg", FileMode.Open, FileAccess.Read);
                    PictureBox profilepb = new PictureBox();
                    profilepb.Width = 40;
                    profilepb.Height = 40;
                    profilepb.Location = new Point(listpro_x, listpro_y);
                    profilepb.SizeMode = PictureBoxSizeMode.StretchImage;
                    profilepb.Image = Image.FromStream(profilefs);
                    postPanel.Controls.Add(profilepb);
                    profilefs.Close();

                    listpro_y += 290;
                }
            }
        }

        private void profilePic_Click(object sender, EventArgs e)
        {
            if (idTxt.Text == selectedID)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    profilepath = ofd.FileName;
                    profilePic.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            string d1 = clientStorage + "\\profile";
            DirectoryInfo dir1 = new DirectoryInfo(d1);
            if (!dir1.Exists)
                dir1.Create();

            string d2 = d1 + "\\" + idTxt.Text + "_profile.jpg";
            foreach (var item in dir1.GetFiles())
            {
                if (item.FullName == d2)
                    item.Delete();
            }

            // 프로필 이미지 저장
            FileInfo file = new FileInfo(profilepath);
            file.CopyTo(d2, true);

            // 프로필 텍스트 저장
            if (profileTxt.Text != "")
            {
                string d3 = d1 + "\\" + idTxt.Text + "_profile.txt";
                foreach(var item in dir1.GetFiles())
                {
                    if (item.FullName == d3)
                        item.Delete();
                }

                StreamWriter sw = new StreamWriter(d3);
                sw.Write(profileTxt.Text);
                sw.Close();
            }

            MessageBox.Show("프로필이 수정되었습니다!");
        }

        private void searchListBox_DoubleClick(object sender, EventArgs e)
        {
            Panel_Show();
            PicBox_Show();
            mypagePanel.Visible = true;
            pictureBox4.BackColor = Color.LightSkyBlue;

            editBtn.Visible = false;
            profileTxt.Enabled = false;

            // 다른 계정
            selectedID = searchListBox.SelectedItem.ToString();

            // 프로필 정보 가져오기
            string d1 = clientStorage + "\\profile";
            DirectoryInfo dir1 = new DirectoryInfo(d1);
            if (!dir1.Exists)
                dir1.Create();

            int test = 0;
            string d2 = d1 + "\\" + selectedID + "_profile.jpg";
            foreach (var item in dir1.GetFiles())
            {
                if (item.FullName == d2)
                {
                    test += 1;
                    FileStream fs1 = new FileStream(d2, FileMode.Open, FileAccess.Read);
                    profilePic.Image = Image.FromStream(fs1);
                    fs1.Close();
                    break;
                }
            }
            if (test == 0)
            {
                FileStream fs2 = new FileStream(d1 + "\\기본.jpg", FileMode.Open, FileAccess.Read);
                profilePic.Image = Image.FromStream(fs2);
                fs2.Close();
            }
            
            FileInfo file = new FileInfo(d1 + "\\" + selectedID + "_profile.txt");
            if (file.Exists)
            {
                StreamReader sr = new StreamReader(d1 + "\\" + selectedID + "_profile.txt");
                profileTxt.Text = sr.ReadToEnd();
                sr.Close();
            }

            Profile profile = new Profile();
            profile.Type = (int)PacketType.프로필정보;
            profile.id = selectedID;
            Packet.Serialize(profile).CopyTo(sendbuffer, 0);
            this.Send();

            int nRead = 0;
            try
            {
                nRead = 0;
                nRead = m_networkstream.Read(readbuffer, 0, 1024 * 4);
            }
            catch
            {
                m_bConnect = false;
                m_networkstream = null;
            }

            Packet packet = (Packet)Packet.Deserialize(readbuffer);

            if ((int)packet.Type == (int)PacketType.프로필정보)
            {
                m_profile = (Profile)Packet.Deserialize(readbuffer);

                postCount.Text = m_profile.count.ToString();
            }
        }
    }
}
