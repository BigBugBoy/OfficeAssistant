namespace OfficeAssistant.UIForm
{
    partial class FrmUserLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.te_userName = new DevExpress.XtraEditors.TextEdit();
            this.te_userPsd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lc_localIP = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.te_userName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_userPsd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // te_userName
            // 
            this.te_userName.Location = new System.Drawing.Point(155, 82);
            this.te_userName.Name = "te_userName";
            this.te_userName.Size = new System.Drawing.Size(159, 24);
            this.te_userName.TabIndex = 1;
            // 
            // te_userPsd
            // 
            this.te_userPsd.Location = new System.Drawing.Point(155, 136);
            this.te_userPsd.Name = "te_userPsd";
            this.te_userPsd.Size = new System.Drawing.Size(159, 24);
            this.te_userPsd.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(78, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 18);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "本机IP";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(78, 88);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 18);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "账号：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(78, 142);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 18);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "密码：";
            // 
            // lc_localIP
            // 
            this.lc_localIP.Location = new System.Drawing.Point(155, 33);
            this.lc_localIP.Name = "lc_localIP";
            this.lc_localIP.Size = new System.Drawing.Size(104, 18);
            this.lc_localIP.TabIndex = 6;
            this.lc_localIP.Text = "自动获取本机IP";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButton1.Location = new System.Drawing.Point(78, 196);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "登录";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(239, 196);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 9;
            this.simpleButton2.Text = "退出登录";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // UserLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 265);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.lc_localIP);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.te_userPsd);
            this.Controls.Add(this.te_userName);
            this.Name = "UserLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录界面";
            this.Load += new System.EventHandler(this.UserLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.te_userName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_userPsd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit te_userName;
        private DevExpress.XtraEditors.TextEdit te_userPsd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lc_localIP;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}