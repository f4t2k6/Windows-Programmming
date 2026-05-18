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
            llbl_Register = new LinkLabel(); // 1. Khởi tạo đối tượng LinkLabel mới
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lbl_Title
            // 
            lbl_Title.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbl_Title.ForeColor = Color.White;
            lbl_Title.Location = new Point(0, 30);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(460, 45);
            lbl_Title.TabIndex = 0;
            lbl_Title.Text = "ĐĂNG NHẬP HỆ THỐNG";
            lbl_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_User
            // 
            lbl_User.AutoSize = true;
            lbl_User.Font = new Font("Segoe UI", 11F);
            lbl_User.ForeColor = Color.White;
            lbl_User.Location = new Point(60, 150);
            lbl_User.Name = "lbl_User";
            lbl_User.Size = new Size(96, 25);
            lbl_User.TabIndex = 2;
            lbl_User.Text = "Tài khoản:";
            // 
            // lbl_Pass
            // 
            lbl_Pass.AutoSize = true;
            lbl_Pass.Font = new Font("Segoe UI", 11F);
            lbl_Pass.ForeColor = Color.White;
            lbl_Pass.Location = new Point(60, 205);
            lbl_Pass.Name = "lbl_Pass";
            lbl_Pass.Size = new Size(95, 25);
            lbl_Pass.TabIndex = 3;
            lbl_Pass.Text = "Mật khẩu:";
            // 
            // lbl_Role
            // 
            lbl_Role.AutoSize = true;
            lbl_Role.Font = new Font("Segoe UI", 11F);
            lbl_Role.ForeColor = Color.White;
            lbl_Role.Location = new Point(60, 100);
            lbl_Role.Name = "lbl_Role";
            lbl_Role.Size = new Size(71, 25);
            lbl_Role.TabIndex = 1;
            lbl_Role.Text = "Vai trò:";
            // 
            // txb_User
            // 
            txb_User.Font = new Font("Segoe UI", 11F);
            txb_User.Location = new Point(170, 147);
            txb_User.Name = "txb_User";
            txb_User.Size = new Size(220, 32);
            txb_User.TabIndex = 2;
            txb_User.TextChanged += txb_User_TextChanged;
            // 
            // txb_Pass
            // 
            txb_Pass.Font = new Font("Segoe UI", 11F);
            txb_Pass.Location = new Point(170, 202);
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
            rdb_Student.Font = new Font("Segoe UI", 11F);
            rdb_Student.ForeColor = Color.White;
            rdb_Student.Location = new Point(140, 98);
            rdb_Student.Name = "rdb_Student";
            rdb_Student.Size = new Size(97, 29);
            rdb_Student.TabIndex = 0;
            rdb_Student.TabStop = true;
            rdb_Student.Text = "Student";
            // 
            // rdb_HR
            // 
            rdb_HR.AutoSize = true;
            rdb_HR.Font = new Font("Segoe UI", 11F);
            rdb_HR.ForeColor = Color.White;
            rdb_HR.Location = new Point(240, 98);
            rdb_HR.Name = "rdb_HR";
            rdb_HR.Size = new Size(57, 29);
            rdb_HR.TabIndex = 1;
            rdb_HR.Text = "HR";
            // 
            // chk_Remember
            // 
            chk_Remember.AutoSize = true;
            chk_Remember.Font = new Font("Segoe UI", 10F);
            chk_Remember.ForeColor = Color.White;
            chk_Remember.Location = new Point(65, 248);
            chk_Remember.Name = "chk_Remember";
            chk_Remember.Size = new Size(181, 27);
            chk_Remember.TabIndex = 4;
            chk_Remember.Text = "Ghi nhớ đăng nhập";
            chk_Remember.UseVisualStyleBackColor = true;
            // 
            // llbl_Register
            // 
            llbl_Register.AutoSize = true;
            llbl_Register.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            llbl_Register.LinkColor = Color.LightSkyBlue; // Màu xanh nhạt nổi bật trên nền xanh đen đêm muộn
            llbl_Register.Location = new Point(265, 249);
            llbl_Register.Name = "llbl_Register";
            llbl_Register.Size = new Size(144, 23);
            llbl_Register.TabIndex = 7;
            llbl_Register.TabStop = true;
            llbl_Register.Text = "Đăng ký tài khoản?";
            llbl_Register.LinkClicked += llbl_Register_LinkClicked; // Đính kèm sự kiện click chuyển form
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.ForestGreen;
            btn_Login.FlatAppearance.BorderSize = 0;
            btn_Login.FlatStyle = FlatStyle.Flat;
            btn_Login.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn_Login.ForeColor = Color.White;
            btn_Login.Location = new Point(80, 295);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(130, 42);
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
            btn_Cancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn_Cancel.ForeColor = Color.White;
            btn_Cancel.Location = new Point(250, 295);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(130, 42);
            btn_Cancel.TabIndex = 6;
            btn_Cancel.Text = "Hủy";
            btn_Cancel.UseVisualStyleBackColor = false;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // f_Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(460, 370); // Điều chỉnh tăng chiều cao form một chút để cân đối nút bấm
            Controls.Add(llbl_Register); // 2. Đưa LinkLabel vào Form
            Controls.Add(lbl_Title);
            Controls.Add(lbl_Role);
            Controls.Add(rdb_Student);
            Controls.Add(rdb_HR);
            Controls.Add(lbl_User);
            Controls.Add(txb_User);
            Controls.Add(lbl_Pass);
            Controls.Add(txb_Pass);
            Controls.Add(chk_Remember);
            Controls.Add(btn_Login);
            Controls.Add(btn_Cancel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "f_Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            Load += f_Login_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
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
    }
}