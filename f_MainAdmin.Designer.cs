namespace ProjectMonHoc
{
    partial class f_MainAdmin
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
            pnl_MainAdmin = new Panel();
            btn_Logout_MainAdmin = new Button();
            btn_ListStudent_MainAdmin = new Button();
            btn_StudentScore_MainAdmin = new Button();
            btn_AddStudent_MainAdmin = new Button();
            btn_letter_MainAdmin = new Button();
            pic_Logo_HCMUTE_MainAdmin = new PictureBox();
            flp_requests_MainAdmin = new FlowLayoutPanel();
            pnl_content_MainAdmin = new Panel();
            pnl_MainAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Logo_HCMUTE_MainAdmin).BeginInit();
            SuspendLayout();
            // 
            // pnl_MainAdmin
            // 
            pnl_MainAdmin.BackColor = Color.RoyalBlue;
            pnl_MainAdmin.Controls.Add(btn_Logout_MainAdmin);
            pnl_MainAdmin.Controls.Add(btn_ListStudent_MainAdmin);
            pnl_MainAdmin.Controls.Add(btn_StudentScore_MainAdmin);
            pnl_MainAdmin.Controls.Add(btn_AddStudent_MainAdmin);
            pnl_MainAdmin.Controls.Add(btn_letter_MainAdmin);
            pnl_MainAdmin.Controls.Add(pic_Logo_HCMUTE_MainAdmin);
            pnl_MainAdmin.Dock = DockStyle.Left;
            pnl_MainAdmin.Location = new Point(0, 0);
            pnl_MainAdmin.Name = "pnl_MainAdmin";
            pnl_MainAdmin.Size = new Size(182, 626);
            pnl_MainAdmin.TabIndex = 2;
            // 
            // btn_Logout_MainAdmin
            // 
            btn_Logout_MainAdmin.BackColor = Color.RoyalBlue;
            btn_Logout_MainAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_Logout_MainAdmin.ForeColor = SystemColors.Window;
            btn_Logout_MainAdmin.Location = new Point(0, 553);
            btn_Logout_MainAdmin.Name = "btn_Logout_MainAdmin";
            btn_Logout_MainAdmin.Size = new Size(182, 46);
            btn_Logout_MainAdmin.TabIndex = 4;
            btn_Logout_MainAdmin.Text = "Đăng xuất";
            btn_Logout_MainAdmin.UseVisualStyleBackColor = false;
            btn_Logout_MainAdmin.Click += btn_Logout_MainAdmin_Click;
            // 
            // btn_ListStudent_MainAdmin
            // 
            btn_ListStudent_MainAdmin.BackColor = Color.RoyalBlue;
            btn_ListStudent_MainAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_ListStudent_MainAdmin.ForeColor = SystemColors.Menu;
            btn_ListStudent_MainAdmin.Location = new Point(0, 319);
            btn_ListStudent_MainAdmin.Name = "btn_ListStudent_MainAdmin";
            btn_ListStudent_MainAdmin.Size = new Size(182, 56);
            btn_ListStudent_MainAdmin.TabIndex = 6;
            btn_ListStudent_MainAdmin.Text = "Danh sách sinh viên";
            btn_ListStudent_MainAdmin.UseVisualStyleBackColor = false;
            btn_ListStudent_MainAdmin.Click += btn_ListStudent_MainAdmin_Click;
            // 
            // btn_StudentScore_MainAdmin
            // 
            btn_StudentScore_MainAdmin.BackColor = Color.RoyalBlue;
            btn_StudentScore_MainAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_StudentScore_MainAdmin.ForeColor = SystemColors.Window;
            btn_StudentScore_MainAdmin.Location = new Point(0, 267);
            btn_StudentScore_MainAdmin.Name = "btn_StudentScore_MainAdmin";
            btn_StudentScore_MainAdmin.Size = new Size(182, 46);
            btn_StudentScore_MainAdmin.TabIndex = 5;
            btn_StudentScore_MainAdmin.Text = "Điểm sinh viên";
            btn_StudentScore_MainAdmin.UseVisualStyleBackColor = false;
            btn_StudentScore_MainAdmin.Click += btn_StudentScore_MainAdmin_Click;
            // 
            // btn_AddStudent_MainAdmin
            // 
            btn_AddStudent_MainAdmin.BackColor = Color.RoyalBlue;
            btn_AddStudent_MainAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_AddStudent_MainAdmin.ForeColor = SystemColors.Menu;
            btn_AddStudent_MainAdmin.Location = new Point(0, 215);
            btn_AddStudent_MainAdmin.Name = "btn_AddStudent_MainAdmin";
            btn_AddStudent_MainAdmin.Size = new Size(182, 46);
            btn_AddStudent_MainAdmin.TabIndex = 4;
            btn_AddStudent_MainAdmin.Text = "Thêm sinh viên";
            btn_AddStudent_MainAdmin.UseVisualStyleBackColor = false;
            btn_AddStudent_MainAdmin.Click += btn_AddStudent_MainAdmin_Click;
            // 
            // btn_letter_MainAdmin
            // 
            btn_letter_MainAdmin.BackColor = Color.RoyalBlue;
            btn_letter_MainAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_letter_MainAdmin.ForeColor = SystemColors.Window;
            btn_letter_MainAdmin.Location = new Point(0, 163);
            btn_letter_MainAdmin.Name = "btn_letter_MainAdmin";
            btn_letter_MainAdmin.Size = new Size(182, 46);
            btn_letter_MainAdmin.TabIndex = 1;
            btn_letter_MainAdmin.Text = "Hộp thư";
            btn_letter_MainAdmin.UseVisualStyleBackColor = false;
            btn_letter_MainAdmin.Click += btn_letter_MainAdmin_Click;
            // 
            // pic_Logo_HCMUTE_MainAdmin
            // 
            pic_Logo_HCMUTE_MainAdmin.BackgroundImage = Properties.Resources.logo_HCMUTE_MainMenu;
            pic_Logo_HCMUTE_MainAdmin.Location = new Point(-34, 0);
            pic_Logo_HCMUTE_MainAdmin.Name = "pic_Logo_HCMUTE_MainAdmin";
            pic_Logo_HCMUTE_MainAdmin.Size = new Size(216, 148);
            pic_Logo_HCMUTE_MainAdmin.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Logo_HCMUTE_MainAdmin.TabIndex = 0;
            pic_Logo_HCMUTE_MainAdmin.TabStop = false;
            // 
            // flp_requests_MainAdmin
            // 
            flp_requests_MainAdmin.AutoScroll = true;
            flp_requests_MainAdmin.Location = new Point(195, 12);
            flp_requests_MainAdmin.Name = "flp_requests_MainAdmin";
            flp_requests_MainAdmin.Size = new Size(1037, 602);
            flp_requests_MainAdmin.TabIndex = 3;
            // 
            // pnl_content_MainAdmin
            // 
            pnl_content_MainAdmin.Dock = DockStyle.Fill;
            pnl_content_MainAdmin.Location = new Point(182, 0);
            pnl_content_MainAdmin.Name = "pnl_content_MainAdmin";
            pnl_content_MainAdmin.Size = new Size(1062, 626);
            pnl_content_MainAdmin.TabIndex = 4;
            pnl_content_MainAdmin.Visible = false;
            // 
            // f_MainAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1244, 626);
            Controls.Add(flp_requests_MainAdmin);
            Controls.Add(pnl_content_MainAdmin);
            Controls.Add(pnl_MainAdmin);
            Name = "f_MainAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Admin";
            pnl_MainAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_Logo_HCMUTE_MainAdmin).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private Panel pnl_MainAdmin;
        private Button btn_letter_MainAdmin;
        private PictureBox pic_Logo_HCMUTE_MainAdmin;
        private FlowLayoutPanel flp_requests_MainAdmin;
        private Button btn_Logout_MainAdmin;
        private Button btn_ListStudent_MainAdmin;
        private Button btn_StudentScore_MainAdmin;
        private Button btn_AddStudent_MainAdmin;
        private Panel pnl_content_MainAdmin;
    }
}