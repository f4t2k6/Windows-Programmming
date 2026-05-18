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
            lbl_Email = new Label();
            txb_Email = new TextBox();
            ptb_Picture = new PictureBox();
            btn_UploadPic = new Button();
            btn_Register = new Button();
            panel_Line = new Panel();
            ((System.ComponentModel.ISupportInitialize)ptb_Picture).BeginInit();
            SuspendLayout();
            // 
            // lbl_Header
            // 
            lbl_Header.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl_Header.ForeColor = Color.MediumBlue;
            lbl_Header.Location = new Point(0, 15);
            lbl_Header.Name = "lbl_Header";
            lbl_Header.Size = new Size(540, 40);
            lbl_Header.TabIndex = 0;
            lbl_Header.Text = "ĐĂNG KÝ TÀI KHOẢN MỚI";
            lbl_Header.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_MSGV
            // 
            lbl_MSGV.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_MSGV.ForeColor = Color.Black;
            lbl_MSGV.Location = new Point(40, 85);
            lbl_MSGV.Name = "lbl_MSGV";
            lbl_MSGV.Size = new Size(130, 25);
            lbl_MSGV.TabIndex = 1;
            lbl_MSGV.Text = "Mã số (ID):";
            lbl_MSGV.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txb_MSGV
            // 
            txb_MSGV.Font = new Font("Segoe UI", 10F);
            txb_MSGV.Location = new Point(180, 83);
            txb_MSGV.Name = "txb_MSGV";
            txb_MSGV.Size = new Size(160, 30);
            txb_MSGV.TabIndex = 2;
            // 
            // lbl_Fname
            // 
            lbl_Fname.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_Fname.ForeColor = Color.Black;
            lbl_Fname.Location = new Point(40, 130);
            lbl_Fname.Name = "lbl_Fname";
            lbl_Fname.Size = new Size(130, 25);
            lbl_Fname.TabIndex = 3;
            lbl_Fname.Text = "Họ và tên đệm:";
            lbl_Fname.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txb_Fname
            // 
            txb_Fname.Font = new Font("Segoe UI", 10F);
            txb_Fname.Location = new Point(180, 128);
            txb_Fname.Name = "txb_Fname";
            txb_Fname.Size = new Size(160, 30);
            txb_Fname.TabIndex = 4;
            // 
            // lbl_Lname
            // 
            lbl_Lname.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_Lname.ForeColor = Color.Black;
            lbl_Lname.Location = new Point(40, 175);
            lbl_Lname.Name = "lbl_Lname";
            lbl_Lname.Size = new Size(130, 25);
            lbl_Lname.TabIndex = 5;
            lbl_Lname.Text = "Tên:";
            lbl_Lname.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txb_Lname
            // 
            txb_Lname.Font = new Font("Segoe UI", 10F);
            txb_Lname.Location = new Point(180, 173);
            txb_Lname.Name = "txb_Lname";
            txb_Lname.Size = new Size(160, 30);
            txb_Lname.TabIndex = 6;
            // 
            // lbl_User
            // 
            lbl_User.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_User.ForeColor = Color.Black;
            lbl_User.Location = new Point(40, 220);
            lbl_User.Name = "lbl_User";
            lbl_User.Size = new Size(130, 25);
            lbl_User.TabIndex = 7;
            lbl_User.Text = "Tên tài khoản:";
            lbl_User.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txb_User
            // 
            txb_User.Font = new Font("Segoe UI", 10F);
            txb_User.Location = new Point(180, 218);
            txb_User.Name = "txb_User";
            txb_User.Size = new Size(160, 30);
            txb_User.TabIndex = 8;
            // 
            // lbl_Pass
            // 
            lbl_Pass.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_Pass.ForeColor = Color.Black;
            lbl_Pass.Location = new Point(40, 265);
            lbl_Pass.Name = "lbl_Pass";
            lbl_Pass.Size = new Size(130, 25);
            lbl_Pass.TabIndex = 9;
            lbl_Pass.Text = "Mật khẩu:";
            lbl_Pass.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txb_Pass
            // 
            txb_Pass.Font = new Font("Segoe UI", 10F);
            txb_Pass.Location = new Point(180, 263);
            txb_Pass.Name = "txb_Pass";
            txb_Pass.PasswordChar = '●';
            txb_Pass.Size = new Size(160, 30);
            txb_Pass.TabIndex = 10;
            // 
            // lbl_Email
            // 
            lbl_Email.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_Email.ForeColor = Color.Black;
            lbl_Email.Location = new Point(40, 310);
            lbl_Email.Name = "lbl_Email";
            lbl_Email.Size = new Size(130, 25);
            lbl_Email.TabIndex = 11;
            lbl_Email.Text = "Email xác thực:";
            lbl_Email.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txb_Email
            // 
            txb_Email.Font = new Font("Segoe UI", 10F);
            txb_Email.Location = new Point(180, 308);
            txb_Email.Name = "txb_Email";
            txb_Email.Size = new Size(320, 30);
            txb_Email.TabIndex = 12;
            // 
            // ptb_Picture
            // 
            ptb_Picture.BackColor = Color.FromArgb(240, 245, 255);
            ptb_Picture.BorderStyle = BorderStyle.FixedSingle;
            ptb_Picture.Location = new Point(370, 83);
            ptb_Picture.Name = "ptb_Picture";
            ptb_Picture.Size = new Size(130, 140);
            ptb_Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            ptb_Picture.TabIndex = 13;
            ptb_Picture.TabStop = false;
            ptb_Picture.Click += ptb_Picture_Click;
            // 
            // btn_UploadPic
            // 
            btn_UploadPic.BackColor = Color.White;
            btn_UploadPic.Cursor = Cursors.Hand;
            btn_UploadPic.FlatStyle = FlatStyle.Flat;
            btn_UploadPic.Font = new Font("Segoe UI", 8.5F);
            btn_UploadPic.ForeColor = Color.MediumBlue;
            btn_UploadPic.Location = new Point(370, 233);
            btn_UploadPic.Name = "btn_UploadPic";
            btn_UploadPic.Size = new Size(130, 30);
            btn_UploadPic.TabIndex = 14;
            btn_UploadPic.Text = "Chọn hình ảnh";
            btn_UploadPic.UseVisualStyleBackColor = false;
            btn_UploadPic.Click += btn_UploadPic_Click;
            // 
            // btn_Register
            // 
            btn_Register.BackColor = Color.MediumBlue;
            btn_Register.Cursor = Cursors.Hand;
            btn_Register.FlatAppearance.BorderSize = 0;
            btn_Register.FlatStyle = FlatStyle.Flat;
            btn_Register.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Register.ForeColor = Color.White;
            btn_Register.Location = new Point(40, 365);
            btn_Register.Name = "btn_Register";
            btn_Register.Size = new Size(460, 45);
            btn_Register.TabIndex = 15;
            btn_Register.Text = "TIẾN HÀNH ĐĂNG KÝ";
            btn_Register.UseVisualStyleBackColor = false;
            btn_Register.Click += btn_Register_Click;
            // 
            // panel_Line
            // 
            panel_Line.BackColor = Color.LightGray;
            panel_Line.Location = new Point(40, 65);
            panel_Line.Name = "panel_Line";
            panel_Line.Size = new Size(460, 2);
            panel_Line.TabIndex = 16;
            // 
            // f_Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(540, 445);
            Controls.Add(panel_Line);
            Controls.Add(btn_Register);
            Controls.Add(btn_UploadPic);
            Controls.Add(ptb_Picture);
            Controls.Add(txb_Email);
            Controls.Add(lbl_Email);
            Controls.Add(txb_Pass);
            Controls.Add(lbl_Pass);
            Controls.Add(txb_User);
            Controls.Add(lbl_User);
            Controls.Add(txb_Lname);
            Controls.Add(lbl_Lname);
            Controls.Add(txb_Fname);
            Controls.Add(lbl_Fname);
            Controls.Add(txb_MSGV);
            Controls.Add(lbl_MSGV);
            Controls.Add(lbl_Header);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "f_Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Ký Tài Khoản";
            Load += f_Register_Load;
            ((System.ComponentModel.ISupportInitialize)ptb_Picture).EndInit();
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
        private Label lbl_Email;
        private TextBox txb_Email;
        private PictureBox ptb_Picture;
        private Button btn_UploadPic;
        private Button btn_Register;
        private Panel panel_Line;
        private Label lbl_ConfirmPass;
        private TextBox txb_ConfirmPass;
        private Label lbl_PassStatus; // Thêm label nhỏ này để hiển thị thông báo realtime (Mật khẩu trùng/không trùng)
    }
}