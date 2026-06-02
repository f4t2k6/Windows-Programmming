namespace ProjectMonHoc
{
    partial class f_MainStudent
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_MainStudent));
            pnl_Side_Student = new Panel();
            btn_PrintRequest = new Button();
            btn_RegisterCourse = new Button();
            panel1 = new Panel();
            pb_main_student = new PictureBox();
            btn_Logout_Student = new Button();
            btn_Timetable = new Button();
            btn_ListScore = new Button();
            btn_Student_Info = new Button();
            pnl_Content_Student = new Panel();
            pnl_Side_Student.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_main_student).BeginInit();
            SuspendLayout();
            // 
            // pnl_Side_Student
            // 
            pnl_Side_Student.BackColor = Color.SteelBlue;
            pnl_Side_Student.Controls.Add(btn_PrintRequest);
            pnl_Side_Student.Controls.Add(btn_RegisterCourse);
            pnl_Side_Student.Controls.Add(panel1);
            pnl_Side_Student.Controls.Add(pb_main_student);
            pnl_Side_Student.Controls.Add(btn_Logout_Student);
            pnl_Side_Student.Controls.Add(btn_Timetable);
            pnl_Side_Student.Controls.Add(btn_ListScore);
            pnl_Side_Student.Controls.Add(btn_Student_Info);
            pnl_Side_Student.Location = new Point(0, 0);
            pnl_Side_Student.Name = "pnl_Side_Student";
            pnl_Side_Student.Size = new Size(220, 720);
            pnl_Side_Student.TabIndex = 0;
            pnl_Side_Student.Paint += pnl_Side_Student_Paint;
            // 
            // btn_PrintRequest
            // 
            btn_PrintRequest.BackColor = Color.SteelBlue;
            btn_PrintRequest.FlatAppearance.BorderSize = 0;
            btn_PrintRequest.FlatStyle = FlatStyle.Flat;
            btn_PrintRequest.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btn_PrintRequest.ForeColor = SystemColors.Window;
            btn_PrintRequest.Location = new Point(12, 376);
            btn_PrintRequest.Name = "btn_PrintRequest";
            btn_PrintRequest.Size = new Size(208, 45);
            btn_PrintRequest.TabIndex = 7;
            btn_PrintRequest.Text = "🖨️ In giấy Xác nhận";
            btn_PrintRequest.TextAlign = ContentAlignment.MiddleLeft;
            btn_PrintRequest.UseVisualStyleBackColor = false;
            btn_PrintRequest.Click += btn_PrintRequest_Click;
            // 
            // btn_RegisterCourse
            // 
            btn_RegisterCourse.BackColor = Color.SteelBlue;
            btn_RegisterCourse.FlatAppearance.BorderSize = 0;
            btn_RegisterCourse.FlatStyle = FlatStyle.Flat;
            btn_RegisterCourse.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btn_RegisterCourse.ForeColor = SystemColors.Window;
            btn_RegisterCourse.Location = new Point(12, 320);
            btn_RegisterCourse.Name = "btn_RegisterCourse";
            btn_RegisterCourse.Size = new Size(195, 50);
            btn_RegisterCourse.TabIndex = 6;
            btn_RegisterCourse.Text = "📝 Đăng kí môn học";
            btn_RegisterCourse.TextAlign = ContentAlignment.MiddleLeft;
            btn_RegisterCourse.UseVisualStyleBackColor = false;
            btn_RegisterCourse.Click += btn_RegisterCourse_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(220, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1000, 720);
            panel1.TabIndex = 1;
            // 
            // pb_main_student
            // 
            pb_main_student.Image = (Image)resources.GetObject("pb_main_student.Image");
            pb_main_student.Location = new Point(21, 12);
            pb_main_student.Name = "pb_main_student";
            pb_main_student.Size = new Size(173, 134);
            pb_main_student.SizeMode = PictureBoxSizeMode.Zoom;
            pb_main_student.TabIndex = 5;
            pb_main_student.TabStop = false;
            pb_main_student.Click += pb_main_student_Click;
            // 
            // btn_Logout_Student
            // 
            btn_Logout_Student.BackColor = Color.SteelBlue;
            btn_Logout_Student.FlatAppearance.BorderSize = 0;
            btn_Logout_Student.FlatStyle = FlatStyle.Flat;
            btn_Logout_Student.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btn_Logout_Student.ForeColor = Color.White;
            btn_Logout_Student.Location = new Point(12, 615);
            btn_Logout_Student.Name = "btn_Logout_Student";
            btn_Logout_Student.Size = new Size(182, 46);
            btn_Logout_Student.TabIndex = 4;
            btn_Logout_Student.Text = "🚪 Đăng xuất";
            btn_Logout_Student.TextAlign = ContentAlignment.MiddleLeft;
            btn_Logout_Student.UseVisualStyleBackColor = false;
            btn_Logout_Student.Click += btn_Logout_Student_Click;
            // 
            // btn_Timetable
            // 
            btn_Timetable.BackColor = Color.SteelBlue;
            btn_Timetable.FlatAppearance.BorderSize = 0;
            btn_Timetable.FlatStyle = FlatStyle.Flat;
            btn_Timetable.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btn_Timetable.ForeColor = SystemColors.Menu;
            btn_Timetable.Location = new Point(12, 208);
            btn_Timetable.Name = "btn_Timetable";
            btn_Timetable.Size = new Size(195, 50);
            btn_Timetable.TabIndex = 2;
            btn_Timetable.Text = "📅 Thời khóa biểu";
            btn_Timetable.TextAlign = ContentAlignment.MiddleLeft;
            btn_Timetable.UseVisualStyleBackColor = false;
            btn_Timetable.Click += btn_Timetable_Click;
            // 
            // btn_ListScore
            // 
            btn_ListScore.BackColor = Color.SteelBlue;
            btn_ListScore.FlatAppearance.BorderSize = 0;
            btn_ListScore.FlatStyle = FlatStyle.Flat;
            btn_ListScore.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btn_ListScore.ForeColor = SystemColors.Window;
            btn_ListScore.Location = new Point(12, 264);
            btn_ListScore.Name = "btn_ListScore";
            btn_ListScore.Size = new Size(195, 50);
            btn_ListScore.TabIndex = 2;
            btn_ListScore.Text = "📊 Xem điểm";
            btn_ListScore.TextAlign = ContentAlignment.MiddleLeft;
            btn_ListScore.UseVisualStyleBackColor = false;
            btn_ListScore.Click += btn_Student_Score_Click;
            // 
            // btn_Student_Info
            // 
            btn_Student_Info.BackColor = Color.SteelBlue;
            btn_Student_Info.FlatAppearance.BorderSize = 0;
            btn_Student_Info.FlatStyle = FlatStyle.Flat;
            btn_Student_Info.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btn_Student_Info.ForeColor = Color.White;
            btn_Student_Info.Location = new Point(12, 152);
            btn_Student_Info.Name = "btn_Student_Info";
            btn_Student_Info.Size = new Size(195, 50);
            btn_Student_Info.TabIndex = 1;
            btn_Student_Info.Text = "👤 Thông tin cá nhân";
            btn_Student_Info.TextAlign = ContentAlignment.MiddleLeft;
            btn_Student_Info.UseVisualStyleBackColor = false;
            btn_Student_Info.Click += btn_Student_Info_Click;
            // 
            // pnl_Content_Student
            // 
            pnl_Content_Student.Location = new Point(220, 0);
            pnl_Content_Student.Name = "pnl_Content_Student";
            pnl_Content_Student.Size = new Size(1045, 675);
            pnl_Content_Student.TabIndex = 1;
            pnl_Content_Student.Paint += pnl_content_Student_Paint;
            // 
            // f_MainStudent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1262, 673);
            Controls.Add(pnl_Content_Student);
            Controls.Add(pnl_Side_Student);
            Name = "f_MainStudent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "f_MainStudent";
            Load += f_MainStudent_Load;
            pnl_Side_Student.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_main_student).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnl_Side_Student;
        private System.Windows.Forms.Button btn_Timetable;
        private System.Windows.Forms.Button btn_ListScore;
        private System.Windows.Forms.Button btn_Student_Info;
        private System.Windows.Forms.Button btn_Logout_Student;
        private System.Windows.Forms.PictureBox pb_main_student;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_Content_Student;
        private System.Windows.Forms.Button btn_RegisterCourse;
        private System.Windows.Forms.Button btn_PrintRequest;    // ← MỚI
    }
}