namespace 인스타그램_Client
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.joinBtn = new System.Windows.Forms.Button();
            this.ipTxt = new System.Windows.Forms.TextBox();
            this.portTxt = new System.Windows.Forms.TextBox();
            this.idTxt = new System.Windows.Forms.TextBox();
            this.pwTxt = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.searchListBox = new System.Windows.Forms.ListBox();
            this.uploadPanel = new System.Windows.Forms.Panel();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.findBtn = new System.Windows.Forms.Button();
            this.uploadTxt = new System.Windows.Forms.TextBox();
            this.picPathTxt = new System.Windows.Forms.TextBox();
            this.uploadPic = new System.Windows.Forms.PictureBox();
            this.editBtn = new System.Windows.Forms.Button();
            this.viewType1 = new System.Windows.Forms.Button();
            this.viewType2 = new System.Windows.Forms.Button();
            this.postCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.profilePic = new System.Windows.Forms.PictureBox();
            this.profileTxt = new System.Windows.Forms.TextBox();
            this.mypagePanel = new System.Windows.Forms.Panel();
            this.postPanel = new System.Windows.Forms.Panel();
            this.homePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.uploadPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uploadPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePic)).BeginInit();
            this.mypagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(67, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(312, 40);
            this.label3.TabIndex = 2;
            this.label3.Text = "MINI Instagram";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 370);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "아직 계정이 없나요?";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(290, 38);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(93, 76);
            this.connectBtn.TabIndex = 6;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.Enabled = false;
            this.loginBtn.Location = new System.Drawing.Point(290, 258);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(89, 70);
            this.loginBtn.TabIndex = 7;
            this.loginBtn.Text = "로그인";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // joinBtn
            // 
            this.joinBtn.Enabled = false;
            this.joinBtn.Location = new System.Drawing.Point(244, 363);
            this.joinBtn.Name = "joinBtn";
            this.joinBtn.Size = new System.Drawing.Size(104, 32);
            this.joinBtn.TabIndex = 8;
            this.joinBtn.Text = "회원가입";
            this.joinBtn.UseVisualStyleBackColor = true;
            this.joinBtn.Click += new System.EventHandler(this.joinBtn_Click);
            // 
            // ipTxt
            // 
            this.ipTxt.Location = new System.Drawing.Point(114, 35);
            this.ipTxt.Name = "ipTxt";
            this.ipTxt.Size = new System.Drawing.Size(170, 28);
            this.ipTxt.TabIndex = 9;
            this.ipTxt.Text = "192.168.219.104";
            // 
            // portTxt
            // 
            this.portTxt.Location = new System.Drawing.Point(114, 93);
            this.portTxt.Name = "portTxt";
            this.portTxt.Size = new System.Drawing.Size(170, 28);
            this.portTxt.TabIndex = 10;
            this.portTxt.Text = "5048";
            // 
            // idTxt
            // 
            this.idTxt.Enabled = false;
            this.idTxt.Location = new System.Drawing.Point(114, 253);
            this.idTxt.Name = "idTxt";
            this.idTxt.Size = new System.Drawing.Size(170, 28);
            this.idTxt.TabIndex = 11;
            // 
            // pwTxt
            // 
            this.pwTxt.Enabled = false;
            this.pwTxt.Location = new System.Drawing.Point(114, 307);
            this.pwTxt.Name = "pwTxt";
            this.pwTxt.Size = new System.Drawing.Size(170, 28);
            this.pwTxt.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::인스타그램_Client.Properties.Resources.button_home;
            this.pictureBox1.Location = new System.Drawing.Point(437, 562);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::인스타그램_Client.Properties.Resources.button_search;
            this.pictureBox2.Location = new System.Drawing.Point(543, 562);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::인스타그램_Client.Properties.Resources.button_upload;
            this.pictureBox3.Location = new System.Drawing.Point(649, 562);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(80, 80);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::인스타그램_Client.Properties.Resources.button_mypage;
            this.pictureBox4.Location = new System.Drawing.Point(756, 562);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(80, 80);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.searchBtn);
            this.searchPanel.Controls.Add(this.searchTxt);
            this.searchPanel.Controls.Add(this.searchListBox);
            this.searchPanel.Location = new System.Drawing.Point(437, 12);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(399, 544);
            this.searchPanel.TabIndex = 17;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(298, 20);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(81, 31);
            this.searchBtn.TabIndex = 18;
            this.searchBtn.Text = "찾기";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchTxt
            // 
            this.searchTxt.Location = new System.Drawing.Point(28, 23);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(264, 28);
            this.searchTxt.TabIndex = 20;
            // 
            // searchListBox
            // 
            this.searchListBox.FormattingEnabled = true;
            this.searchListBox.ItemHeight = 18;
            this.searchListBox.Location = new System.Drawing.Point(28, 57);
            this.searchListBox.Name = "searchListBox";
            this.searchListBox.Size = new System.Drawing.Size(351, 472);
            this.searchListBox.TabIndex = 19;
            this.searchListBox.DoubleClick += new System.EventHandler(this.searchListBox_DoubleClick);
            // 
            // uploadPanel
            // 
            this.uploadPanel.Controls.Add(this.uploadBtn);
            this.uploadPanel.Controls.Add(this.findBtn);
            this.uploadPanel.Controls.Add(this.uploadTxt);
            this.uploadPanel.Controls.Add(this.picPathTxt);
            this.uploadPanel.Controls.Add(this.uploadPic);
            this.uploadPanel.Location = new System.Drawing.Point(437, 12);
            this.uploadPanel.Name = "uploadPanel";
            this.uploadPanel.Size = new System.Drawing.Size(399, 544);
            this.uploadPanel.TabIndex = 18;
            // 
            // uploadBtn
            // 
            this.uploadBtn.Location = new System.Drawing.Point(18, 485);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(361, 37);
            this.uploadBtn.TabIndex = 23;
            this.uploadBtn.Text = "게시물 등록하기";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(18, 13);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(73, 31);
            this.findBtn.TabIndex = 19;
            this.findBtn.Text = "찾기";
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // uploadTxt
            // 
            this.uploadTxt.Location = new System.Drawing.Point(18, 394);
            this.uploadTxt.Multiline = true;
            this.uploadTxt.Name = "uploadTxt";
            this.uploadTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uploadTxt.Size = new System.Drawing.Size(361, 85);
            this.uploadTxt.TabIndex = 22;
            // 
            // picPathTxt
            // 
            this.picPathTxt.Location = new System.Drawing.Point(97, 16);
            this.picPathTxt.Name = "picPathTxt";
            this.picPathTxt.Size = new System.Drawing.Size(282, 28);
            this.picPathTxt.TabIndex = 20;
            // 
            // uploadPic
            // 
            this.uploadPic.Location = new System.Drawing.Point(18, 50);
            this.uploadPic.Name = "uploadPic";
            this.uploadPic.Size = new System.Drawing.Size(361, 338);
            this.uploadPic.TabIndex = 21;
            this.uploadPic.TabStop = false;
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(217, 82);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(144, 35);
            this.editBtn.TabIndex = 19;
            this.editBtn.Text = "프로필 수정";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // viewType1
            // 
            this.viewType1.Location = new System.Drawing.Point(39, 186);
            this.viewType1.Name = "viewType1";
            this.viewType1.Size = new System.Drawing.Size(147, 32);
            this.viewType1.TabIndex = 20;
            this.viewType1.Text = "바둑판";
            this.viewType1.UseVisualStyleBackColor = true;
            this.viewType1.Click += new System.EventHandler(this.viewType1_Click);
            // 
            // viewType2
            // 
            this.viewType2.Location = new System.Drawing.Point(202, 186);
            this.viewType2.Name = "viewType2";
            this.viewType2.Size = new System.Drawing.Size(147, 32);
            this.viewType2.TabIndex = 21;
            this.viewType2.Text = "리스트";
            this.viewType2.UseVisualStyleBackColor = true;
            this.viewType2.Click += new System.EventHandler(this.viewType2_Click);
            // 
            // postCount
            // 
            this.postCount.AutoSize = true;
            this.postCount.Location = new System.Drawing.Point(286, 33);
            this.postCount.Name = "postCount";
            this.postCount.Size = new System.Drawing.Size(18, 18);
            this.postCount.TabIndex = 22;
            this.postCount.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(265, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "게시물";
            // 
            // profilePic
            // 
            this.profilePic.Image = global::인스타그램_Client.Properties.Resources.profile_img;
            this.profilePic.Location = new System.Drawing.Point(18, 13);
            this.profilePic.Name = "profilePic";
            this.profilePic.Size = new System.Drawing.Size(153, 104);
            this.profilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.profilePic.TabIndex = 24;
            this.profilePic.TabStop = false;
            this.profilePic.Click += new System.EventHandler(this.profilePic_Click);
            // 
            // profileTxt
            // 
            this.profileTxt.Location = new System.Drawing.Point(18, 123);
            this.profileTxt.Multiline = true;
            this.profileTxt.Name = "profileTxt";
            this.profileTxt.Size = new System.Drawing.Size(343, 57);
            this.profileTxt.TabIndex = 25;
            // 
            // mypagePanel
            // 
            this.mypagePanel.Controls.Add(this.postPanel);
            this.mypagePanel.Controls.Add(this.profilePic);
            this.mypagePanel.Controls.Add(this.postCount);
            this.mypagePanel.Controls.Add(this.viewType2);
            this.mypagePanel.Controls.Add(this.profileTxt);
            this.mypagePanel.Controls.Add(this.viewType1);
            this.mypagePanel.Controls.Add(this.label8);
            this.mypagePanel.Controls.Add(this.editBtn);
            this.mypagePanel.Location = new System.Drawing.Point(434, 9);
            this.mypagePanel.Name = "mypagePanel";
            this.mypagePanel.Size = new System.Drawing.Size(399, 544);
            this.mypagePanel.TabIndex = 26;
            // 
            // postPanel
            // 
            this.postPanel.AutoScroll = true;
            this.postPanel.Location = new System.Drawing.Point(18, 228);
            this.postPanel.Name = "postPanel";
            this.postPanel.Size = new System.Drawing.Size(361, 305);
            this.postPanel.TabIndex = 27;
            // 
            // homePanel
            // 
            this.homePanel.AutoScroll = true;
            this.homePanel.Location = new System.Drawing.Point(434, 6);
            this.homePanel.Name = "homePanel";
            this.homePanel.Size = new System.Drawing.Size(399, 544);
            this.homePanel.TabIndex = 28;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 654);
            this.Controls.Add(this.uploadPanel);
            this.Controls.Add(this.homePanel);
            this.Controls.Add(this.mypagePanel);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pwTxt);
            this.Controls.Add(this.idTxt);
            this.Controls.Add(this.portTxt);
            this.Controls.Add(this.ipTxt);
            this.Controls.Add(this.joinBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Mini Instagram Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.uploadPanel.ResumeLayout(false);
            this.uploadPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uploadPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePic)).EndInit();
            this.mypagePanel.ResumeLayout(false);
            this.mypagePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button joinBtn;
        private System.Windows.Forms.TextBox ipTxt;
        private System.Windows.Forms.TextBox portTxt;
        private System.Windows.Forms.TextBox idTxt;
        private System.Windows.Forms.TextBox pwTxt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox searchTxt;
        private System.Windows.Forms.ListBox searchListBox;
        private System.Windows.Forms.Panel uploadPanel;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.TextBox uploadTxt;
        private System.Windows.Forms.TextBox picPathTxt;
        private System.Windows.Forms.PictureBox uploadPic;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button viewType1;
        private System.Windows.Forms.Button viewType2;
        private System.Windows.Forms.Label postCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox profilePic;
        private System.Windows.Forms.TextBox profileTxt;
        private System.Windows.Forms.Panel mypagePanel;
        private System.Windows.Forms.Panel postPanel;
        private System.Windows.Forms.Panel homePanel;
    }
}

