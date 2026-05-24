namespace ProjectMonHoc
{
    partial class f_MainStudent
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
            pnl_MainStudent_Student = new Panel();
            btn_Logout_MainStudent = new Button();
            btn_Timetable = new Button();
            btn_StudentScore = new Button();
            btn_StudentInfo = new Button();
            pic_Logo_HCMUTE_MStu = new PictureBox();
            pnl_content_MainStudent = new Panel();
            pnl_MainStudent_Student.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Logo_HCMUTE_MStu).BeginInit();
            SuspendLayout();
            // 
            // pnl_MainStudent_Student
            // 
            pnl_MainStudent_Student.BackColor = Color.RoyalBlue;
            pnl_MainStudent_Student.Controls.Add(btn_Logout_MainStudent);
            pnl_MainStudent_Student.Controls.Add(btn_Timetable);
            pnl_MainStudent_Student.Controls.Add(btn_StudentScore);
            pnl_MainStudent_Student.Controls.Add(btn_StudentInfo);
            pnl_MainStudent_Student.Controls.Add(pic_Logo_HCMUTE_MStu);
            pnl_MainStudent_Student.Dock = DockStyle.Left;
            pnl_MainStudent_Student.Location = new Point(0, 0);
            pnl_MainStudent_Student.Name = "pnl_MainStudent_Student";
            pnl_MainStudent_Student.Size = new Size(182, 626);
            pnl_MainStudent_Student.TabIndex = 0;
            // 
            // btn_Logout_MainStudent
            // 
            btn_Logout_MainStudent.BackColor = Color.RoyalBlue;
            btn_Logout_MainStudent.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_Logout_MainStudent.ForeColor = SystemColors.Window;
            btn_Logout_MainStudent.Location = new Point(0, 559);
            btn_Logout_MainStudent.Name = "btn_Logout_MainStudent";
            btn_Logout_MainStudent.Size = new Size(182, 46);
            btn_Logout_MainStudent.TabIndex = 4;
            btn_Logout_MainStudent.Text = "Đăng xuất";
            btn_Logout_MainStudent.UseVisualStyleBackColor = false;
            btn_Logout_MainStudent.Click += btn_Logout_MainStudent_Click;
            // 
            // btn_Timetable
            // 
            btn_Timetable.BackColor = Color.RoyalBlue;
            btn_Timetable.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_Timetable.ForeColor = SystemColors.Menu;
            btn_Timetable.Location = new Point(0, 215);
            btn_Timetable.Name = "btn_Timetable";
            btn_Timetable.Size = new Size(182, 46);
            btn_Timetable.TabIndex = 2;
            btn_Timetable.Text = "Thời khóa biểu ";
            btn_Timetable.UseVisualStyleBackColor = false;
            // 
            // btn_StudentScore
            // 
            btn_StudentScore.BackColor = Color.RoyalBlue;
            btn_StudentScore.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_StudentScore.ForeColor = SystemColors.Window;
            btn_StudentScore.Location = new Point(0, 267);
            btn_StudentScore.Name = "btn_StudentScore";
            btn_StudentScore.Size = new Size(182, 46);
            btn_StudentScore.TabIndex = 2;
            btn_StudentScore.Text = "Xem điểm ";
            btn_StudentScore.UseVisualStyleBackColor = false;
            btn_StudentScore.Click += btn_StudentScore_Click;
            // 
            // btn_StudentInfo
            // 
            btn_StudentInfo.BackColor = Color.RoyalBlue;
            btn_StudentInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_StudentInfo.ForeColor = SystemColors.Window;
            btn_StudentInfo.Location = new Point(0, 163);
            btn_StudentInfo.Name = "btn_StudentInfo";
            btn_StudentInfo.Size = new Size(182, 46);
            btn_StudentInfo.TabIndex = 1;
            btn_StudentInfo.Text = "Thông tin sinh viên";
            btn_StudentInfo.UseVisualStyleBackColor = false;
            btn_StudentInfo.Click += btn_StudentInfo_Click;
            // 
            // pic_Logo_HCMUTE_MStu
            // 
            pic_Logo_HCMUTE_MStu.BackgroundImage = Properties.Resources.logo_HCMUTE_MainMenu;
            pic_Logo_HCMUTE_MStu.Location = new Point(-34, 0);
            pic_Logo_HCMUTE_MStu.Name = "pic_Logo_HCMUTE_MStu";
            pic_Logo_HCMUTE_MStu.Size = new Size(216, 148);
            pic_Logo_HCMUTE_MStu.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Logo_HCMUTE_MStu.TabIndex = 0;
            pic_Logo_HCMUTE_MStu.TabStop = false;
            // 
            // pnl_content_MainStudent
            // 
            pnl_content_MainStudent.Dock = DockStyle.Fill;
            pnl_content_MainStudent.Location = new Point(182, 0);
            pnl_content_MainStudent.Name = "pnl_content_MainStudent";
            pnl_content_MainStudent.Size = new Size(1062, 626);
            pnl_content_MainStudent.TabIndex = 1;
            // 
            // f_MainStudent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1244, 626);
            Controls.Add(pnl_content_MainStudent);
            Controls.Add(pnl_MainStudent_Student);
            Name = "f_MainStudent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Student";
            pnl_MainStudent_Student.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_Logo_HCMUTE_MStu).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private Panel pnl_MainStudent_Student;
        private PictureBox pic_Logo_HCMUTE_MStu;
        private Button btn_Timetable;
        private Button btn_StudentScore;
        private Button btn_StudentInfo;
        private Button btn_Logout_MainStudent;
        private Panel pnl_content_MainStudent;
    }
}