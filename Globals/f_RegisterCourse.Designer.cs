namespace ProjectMonHoc
{
    partial class f_RegisterCourse
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDangKy = new System.Windows.Forms.TabPage();
            this.tabHuyDangKy = new System.Windows.Forms.TabPage();

            // ── Tab Đăng ký ──
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.cboStudent = new System.Windows.Forms.ComboBox();
            this.lblCourse = new System.Windows.Forms.Label();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnNewDK = new System.Windows.Forms.Button();
            this.lblCourseInfo = new System.Windows.Forms.Label();
            this.btnAISuggest = new System.Windows.Forms.Button();

            this.lblRegistered = new System.Windows.Forms.Label();
            this.dgvRegistered = new System.Windows.Forms.DataGridView();

            // ── Tab Hủy đăng ký ──
            this.grpHuy = new System.Windows.Forms.GroupBox();
            this.lblStudentHuy = new System.Windows.Forms.Label();
            this.cboStudentHuy = new System.Windows.Forms.ComboBox();
            this.btnLoadHuy = new System.Windows.Forms.Button();
            this.dgvHuy = new System.Windows.Forms.DataGridView();
            this.btnUnregister = new System.Windows.Forms.Button();

            // ── Status strip ──
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();

            this.tabControl1.SuspendLayout();
            this.tabDangKy.SuspendLayout();
            this.tabHuyDangKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvRegistered).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvHuy).BeginInit();
            this.SuspendLayout();

            // ════════════════════════════════════════
            // tabControl1
            // ════════════════════════════════════════
            this.tabControl1.Controls.Add(this.tabDangKy);
            this.tabControl1.Controls.Add(this.tabHuyDangKy);
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(764, 500);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Regular);

            // ════════════════════════════════════════
            // tabDangKy
            // ════════════════════════════════════════
            this.tabDangKy.Controls.Add(this.grpFilter);
            this.tabDangKy.Controls.Add(this.lblRegistered);
            this.tabDangKy.Controls.Add(this.dgvRegistered);
            this.tabDangKy.Location = new System.Drawing.Point(4, 26);
            this.tabDangKy.Name = "tabDangKy";
            this.tabDangKy.Padding = new System.Windows.Forms.Padding(8);
            this.tabDangKy.Size = new System.Drawing.Size(756, 470);
            this.tabDangKy.Text = "  ➕  Đăng ký môn học  ";
            this.tabDangKy.UseVisualStyleBackColor = true;

            // ── grpFilter ──
            this.grpFilter.Controls.Add(this.lblStudent);
            this.grpFilter.Controls.Add(this.cboStudent);
            this.grpFilter.Controls.Add(this.lblCourse);
            this.grpFilter.Controls.Add(this.cboCourse);
            this.grpFilter.Controls.Add(this.btnRegister);
            this.grpFilter.Controls.Add(this.btnNewDK);
            this.grpFilter.Controls.Add(this.lblCourseInfo);
            this.grpFilter.Controls.Add(this.btnAISuggest);
            this.grpFilter.Location = new System.Drawing.Point(10, 10);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(730, 100);
            this.grpFilter.Text = "";
            this.grpFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // lblStudent
            this.lblStudent.AutoSize = true;
            this.lblStudent.Location = new System.Drawing.Point(14, 22);
            this.lblStudent.Text = "Sinh viên *";
            this.lblStudent.Font = new System.Drawing.Font("Segoe UI", 9f);

            // cboStudent
            this.cboStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStudent.Location = new System.Drawing.Point(90, 18);
            this.cboStudent.Name = "cboStudent";
            this.cboStudent.Size = new System.Drawing.Size(260, 24);
            this.cboStudent.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            // lblCourse
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(370, 22);
            this.lblCourse.Text = "Môn học *";
            this.lblCourse.Font = new System.Drawing.Font("Segoe UI", 9f);

            // cboCourse
            this.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourse.Location = new System.Drawing.Point(445, 18);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(260, 24);
            this.cboCourse.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            // btnRegister  (blue, primary)
            this.btnRegister.Location = new System.Drawing.Point(90, 58);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(120, 32);
            this.btnRegister.Text = "✚  Đăng ký";
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(0, 114, 188);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;

            // btnNewDK (reset / làm mới)
            this.btnNewDK.Location = new System.Drawing.Point(222, 58);
            this.btnNewDK.Name = "btnNewDK";
            this.btnNewDK.Size = new System.Drawing.Size(90, 32);
            this.btnNewDK.Text = "Làm mới";
            this.btnNewDK.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.btnNewDK.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.btnNewDK.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.btnNewDK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewDK.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnNewDK.Cursor = System.Windows.Forms.Cursors.Hand;

            // lblCourseInfo
            this.lblCourseInfo.AutoSize = true;
            this.lblCourseInfo.Location = new System.Drawing.Point(325, 65);
            this.lblCourseInfo.Name = "lblCourseInfo";
            this.lblCourseInfo.Text = "Chọn môn học để xem thông tin";
            this.lblCourseInfo.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Italic);
            this.lblCourseInfo.ForeColor = System.Drawing.Color.DimGray;

            // btnAISuggest (màu tím)
            this.btnAISuggest.Location = new System.Drawing.Point(585, 58);
            this.btnAISuggest.Name = "btnAISuggest";
            this.btnAISuggest.Size = new System.Drawing.Size(120, 32);
            this.btnAISuggest.Text = "💡 Gợi ý AI";
            this.btnAISuggest.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnAISuggest.BackColor = System.Drawing.Color.FromArgb(142, 68, 173); // Tím Amethyst
            this.btnAISuggest.ForeColor = System.Drawing.Color.White;
            this.btnAISuggest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAISuggest.FlatAppearance.BorderSize = 0;
            this.btnAISuggest.Cursor = System.Windows.Forms.Cursors.Hand;

            // lblRegistered
            this.lblRegistered.AutoSize = true;
            this.lblRegistered.Location = new System.Drawing.Point(10, 118);
            this.lblRegistered.Text = "Danh sách môn đã đăng ký:";
            this.lblRegistered.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblRegistered.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);

            // dgvRegistered
            this.dgvRegistered.Location = new System.Drawing.Point(10, 138);
            this.dgvRegistered.Name = "dgvRegistered";
            this.dgvRegistered.Size = new System.Drawing.Size(730, 310);
            this.dgvRegistered.AllowUserToAddRows = false;
            this.dgvRegistered.ReadOnly = true;
            this.dgvRegistered.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistered.MultiSelect = false;
            this.dgvRegistered.RowHeadersVisible = false;
            this.dgvRegistered.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegistered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvRegistered.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistered.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dgvRegistered.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.dgvRegistered.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.dgvRegistered.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRegistered.EnableHeadersVisualStyles = false;
            this.dgvRegistered.ColumnHeadersHeight = 32;

            // ════════════════════════════════════════
            // tabHuyDangKy
            // ════════════════════════════════════════
            this.tabHuyDangKy.Controls.Add(this.grpHuy);
            this.tabHuyDangKy.Controls.Add(this.dgvHuy);
            this.tabHuyDangKy.Controls.Add(this.btnUnregister);
            this.tabHuyDangKy.Location = new System.Drawing.Point(4, 26);
            this.tabHuyDangKy.Name = "tabHuyDangKy";
            this.tabHuyDangKy.Padding = new System.Windows.Forms.Padding(8);
            this.tabHuyDangKy.Size = new System.Drawing.Size(756, 470);
            this.tabHuyDangKy.Text = "  🗑  Hủy đăng ký  ";
            this.tabHuyDangKy.UseVisualStyleBackColor = true;

            // grpHuy
            this.grpHuy.Controls.Add(this.lblStudentHuy);
            this.grpHuy.Controls.Add(this.cboStudentHuy);
            this.grpHuy.Controls.Add(this.btnLoadHuy);
            this.grpHuy.Location = new System.Drawing.Point(10, 10);
            this.grpHuy.Name = "grpHuy";
            this.grpHuy.Size = new System.Drawing.Size(730, 70);
            this.grpHuy.Text = "";
            this.grpHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // lblStudentHuy
            this.lblStudentHuy.AutoSize = true;
            this.lblStudentHuy.Location = new System.Drawing.Point(14, 22);
            this.lblStudentHuy.Text = "Sinh viên *";
            this.lblStudentHuy.Font = new System.Drawing.Font("Segoe UI", 9f);

            // cboStudentHuy
            this.cboStudentHuy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStudentHuy.Location = new System.Drawing.Point(90, 18);
            this.cboStudentHuy.Name = "cboStudentHuy";
            this.cboStudentHuy.Size = new System.Drawing.Size(280, 24);
            this.cboStudentHuy.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            // btnLoadHuy
            this.btnLoadHuy.Location = new System.Drawing.Point(384, 17);
            this.btnLoadHuy.Name = "btnLoadHuy";
            this.btnLoadHuy.Size = new System.Drawing.Size(120, 28);
            this.btnLoadHuy.Text = "🔍  Tải danh sách";
            this.btnLoadHuy.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.btnLoadHuy.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.btnLoadHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadHuy.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLoadHuy.Cursor = System.Windows.Forms.Cursors.Hand;

            // dgvHuy
            this.dgvHuy.Location = new System.Drawing.Point(10, 90);
            this.dgvHuy.Name = "dgvHuy";
            this.dgvHuy.Size = new System.Drawing.Size(730, 330);
            this.dgvHuy.AllowUserToAddRows = false;
            this.dgvHuy.ReadOnly = true;
            this.dgvHuy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHuy.MultiSelect = false;
            this.dgvHuy.RowHeadersVisible = false;
            this.dgvHuy.BackgroundColor = System.Drawing.Color.White;
            this.dgvHuy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvHuy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHuy.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dgvHuy.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.dgvHuy.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.dgvHuy.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHuy.EnableHeadersVisualStyles = false;
            this.dgvHuy.ColumnHeadersHeight = 32;

            // btnUnregister (đỏ)
            this.btnUnregister.Location = new System.Drawing.Point(10, 430);
            this.btnUnregister.Name = "btnUnregister";
            this.btnUnregister.Size = new System.Drawing.Size(140, 32);
            this.btnUnregister.Text = "🗑  Hủy đăng ký";
            this.btnUnregister.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.btnUnregister.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.btnUnregister.ForeColor = System.Drawing.Color.White;
            this.btnUnregister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnregister.FlatAppearance.BorderSize = 0;
            this.btnUnregister.Cursor = System.Windows.Forms.Cursors.Hand;

            // ════════════════════════════════════════
            // statusStrip1
            // ════════════════════════════════════════
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
            this.statusStrip1.Location = new System.Drawing.Point(0, 520);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);

            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Sẵn sàng";
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);

            // ════════════════════════════════════════
            // f_RegisterCourse
            // ════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(784, 542);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "f_RegisterCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký Môn học";

            this.tabControl1.ResumeLayout(false);
            this.tabDangKy.ResumeLayout(false);
            this.tabDangKy.PerformLayout();
            this.tabHuyDangKy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvRegistered).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvHuy).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // ── Controls ──
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDangKy;
        private System.Windows.Forms.TabPage tabHuyDangKy;

        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.ComboBox cboStudent;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.ComboBox cboCourse;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnNewDK;
        private System.Windows.Forms.Label lblCourseInfo;
        private System.Windows.Forms.Button btnAISuggest;
        private System.Windows.Forms.Label lblRegistered;
        private System.Windows.Forms.DataGridView dgvRegistered;

        private System.Windows.Forms.GroupBox grpHuy;
        private System.Windows.Forms.Label lblStudentHuy;
        private System.Windows.Forms.ComboBox cboStudentHuy;
        private System.Windows.Forms.Button btnLoadHuy;
        private System.Windows.Forms.DataGridView dgvHuy;
        private System.Windows.Forms.Button btnUnregister;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}