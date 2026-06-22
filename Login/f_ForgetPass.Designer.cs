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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lbl_Email_FPass = new Label();
            txb_Email = new TextBox();
            btn_SendOTP = new Button();
            btn_Cancel_ForgetPass = new Button();
            lbl_Title = new Label();
            llbl_Register = new LinkLabel();
            btn_AskAI = new Button();
            SuspendLayout();
            // 
            // lbl_Email_FPass
            // 
            lbl_Email_FPass.AutoSize = true;
            lbl_Email_FPass.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Email_FPass.ForeColor = SystemColors.GrayText;
            lbl_Email_FPass.Location = new Point(44, 231);
            lbl_Email_FPass.Name = "lbl_Email_FPass";
            lbl_Email_FPass.Size = new Size(55, 23);
            lbl_Email_FPass.TabIndex = 1;
            lbl_Email_FPass.Text = "Email:";
            // 
            // txb_Email
            // 
            txb_Email.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_Email.Location = new Point(44, 257);
            txb_Email.Name = "txb_Email";
            txb_Email.Size = new Size(409, 34);
            txb_Email.TabIndex = 2;
            txb_Email.TextChanged += txb_Email_TextChanged;
            // 
            // btn_SendOTP
            // 
            btn_SendOTP.BackColor = Color.SteelBlue;
            btn_SendOTP.Cursor = Cursors.Hand;
            btn_SendOTP.FlatAppearance.BorderSize = 0;
            btn_SendOTP.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn_SendOTP.ForeColor = Color.White;
            btn_SendOTP.Location = new Point(44, 314);
            btn_SendOTP.Name = "btn_SendOTP";
            btn_SendOTP.Size = new Size(156, 70);
            btn_SendOTP.TabIndex = 3;
            btn_SendOTP.Text = "Gửi OTP";
            btn_SendOTP.UseVisualStyleBackColor = false;
            btn_SendOTP.Click += btn_SendOTP_Click;
            // 
            // btn_Cancel_ForgetPass
            // 
            btn_Cancel_ForgetPass.BackColor = Color.IndianRed;
            btn_Cancel_ForgetPass.Cursor = Cursors.Hand;
            btn_Cancel_ForgetPass.FlatAppearance.BorderSize = 0;
            btn_Cancel_ForgetPass.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn_Cancel_ForgetPass.ForeColor = Color.White;
            btn_Cancel_ForgetPass.Location = new Point(299, 314);
            btn_Cancel_ForgetPass.Name = "btn_Cancel_ForgetPass";
            btn_Cancel_ForgetPass.Size = new Size(154, 70);
            btn_Cancel_ForgetPass.TabIndex = 4;
            btn_Cancel_ForgetPass.Text = "Hủy";
            btn_Cancel_ForgetPass.UseVisualStyleBackColor = false;
            btn_Cancel_ForgetPass.Click += btn_Cancel_ForgetPass_Click;
            // 
            // lbl_Title
            // 
            lbl_Title.BackColor = Color.Transparent;
            lbl_Title.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Title.ForeColor = Color.SteelBlue;
            lbl_Title.Location = new Point(12, 9);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(476, 119);
            lbl_Title.TabIndex = 3;
            lbl_Title.Text = "KHÔI PHỤC MẬT KHẨU\r\nSTUDENT";
            lbl_Title.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Title.Click += lbl_Title_Click;
            // 
            // llbl_Register
            // 
            llbl_Register.BackColor = Color.White;
            llbl_Register.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            llbl_Register.ForeColor = Color.DimGray;
            llbl_Register.LinkBehavior = LinkBehavior.NeverUnderline;
            llbl_Register.LinkColor = Color.DimGray;
            llbl_Register.Location = new Point(12, 162);
            llbl_Register.Name = "llbl_Register";
            llbl_Register.Size = new Size(476, 28);
            llbl_Register.TabIndex = 8;
            llbl_Register.TabStop = true;
            llbl_Register.Text = "Nhập email để xác thực qua OTP";
            llbl_Register.TextAlign = ContentAlignment.MiddleCenter;
            llbl_Register.LinkClicked += llbl_Register_LinkClicked;
            // 
            // btn_AskAI
            // 
            btn_AskAI.BackColor = Color.FromArgb(41, 128, 185);
            btn_AskAI.Cursor = Cursors.Hand;
            btn_AskAI.FlatAppearance.BorderSize = 0;
            btn_AskAI.FlatStyle = FlatStyle.Flat;
            btn_AskAI.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn_AskAI.ForeColor = Color.White;
            btn_AskAI.Location = new Point(44, 410);
            btn_AskAI.Name = "btn_AskAI";
            btn_AskAI.Size = new Size(409, 50);
            btn_AskAI.TabIndex = 9;
            btn_AskAI.Text = "💬 Hỏi Trợ Lý AI";
            btn_AskAI.UseVisualStyleBackColor = false;
            btn_AskAI.Click += btn_AskAI_Click;
            // 
            // f_ForgetPass
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 643);
            Controls.Add(btn_AskAI);
            Controls.Add(llbl_Register);
            Controls.Add(lbl_Title);
            Controls.Add(btn_Cancel_ForgetPass);
            Controls.Add(btn_SendOTP);
            Controls.Add(txb_Email);
            Controls.Add(lbl_Email_FPass);
            FormBorderStyle = FormBorderStyle.None;
            Name = "f_ForgetPass";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quên Mật Khẩu";
            Load += f_ForgetPass_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbl_Email_FPass;
        private TextBox txb_Email;
        private Button btn_SendOTP;
        private Button btn_Cancel_ForgetPass;
        private Label lbl_Title;
        private LinkLabel llbl_Register;
        private Button btn_AskAI;
    }
}