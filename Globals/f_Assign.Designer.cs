namespace ProjectMonHoc
{
    partial class f_Assign
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnl_header = new Panel();
            pnl_headerAccent = new Panel();
            lbl_schoolName = new Label();
            lbl_schoolNameEn = new Label();
            pnl_toolbar = new Panel();
            pnl_toolbarDivider = new Panel();
            lbl_HR = new Label();
            cboHR = new ComboBox();
            lbl_Course = new Label();
            cboCourse = new ComboBox();
            btnAssign = new Button();
            btnRemove = new Button();
            btnRefresh = new Button();
            dgvAssign = new DataGridView();
            pnl_footer = new Panel();
            pnl_footerAccent = new Panel();
            lbl_footerNote = new Label();
            pnl_header.SuspendLayout();
            pnl_toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAssign).BeginInit();
            pnl_footer.SuspendLayout();
            SuspendLayout();
            // 
            // pnl_header
            // 
            pnl_header.BackColor = Color.FromArgb(31, 97, 141);
            pnl_header.Controls.Add(pnl_headerAccent);
            pnl_header.Controls.Add(lbl_schoolName);
            pnl_header.Controls.Add(lbl_schoolNameEn);
            pnl_header.Dock = DockStyle.Top;
            pnl_header.Location = new Point(0, 0);
            pnl_header.Name = "pnl_header";
            pnl_header.Padding = new Padding(20, 0, 20, 0);
            pnl_header.Size = new Size(1620, 100);
            pnl_header.TabIndex = 3;
            // 
            // pnl_headerAccent
            // 
            pnl_headerAccent.BackColor = Color.FromArgb(192, 57, 43);
            pnl_headerAccent.Dock = DockStyle.Bottom;
            pnl_headerAccent.Location = new Point(20, 96);
            pnl_headerAccent.Name = "pnl_headerAccent";
            pnl_headerAccent.Size = new Size(1580, 4);
            pnl_headerAccent.TabIndex = 0;
            // 
            // lbl_schoolName
            // 
            lbl_schoolName.BackColor = Color.Transparent;
            lbl_schoolName.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lbl_schoolName.ForeColor = Color.White;
            lbl_schoolName.Location = new Point(24, 17);
            lbl_schoolName.Name = "lbl_schoolName";
            lbl_schoolName.Size = new Size(1000, 36);
            lbl_schoolName.TabIndex = 1;
            lbl_schoolName.Text = "TRƯỜNG ĐẠI HỌC CÔNG NGHỆ KỸ THUẬT TP. HỒ CHÍ MINH";
            lbl_schoolName.Click += lblTitle_Click;
            // 
            // lbl_schoolNameEn
            // 
            lbl_schoolNameEn.BackColor = Color.Transparent;
            lbl_schoolNameEn.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lbl_schoolNameEn.ForeColor = Color.FromArgb(210, 230, 255);
            lbl_schoolNameEn.Location = new Point(24, 55);
            lbl_schoolNameEn.Name = "lbl_schoolNameEn";
            lbl_schoolNameEn.Size = new Size(900, 28);
            lbl_schoolNameEn.TabIndex = 2;
            lbl_schoolNameEn.Text = "Ho Chi Minh City University of Technology and Engineering";
            // 
            // pnl_toolbar
            // 
            pnl_toolbar.BackColor = Color.FromArgb(242, 246, 252);
            pnl_toolbar.Controls.Add(pnl_toolbarDivider);
            pnl_toolbar.Controls.Add(lbl_HR);
            pnl_toolbar.Controls.Add(cboHR);
            pnl_toolbar.Controls.Add(lbl_Course);
            pnl_toolbar.Controls.Add(cboCourse);
            pnl_toolbar.Controls.Add(btnAssign);
            pnl_toolbar.Controls.Add(btnRemove);
            pnl_toolbar.Controls.Add(btnRefresh);
            pnl_toolbar.Dock = DockStyle.Top;
            pnl_toolbar.Location = new Point(0, 100);
            pnl_toolbar.Name = "pnl_toolbar";
            pnl_toolbar.Padding = new Padding(24, 0, 24, 0);
            pnl_toolbar.Size = new Size(1620, 68);
            pnl_toolbar.TabIndex = 1;
            // 
            // pnl_toolbarDivider
            // 
            pnl_toolbarDivider.BackColor = Color.FromArgb(192, 57, 43);
            pnl_toolbarDivider.Dock = DockStyle.Bottom;
            pnl_toolbarDivider.Location = new Point(24, 66);
            pnl_toolbarDivider.Name = "pnl_toolbarDivider";
            pnl_toolbarDivider.Size = new Size(1572, 2);
            pnl_toolbarDivider.TabIndex = 0;
            // 
            // lbl_HR
            // 
            lbl_HR.AutoSize = true;
            lbl_HR.Font = new Font("Segoe UI", 10F);
            lbl_HR.ForeColor = Color.FromArgb(60, 60, 60);
            lbl_HR.Location = new Point(20, 23);
            lbl_HR.Name = "lbl_HR";
            lbl_HR.Size = new Size(95, 23);
            lbl_HR.TabIndex = 2;
            lbl_HR.Text = "Giảng viên:";
            lbl_HR.Click += lblHR_Click;
            // 
            // cboHR
            // 
            cboHR.BackColor = Color.White;
            cboHR.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHR.FlatStyle = FlatStyle.Flat;
            cboHR.Font = new Font("Segoe UI", 10F);
            cboHR.ForeColor = Color.FromArgb(40, 40, 40);
            cboHR.Location = new Point(130, 19);
            cboHR.Name = "cboHR";
            cboHR.Size = new Size(340, 31);
            cboHR.TabIndex = 1;
            // 
            // lbl_Course
            // 
            lbl_Course.AutoSize = true;
            lbl_Course.Font = new Font("Segoe UI", 10F);
            lbl_Course.ForeColor = Color.FromArgb(60, 60, 60);
            lbl_Course.Location = new Point(490, 23);
            lbl_Course.Name = "lbl_Course";
            lbl_Course.Size = new Size(82, 23);
            lbl_Course.TabIndex = 3;
            lbl_Course.Text = "Môn học:";
            // 
            // cboCourse
            // 
            cboCourse.BackColor = Color.White;
            cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCourse.FlatStyle = FlatStyle.Flat;
            cboCourse.Font = new Font("Segoe UI", 10F);
            cboCourse.ForeColor = Color.FromArgb(40, 40, 40);
            cboCourse.Location = new Point(580, 19);
            cboCourse.Name = "cboCourse";
            cboCourse.Size = new Size(380, 31);
            cboCourse.TabIndex = 2;
            // 
            // btnAssign
            // 
            btnAssign.BackColor = Color.FromArgb(31, 97, 141);
            btnAssign.Cursor = Cursors.Hand;
            btnAssign.FlatAppearance.BorderSize = 0;
            btnAssign.FlatStyle = FlatStyle.Flat;
            btnAssign.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAssign.ForeColor = Color.White;
            btnAssign.Location = new Point(1118, 16);
            btnAssign.Name = "btnAssign";
            btnAssign.Size = new Size(150, 36);
            btnAssign.TabIndex = 3;
            btnAssign.Text = "＋  Phân công";
            btnAssign.UseVisualStyleBackColor = false;
            btnAssign.Click += btnAssign_Click;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.FromArgb(192, 57, 43);
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(1278, 16);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(170, 36);
            btnRemove.TabIndex = 4;
            btnRemove.Text = "✖  Hủy phân công";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(230, 126, 34);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(1458, 16);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(140, 36);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "⟳  Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvAssign
            // 
            dgvAssign.AllowUserToAddRows = false;
            dgvAssign.AllowUserToDeleteRows = false;
            dgvAssign.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 248, 255);
            dgvAssign.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAssign.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAssign.BackgroundColor = Color.White;
            dgvAssign.BorderStyle = BorderStyle.None;
            dgvAssign.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(31, 97, 141);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 97, 141);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAssign.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAssign.ColumnHeadersHeight = 46;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(210, 228, 248);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(20, 60, 100);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvAssign.DefaultCellStyle = dataGridViewCellStyle3;
            dgvAssign.Dock = DockStyle.Fill;
            dgvAssign.EnableHeadersVisualStyles = false;
            dgvAssign.Font = new Font("Segoe UI", 10F);
            dgvAssign.GridColor = Color.FromArgb(220, 228, 240);
            dgvAssign.Location = new Point(0, 168);
            dgvAssign.MultiSelect = false;
            dgvAssign.Name = "dgvAssign";
            dgvAssign.ReadOnly = true;
            dgvAssign.RowHeadersVisible = false;
            dgvAssign.RowHeadersWidth = 51;
            dgvAssign.RowTemplate.Height = 42;
            dgvAssign.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAssign.Size = new Size(1620, 807);
            dgvAssign.TabIndex = 0;
            // 
            // pnl_footer
            // 
            pnl_footer.BackColor = Color.FromArgb(242, 246, 252);
            pnl_footer.Controls.Add(pnl_footerAccent);
            pnl_footer.Controls.Add(lbl_footerNote);
            pnl_footer.Dock = DockStyle.Bottom;
            pnl_footer.Location = new Point(0, 975);
            pnl_footer.Name = "pnl_footer";
            pnl_footer.Size = new Size(1620, 58);
            pnl_footer.TabIndex = 2;
            // 
            // pnl_footerAccent
            // 
            pnl_footerAccent.BackColor = Color.FromArgb(192, 57, 43);
            pnl_footerAccent.Dock = DockStyle.Top;
            pnl_footerAccent.Location = new Point(0, 0);
            pnl_footerAccent.Name = "pnl_footerAccent";
            pnl_footerAccent.Size = new Size(1620, 3);
            pnl_footerAccent.TabIndex = 0;
            // 
            // lbl_footerNote
            // 
            lbl_footerNote.AutoSize = true;
            lbl_footerNote.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lbl_footerNote.ForeColor = Color.FromArgb(130, 130, 130);
            lbl_footerNote.Location = new Point(24, 20);
            lbl_footerNote.Name = "lbl_footerNote";
            lbl_footerNote.Size = new Size(643, 20);
            lbl_footerNote.TabIndex = 1;
            lbl_footerNote.Text = "* Mỗi giảng viên chỉ được phân công tối đa 5 môn học.  |  Chọn dòng trong bảng để hủy phân công.";
            // 
            // f_Assign
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1620, 1033);
            Controls.Add(dgvAssign);
            Controls.Add(pnl_toolbar);
            Controls.Add(pnl_footer);
            Controls.Add(pnl_header);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "f_Assign";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Phân công giảng dạy";
            Load += f_Assign_Load;
            pnl_header.ResumeLayout(false);
            pnl_toolbar.ResumeLayout(false);
            pnl_toolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAssign).EndInit();
            pnl_footer.ResumeLayout(false);
            pnl_footer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // ── Header ──────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Panel pnl_headerAccent;
        private System.Windows.Forms.Label lbl_schoolName;
        private System.Windows.Forms.Label lbl_schoolNameEn;

        // ── Toolbar ─────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnl_toolbar;
        private System.Windows.Forms.Panel pnl_toolbarDivider;
        private System.Windows.Forms.Label lbl_HR;
        private System.Windows.Forms.ComboBox cboHR;
        private System.Windows.Forms.Label lbl_Course;
        private System.Windows.Forms.ComboBox cboCourse;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRefresh;

        // ── Grid ────────────────────────────────────────────────────────
        private System.Windows.Forms.DataGridView dgvAssign;

        // ── Footer ──────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnl_footer;
        private System.Windows.Forms.Panel pnl_footerAccent;
        private System.Windows.Forms.Label lbl_footerNote;

        // Alias để f_Assign.cs không cần đổi tên
        private System.Windows.Forms.Label lblTitle => lbl_schoolName;
        private System.Windows.Forms.Label lblHR => lbl_HR;
        private System.Windows.Forms.Label lblCourse => lbl_Course;
    }
}