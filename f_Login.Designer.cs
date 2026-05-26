namespace ProjectMonHoc
{
    partial class f_Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_Login));
            lbl_Title = new Label();
            lbl_User = new Label();
            lbl_Pass = new Label();
            lbl_Role = new Label();
            txb_User = new TextBox();
            txb_Pass = new TextBox();
            rdb_Student = new RadioButton();
            rdb_HR = new RadioButton();
            chk_Remember = new CheckBox();
            btn_Login = new Button();
            btn_Cancel_Login = new Button();
            errorProvider1 = new ErrorProvider(components);
            label1 = new Label();
            pnl_login = new Panel();
            llbl_ForgetPass = new LinkLabel();
            llbl_Register = new LinkLabel();
            lb_HCMUTE_name = new Label();
            pic_HCMUTE = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            pnl_login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_HCMUTE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbl_Title
            // 
            lbl_Title.BackColor = Color.Transparent;
            lbl_Title.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lbl_Title.ForeColor = Color.SteelBlue;
            lbl_Title.Location = new Point(57, 75);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(524, 54);
            lbl_Title.TabIndex = 0;
            lbl_Title.Text = "ĐĂNG NHẬP HỆ THỐNG";
            lbl_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_User
            // 
            lbl_User.AutoSize = true;
            lbl_User.BackColor = Color.White;
            lbl_User.Font = new Font("Segoe UI", 13F);
            lbl_User.ForeColor = SystemColors.GrayText;
            lbl_User.Location = new Point(58, 227);
            lbl_User.Name = "lbl_User";
            lbl_User.Size = new Size(109, 30);
            lbl_User.TabIndex = 2;
            lbl_User.Text = "Tài khoản:";
            // 
            // lbl_Pass
            // 
            lbl_Pass.AutoSize = true;
            lbl_Pass.BackColor = Color.White;
            lbl_Pass.Font = new Font("Segoe UI", 13F);
            lbl_Pass.ForeColor = SystemColors.GrayText;
            lbl_Pass.Location = new Point(57, 296);
            lbl_Pass.Name = "lbl_Pass";
            lbl_Pass.Size = new Size(108, 30);
            lbl_Pass.TabIndex = 3;
            lbl_Pass.Text = "Mật khẩu:";
            // 
            // lbl_Role
            // 
            lbl_Role.AutoSize = true;
            lbl_Role.Font = new Font("Segoe UI", 13F);
            lbl_Role.ForeColor = SystemColors.GrayText;
            lbl_Role.Location = new Point(57, 171);
            lbl_Role.Name = "lbl_Role";
            lbl_Role.Size = new Size(80, 30);
            lbl_Role.TabIndex = 1;
            lbl_Role.Text = "Vai trò:";
            // 
            // txb_User
            // 
            txb_User.BackColor = Color.White;
            txb_User.BorderStyle = BorderStyle.FixedSingle;
            txb_User.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_User.ForeColor = Color.Black;
            txb_User.Location = new Point(204, 226);
            txb_User.Name = "txb_User";
            txb_User.Size = new Size(220, 34);
            txb_User.TabIndex = 2;
            txb_User.TextChanged += txb_User_TextChanged;
            // 
            // txb_Pass
            // 
            txb_Pass.BackColor = Color.White;
            txb_Pass.BorderStyle = BorderStyle.FixedSingle;
            txb_Pass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_Pass.ForeColor = Color.Black;
            txb_Pass.Location = new Point(204, 295);
            txb_Pass.Name = "txb_Pass";
            txb_Pass.PasswordChar = '●';
            txb_Pass.Size = new Size(220, 34);
            txb_Pass.TabIndex = 3;
            txb_Pass.TextChanged += txb_Pass_TextChanged;
            // 
            // rdb_Student
            // 
            rdb_Student.AutoSize = true;
            rdb_Student.Checked = true;
            rdb_Student.Font = new Font("Segoe UI Semibold", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rdb_Student.ForeColor = Color.Black;
            rdb_Student.Location = new Point(204, 169);
            rdb_Student.Name = "rdb_Student";
            rdb_Student.Size = new Size(115, 35);
            rdb_Student.TabIndex = 0;
            rdb_Student.TabStop = true;
            rdb_Student.Text = "Student";
            // 
            // rdb_HR
            // 
            rdb_HR.AutoSize = true;
            rdb_HR.Font = new Font("Segoe UI Semibold", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rdb_HR.ForeColor = Color.Black;
            rdb_HR.Location = new Point(390, 169);
            rdb_HR.Name = "rdb_HR";
            rdb_HR.Size = new Size(66, 35);
            rdb_HR.TabIndex = 1;
            rdb_HR.Text = "HR";
            // 
            // chk_Remember
            // 
            chk_Remember.AutoSize = true;
            chk_Remember.BackColor = Color.White;
            chk_Remember.Font = new Font("Segoe UI", 12F);
            chk_Remember.ForeColor = SystemColors.GrayText;
            chk_Remember.Location = new Point(83, 365);
            chk_Remember.Name = "chk_Remember";
            chk_Remember.Size = new Size(202, 32);
            chk_Remember.TabIndex = 4;
            chk_Remember.Text = "Ghi nhớ đăng nhập";
            chk_Remember.UseVisualStyleBackColor = false;
            chk_Remember.CheckedChanged += chk_Remember_CheckedChanged;
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.YellowGreen;
            btn_Login.FlatAppearance.BorderSize = 0;
            btn_Login.FlatStyle = FlatStyle.Flat;
            btn_Login.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btn_Login.ForeColor = Color.White;
            btn_Login.Location = new Point(93, 429);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(154, 70);
            btn_Login.TabIndex = 5;
            btn_Login.Text = "Đăng nhập";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // btn_Cancel_Login
            // 
            btn_Cancel_Login.BackColor = Color.IndianRed;
            btn_Cancel_Login.FlatAppearance.BorderSize = 0;
            btn_Cancel_Login.FlatStyle = FlatStyle.Flat;
            btn_Cancel_Login.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btn_Cancel_Login.ForeColor = Color.White;
            btn_Cancel_Login.Location = new Point(364, 429);
            btn_Cancel_Login.Name = "btn_Cancel_Login";
            btn_Cancel_Login.Size = new Size(154, 70);
            btn_Cancel_Login.TabIndex = 6;
            btn_Cancel_Login.Text = "Hủy";
            btn_Cancel_Login.UseVisualStyleBackColor = false;
            btn_Cancel_Login.Click += btn_Cancel_Login_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(553, 202);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 8;
            // 
            // pnl_login
            // 
            pnl_login.BackColor = Color.White;
            pnl_login.Controls.Add(llbl_ForgetPass);
            pnl_login.Controls.Add(lbl_Role);
            pnl_login.Controls.Add(lbl_Title);
            pnl_login.Controls.Add(btn_Cancel_Login);
            pnl_login.Controls.Add(btn_Login);
            pnl_login.Controls.Add(llbl_Register);
            pnl_login.Controls.Add(rdb_Student);
            pnl_login.Controls.Add(chk_Remember);
            pnl_login.Controls.Add(txb_Pass);
            pnl_login.Controls.Add(lbl_Pass);
            pnl_login.Controls.Add(txb_User);
            pnl_login.Controls.Add(lbl_User);
            pnl_login.Controls.Add(rdb_HR);
            pnl_login.Location = new Point(640, 0);
            pnl_login.Name = "pnl_login";
            pnl_login.Size = new Size(640, 720);
            pnl_login.TabIndex = 9;
            // 
            // llbl_ForgetPass
            // 
            llbl_ForgetPass.AutoSize = true;
            llbl_ForgetPass.BackColor = Color.Transparent;
            llbl_ForgetPass.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            llbl_ForgetPass.ForeColor = SystemColors.ControlLight;
            llbl_ForgetPass.LinkBehavior = LinkBehavior.NeverUnderline;
            llbl_ForgetPass.LinkColor = Color.DimGray;
            llbl_ForgetPass.Location = new Point(83, 519);
            llbl_ForgetPass.Name = "llbl_ForgetPass";
            llbl_ForgetPass.Size = new Size(157, 28);
            llbl_ForgetPass.TabIndex = 8;
            llbl_ForgetPass.TabStop = true;
            llbl_ForgetPass.Text = "Quên mật khẩu?";
            llbl_ForgetPass.LinkClicked += llbl_ForgetPass_LinkClicked;
            // 
            // llbl_Register
            // 
            llbl_Register.AutoSize = true;
            llbl_Register.BackColor = Color.White;
            llbl_Register.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            llbl_Register.ForeColor = SystemColors.ActiveBorder;
            llbl_Register.LinkBehavior = LinkBehavior.NeverUnderline;
            llbl_Register.LinkColor = Color.DimGray;
            llbl_Register.Location = new Point(364, 366);
            llbl_Register.Name = "llbl_Register";
            llbl_Register.Size = new Size(182, 28);
            llbl_Register.TabIndex = 7;
            llbl_Register.TabStop = true;
            llbl_Register.Text = "Đăng ký tài khoản?";
            llbl_Register.LinkClicked += llbl_Register_LinkClicked;
            // 
            // lb_HCMUTE_name
            // 
            lb_HCMUTE_name.BackColor = Color.Transparent;
            lb_HCMUTE_name.Font = new Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_HCMUTE_name.ForeColor = Color.Black;
            lb_HCMUTE_name.Location = new Point(92, 9);
            lb_HCMUTE_name.Name = "lb_HCMUTE_name";
            lb_HCMUTE_name.Size = new Size(542, 89);
            lb_HCMUTE_name.TabIndex = 10;
            lb_HCMUTE_name.Text = "TRƯỜNG ĐẠI HỌC CÔNG NGHỆ KỸ THUẬT\r\nTP.HCM";
            lb_HCMUTE_name.TextAlign = ContentAlignment.MiddleCenter;
            lb_HCMUTE_name.Click += llb_HCMUTE_name_Click;
            // 
            // pic_HCMUTE
            // 
            pic_HCMUTE.BackColor = Color.Transparent;
            pic_HCMUTE.Image = (Image)resources.GetObject("pic_HCMUTE.Image");
            pic_HCMUTE.Location = new Point(12, 9);
            pic_HCMUTE.Name = "pic_HCMUTE";
            pic_HCMUTE.Size = new Size(92, 120);
            pic_HCMUTE.SizeMode = PictureBoxSizeMode.Zoom;
            pic_HCMUTE.TabIndex = 11;
            pic_HCMUTE.TabStop = false;
            pic_HCMUTE.Click += pic_HCMUTE_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(640, 720);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // f_Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1280, 720);
            Controls.Add(pic_HCMUTE);
            Controls.Add(lb_HCMUTE_name);
            Controls.Add(pnl_login);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "f_Login";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UTEID";
            Load += f_Login_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            pnl_login.ResumeLayout(false);
            pnl_login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_HCMUTE).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Title;
        private Label lbl_User;
        private Label lbl_Pass;
        private Label lbl_Role;
        private TextBox txb_User;
        private TextBox txb_Pass;
        private RadioButton rdb_Student;
        private RadioButton rdb_HR;
        private CheckBox chk_Remember;
        private Button btn_Login;
        private Button btn_Cancel_Login;
        private ErrorProvider errorProvider1;
        internal Panel pnl_login;
        private Label label1;
        private Label lb_HCMUTE_name;
        private PictureBox pic_HCMUTE;
        private PictureBox pictureBox1;
        private LinkLabel llbl_ForgetPass;
        private LinkLabel llbl_Register;
    }
}