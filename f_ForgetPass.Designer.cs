namespace ProjectMonHoc
{
    partial class f_ForgetPass
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
            panel1 = new Panel();
            lbl_ForgetPass_1 = new Label();
            lbl_ForgetPass = new Label();
            pic_Logo_HCMUTE_FPass = new PictureBox();
            lbl_Email_FPass = new Label();
            txb_Email = new TextBox();
            btn_SendOTP = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Logo_HCMUTE_FPass).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Controls.Add(lbl_ForgetPass_1);
            panel1.Controls.Add(lbl_ForgetPass);
            panel1.Controls.Add(pic_Logo_HCMUTE_FPass);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(582, 100);
            panel1.TabIndex = 0;
            // 
            // lbl_ForgetPass_1
            // 
            lbl_ForgetPass_1.AutoSize = true;
            lbl_ForgetPass_1.Font = new Font("Segoe UI", 12F);
            lbl_ForgetPass_1.ForeColor = SystemColors.Window;
            lbl_ForgetPass_1.Location = new Point(217, 47);
            lbl_ForgetPass_1.Name = "lbl_ForgetPass_1";
            lbl_ForgetPass_1.Size = new Size(284, 28);
            lbl_ForgetPass_1.TabIndex = 2;
            lbl_ForgetPass_1.Text = "Nhập email để lấy lại mật khẩu.";
            lbl_ForgetPass_1.Click += lbl_ForgetPass_1_Click;
            // 
            // lbl_ForgetPass
            // 
            lbl_ForgetPass.AutoSize = true;
            lbl_ForgetPass.Font = new Font("Segoe UI Historic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_ForgetPass.ForeColor = SystemColors.Window;
            lbl_ForgetPass.Location = new Point(217, 9);
            lbl_ForgetPass.Name = "lbl_ForgetPass";
            lbl_ForgetPass.Size = new Size(252, 38);
            lbl_ForgetPass.TabIndex = 1;
            lbl_ForgetPass.Text = "Quên mật khẩu ?";
            lbl_ForgetPass.Click += lbl_ForgetPass_Click;
            // 
            // pic_Logo_HCMUTE_FPass
            // 
            pic_Logo_HCMUTE_FPass.BackColor = Color.DarkBlue;
            pic_Logo_HCMUTE_FPass.Image = Properties.Resources.logo_HCMUTE_MainMenu;
            pic_Logo_HCMUTE_FPass.Location = new Point(0, -81);
            pic_Logo_HCMUTE_FPass.Name = "pic_Logo_HCMUTE_FPass";
            pic_Logo_HCMUTE_FPass.Size = new Size(177, 262);
            pic_Logo_HCMUTE_FPass.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Logo_HCMUTE_FPass.TabIndex = 0;
            pic_Logo_HCMUTE_FPass.TabStop = false;
            // 
            // lbl_Email_FPass
            // 
            lbl_Email_FPass.AutoSize = true;
            lbl_Email_FPass.BackColor = SystemColors.ScrollBar;
            lbl_Email_FPass.Font = new Font("Segoe UI", 11F);
            lbl_Email_FPass.Location = new Point(70, 183);
            lbl_Email_FPass.Name = "lbl_Email_FPass";
            lbl_Email_FPass.Size = new Size(109, 25);
            lbl_Email_FPass.TabIndex = 1;
            lbl_Email_FPass.Text = "Nhập Email";
            // 
            // txb_Email
            // 
            txb_Email.Location = new Point(204, 181);
            txb_Email.Name = "txb_Email";
            txb_Email.Size = new Size(265, 27);
            txb_Email.TabIndex = 2;
            // 
            // btn_SendOTP
            // 
            btn_SendOTP.BackColor = Color.BurlyWood;
            btn_SendOTP.Font = new Font("Segoe UI", 11F);
            btn_SendOTP.ForeColor = SystemColors.ControlText;
            btn_SendOTP.Location = new Point(217, 288);
            btn_SendOTP.Name = "btn_SendOTP";
            btn_SendOTP.Size = new Size(121, 49);
            btn_SendOTP.TabIndex = 3;
            btn_SendOTP.Text = "Gửi mã OTP";
            btn_SendOTP.UseVisualStyleBackColor = false;
            btn_SendOTP.Click += btn_SendOTP_Click;
            // 
            // f_ForgetPass
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(582, 453);
            Controls.Add(btn_SendOTP);
            Controls.Add(txb_Email);
            Controls.Add(lbl_Email_FPass);
            Controls.Add(panel1);
            Name = "f_ForgetPass";
            Text = "f_ForgetPass";
            Load += f_ForgetPass_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Logo_HCMUTE_FPass).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lbl_ForgetPass;
        private PictureBox pic_Logo_HCMUTE_FPass;
        private Label lbl_ForgetPass_1;
        private Label lbl_Email_FPass;
        private TextBox txb_Email;
        private Button btn_SendOTP;
    }
}