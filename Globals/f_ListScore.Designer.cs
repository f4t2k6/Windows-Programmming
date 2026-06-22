namespace ProjectMonHoc
{
    partial class f_ListScore
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvScores = new DataGridView();
            txtSearch = new TextBox();
            cboSort = new ComboBox();
            lblSort = new Label();
            lblTotal = new Label();
            lblCurrentUser = new Label();
            lblNotification = new Label();
            pnl_studentSelector = new Panel();
            cboSelectStudent = new ComboBox();
            lblSelectStudent = new Label();
            lblStudentInfo = new Label();
            btnRefresh = new Button();
            lblGPA = new Label();
            lblHocLuc = new Label();
            btn_Print = new Button();
            pnl_header = new Panel();
            lblSchoolName = new Label();
            lblSchoolNameEn = new Label();
            pnl_headerDivider = new Panel();
            pnl_toolbar = new Panel();
            label_Search = new Label();
            pnl_footer = new Panel();
            pnl_footerTop = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvScores).BeginInit();
            pnl_studentSelector.SuspendLayout();
            pnl_header.SuspendLayout();
            pnl_toolbar.SuspendLayout();
            pnl_footer.SuspendLayout();
            SuspendLayout();
            // 
            // dgvScores
            // 
            dgvScores.AllowUserToAddRows = false;
            dgvScores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 248, 255);
            dgvScores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvScores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvScores.BackgroundColor = Color.White;
            dgvScores.BorderStyle = BorderStyle.None;
            dgvScores.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(31, 97, 141);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 97, 141);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvScores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvScores.ColumnHeadersHeight = 46;
            dgvScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(6, 4, 6, 4);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(210, 228, 248);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(20, 60, 100);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvScores.DefaultCellStyle = dataGridViewCellStyle3;
            dgvScores.Dock = DockStyle.Fill;
            dgvScores.EnableHeadersVisualStyles = false;
            dgvScores.GridColor = Color.FromArgb(230, 235, 245);
            dgvScores.Location = new Point(0, 226);
            dgvScores.Name = "dgvScores";
            dgvScores.ReadOnly = true;
            dgvScores.RowHeadersVisible = false;
            dgvScores.RowHeadersWidth = 51;
            dgvScores.RowTemplate.Height = 42;
            dgvScores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvScores.Size = new Size(1620, 749);
            dgvScores.TabIndex = 0;
            dgvScores.CellContentClick += dgvScores_CellContentClick;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Location = new Point(680, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(340, 32);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.Enter += txtSearch_Enter;
            txtSearch.Leave += txtSearch_Leave;
            // 
            // cboSort
            // 
            cboSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSort.FlatStyle = FlatStyle.Flat;
            cboSort.Font = new Font("Segoe UI", 11F);
            cboSort.Location = new Point(110, 17);
            cboSort.Name = "cboSort";
            cboSort.Size = new Size(300, 33);
            cboSort.TabIndex = 2;
            cboSort.SelectedIndexChanged += cboSort_SelectedIndexChanged;
            // 
            // lblSort
            // 
            lblSort.AutoSize = true;
            lblSort.Font = new Font("Segoe UI", 11F);
            lblSort.ForeColor = Color.FromArgb(60, 80, 110);
            lblSort.Location = new Point(22, 21);
            lblSort.Name = "lblSort";
            lblSort.Size = new Size(82, 25);
            lblSort.TabIndex = 1;
            lblSort.Text = "Sắp xếp:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(31, 97, 141);
            lblTotal.Location = new Point(22, 16);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(178, 25);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "📚 Tổng số môn: 0";
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.Font = new Font("Segoe UI", 10.5F, FontStyle.Italic);
            lblCurrentUser.ForeColor = Color.FromArgb(200, 220, 255);
            lblCurrentUser.Location = new Point(1100, 18);
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(450, 26);
            lblCurrentUser.TabIndex = 2;
            lblCurrentUser.Text = "Đang đăng nhập: ...";
            lblCurrentUser.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNotification
            // 
            lblNotification.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblNotification.ForeColor = Color.FromArgb(200, 230, 255);
            lblNotification.Location = new Point(1100, 50);
            lblNotification.Name = "lblNotification";
            lblNotification.Size = new Size(450, 26);
            lblNotification.TabIndex = 3;
            lblNotification.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnl_studentSelector
            // 
            pnl_studentSelector.BackColor = Color.FromArgb(232, 244, 255);
            pnl_studentSelector.Controls.Add(cboSelectStudent);
            pnl_studentSelector.Controls.Add(lblSelectStudent);
            pnl_studentSelector.Controls.Add(lblStudentInfo);
            pnl_studentSelector.Dock = DockStyle.Top;
            pnl_studentSelector.Location = new Point(0, 168);
            pnl_studentSelector.Name = "pnl_studentSelector";
            pnl_studentSelector.Size = new Size(1620, 58);
            pnl_studentSelector.TabIndex = 1;
            pnl_studentSelector.Visible = false;
            pnl_studentSelector.Paint += pnl_studentSelector_Paint;
            // 
            // cboSelectStudent
            // 
            cboSelectStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSelectStudent.FlatStyle = FlatStyle.Flat;
            cboSelectStudent.Font = new Font("Segoe UI", 11F);
            cboSelectStudent.Location = new Point(202, 12);
            cboSelectStudent.Name = "cboSelectStudent";
            cboSelectStudent.Size = new Size(400, 33);
            cboSelectStudent.TabIndex = 1;
            cboSelectStudent.SelectedIndexChanged += cboSelectStudent_SelectedIndexChanged;
            // 
            // lblSelectStudent
            // 
            lblSelectStudent.AutoSize = true;
            lblSelectStudent.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSelectStudent.ForeColor = Color.FromArgb(31, 97, 141);
            lblSelectStudent.Location = new Point(22, 17);
            lblSelectStudent.Name = "lblSelectStudent";
            lblSelectStudent.Size = new Size(174, 25);
            lblSelectStudent.TabIndex = 0;
            lblSelectStudent.Text = "👤 Chọn sinh viên:";
            // 
            // lblStudentInfo
            // 
            lblStudentInfo.AutoSize = true;
            lblStudentInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStudentInfo.ForeColor = Color.FromArgb(31, 97, 141);
            lblStudentInfo.Location = new Point(683, 15);
            lblStudentInfo.Name = "lblStudentInfo";
            lblStudentInfo.Size = new Size(213, 28);
            lblStudentInfo.TabIndex = 2;
            lblStudentInfo.Text = "📋 Bảng điểm của: ...";
            lblStudentInfo.Visible = false;
            lblStudentInfo.Click += lblStudentInfo_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(230, 126, 34);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(1060, 13);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(165, 42);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "↻  Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblGPA
            // 
            lblGPA.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblGPA.ForeColor = Color.DarkGreen;
            lblGPA.Location = new Point(260, 16);
            lblGPA.Name = "lblGPA";
            lblGPA.Size = new Size(420, 26);
            lblGPA.TabIndex = 5;
            lblGPA.Text = "GPA: --   |   Tổng TC tích lũy: --";
            // 
            // lblHocLuc
            // 
            lblHocLuc.AutoSize = true;
            lblHocLuc.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHocLuc.ForeColor = Color.Gray;
            lblHocLuc.Location = new Point(720, 16);
            lblHocLuc.Name = "lblHocLuc";
            lblHocLuc.Size = new Size(133, 25);
            lblHocLuc.TabIndex = 6;
            lblHocLuc.Text = "🎓 Học lực: --";
            // 
            // btn_Print
            // 
            btn_Print.BackColor = Color.FromArgb(31, 97, 141);
            btn_Print.Cursor = Cursors.Hand;
            btn_Print.FlatAppearance.BorderSize = 0;
            btn_Print.FlatStyle = FlatStyle.Flat;
            btn_Print.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Print.ForeColor = Color.White;
            btn_Print.Location = new Point(1400, 9);
            btn_Print.Name = "btn_Print";
            btn_Print.Size = new Size(190, 40);
            btn_Print.TabIndex = 7;
            btn_Print.Text = "🖨️  In Bảng Điểm";
            btn_Print.UseVisualStyleBackColor = false;
            btn_Print.Click += btn_Print_Click;
            // 
            // pnl_header
            // 
            pnl_header.BackColor = Color.FromArgb(31, 97, 141);
            pnl_header.Controls.Add(lblSchoolName);
            pnl_header.Controls.Add(lblSchoolNameEn);
            pnl_header.Controls.Add(lblCurrentUser);
            pnl_header.Controls.Add(lblNotification);
            pnl_header.Controls.Add(pnl_headerDivider);
            pnl_header.Dock = DockStyle.Top;
            pnl_header.Location = new Point(0, 0);
            pnl_header.Name = "pnl_header";
            pnl_header.Size = new Size(1620, 100);
            pnl_header.TabIndex = 3;
            // 
            // lblSchoolName
            // 
            lblSchoolName.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblSchoolName.ForeColor = Color.White;
            lblSchoolName.Location = new Point(12, 16);
            lblSchoolName.Name = "lblSchoolName";
            lblSchoolName.Size = new Size(860, 36);
            lblSchoolName.TabIndex = 0;
            lblSchoolName.Text = "TRƯỜNG ĐẠI HỌC CÔNG NGHỆ KỸ THUẬT TP. HỒ CHÍ MINH";
            // 
            // lblSchoolNameEn
            // 
            lblSchoolNameEn.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblSchoolNameEn.ForeColor = Color.FromArgb(210, 230, 255);
            lblSchoolNameEn.Location = new Point(12, 54);
            lblSchoolNameEn.Name = "lblSchoolNameEn";
            lblSchoolNameEn.Size = new Size(700, 28);
            lblSchoolNameEn.TabIndex = 1;
            lblSchoolNameEn.Text = "Ho Chi Minh City University of Technology and Engineering";
            // 
            // pnl_headerDivider
            // 
            pnl_headerDivider.BackColor = Color.FromArgb(192, 57, 43);
            pnl_headerDivider.Dock = DockStyle.Bottom;
            pnl_headerDivider.Location = new Point(0, 96);
            pnl_headerDivider.Name = "pnl_headerDivider";
            pnl_headerDivider.Size = new Size(1620, 4);
            pnl_headerDivider.TabIndex = 11;
            // 
            // pnl_toolbar
            // 
            pnl_toolbar.BackColor = Color.FromArgb(242, 246, 252);
            pnl_toolbar.Controls.Add(label_Search);
            pnl_toolbar.Controls.Add(txtSearch);
            pnl_toolbar.Controls.Add(cboSort);
            pnl_toolbar.Controls.Add(lblSort);
            pnl_toolbar.Controls.Add(btnRefresh);
            pnl_toolbar.Dock = DockStyle.Top;
            pnl_toolbar.Location = new Point(0, 100);
            pnl_toolbar.Name = "pnl_toolbar";
            pnl_toolbar.Size = new Size(1620, 68);
            pnl_toolbar.TabIndex = 2;
            // 
            // label_Search
            // 
            label_Search.AutoSize = true;
            label_Search.Font = new Font("Segoe UI", 11F);
            label_Search.ForeColor = Color.FromArgb(60, 80, 110);
            label_Search.Location = new Point(477, 21);
            label_Search.Name = "label_Search";
            label_Search.Size = new Size(197, 25);
            label_Search.TabIndex = 4;
            label_Search.Text = "🔍 Tìm kiếm môn học:";
            // 
            // pnl_footer
            // 
            pnl_footer.BackColor = Color.FromArgb(242, 246, 252);
            pnl_footer.Controls.Add(pnl_footerTop);
            pnl_footer.Controls.Add(lblTotal);
            pnl_footer.Controls.Add(lblGPA);
            pnl_footer.Controls.Add(lblHocLuc);
            pnl_footer.Controls.Add(btn_Print);
            pnl_footer.Dock = DockStyle.Bottom;
            pnl_footer.Location = new Point(0, 975);
            pnl_footer.Name = "pnl_footer";
            pnl_footer.Size = new Size(1620, 58);
            pnl_footer.TabIndex = 4;
            pnl_footer.Paint += pnl_footer_Paint;
            // 
            // pnl_footerTop
            // 
            pnl_footerTop.BackColor = Color.FromArgb(192, 57, 43);
            pnl_footerTop.Dock = DockStyle.Top;
            pnl_footerTop.Location = new Point(0, 0);
            pnl_footerTop.Name = "pnl_footerTop";
            pnl_footerTop.Size = new Size(1620, 3);
            pnl_footerTop.TabIndex = 10;
            // 
            // f_ListScore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1620, 1033);
            Controls.Add(dgvScores);
            Controls.Add(pnl_studentSelector);
            Controls.Add(pnl_toolbar);
            Controls.Add(pnl_header);
            Controls.Add(pnl_footer);
            MinimumSize = new Size(1280, 800);
            Name = "f_ListScore";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "📊 Bảng Điểm Môn Học  –  HCM-UTE";
            Load += f_ListScore_Load;
            ((System.ComponentModel.ISupportInitialize)dgvScores).EndInit();
            pnl_studentSelector.ResumeLayout(false);
            pnl_studentSelector.PerformLayout();
            pnl_header.ResumeLayout(false);
            pnl_toolbar.ResumeLayout(false);
            pnl_toolbar.PerformLayout();
            pnl_footer.ResumeLayout(false);
            pnl_footer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // Controls
        private System.Windows.Forms.DataGridView dgvScores;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboSort;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label lblNotification;
        private System.Windows.Forms.Panel pnl_studentSelector;
        private System.Windows.Forms.Label lblSelectStudent;
        private System.Windows.Forms.ComboBox cboSelectStudent;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Panel pnl_toolbar;
        private System.Windows.Forms.Panel pnl_footer;
        private System.Windows.Forms.Panel pnl_footerTop;
        private System.Windows.Forms.Panel pnl_headerDivider;
        private Label lblStudentInfo;
        private Label lblGPA;
        private Label lblHocLuc;
        private Label label_Search;
        private Label lblSchoolName;
        private Label lblSchoolNameEn;
        private Button btn_Print;
    }
}