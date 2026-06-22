namespace ProjectMonHoc
{
    partial class f_ListStudent
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvStudents = new DataGridView();
            txtSearch = new TextBox();
            cboSort = new ComboBox();
            lblSort = new Label();
            lblTotal = new Label();
            lblCurrentUser = new Label();
            btnAddStudent = new Button();
            btnRefresh = new Button();
            cboGenderFilter = new ComboBox();
            lblGenderFilter = new Label();
            lb_Notification = new Label();
            pnl_header = new Panel();
            lblSchoolName = new Label();
            lblSchoolNameEn = new Label();
            pnl_headerDivider = new Panel();
            pnl_toolbar = new Panel();
            label_Search = new Label();
            pnl_footer = new Panel();
            pnl_footerTop = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            pnl_header.SuspendLayout();
            pnl_toolbar.SuspendLayout();
            pnl_footer.SuspendLayout();
            SuspendLayout();
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 248, 255);
            dgvStudents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.BorderStyle = BorderStyle.None;
            dgvStudents.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(31, 97, 141);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 97, 141);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvStudents.ColumnHeadersHeight = 46;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(6, 4, 6, 4);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(210, 228, 248);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(20, 60, 100);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvStudents.DefaultCellStyle = dataGridViewCellStyle3;
            dgvStudents.Dock = DockStyle.Fill;
            dgvStudents.EnableHeadersVisualStyles = false;
            dgvStudents.GridColor = Color.FromArgb(230, 235, 245);
            dgvStudents.Location = new Point(0, 168);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.RowTemplate.Height = 70;
            dgvStudents.ScrollBars = ScrollBars.Vertical;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(1620, 807);
            dgvStudents.TabIndex = 0;
            dgvStudents.CellContentClick += dgvStudents_CellContentClick;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Location = new Point(136, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(340, 32);
            txtSearch.TabIndex = 0;
            txtSearch.Text = "Tìm kiếm...";
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cboSort
            // 
            cboSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSort.FlatStyle = FlatStyle.Flat;
            cboSort.Font = new Font("Segoe UI", 11F);
            cboSort.Location = new Point(886, 17);
            cboSort.Name = "cboSort";
            cboSort.Size = new Size(240, 33);
            cboSort.TabIndex = 2;
            cboSort.SelectedIndexChanged += cboSort_SelectedIndexChanged;
            // 
            // lblSort
            // 
            lblSort.AutoSize = true;
            lblSort.Font = new Font("Segoe UI", 11F);
            lblSort.ForeColor = Color.FromArgb(60, 80, 110);
            lblSort.Location = new Point(795, 21);
            lblSort.Name = "lblSort";
            lblSort.Size = new Size(82, 25);
            lblSort.TabIndex = 2;
            lblSort.Text = "Sắp xếp:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(31, 97, 141);
            lblTotal.Location = new Point(22, 18);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(215, 25);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "👥 Tổng số sinh viên: 0";
            lblTotal.Click += lblTotal_Click;
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
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.FromArgb(39, 174, 96);
            btnAddStudent.Cursor = Cursors.Hand;
            btnAddStudent.FlatAppearance.BorderSize = 0;
            btnAddStudent.FlatStyle = FlatStyle.Flat;
            btnAddStudent.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(1190, 13);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(190, 42);
            btnAddStudent.TabIndex = 3;
            btnAddStudent.Text = "＋  Thêm sinh viên";
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(230, 126, 34);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(1400, 13);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(165, 42);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "↻  Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // cboGenderFilter
            // 
            cboGenderFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGenderFilter.FlatStyle = FlatStyle.Flat;
            cboGenderFilter.Font = new Font("Segoe UI", 11F);
            cboGenderFilter.Location = new Point(600, 17);
            cboGenderFilter.Name = "cboGenderFilter";
            cboGenderFilter.Size = new Size(170, 33);
            cboGenderFilter.TabIndex = 8;
            cboGenderFilter.SelectedIndexChanged += cboGenderFilter_SelectedIndexChanged;
            // 
            // lblGenderFilter
            // 
            lblGenderFilter.AutoSize = true;
            lblGenderFilter.Font = new Font("Segoe UI", 11F);
            lblGenderFilter.ForeColor = Color.FromArgb(60, 80, 110);
            lblGenderFilter.Location = new Point(500, 21);
            lblGenderFilter.Name = "lblGenderFilter";
            lblGenderFilter.Size = new Size(88, 25);
            lblGenderFilter.TabIndex = 7;
            lblGenderFilter.Text = "Giới tính:";
            // 
            // lb_Notification
            // 
            lb_Notification.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lb_Notification.ForeColor = Color.FromArgb(200, 230, 255);
            lb_Notification.Location = new Point(1100, 50);
            lb_Notification.Name = "lb_Notification";
            lb_Notification.Size = new Size(450, 26);
            lb_Notification.TabIndex = 3;
            lb_Notification.Text = "💡 Nhấn đúp vào dòng để chỉnh sửa thông tin";
            lb_Notification.TextAlign = ContentAlignment.MiddleRight;
            lb_Notification.Click += lb_Notification_Click;
            // 
            // pnl_header
            // 
            pnl_header.BackColor = Color.FromArgb(31, 97, 141);
            pnl_header.Controls.Add(lblSchoolName);
            pnl_header.Controls.Add(lblSchoolNameEn);
            pnl_header.Controls.Add(lblCurrentUser);
            pnl_header.Controls.Add(lb_Notification);
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
            lblSchoolName.Location = new Point(14, 16);
            lblSchoolName.Name = "lblSchoolName";
            lblSchoolName.Size = new Size(860, 36);
            lblSchoolName.TabIndex = 0;
            lblSchoolName.Text = "TRƯỜNG ĐẠI HỌC CÔNG NGHỆ KỸ THUẬT TP. HỒ CHÍ MINH";
            // 
            // lblSchoolNameEn
            // 
            lblSchoolNameEn.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblSchoolNameEn.ForeColor = Color.FromArgb(210, 230, 255);
            lblSchoolNameEn.Location = new Point(14, 54);
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
            pnl_toolbar.Controls.Add(lblGenderFilter);
            pnl_toolbar.Controls.Add(cboGenderFilter);
            pnl_toolbar.Controls.Add(lblSort);
            pnl_toolbar.Controls.Add(cboSort);
            pnl_toolbar.Controls.Add(btnAddStudent);
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
            label_Search.Location = new Point(12, 20);
            label_Search.Name = "label_Search";
            label_Search.Size = new Size(118, 25);
            label_Search.TabIndex = 10;
            label_Search.Text = "🔍 Tìm kiếm:";
            // 
            // pnl_footer
            // 
            pnl_footer.BackColor = Color.FromArgb(242, 246, 252);
            pnl_footer.Controls.Add(pnl_footerTop);
            pnl_footer.Controls.Add(lblTotal);
            pnl_footer.Dock = DockStyle.Bottom;
            pnl_footer.Location = new Point(0, 975);
            pnl_footer.Name = "pnl_footer";
            pnl_footer.Size = new Size(1620, 58);
            pnl_footer.TabIndex = 4;
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
            // f_ListStudent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1620, 1033);
            Controls.Add(dgvStudents);
            Controls.Add(pnl_toolbar);
            Controls.Add(pnl_header);
            Controls.Add(pnl_footer);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1280, 800);
            Name = "f_ListStudent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "👥 Danh Sách Sinh Viên  –  HCM-UTE";
            Load += f_ListStudent_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            pnl_header.ResumeLayout(false);
            pnl_toolbar.ResumeLayout(false);
            pnl_toolbar.PerformLayout();
            pnl_footer.ResumeLayout(false);
            pnl_footer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvStudents;
        private TextBox txtSearch;
        private ComboBox cboSort;
        private Label lblSort;
        private Label lblTotal;
        private Label lblCurrentUser;
        private Button btnAddStudent;
        private Button btnRefresh;
        private ComboBox cboGenderFilter;
        private Label lblGenderFilter;
        private Label lb_Notification;

        // New layout controls
        private Panel pnl_header;
        private Panel pnl_headerDivider;
        private Panel pnl_toolbar;
        private Panel pnl_footer;
        private Panel pnl_footerTop;
        private Label lblSchoolName;
        private Label lblSchoolNameEn;
        private Label label_Search;
    }
}