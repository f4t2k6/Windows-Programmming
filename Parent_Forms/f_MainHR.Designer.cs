namespace ProjectMonHoc
{
    partial class f_MainHR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_MainHR));
            pnl_Side_HR = new Panel();
            button_Classroom = new Button();
            button_Chart = new Button();
            pb_Logo_HR = new PictureBox();
            btn_ManageCourse = new Button();
            btn_ListStudent = new Button();
            btn_Logout_HR = new Button();
            btn_ListScore = new Button();
            pnl_content_MainHR = new Panel();
            pnl_Side_HR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Logo_HR).BeginInit();
            SuspendLayout();
            // 
            // pnl_Side_HR
            // 
            pnl_Side_HR.BackColor = Color.RoyalBlue;
            pnl_Side_HR.Controls.Add(button_Classroom);
            pnl_Side_HR.Controls.Add(button_Chart);
            pnl_Side_HR.Controls.Add(pb_Logo_HR);
            pnl_Side_HR.Controls.Add(btn_ManageCourse);
            pnl_Side_HR.Controls.Add(btn_ListStudent);
            pnl_Side_HR.Controls.Add(btn_Logout_HR);
            pnl_Side_HR.Controls.Add(btn_ListScore);
            pnl_Side_HR.Location = new Point(0, 0);
            pnl_Side_HR.Name = "pnl_Side_HR";
            pnl_Side_HR.Size = new Size(220, 720);
            pnl_Side_HR.TabIndex = 1;
            pnl_Side_HR.Paint += pnl_MainHR_Paint;
            // 
            // button_Classroom
            // 
            button_Classroom.BackColor = Color.RoyalBlue;
            button_Classroom.FlatAppearance.BorderSize = 0;
            button_Classroom.FlatStyle = FlatStyle.Flat;
            button_Classroom.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Classroom.ForeColor = SystemColors.Menu;
            button_Classroom.Location = new Point(6, 376);
            button_Classroom.Name = "button_Classroom";
            button_Classroom.Size = new Size(200, 50);
            button_Classroom.TabIndex = 9;
            button_Classroom.Text = "🏫 Quản lý lớp học";
            button_Classroom.TextAlign = ContentAlignment.MiddleLeft;
            button_Classroom.UseVisualStyleBackColor = false;
            button_Classroom.Click += button2_Click;
            // 
            // button_Chart
            // 
            button_Chart.BackColor = Color.RoyalBlue;
            button_Chart.FlatAppearance.BorderSize = 0;
            button_Chart.FlatStyle = FlatStyle.Flat;
            button_Chart.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Chart.ForeColor = SystemColors.Menu;
            button_Chart.Location = new Point(6, 320);
            button_Chart.Name = "button_Chart";
            button_Chart.Size = new Size(200, 50);
            button_Chart.TabIndex = 8;
            button_Chart.Text = "📈 Thống kê sinh viên";
            button_Chart.TextAlign = ContentAlignment.MiddleLeft;
            button_Chart.UseVisualStyleBackColor = false;
            button_Chart.Click += this.button1_Click;
            // 
            // pb_Logo_HR
            // 
            pb_Logo_HR.Image = (Image)resources.GetObject("pb_Logo_HR.Image");
            pb_Logo_HR.Location = new Point(21, 12);
            pb_Logo_HR.Name = "pb_Logo_HR";
            pb_Logo_HR.Size = new Size(173, 134);
            pb_Logo_HR.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Logo_HR.TabIndex = 6;
            pb_Logo_HR.TabStop = false;
            pb_Logo_HR.Click += pb_Logo_HR_Click;
            // 
            // btn_ManageCourse
            // 
            btn_ManageCourse.BackColor = Color.RoyalBlue;
            btn_ManageCourse.FlatAppearance.BorderSize = 0;
            btn_ManageCourse.FlatStyle = FlatStyle.Flat;
            btn_ManageCourse.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_ManageCourse.ForeColor = SystemColors.Menu;
            btn_ManageCourse.Location = new Point(6, 264);
            btn_ManageCourse.Name = "btn_ManageCourse";
            btn_ManageCourse.Size = new Size(195, 50);
            btn_ManageCourse.TabIndex = 5;
            btn_ManageCourse.Text = "🗂️ Quản lý môn học";
            btn_ManageCourse.TextAlign = ContentAlignment.MiddleLeft;
            btn_ManageCourse.UseVisualStyleBackColor = false;
            btn_ManageCourse.Click += btn_ManageCourse_Click;
            // 
            // btn_ListStudent
            // 
            btn_ListStudent.BackColor = Color.RoyalBlue;
            btn_ListStudent.FlatAppearance.BorderSize = 0;
            btn_ListStudent.FlatStyle = FlatStyle.Flat;
            btn_ListStudent.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_ListStudent.ForeColor = SystemColors.Menu;
            btn_ListStudent.Location = new Point(6, 152);
            btn_ListStudent.Name = "btn_ListStudent";
            btn_ListStudent.Size = new Size(211, 50);
            btn_ListStudent.TabIndex = 4;
            btn_ListStudent.Text = "👨‍🎓Danh sách sinh viên";
            btn_ListStudent.TextAlign = ContentAlignment.MiddleLeft;
            btn_ListStudent.UseVisualStyleBackColor = false;
            btn_ListStudent.Click += btn_ListStudent_Click;
            // 
            // btn_Logout_HR
            // 
            btn_Logout_HR.BackColor = Color.RoyalBlue;
            btn_Logout_HR.FlatAppearance.BorderSize = 0;
            btn_Logout_HR.FlatStyle = FlatStyle.Flat;
            btn_Logout_HR.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Logout_HR.ForeColor = SystemColors.Window;
            btn_Logout_HR.Location = new Point(6, 611);
            btn_Logout_HR.Name = "btn_Logout_HR";
            btn_Logout_HR.Size = new Size(195, 50);
            btn_Logout_HR.TabIndex = 3;
            btn_Logout_HR.Text = "🚪 Đăng xuất";
            btn_Logout_HR.TextAlign = ContentAlignment.MiddleLeft;
            btn_Logout_HR.UseVisualStyleBackColor = false;
            btn_Logout_HR.Click += btn_Logout_MainHR_Click;
            // 
            // btn_ListScore
            // 
            btn_ListScore.BackColor = Color.RoyalBlue;
            btn_ListScore.FlatAppearance.BorderSize = 0;
            btn_ListScore.FlatStyle = FlatStyle.Flat;
            btn_ListScore.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_ListScore.ForeColor = SystemColors.Window;
            btn_ListScore.Location = new Point(6, 208);
            btn_ListScore.Name = "btn_ListScore";
            btn_ListScore.Size = new Size(195, 50);
            btn_ListScore.TabIndex = 2;
            btn_ListScore.Text = "📊 Điểm sinh viên";
            btn_ListScore.TextAlign = ContentAlignment.MiddleLeft;
            btn_ListScore.UseVisualStyleBackColor = false;
            btn_ListScore.Click += btn_FixStudentScore_Click;
            // 
            // pnl_content_MainHR
            // 
            pnl_content_MainHR.Location = new Point(220, 0);
            pnl_content_MainHR.Name = "pnl_content_MainHR";
            pnl_content_MainHR.Size = new Size(1045, 675);
            pnl_content_MainHR.TabIndex = 2;
            pnl_content_MainHR.Paint += pnl_content_MainHR_Paint;
            // 
            // f_MainHR
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            Controls.Add(pnl_content_MainHR);
            Controls.Add(pnl_Side_HR);
            Name = "f_MainHR";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "f_MainHR";
            pnl_Side_HR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_Logo_HR).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnl_Side_HR;
        private Button btn_ListScore;
        private Button btn_Logout_HR;
        private Panel pnl_content_MainHR;
        private Button btn_ListStudent;
        private Button btn_ManageCourse;
        private PictureBox pb_Logo_HR;
        private Button button_Chart;
        private Button button_Classroom;
    }
}