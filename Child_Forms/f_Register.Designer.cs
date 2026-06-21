namespace ProjectMonHoc
{
    partial class f_Register
    {
        private System.ComponentModel.IContainer components = null;

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
            lbl_Header = new Label();
            lbl_MSGV = new Label();
            txb_MSGV = new TextBox();
            lbl_Fname = new Label();
            txb_Fname = new TextBox();
            lbl_Lname = new Label();
            txb_Lname = new TextBox();
            lbl_User = new Label();
            txb_User = new TextBox();
            lbl_Pass = new Label();
            txb_Pass = new TextBox();
            ptb_ShowPass = new PictureBox();
            lbl_Email = new Label();
            txb_Email = new TextBox();
            lbl_Picture = new Label();
            ptb_Picture = new PictureBox();
            btn_UploadPic = new Button();
            txb_ConfirmPass = new TextBox();
            lbl_ConfirmPass = new Label();
            lbl_PassStatus = new Label();
            ptb_ShowConfirmPass = new PictureBox();
            btn_Cancel_Register = new Button();
            btn_Register = new Button();
            ((System.ComponentModel.ISupportInitialize)ptb_ShowPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptb_Picture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptb_ShowConfirmPass).BeginInit();
            SuspendLayout();
            // 
            // lbl_Header
            // 
            lbl_Header.BackColor = Color.Transparent;
            lbl_Header.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Header.ForeColor = Color.SteelBlue;
            lbl_Header.Location = new Point(21, 18);
            lbl_Header.Margin = new Padding(4, 0, 4, 0);
            lbl_Header.Name = "lbl_Header";
            lbl_Header.Size = new Size(466, 49);
            lbl_Header.TabIndex = 0;
            lbl_Header.Text = "ĐĂNG KÝ TÀI KHOẢN STUDENT";
            lbl_Header.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Header.Click += lbl_Header_Click;
            // 
            // lbl_MSGV
            // 
            lbl_MSGV.AutoSize = true;
            lbl_MSGV.BackColor = Color.Transparent;
            lbl_MSGV.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_MSGV.ForeColor = Color.DimGray;
            lbl_MSGV.Location = new Point(21, 88);
            lbl_MSGV.Margin = new Padding(4, 0, 4, 0);
            lbl_MSGV.Name = "lbl_MSGV";
            lbl_MSGV.Size = new Size(88, 23);
            lbl_MSGV.TabIndex = 1;
            lbl_MSGV.Text = "Mã số (ID)";
            // 
            // txb_MSGV
            // 
            txb_MSGV.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_MSGV.Location = new Point(21, 111);
            txb_MSGV.Margin = new Padding(4);
            txb_MSGV.Name = "txb_MSGV";
            txb_MSGV.Size = new Size(300, 34);
            txb_MSGV.TabIndex = 2;
            txb_MSGV.KeyPress += txb_MSGV_KeyPress;
            // 
            // lbl_Fname
            // 
            lbl_Fname.AutoSize = true;
            lbl_Fname.BackColor = Color.Transparent;
            lbl_Fname.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Fname.ForeColor = Color.DimGray;
            lbl_Fname.Location = new Point(21, 154);
            lbl_Fname.Margin = new Padding(4, 0, 4, 0);
            lbl_Fname.Name = "lbl_Fname";
            lbl_Fname.Size = new Size(123, 23);
            lbl_Fname.TabIndex = 3;
            lbl_Fname.Text = "Họ và tên đệm";
            // 
            // txb_Fname
            // 
            txb_Fname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_Fname.Location = new Point(21, 177);
            txb_Fname.Margin = new Padding(4);
            txb_Fname.Name = "txb_Fname";
            txb_Fname.Size = new Size(300, 34);
            txb_Fname.TabIndex = 4;
            txb_Fname.TextChanged += txb_Fname_TextChanged;
            txb_Fname.KeyPress += txb_Fname_KeyPress;
            // 
            // lbl_Lname
            // 
            lbl_Lname.AutoSize = true;
            lbl_Lname.BackColor = Color.Transparent;
            lbl_Lname.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Lname.ForeColor = Color.DimGray;
            lbl_Lname.Location = new Point(21, 220);
            lbl_Lname.Margin = new Padding(4, 0, 4, 0);
            lbl_Lname.Name = "lbl_Lname";
            lbl_Lname.Size = new Size(36, 23);
            lbl_Lname.TabIndex = 5;
            lbl_Lname.Text = "Tên";
            // 
            // txb_Lname
            // 
            txb_Lname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_Lname.Location = new Point(21, 243);
            txb_Lname.Margin = new Padding(4);
            txb_Lname.Name = "txb_Lname";
            txb_Lname.Size = new Size(300, 34);
            txb_Lname.TabIndex = 6;
            txb_Lname.TextChanged += txb_Lname_TextChanged;
            txb_Lname.KeyPress += txb_Lname_KeyPress;
            // 
            // lbl_User
            // 
            lbl_User.AutoSize = true;
            lbl_User.BackColor = Color.Transparent;
            lbl_User.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_User.ForeColor = Color.DimGray;
            lbl_User.Location = new Point(21, 286);
            lbl_User.Margin = new Padding(4, 0, 4, 0);
            lbl_User.Name = "lbl_User";
            lbl_User.Size = new Size(112, 23);
            lbl_User.TabIndex = 7;
            lbl_User.Text = "Tên tài khoản";
            // 
            // txb_User
            // 
            txb_User.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_User.Location = new Point(21, 309);
            txb_User.Margin = new Padding(4);
            txb_User.Name = "txb_User";
            txb_User.Size = new Size(339, 34);
            txb_User.TabIndex = 8;
            // 
            // lbl_Pass
            // 
            lbl_Pass.AutoSize = true;
            lbl_Pass.BackColor = Color.Transparent;
            lbl_Pass.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Pass.ForeColor = Color.DimGray;
            lbl_Pass.Location = new Point(21, 352);
            lbl_Pass.Margin = new Padding(4, 0, 4, 0);
            lbl_Pass.Name = "lbl_Pass";
            lbl_Pass.Size = new Size(82, 23);
            lbl_Pass.TabIndex = 9;
            lbl_Pass.Text = "Mật khẩu";
            // 
            // txb_Pass
            // 
            txb_Pass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_Pass.Location = new Point(21, 375);
            txb_Pass.Margin = new Padding(4);
            txb_Pass.Name = "txb_Pass";
            txb_Pass.PasswordChar = '●';
            txb_Pass.Size = new Size(339, 34);
            txb_Pass.TabIndex = 10;
            txb_Pass.TextChanged += txb_Pass_TextChanged;
            // 
            // ptb_ShowPass
            // 
            ptb_ShowPass.Cursor = Cursors.Hand;
            ptb_ShowPass.Location = new Point(368, 375);
            ptb_ShowPass.Margin = new Padding(4);
            ptb_ShowPass.Name = "ptb_ShowPass";
            ptb_ShowPass.Size = new Size(32, 32);
            ptb_ShowPass.SizeMode = PictureBoxSizeMode.Zoom;
            ptb_ShowPass.TabIndex = 11;
            ptb_ShowPass.TabStop = false;
            ptb_ShowPass.Click += ptb_ShowPass_Click;
            // 
            // lbl_Email
            // 
            lbl_Email.AutoSize = true;
            lbl_Email.BackColor = Color.Transparent;
            lbl_Email.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Email.ForeColor = Color.DimGray;
            lbl_Email.Location = new Point(21, 489);
            lbl_Email.Margin = new Padding(4, 0, 4, 0);
            lbl_Email.Name = "lbl_Email";
            lbl_Email.Size = new Size(120, 23);
            lbl_Email.TabIndex = 15;
            lbl_Email.Text = "Email xác thực";
            // 
            // txb_Email
            // 
            txb_Email.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_Email.Location = new Point(21, 513);
            txb_Email.Margin = new Padding(4);
            txb_Email.Name = "txb_Email";
            txb_Email.Size = new Size(452, 34);
            txb_Email.TabIndex = 16;
            // 
            // lbl_Picture
            // 
            lbl_Picture.AutoSize = true;
            lbl_Picture.BackColor = Color.Transparent;
            lbl_Picture.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Picture.ForeColor = Color.DimGray;
            lbl_Picture.Location = new Point(360, 88);
            lbl_Picture.Margin = new Padding(4, 0, 4, 0);
            lbl_Picture.Name = "lbl_Picture";
            lbl_Picture.Size = new Size(107, 23);
            lbl_Picture.TabIndex = 17;
            lbl_Picture.Text = "Ảnh đại diện";
            // 
            // ptb_Picture
            // 
            ptb_Picture.BackColor = Color.FromArgb(240, 245, 255);
            ptb_Picture.BorderStyle = BorderStyle.FixedSingle;
            ptb_Picture.Location = new Point(360, 111);
            ptb_Picture.Margin = new Padding(4);
            ptb_Picture.Name = "ptb_Picture";
            ptb_Picture.Size = new Size(120, 120);
            ptb_Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            ptb_Picture.TabIndex = 18;
            ptb_Picture.TabStop = false;
            ptb_Picture.Click += ptb_Picture_Click;
            // 
            // btn_UploadPic
            // 
            btn_UploadPic.BackColor = Color.White;
            btn_UploadPic.Cursor = Cursors.Hand;
            btn_UploadPic.FlatAppearance.BorderColor = Color.SteelBlue;
            btn_UploadPic.FlatStyle = FlatStyle.Flat;
            btn_UploadPic.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_UploadPic.ForeColor = Color.SteelBlue;
            btn_UploadPic.Location = new Point(360, 243);
            btn_UploadPic.Margin = new Padding(4);
            btn_UploadPic.Name = "btn_UploadPic";
            btn_UploadPic.Size = new Size(120, 34);
            btn_UploadPic.TabIndex = 19;
            btn_UploadPic.Text = "Chọn hình ảnh";
            btn_UploadPic.UseVisualStyleBackColor = false;
            btn_UploadPic.Click += btn_UploadPic_Click;
            // 
            // txb_ConfirmPass
            // 
            txb_ConfirmPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_ConfirmPass.ForeColor = SystemColors.WindowText;
            txb_ConfirmPass.Location = new Point(21, 441);
            txb_ConfirmPass.Margin = new Padding(4);
            txb_ConfirmPass.Name = "txb_ConfirmPass";
            txb_ConfirmPass.PasswordChar = '●';
            txb_ConfirmPass.Size = new Size(339, 34);
            txb_ConfirmPass.TabIndex = 12;
            txb_ConfirmPass.TextChanged += txb_ConfirmPass_TextChanged;
            // 
            // lbl_ConfirmPass
            // 
            lbl_ConfirmPass.AutoSize = true;
            lbl_ConfirmPass.BackColor = Color.Transparent;
            lbl_ConfirmPass.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_ConfirmPass.ForeColor = Color.DimGray;
            lbl_ConfirmPass.Location = new Point(21, 418);
            lbl_ConfirmPass.Margin = new Padding(4, 0, 4, 0);
            lbl_ConfirmPass.Name = "lbl_ConfirmPass";
            lbl_ConfirmPass.Size = new Size(151, 23);
            lbl_ConfirmPass.TabIndex = 11;
            lbl_ConfirmPass.Text = "Nhập lại mật khẩu";
            // 
            // lbl_PassStatus
            // 
            lbl_PassStatus.AutoSize = true;
            lbl_PassStatus.BackColor = Color.Transparent;
            lbl_PassStatus.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_PassStatus.ForeColor = Color.SeaGreen;
            lbl_PassStatus.Location = new Point(408, 441);
            lbl_PassStatus.Margin = new Padding(4, 0, 4, 0);
            lbl_PassStatus.Name = "lbl_PassStatus";
            lbl_PassStatus.Size = new Size(38, 37);
            lbl_PassStatus.TabIndex = 14;
            lbl_PassStatus.Text = "✓";
            lbl_PassStatus.Visible = false;
            // 
            // ptb_ShowConfirmPass
            // 
            ptb_ShowConfirmPass.Cursor = Cursors.Hand;
            ptb_ShowConfirmPass.Location = new Point(368, 441);
            ptb_ShowConfirmPass.Margin = new Padding(4);
            ptb_ShowConfirmPass.Name = "ptb_ShowConfirmPass";
            ptb_ShowConfirmPass.Size = new Size(32, 32);
            ptb_ShowConfirmPass.SizeMode = PictureBoxSizeMode.Zoom;
            ptb_ShowConfirmPass.TabIndex = 13;
            ptb_ShowConfirmPass.TabStop = false;
            ptb_ShowConfirmPass.Click += ptb_ShowConfirmPass_Click;
            // 
            // btn_Cancel_Register
            // 
            btn_Cancel_Register.BackColor = Color.IndianRed;
            btn_Cancel_Register.Cursor = Cursors.Hand;
            btn_Cancel_Register.FlatAppearance.BorderSize = 0;
            btn_Cancel_Register.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Cancel_Register.ForeColor = Color.White;
            btn_Cancel_Register.Location = new Point(253, 572);
            btn_Cancel_Register.Margin = new Padding(4);
            btn_Cancel_Register.Name = "btn_Cancel_Register";
            btn_Cancel_Register.Size = new Size(220, 55);
            btn_Cancel_Register.TabIndex = 21;
            btn_Cancel_Register.Text = "Hủy";
            btn_Cancel_Register.UseVisualStyleBackColor = false;
            btn_Cancel_Register.Click += btn_Cancel_Register_Click;
            // 
            // btn_Register
            // 
            btn_Register.BackColor = Color.SteelBlue;
            btn_Register.Cursor = Cursors.Hand;
            btn_Register.FlatAppearance.BorderSize = 0;
            btn_Register.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Register.ForeColor = Color.White;
            btn_Register.Location = new Point(21, 572);
            btn_Register.Margin = new Padding(4);
            btn_Register.Name = "btn_Register";
            btn_Register.Size = new Size(220, 55);
            btn_Register.TabIndex = 20;
            btn_Register.Text = "Đăng ký";
            btn_Register.UseVisualStyleBackColor = false;
            btn_Register.Click += btn_Register_Click;
            // 
            // f_Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 643);
            Controls.Add(lbl_Header);
            Controls.Add(lbl_MSGV);
            Controls.Add(txb_MSGV);
            Controls.Add(lbl_Fname);
            Controls.Add(txb_Fname);
            Controls.Add(lbl_Lname);
            Controls.Add(txb_Lname);
            Controls.Add(lbl_User);
            Controls.Add(txb_User);
            Controls.Add(lbl_Pass);
            Controls.Add(txb_Pass);
            Controls.Add(ptb_ShowPass);
            Controls.Add(lbl_ConfirmPass);
            Controls.Add(txb_ConfirmPass);
            Controls.Add(ptb_ShowConfirmPass);
            Controls.Add(lbl_PassStatus);
            Controls.Add(lbl_Email);
            Controls.Add(txb_Email);
            Controls.Add(lbl_Picture);
            Controls.Add(ptb_Picture);
            Controls.Add(btn_UploadPic);
            Controls.Add(btn_Register);
            Controls.Add(btn_Cancel_Register);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "f_Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Ký Tài Khoản";
            Load += f_Register_Load;
            ((System.ComponentModel.ISupportInitialize)ptb_ShowPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptb_Picture).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptb_ShowConfirmPass).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Header;
        private Label lbl_MSGV;
        private TextBox txb_MSGV;
        private Label lbl_Fname;
        private TextBox txb_Fname;
        private Label lbl_Lname;
        private TextBox txb_Lname;
        private Label lbl_User;
        private TextBox txb_User;
        private Label lbl_Pass;
        private TextBox txb_Pass;
        private PictureBox ptb_ShowPass;
        private Label lbl_Email;
        private TextBox txb_Email;
        private Label lbl_Picture;
        private PictureBox ptb_Picture;
        private Button btn_UploadPic;
        private TextBox txb_ConfirmPass;
        private Label lbl_ConfirmPass;
        private Label lbl_PassStatus;
        private PictureBox ptb_ShowConfirmPass;
        private Button btn_Cancel_Register;
        private Button btn_Register;
    }
}