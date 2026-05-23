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
            pnl_MainHR = new Panel();
            btn_Logout_MainHR = new Button();
            btn_AddStudent = new Button();
            btn_FixStudentScore = new Button();
            pic_Logo_HCMUTE_MHR = new PictureBox();
            pnl_content_MainHR = new Panel();
            pnl_MainHR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Logo_HCMUTE_MHR).BeginInit();
            SuspendLayout();
            // 
            // pnl_MainHR
            // 
            pnl_MainHR.BackColor = Color.RoyalBlue;
            pnl_MainHR.Controls.Add(btn_Logout_MainHR);
            pnl_MainHR.Controls.Add(btn_AddStudent);
            pnl_MainHR.Controls.Add(btn_FixStudentScore);
            pnl_MainHR.Controls.Add(pic_Logo_HCMUTE_MHR);
            pnl_MainHR.Location = new Point(0, 0);
            pnl_MainHR.Name = "pnl_MainHR";
            pnl_MainHR.Size = new Size(182, 627);
            pnl_MainHR.TabIndex = 1;
            // 
            // btn_Logout_MainHR
            // 
            btn_Logout_MainHR.BackColor = Color.RoyalBlue;
            btn_Logout_MainHR.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Logout_MainHR.ForeColor = SystemColors.Window;
            btn_Logout_MainHR.Location = new Point(0, 553);
            btn_Logout_MainHR.Name = "btn_Logout_MainHR";
            btn_Logout_MainHR.Size = new Size(182, 46);
            btn_Logout_MainHR.TabIndex = 3;
            btn_Logout_MainHR.Text = "Đăng xuất";
            btn_Logout_MainHR.UseVisualStyleBackColor = false;
            btn_Logout_MainHR.Click += btn_Logout_MainHR_Click;
            // 
            // btn_AddStudent
            // 
            btn_AddStudent.BackColor = Color.RoyalBlue;
            btn_AddStudent.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_AddStudent.ForeColor = SystemColors.Menu;
            btn_AddStudent.Location = new Point(0, 164);
            btn_AddStudent.Name = "btn_AddStudent";
            btn_AddStudent.Size = new Size(182, 46);
            btn_AddStudent.TabIndex = 2;
            btn_AddStudent.Text = "Thêm sinh viên  ";
            btn_AddStudent.UseVisualStyleBackColor = false;
            btn_AddStudent.Click += btn_AddStudent_Click;
            // 
            // btn_FixStudentScore
            // 
            btn_FixStudentScore.BackColor = Color.RoyalBlue;
            btn_FixStudentScore.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_FixStudentScore.ForeColor = SystemColors.Window;
            btn_FixStudentScore.Location = new Point(0, 216);
            btn_FixStudentScore.Name = "btn_FixStudentScore";
            btn_FixStudentScore.Size = new Size(182, 46);
            btn_FixStudentScore.TabIndex = 2;
            btn_FixStudentScore.Text = "Điểm sinh viên  ";
            btn_FixStudentScore.UseVisualStyleBackColor = false;
            // 
            // pic_Logo_HCMUTE_MHR
            // 
            pic_Logo_HCMUTE_MHR.BackgroundImage = Properties.Resources.logo_HCMUTE_MainMenu;
            pic_Logo_HCMUTE_MHR.Location = new Point(-34, 0);
            pic_Logo_HCMUTE_MHR.Name = "pic_Logo_HCMUTE_MHR";
            pic_Logo_HCMUTE_MHR.Size = new Size(216, 148);
            pic_Logo_HCMUTE_MHR.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Logo_HCMUTE_MHR.TabIndex = 0;
            pic_Logo_HCMUTE_MHR.TabStop = false;
            // 
            // pnl_content_MainHR
            // 
            pnl_content_MainHR.Location = new Point(182, 0);
            pnl_content_MainHR.Name = "pnl_content_MainHR";
            pnl_content_MainHR.Size = new Size(1063, 627);
            pnl_content_MainHR.TabIndex = 2;
            // 
            // f_MainHR
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1244, 626);
            Controls.Add(pnl_content_MainHR);
            Controls.Add(pnl_MainHR);
            Name = "f_MainHR";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "f_MainHR";
            pnl_MainHR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_Logo_HCMUTE_MHR).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnl_MainHR;
        private Button btn_AddStudent;
        private Button btn_FixStudentScore;
        private PictureBox pic_Logo_HCMUTE_MHR;
        private Button btn_Logout_MainHR;
        private Panel pnl_content_MainHR;
    }
}