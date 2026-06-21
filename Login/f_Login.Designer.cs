using System.Windows.Forms;

namespace ProjectMonHoc
{
    partial class f_Login
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
            components = new System.ComponentModel.Container();
            picturebox_Background = new PictureBox();
            panel_Login = new Panel();
            llbl_QuenMK = new LinkLabel();
            button_Thoat = new Button();
            llbl_Dangky = new LinkLabel();
            label_Line = new Label();
            checkBox_Ghinhodangnhap = new CheckBox();
            radioButton_Sinhvien = new RadioButton();
            radioButton_HR = new RadioButton();
            button_Dangnhap = new Button();
            textBox_Matkhau = new TextBox();
            ptb_ShowPass = new PictureBox();
            textBox_Taikhoan = new TextBox();
            label_Matkhau = new Label();
            label_Tendangnhap = new Label();
            label_Dangnhap = new Label();
            errorProvider_Baoloi = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)picturebox_Background).BeginInit();
            panel_Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptb_ShowPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider_Baoloi).BeginInit();
            SuspendLayout();
            // 
            // picturebox_Background
            // 
            picturebox_Background.Image = Properties.Resources.f_Login_BackGround;
            picturebox_Background.Location = new Point(0, 0);
            picturebox_Background.Margin = new Padding(4);
            picturebox_Background.Name = "picturebox_Background";
            picturebox_Background.Size = new Size(1922, 1081);
            picturebox_Background.SizeMode = PictureBoxSizeMode.Zoom;
            picturebox_Background.TabIndex = 0;
            picturebox_Background.TabStop = false;
            picturebox_Background.Click += picturebox_Background_Click;
            // 
            // panel_Login
            // 
            panel_Login.BackColor = Color.White;
            panel_Login.BorderStyle = BorderStyle.FixedSingle;
            panel_Login.Controls.Add(llbl_QuenMK);
            panel_Login.Controls.Add(button_Thoat);
            panel_Login.Controls.Add(llbl_Dangky);
            panel_Login.Controls.Add(label_Line);
            panel_Login.Controls.Add(checkBox_Ghinhodangnhap);
            panel_Login.Controls.Add(radioButton_Sinhvien);
            panel_Login.Controls.Add(radioButton_HR);
            panel_Login.Controls.Add(button_Dangnhap);
            panel_Login.Controls.Add(textBox_Matkhau);
            panel_Login.Controls.Add(ptb_ShowPass);
            panel_Login.Controls.Add(textBox_Taikhoan);
            panel_Login.Controls.Add(label_Matkhau);
            panel_Login.Controls.Add(label_Tendangnhap);
            panel_Login.Controls.Add(label_Dangnhap);
            panel_Login.Location = new Point(712, 255);
            panel_Login.Margin = new Padding(4);
            panel_Login.Name = "panel_Login";
            panel_Login.Size = new Size(500, 643);
            panel_Login.TabIndex = 1;
            panel_Login.Paint += panel_Login_Paint;
            // 
            // llbl_QuenMK
            // 
            llbl_QuenMK.AutoSize = true;
            llbl_QuenMK.BackColor = Color.Transparent;
            llbl_QuenMK.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            llbl_QuenMK.ForeColor = SystemColors.ControlLight;
            llbl_QuenMK.LinkBehavior = LinkBehavior.NeverUnderline;
            llbl_QuenMK.LinkColor = Color.DimGray;
            llbl_QuenMK.Location = new Point(319, 479);
            llbl_QuenMK.Margin = new Padding(4, 0, 4, 0);
            llbl_QuenMK.Name = "llbl_QuenMK";
            llbl_QuenMK.Size = new Size(154, 28);
            llbl_QuenMK.TabIndex = 10;
            llbl_QuenMK.TabStop = true;
            llbl_QuenMK.Text = "Quên mật khẩu?";
            llbl_QuenMK.LinkClicked += llbl_QuenMK_LinkClicked;
            // 
            // button_Thoat
            // 
            button_Thoat.BackColor = Color.IndianRed;
            button_Thoat.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Thoat.ForeColor = Color.White;
            button_Thoat.Location = new Point(21, 542);
            button_Thoat.Margin = new Padding(4);
            button_Thoat.Name = "button_Thoat";
            button_Thoat.Size = new Size(452, 68);
            button_Thoat.TabIndex = 9;
            button_Thoat.Text = "Thoát";
            button_Thoat.UseVisualStyleBackColor = false;
            button_Thoat.Click += button_Thoat_Click;
            // 
            // llbl_Dangky
            // 
            llbl_Dangky.AutoSize = true;
            llbl_Dangky.BackColor = Color.White;
            llbl_Dangky.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            llbl_Dangky.ForeColor = SystemColors.ActiveBorder;
            llbl_Dangky.LinkBehavior = LinkBehavior.NeverUnderline;
            llbl_Dangky.LinkColor = Color.DimGray;
            llbl_Dangky.Location = new Point(20, 479);
            llbl_Dangky.Margin = new Padding(4, 0, 4, 0);
            llbl_Dangky.Name = "llbl_Dangky";
            llbl_Dangky.Size = new Size(179, 28);
            llbl_Dangky.TabIndex = 9;
            llbl_Dangky.TabStop = true;
            llbl_Dangky.Text = "Đăng ký tài khoản?";
            llbl_Dangky.LinkClicked += llbl_Dangky_LinkClicked;
            // 
            // label_Line
            // 
            label_Line.BackColor = Color.DimGray;
            label_Line.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Line.ForeColor = Color.DimGray;
            label_Line.Location = new Point(21, 450);
            label_Line.Margin = new Padding(4, 0, 4, 0);
            label_Line.Name = "label_Line";
            label_Line.Size = new Size(452, 1);
            label_Line.TabIndex = 8;
            // 
            // checkBox_Ghinhodangnhap
            // 
            checkBox_Ghinhodangnhap.AutoSize = true;
            checkBox_Ghinhodangnhap.BackColor = Color.White;
            checkBox_Ghinhodangnhap.Font = new Font("Segoe UI", 9.75F);
            checkBox_Ghinhodangnhap.ForeColor = SystemColors.GrayText;
            checkBox_Ghinhodangnhap.Location = new Point(24, 324);
            checkBox_Ghinhodangnhap.Margin = new Padding(4, 2, 4, 2);
            checkBox_Ghinhodangnhap.Name = "checkBox_Ghinhodangnhap";
            checkBox_Ghinhodangnhap.Size = new Size(181, 27);
            checkBox_Ghinhodangnhap.TabIndex = 7;
            checkBox_Ghinhodangnhap.Text = "Ghi nhớ đăng nhập";
            checkBox_Ghinhodangnhap.UseVisualStyleBackColor = false;
            checkBox_Ghinhodangnhap.CheckedChanged += checkBox_Ghinhodangnhap_CheckedChanged;
            // 
            // radioButton_Sinhvien
            // 
            radioButton_Sinhvien.AutoSize = true;
            radioButton_Sinhvien.Checked = true;
            radioButton_Sinhvien.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButton_Sinhvien.ForeColor = Color.Black;
            radioButton_Sinhvien.Location = new Point(21, 95);
            radioButton_Sinhvien.Margin = new Padding(4, 2, 4, 2);
            radioButton_Sinhvien.Name = "radioButton_Sinhvien";
            radioButton_Sinhvien.Size = new Size(139, 36);
            radioButton_Sinhvien.TabIndex = 2;
            radioButton_Sinhvien.TabStop = true;
            radioButton_Sinhvien.Text = "Sinh viên";
            radioButton_Sinhvien.CheckedChanged += radioButton_Sinhvien_CheckedChanged;
            // 
            // radioButton_HR
            // 
            radioButton_HR.AutoSize = true;
            radioButton_HR.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButton_HR.ForeColor = Color.Black;
            radioButton_HR.Location = new Point(396, 95);
            radioButton_HR.Margin = new Padding(4, 2, 4, 2);
            radioButton_HR.Name = "radioButton_HR";
            radioButton_HR.Size = new Size(69, 36);
            radioButton_HR.TabIndex = 3;
            radioButton_HR.Text = "HR";
            radioButton_HR.CheckedChanged += radioButton_HR_CheckedChanged;
            // 
            // button_Dangnhap
            // 
            button_Dangnhap.BackColor = Color.SteelBlue;
            button_Dangnhap.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Dangnhap.ForeColor = Color.White;
            button_Dangnhap.Location = new Point(21, 366);
            button_Dangnhap.Margin = new Padding(4);
            button_Dangnhap.Name = "button_Dangnhap";
            button_Dangnhap.Size = new Size(452, 68);
            button_Dangnhap.TabIndex = 6;
            button_Dangnhap.Text = "Đăng nhập";
            button_Dangnhap.UseVisualStyleBackColor = false;
            button_Dangnhap.Click += button_Dangnhap_Click;
            // 
            // textBox_Matkhau
            // 
            textBox_Matkhau.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_Matkhau.Location = new Point(21, 278);
            textBox_Matkhau.Margin = new Padding(4);
            textBox_Matkhau.Name = "textBox_Matkhau";
            textBox_Matkhau.PasswordChar = '●';
            textBox_Matkhau.Size = new Size(402, 34);
            textBox_Matkhau.TabIndex = 5;
            textBox_Matkhau.TextChanged += textBox_Matkhau_TextChanged;
            // 
            // ptb_ShowPass
            // 
            ptb_ShowPass.Cursor = Cursors.Hand;
            ptb_ShowPass.Location = new Point(431, 278);
            ptb_ShowPass.Margin = new Padding(4);
            ptb_ShowPass.Name = "ptb_ShowPass";
            ptb_ShowPass.Size = new Size(34, 34);
            ptb_ShowPass.SizeMode = PictureBoxSizeMode.Zoom;
            ptb_ShowPass.TabIndex = 11;
            ptb_ShowPass.TabStop = false;
            ptb_ShowPass.Click += ptb_ShowPass_Click;
            // 
            // textBox_Taikhoan
            // 
            textBox_Taikhoan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_Taikhoan.Location = new Point(21, 180);
            textBox_Taikhoan.Margin = new Padding(4);
            textBox_Taikhoan.Name = "textBox_Taikhoan";
            textBox_Taikhoan.Size = new Size(444, 34);
            textBox_Taikhoan.TabIndex = 4;
            textBox_Taikhoan.TextChanged += textBox_Taikhoan_TextChanged;
            // 
            // label_Matkhau
            // 
            label_Matkhau.AutoSize = true;
            label_Matkhau.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Matkhau.ForeColor = Color.DimGray;
            label_Matkhau.Location = new Point(21, 252);
            label_Matkhau.Margin = new Padding(4, 0, 4, 0);
            label_Matkhau.Name = "label_Matkhau";
            label_Matkhau.Size = new Size(82, 23);
            label_Matkhau.TabIndex = 2;
            label_Matkhau.Text = "Mật khẩu";
            label_Matkhau.Click += label_Matkhau_Click;
            // 
            // label_Tendangnhap
            // 
            label_Tendangnhap.AutoSize = true;
            label_Tendangnhap.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Tendangnhap.ForeColor = Color.DimGray;
            label_Tendangnhap.Location = new Point(21, 155);
            label_Tendangnhap.Margin = new Padding(4, 0, 4, 0);
            label_Tendangnhap.Name = "label_Tendangnhap";
            label_Tendangnhap.Size = new Size(124, 23);
            label_Tendangnhap.TabIndex = 1;
            label_Tendangnhap.Text = "Tên đăng nhập";
            label_Tendangnhap.Click += label_Tendangnhap_Click;
            // 
            // label_Dangnhap
            // 
            label_Dangnhap.AutoSize = true;
            label_Dangnhap.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Dangnhap.ForeColor = Color.SteelBlue;
            label_Dangnhap.Location = new Point(21, 20);
            label_Dangnhap.Margin = new Padding(4, 0, 4, 0);
            label_Dangnhap.Name = "label_Dangnhap";
            label_Dangnhap.Size = new Size(268, 54);
            label_Dangnhap.TabIndex = 0;
            label_Dangnhap.Text = "ĐĂNG NHẬP";
            label_Dangnhap.Click += label_Dangnhap_Click;
            // 
            // errorProvider_Baoloi
            // 
            errorProvider_Baoloi.ContainerControl = this;
            // 
            // f_Login
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1902, 1032);
            Controls.Add(panel_Login);
            Controls.Add(picturebox_Background);
            Margin = new Padding(4);
            Name = "f_Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UTEID";
            WindowState = FormWindowState.Maximized;
            Load += f_Login_Load;
            ((System.ComponentModel.ISupportInitialize)picturebox_Background).EndInit();
            panel_Login.ResumeLayout(false);
            panel_Login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptb_ShowPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider_Baoloi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picturebox_Background;
        private Panel panel_Login;
        private Label label_Tendangnhap;
        private Label label_Dangnhap;
        private Label label_Matkhau;
        private TextBox textBox_Matkhau;
        private PictureBox ptb_ShowPass;
        private TextBox textBox_Taikhoan;
        private RadioButton radioButton_Sinhvien;
        private RadioButton radioButton_HR;
        private Button button_Dangnhap;
        private CheckBox checkBox_Ghinhodangnhap;
        private Label label_Line;
        private Button button_Thoat;
        private LinkLabel llbl_QuenMK;
        private LinkLabel llbl_Dangky;
        private ErrorProvider errorProvider_Baoloi;
    }
}