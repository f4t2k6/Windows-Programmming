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
            btn_Cancel = new Button();
            errorProvider1 = new ErrorProvider(components);
            llbl_Register = new LinkLabel();
            label1 = new Label();
            pnl_login = new Panel();
            lbl_Welback_Login = new Label();
            pic_logo_HCMUTE_Login = new PictureBox();
            lbl_Intro_Login = new Label();
            llbl_ForgetPass = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            pnl_login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_logo_HCMUTE_Login).BeginInit();
            SuspendLayout();
            // 
            // lbl_Title
            // 
            lbl_Title.BackColor = Color.Transparent;
            lbl_Title.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lbl_Title.ForeColor = Color.DimGray;
            lbl_Title.Location = new Point(49, 43);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(524, 54);
            lbl_Title.TabIndex = 0;
            lbl_Title.Text = "ĐĂNG NHẬP HỆ THỐNG";
            lbl_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_User
            // 
            lbl_User.AutoSize = true;
            lbl_User.BackColor = SystemColors.GrayText;
            lbl_User.Font = new Font("Segoe UI", 13F);
            lbl_User.ForeColor = Color.White;
            lbl_User.Location = new Point(49, 181);
            lbl_User.Name = "lbl_User";
            lbl_User.Size = new Size(109, 30);
            lbl_User.TabIndex = 2;
            lbl_User.Text = "Tài khoản:";
            // 
            // lbl_Pass
            // 
            lbl_Pass.AutoSize = true;
            lbl_Pass.BackColor = SystemColors.GrayText;
            lbl_Pass.Font = new Font("Segoe UI", 13F);
            lbl_Pass.ForeColor = Color.White;
            lbl_Pass.Location = new Point(49, 250);
            lbl_Pass.Name = "lbl_Pass";
            lbl_Pass.Size = new Size(108, 30);
            lbl_Pass.TabIndex = 3;
            lbl_Pass.Text = "Mật khẩu:";
            // 
            // lbl_Role
            // 
            lbl_Role.AutoSize = true;
            lbl_Role.Font = new Font("Segoe UI", 13F);
            lbl_Role.ForeColor = Color.Gray;
            lbl_Role.Location = new Point(48, 129);
            lbl_Role.Name = "lbl_Role";
            lbl_Role.Size = new Size(80, 30);
            lbl_Role.TabIndex = 1;
            lbl_Role.Text = "Vai trò:";
            // 
            // txb_User
            // 
            txb_User.Font = new Font("Segoe UI", 11F);
            txb_User.Location = new Point(215, 179);
            txb_User.Name = "txb_User";
            txb_User.Size = new Size(220, 32);
            txb_User.TabIndex = 2;
            txb_User.TextChanged += txb_User_TextChanged;
            // 
            // txb_Pass
            // 
            txb_Pass.Font = new Font("Segoe UI", 11F);
            txb_Pass.Location = new Point(215, 248);
            txb_Pass.Name = "txb_Pass";
            txb_Pass.PasswordChar = '●';
            txb_Pass.Size = new Size(220, 32);
            txb_Pass.TabIndex = 3;
            txb_Pass.TextChanged += txb_Pass_TextChanged;
            // 
            // rdb_Student
            // 
            rdb_Student.AutoSize = true;
            rdb_Student.Checked = true;
            rdb_Student.Font = new Font("Segoe UI", 13F);
            rdb_Student.ForeColor = Color.Gray;
            rdb_Student.Location = new Point(215, 127);
            rdb_Student.Name = "rdb_Student";
            rdb_Student.Size = new Size(108, 34);
            rdb_Student.TabIndex = 0;
            rdb_Student.TabStop = true;
            rdb_Student.Text = "Student";
            // 
            // rdb_HR
            // 
            rdb_HR.AutoSize = true;
            rdb_HR.Font = new Font("Segoe UI", 13F);
            rdb_HR.ForeColor = Color.Gray;
            rdb_HR.Location = new Point(401, 127);
            rdb_HR.Name = "rdb_HR";
            rdb_HR.Size = new Size(63, 34);
            rdb_HR.TabIndex = 1;
            rdb_HR.Text = "HR";
            // 
            // chk_Remember
            // 
            chk_Remember.AutoSize = true;
            chk_Remember.BackColor = SystemColors.GrayText;
            chk_Remember.Font = new Font("Segoe UI", 12F);
            chk_Remember.ForeColor = Color.White;
            chk_Remember.Location = new Point(49, 335);
            chk_Remember.Name = "chk_Remember";
            chk_Remember.Size = new Size(202, 32);
            chk_Remember.TabIndex = 4;
            chk_Remember.Text = "Ghi nhớ đăng nhập";
            chk_Remember.UseVisualStyleBackColor = false;
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.DarkSeaGreen;
            btn_Login.FlatAppearance.BorderSize = 0;
            btn_Login.FlatStyle = FlatStyle.Flat;
            btn_Login.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btn_Login.ForeColor = Color.LightYellow;
            btn_Login.Location = new Point(85, 430);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(154, 70);
            btn_Login.TabIndex = 5;
            btn_Login.Text = "Đăng nhập";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.BackColor = Color.IndianRed;
            btn_Cancel.FlatAppearance.BorderSize = 0;
            btn_Cancel.FlatStyle = FlatStyle.Flat;
            btn_Cancel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btn_Cancel.ForeColor = Color.White;
            btn_Cancel.Location = new Point(356, 430);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(154, 70);
            btn_Cancel.TabIndex = 6;
            btn_Cancel.Text = "Hủy";
            btn_Cancel.UseVisualStyleBackColor = false;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // llbl_Register
            // 
            llbl_Register.AutoSize = true;
            llbl_Register.BackColor = SystemColors.GrayText;
            llbl_Register.Font = new Font("Segoe UI", 13F, FontStyle.Italic);
            llbl_Register.ForeColor = SystemColors.ControlLight;
            llbl_Register.LinkColor = Color.Azure;
            llbl_Register.Location = new Point(340, 337);
            llbl_Register.Name = "llbl_Register";
            llbl_Register.Size = new Size(198, 30);
            llbl_Register.TabIndex = 7;
            llbl_Register.TabStop = true;
            llbl_Register.Text = "Đăng ký tài khoản?";
            llbl_Register.LinkClicked += llbl_Register_LinkClicked;
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
            pnl_login.BackColor = SystemColors.Info;
            pnl_login.Controls.Add(llbl_ForgetPass);
            pnl_login.Controls.Add(lbl_Role);
            pnl_login.Controls.Add(lbl_Title);
            pnl_login.Controls.Add(btn_Cancel);
            pnl_login.Controls.Add(btn_Login);
            pnl_login.Controls.Add(llbl_Register);
            pnl_login.Controls.Add(rdb_Student);
            pnl_login.Controls.Add(chk_Remember);
            pnl_login.Controls.Add(txb_Pass);
            pnl_login.Controls.Add(lbl_Pass);
            pnl_login.Controls.Add(txb_User);
            pnl_login.Controls.Add(lbl_User);
            pnl_login.Controls.Add(rdb_HR);
            pnl_login.Location = new Point(630, -3);
            pnl_login.Name = "pnl_login";
            pnl_login.Size = new Size(633, 677);
            pnl_login.TabIndex = 9;
            // 
            // lbl_Welback_Login
            // 
            lbl_Welback_Login.BackColor = Color.Transparent;
            lbl_Welback_Login.Font = new Font("Sylfaen", 40.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Welback_Login.ForeColor = SystemColors.Window;
            lbl_Welback_Login.Location = new Point(62, 178);
            lbl_Welback_Login.Name = "lbl_Welback_Login";
            lbl_Welback_Login.Size = new Size(491, 87);
            lbl_Welback_Login.TabIndex = 10;
            lbl_Welback_Login.Text = "Welcome Back!";
            lbl_Welback_Login.Click += label2_Click;
            // 
            // pic_logo_HCMUTE_Login
            // 
            pic_logo_HCMUTE_Login.BackColor = Color.Transparent;
            pic_logo_HCMUTE_Login.BackgroundImage = (Image)resources.GetObject("pic_logo_HCMUTE_Login.BackgroundImage");
            pic_logo_HCMUTE_Login.Image = Properties.Resources.logo_HCMUTE_Login;
            pic_logo_HCMUTE_Login.Location = new Point(251, 28);
            pic_logo_HCMUTE_Login.Name = "pic_logo_HCMUTE_Login";
            pic_logo_HCMUTE_Login.Size = new Size(124, 147);
            pic_logo_HCMUTE_Login.SizeMode = PictureBoxSizeMode.Zoom;
            pic_logo_HCMUTE_Login.TabIndex = 11;
            pic_logo_HCMUTE_Login.TabStop = false;
            // 
            // lbl_Intro_Login
            // 
            lbl_Intro_Login.BackColor = Color.Transparent;
            lbl_Intro_Login.Font = new Font("Segoe UI Emoji", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_Intro_Login.Location = new Point(115, 321);
            lbl_Intro_Login.Name = "lbl_Intro_Login";
            lbl_Intro_Login.Size = new Size(426, 81);
            lbl_Intro_Login.TabIndex = 12;
            lbl_Intro_Login.Text = "This website is an academic project             currently under development.";
            // 
            // llbl_ForgetPass
            // 
            llbl_ForgetPass.AutoSize = true;
            llbl_ForgetPass.BackColor = SystemColors.GrayText;
            llbl_ForgetPass.Font = new Font("Segoe UI", 13F, FontStyle.Italic);
            llbl_ForgetPass.ForeColor = SystemColors.ControlLight;
            llbl_ForgetPass.LinkColor = Color.Azure;
            llbl_ForgetPass.Location = new Point(340, 375);
            llbl_ForgetPass.Name = "llbl_ForgetPass";
            llbl_ForgetPass.Size = new Size(171, 30);
            llbl_ForgetPass.TabIndex = 8;
            llbl_ForgetPass.TabStop = true;
            llbl_ForgetPass.Text = "Quên mật khẩu?";
            llbl_ForgetPass.LinkClicked += llbl_ForgetPass_LinkClicked;
            // 
            // f_Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            BackgroundImage = Properties.Resources.pic_background_Login;
            ClientSize = new Size(1262, 673);
            Controls.Add(lbl_Intro_Login);
            Controls.Add(pic_logo_HCMUTE_Login);
            Controls.Add(lbl_Welback_Login);
            Controls.Add(pnl_login);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "f_Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            Load += f_Login_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            pnl_login.ResumeLayout(false);
            pnl_login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_logo_HCMUTE_Login).EndInit();
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
        private Button btn_Cancel;
        private ErrorProvider errorProvider1;
        private LinkLabel llbl_Register; // 3. Thêm định nghĩa biến LinkLabel
        private Panel pnl_login;
        private Label label1;
        private Label lbl_Welback_Login;
        private PictureBox pic_logo_HCMUTE_Login;
        private Label lbl_Intro_Login;
        private LinkLabel llbl_ForgetPass;
    }
}