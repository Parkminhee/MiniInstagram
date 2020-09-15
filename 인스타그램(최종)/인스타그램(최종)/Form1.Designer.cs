namespace 인스타그램_최종_
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
            this.ipTxt = new System.Windows.Forms.TextBox();
            this.portTxt = new System.Windows.Forms.TextBox();
            this.serverLogTxt = new System.Windows.Forms.TextBox();
            this.memberListView = new System.Windows.Forms.ListView();
            this.startBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Member Account List";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(373, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Server Log";
            // 
            // ipTxt
            // 
            this.ipTxt.Location = new System.Drawing.Point(55, 15);
            this.ipTxt.Name = "ipTxt";
            this.ipTxt.Size = new System.Drawing.Size(357, 28);
            this.ipTxt.TabIndex = 4;
            // 
            // portTxt
            // 
            this.portTxt.Location = new System.Drawing.Point(501, 15);
            this.portTxt.Name = "portTxt";
            this.portTxt.Size = new System.Drawing.Size(137, 28);
            this.portTxt.TabIndex = 5;
            // 
            // serverLogTxt
            // 
            this.serverLogTxt.Location = new System.Drawing.Point(376, 87);
            this.serverLogTxt.Multiline = true;
            this.serverLogTxt.Name = "serverLogTxt";
            this.serverLogTxt.Size = new System.Drawing.Size(419, 350);
            this.serverLogTxt.TabIndex = 6;
            // 
            // memberListView
            // 
            this.memberListView.Location = new System.Drawing.Point(24, 87);
            this.memberListView.Name = "memberListView";
            this.memberListView.Size = new System.Drawing.Size(335, 350);
            this.memberListView.TabIndex = 7;
            this.memberListView.UseCompatibleStateImageBehavior = false;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(654, 12);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(141, 31);
            this.startBtn.TabIndex = 8;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 449);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.memberListView);
            this.Controls.Add(this.serverLogTxt);
            this.Controls.Add(this.portTxt);
            this.Controls.Add(this.ipTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Mini Instagram Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ipTxt;
        private System.Windows.Forms.TextBox portTxt;
        private System.Windows.Forms.TextBox serverLogTxt;
        private System.Windows.Forms.ListView memberListView;
        private System.Windows.Forms.Button startBtn;
    }
}

