using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using ClassLibrary1;

namespace 인스타그램_최종_
{
    public partial class Form1 : Form
    {
        private NetworkStream m_networkstream;
        private TcpListener m_listener;
        private byte[] sendbuffer = new byte[1024 * 4];
        private byte[] readbuffer = new byte[1024 * 4];
        private bool m_bClientOn = false;
        private Thread m_thread;

        public Join m_join;
        public Login m_login;
        public Search m_search;
        public Upload m_upload;
        public Profile m_profile;
        public TileType m_tiletype;
        public ListType m_listtype;

        private int memCount = 0;
        string serverStorage = "C:\\Users\\pminh\\Desktop\\2015726006_Server";

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

        private void Form1_Load(object sender, EventArgs e)
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string ip = string.Empty;
            for (int i = 0; i < host.AddressList.Length; i++)
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    ip = host.AddressList[i].ToString();
            }
            ipTxt.Text = ip;
            portTxt.Text = 5048.ToString();

            memberListView.View = View.Details;
            memberListView.Columns.Add("Index");
            memberListView.Columns.Add("ID");
            memberListView.Columns.Add("Password");
            memberListView.Columns[2].Width = 100;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_bClientOn)
            {
                m_listener.Stop();
                m_networkstream.Close();
                m_thread.Abort();
            }
        }

        public void RUN()
        {
            m_listener = new TcpListener(IPAddress.Parse(ipTxt.Text), int.Parse(portTxt.Text));
            m_listener.Start();

            if (!m_bClientOn)
                serverLogTxt.AppendText("waiting for client access.. \n");

            TcpClient client = m_listener.AcceptTcpClient();

            if (client.Connected)
            {
                m_bClientOn = true;
                serverLogTxt.AppendText("Client Access!! \n");
                m_networkstream = client.GetStream();
            }

            int nRead = 0;
            while (m_bClientOn)
            {
                try
                {
                    nRead = 0;
                    nRead = m_networkstream.Read(readbuffer, 0, 1024 * 4);
                }
                catch
                {
                    m_bClientOn = false;
                    m_networkstream = null;
                }

                Packet packet = (Packet)Packet.Deserialize(readbuffer);

                if ((int)packet.Type == (int)PacketType.회원가입)
                {
                    m_join = (Join)Packet.Deserialize(readbuffer);

                    Join join = new Join();
                    join.Type = (int)PacketType.회원가입;
                    join.chk = "중복안됨";
                    for (int i = 0; i < memberListView.Items.Count; i++)
                    {
                        if (memberListView.Items[i].SubItems[1].Text == m_join.id)
                        {
                            join.chk = "중복됨";
                            break;
                        }
                    }
                    Packet.Serialize(join).CopyTo(sendbuffer, 0);
                    this.Send();

                    if (join.chk == "중복안됨")
                    {
                        memCount += 1;
                        ListViewItem lvi = new ListViewItem(memCount.ToString());
                        lvi.SubItems.Add(m_join.id);
                        lvi.SubItems.Add(m_join.pw);
                        memberListView.Items.Add(lvi);

                        serverLogTxt.AppendText(m_join.id + " >> Join \n");
                    }
                }
                else if ((int)packet.Type == (int)PacketType.로그인)
                {
                    m_login = (Login)Packet.Deserialize(readbuffer);

                    Login login = new Login();
                    login.Type = (int)PacketType.로그인;
                    login.chk = "로그인실패";
                    for (int i = 0; i < memberListView.Items.Count; i++)
                    {
                        if (memberListView.Items[i].SubItems[1].Text == m_login.id &&
                            memberListView.Items[i].SubItems[2].Text == m_login.pw)
                        {
                            login.chk = "로그인성공";
                            break;
                        }
                    }
                    Packet.Serialize(login).CopyTo(sendbuffer, 0);
                    this.Send();

                    if (login.chk == "로그인성공")
                        serverLogTxt.AppendText(m_login.id + " >> Login \n");
                }
                else if ((int)packet.Type == (int)PacketType.계정검색)
                {
                    m_search = (Search)Packet.Deserialize(readbuffer);

                    for (int i = 0; i < memberListView.Items.Count; i++)
                    {
                        Search search = new Search();
                        search.Type = (int)PacketType.계정검색;
                        search.id = memberListView.Items[i].SubItems[1].Text;
                        search.count = memberListView.Items.Count - i;
                        Packet.Serialize(search).CopyTo(sendbuffer, 0);
                        this.Send();
                    }
                }
                else if ((int)packet.Type == (int)PacketType.게시물업로드)
                {
                    m_upload = (Upload)Packet.Deserialize(readbuffer);

                    string d1 = serverStorage + "\\" + m_upload.id;
                    DirectoryInfo dir1 = new DirectoryInfo(d1);
                    if (!dir1.Exists)
                        dir1.Create();

                    int count = 0;
                    foreach (var item in dir1.GetDirectories())
                    {
                        count += 1;
                    }

                    string d2 = d1 + "\\" + (count + 1).ToString();
                    DirectoryInfo dir2 = new DirectoryInfo(d2);
                    if (!dir2.Exists)
                        dir2.Create();

                    // 텍스트 저장
                    string txtName = d2 + "\\" + (count + 1).ToString() + ".txt";
                    StreamWriter sw = new StreamWriter(txtName);
                    sw.Write(m_upload.txt);
                    sw.Close();

                    // 이미지 저장
                    string imgName = d2 + "\\" + (count + 1).ToString() + m_upload.ext;
                    FileStream imgfs = new FileStream(imgName, FileMode.Create, FileAccess.Write);
                    BinaryWriter bw = new BinaryWriter(imgfs);
                    for (int i = 0; i < m_upload.sendCount; i++)
                    {
                        int receiveLength = m_networkstream.Read(readbuffer, 0, 1024 * 4);
                        imgfs.Write(readbuffer, 0, receiveLength);
                    }
                    bw.Close();
                    imgfs.Close();
                }
                else if ((int)packet.Type == (int)PacketType.프로필정보)
                {
                    m_profile = (Profile)Packet.Deserialize(readbuffer);

                    string d1 = serverStorage + "\\" + m_profile.id;
                    DirectoryInfo dir1 = new DirectoryInfo(d1);
                    if (!dir1.Exists)
                        dir1.Create();

                    int dircount = 0;
                    foreach (var item in dir1.GetDirectories())
                    {
                        dircount += 1;
                    }

                    Profile profile = new Profile();
                    profile.Type = (int)PacketType.프로필정보;
                    profile.count = dircount;
                    Packet.Serialize(profile).CopyTo(sendbuffer, 0);
                    this.Send();
                }
                else if ((int)packet.Type == (int)PacketType.바둑판)
                {
                    m_tiletype = (TileType)Packet.Deserialize(readbuffer);

                    string d1 = serverStorage + "\\" + m_tiletype.id;
                    DirectoryInfo dir1 = new DirectoryInfo(d1);
                    if (!dir1.Exists)
                        dir1.Create();

                    int dircount = 0;
                    foreach (var item in dir1.GetDirectories())
                    {
                        dircount += 1;
                    }

                    if (dircount == 0)
                    {
                        TileType tiletype = new TileType();
                        tiletype.Type = (int)PacketType.바둑판;
                        tiletype.postCount = -1;
                        Packet.Serialize(tiletype).CopyTo(sendbuffer, 0);
                        this.Send();
                    }
                    else
                    {
                        for (int i = dircount; i > 0; i--)
                        {
                            string d2 = d1 + "\\" + i.ToString();
                            DirectoryInfo dir2 = new DirectoryInfo(d2);
                            if (!dir2.Exists)
                                dir2.Create();

                            foreach (var item in dir2.GetFiles())
                            {
                                if (item.Extension != ".txt")
                                {
                                    FileStream fs = new FileStream(d2 + "\\" + i.ToString() + item.Extension, FileMode.Open, FileAccess.Read);
                                    int fileLength = (int)fs.Length;
                                    byte[] buffer = new byte[fileLength];
                                    int count = fileLength / (1024 * 4) + 1;

                                    TileType tiletype = new TileType();
                                    tiletype.Type = (int)PacketType.바둑판;
                                    tiletype.id = m_tiletype.id;
                                    tiletype.ext = item.Extension;
                                    tiletype.size = fileLength;
                                    tiletype.postCount = i;
                                    tiletype.sendCount = count;
                                    Packet.Serialize(tiletype).CopyTo(sendbuffer, 0);
                                    this.Send();

                                    BinaryReader br = new BinaryReader(fs);
                                    for (int j = 0; j < count; j++)
                                    {
                                        buffer = br.ReadBytes(1024 * 4);
                                        buffer.CopyTo(sendbuffer, 0);
                                        this.Send();
                                    }
                                    br.Close();
                                    fs.Close();

                                    break;
                                }
                            }
                        }
                    }
                }
                else if ((int)packet.Type == (int)PacketType.리스트)
                {
                    m_listtype = (ListType)Packet.Deserialize(readbuffer);

                    string d1 = serverStorage + "\\" + m_listtype.id;
                    DirectoryInfo dir1 = new DirectoryInfo(d1);
                    if (!dir1.Exists)
                        dir1.Create();

                    int dircount = 0;
                    foreach (var item in dir1.GetDirectories())
                    {
                        dircount += 1;
                    }

                    if (dircount == 0)
                    {
                        ListType listtype1 = new ListType();
                        listtype1.Type = (int)PacketType.리스트;
                        listtype1.postCount = 0;
                        Packet.Serialize(listtype1).CopyTo(sendbuffer, 0);
                        this.Send();
                    }
                    else
                    {
                        for (int i = dircount; i > 0; i--)
                        {
                            string ext = string.Empty;
                            string d2 = d1 + "\\" + i.ToString();
                            DirectoryInfo dir2 = new DirectoryInfo(d2);
                            if (!dir2.Exists)
                                dir2.Create();

                            ListType listtype = new ListType();
                            listtype.Type = (int)PacketType.리스트;
                            listtype.id = m_listtype.id;

                            foreach (var item in dir2.GetFiles())
                            {
                                if (item.Extension != ".txt")
                                {
                                    ext = item.Extension;
                                }
                                else
                                {
                                    string txtName = d2 + "\\" + i.ToString() + ".txt";
                                    StreamReader sr = new StreamReader(txtName);
                                    listtype.txt = sr.ReadToEnd();
                                    sr.Close();
                                }
                            }

                            FileStream fs = new FileStream(d2 + "\\" + i.ToString() + ext, FileMode.Open, FileAccess.Read);
                            int fileLength = (int)fs.Length;
                            byte[] buffer = new byte[fileLength];
                            int count = fileLength / (1024 * 4) + 1;

                            listtype.ext = ext;
                            listtype.size = fileLength;
                            listtype.postCount = i;
                            listtype.sendCount = count;
                            Packet.Serialize(listtype).CopyTo(sendbuffer, 0);
                            this.Send();

                            BinaryReader br = new BinaryReader(fs);
                            for (int j = 0; j < count; j++)
                            {
                                buffer = br.ReadBytes(1024 * 4);
                                buffer.CopyTo(sendbuffer, 0);
                                this.Send();
                            }
                            br.Close();
                            fs.Close();
                        }
                    }
                }
            }
        }
        
        private void startBtn_Click(object sender, EventArgs e)
        {
            if (ipTxt.Text == "" || portTxt.Text == "")
            {
                MessageBox.Show("IP 혹은 Port Number가 입력되지 않았습니다.");
                return;
            }

            DirectoryInfo dir = new DirectoryInfo(serverStorage);
            if (!dir.Exists)
                dir.Create();

            startBtn.Text = "Stop";
            startBtn.ForeColor = Color.Red;

            serverLogTxt.Text = "Server-Start\n";
            serverLogTxt.AppendText("Storage Path : " + serverStorage + "\n");
            
            m_thread = new Thread(new ThreadStart(RUN));
            m_thread.Start();
        }
    }
}