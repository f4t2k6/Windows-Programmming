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
            pnl_header = new Panel();
            pnl_toolbar = new Panel();
            label_Search = new Label();
            pnl_footer = new Panel();
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
            dgvScores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvScores.BackgroundColor = Color.White;
            dgvScores.BorderStyle = BorderStyle.None;
            dgvScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvScores.Dock = DockStyle.Fill;
            dgvScores.Font = new Font("Segoe UI", 10F);
            dgvScores.Location = new Point(0, 170);
            dgvScores.Name = "dgvScores";
            dgvScores.ReadOnly = true;
            dgvScores.RowHeadersWidth = 51;
            dgvScores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvScores.Size = new Size(1027, 414);
            dgvScores.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Location = new Point(569, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(280, 32);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.Enter += txtSearch_Enter;
            txtSearch.Leave += txtSearch_Leave;
            // 
            // cboSort
            // 
            cboSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSort.Font = new Font("Segoe UI", 10F);
            cboSort.Location = new Point(100, 13);
            cboSort.Name = "cboSort";
            cboSort.Size = new Size(240, 31);
            cboSort.TabIndex = 2;
            cboSort.SelectedIndexChanged += cboSort_SelectedIndexChanged;
            // 
            // lblSort
            // 
            lblSort.AutoSize = true;
            lblSort.Font = new Font("Segoe UI", 10F);
            lblSort.Location = new Point(20, 16);
            lblSort.Name = "lblSort";
            lblSort.Size = new Size(74, 23);
            lblSort.TabIndex = 1;
            lblSort.Text = "Sắp xếp:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.Location = new Point(15, 10);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(134, 23);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Tổng số môn: 0";
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.AutoSize = true;
            lblCurrentUser.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblCurrentUser.ForeColor = Color.White;
            lblCurrentUser.Location = new Point(20, 18);
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(155, 23);
            lblCurrentUser.TabIndex = 0;
            lblCurrentUser.Text = "Đang đăng nhập: ...";
            // 
            // lblNotification
            // 
            lblNotification.AutoSize = true;
            lblNotification.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblNotification.Location = new Point(500, 10);
            lblNotification.Name = "lblNotification";
            lblNotification.Size = new Size(0, 23);
            lblNotification.TabIndex = 1;
            // 
            // pnl_studentSelector
            // 
            pnl_studentSelector.BackColor = Color.AliceBlue;
            pnl_studentSelector.Controls.Add(cboSelectStudent);
            pnl_studentSelector.Controls.Add(lblSelectStudent);
            pnl_studentSelector.Controls.Add(lblStudentInfo);
            pnl_studentSelector.Dock = DockStyle.Top;
            pnl_studentSelector.Location = new Point(0, 120);
            pnl_studentSelector.Name = "pnl_studentSelector";
            pnl_studentSelector.Size = new Size(1027, 50);
            pnl_studentSelector.TabIndex = 1;
            pnl_studentSelector.Visible = false;
            pnl_studentSelector.Paint += pnl_studentSelector_Paint;
            // 
            // cboSelectStudent
            // 
            cboSelectStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSelectStudent.Font = new Font("Segoe UI", 10F);
            cboSelectStudent.Location = new Point(158, 12);
            cboSelectStudent.Name = "cboSelectStudent";
            cboSelectStudent.Size = new Size(300, 31);
            cboSelectStudent.TabIndex = 1;
            cboSelectStudent.SelectedIndexChanged += cboSelectStudent_SelectedIndexChanged;
            // 
            // lblSelectStudent
            // 
            lblSelectStudent.AutoSize = true;
            lblSelectStudent.Font = new Font("Segoe UI", 10F);
            lblSelectStudent.Location = new Point(23, 15);
            lblSelectStudent.Name = "lblSelectStudent";
            lblSelectStudent.Size = new Size(172, 23);
            lblSelectStudent.TabIndex = 0;
            lblSelectStudent.Text = "Chọn sinh viên:         ";
            // 
            // lblStudentInfo
            // 
            lblStudentInfo.AutoSize = true;
            lblStudentInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStudentInfo.ForeColor = Color.DarkSlateBlue;
            lblStudentInfo.Location = new Point(20, 13);
            lblStudentInfo.Name = "lblStudentInfo";
            lblStudentInfo.Size = new Size(168, 25);
            lblStudentInfo.TabIndex = 2;
            lblStudentInfo.Text = "Bảng điểm của: ...";
            lblStudentInfo.Visible = false;
            lblStudentInfo.Click += lblStudentInfo_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Orange;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(880, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(130, 36);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới ↻";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblGPA
            // 
            lblGPA.AutoSize = true;
            lblGPA.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGPA.ForeColor = Color.DarkGreen;
            lblGPA.Location = new Point(200, 10);
            lblGPA.Name = "lblGPA";
            lblGPA.Size = new Size(67, 23);
            lblGPA.TabIndex = 5;
            lblGPA.Text = "GPA: --";
            // 
            // pnl_header
            // 
            pnl_header.BackColor = Color.SteelBlue;
            pnl_header.Controls.Add(lblCurrentUser);
            pnl_header.Dock = DockStyle.Top;
            pnl_header.Location = new Point(0, 0);
            pnl_header.Name = "pnl_header";
            pnl_header.Size = new Size(1027, 60);
            pnl_header.TabIndex = 3;
            // 
            // pnl_toolbar
            // 
            pnl_toolbar.BackColor = Color.WhiteSmoke;
            pnl_toolbar.Controls.Add(label_Search);
            pnl_toolbar.Controls.Add(txtSearch);
            pnl_toolbar.Controls.Add(cboSort);
            pnl_toolbar.Controls.Add(lblSort);
            pnl_toolbar.Controls.Add(btnRefresh);
            pnl_toolbar.Dock = DockStyle.Top;
            pnl_toolbar.Location = new Point(0, 60);
            pnl_toolbar.Name = "pnl_toolbar";
            pnl_toolbar.Size = new Size(1027, 60);
            pnl_toolbar.TabIndex = 2;
            // 
            // label_Search
            // 
            label_Search.AutoSize = true;
            label_Search.Font = new Font("Segoe UI", 10F);
            label_Search.Location = new Point(407, 16);
            label_Search.Name = "label_Search";
            label_Search.Size = new Size(156, 23);
            label_Search.TabIndex = 4;
            label_Search.Text = "Tìm kiếm môn học:";
            // 
            // pnl_footer
            // 
            pnl_footer.BackColor = Color.WhiteSmoke;
            pnl_footer.Controls.Add(lblTotal);
            pnl_footer.Controls.Add(lblGPA);
            pnl_footer.Controls.Add(lblNotification);
            pnl_footer.Dock = DockStyle.Bottom;
            pnl_footer.Location = new Point(0, 584);
            pnl_footer.Name = "pnl_footer";
            pnl_footer.Size = new Size(1027, 44);
            pnl_footer.TabIndex = 4;
            pnl_footer.Paint += pnl_footer_Paint;
            // 
            // f_ListScore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1027, 628);
            Controls.Add(dgvScores);
            Controls.Add(pnl_studentSelector);
            Controls.Add(pnl_toolbar);
            Controls.Add(pnl_header);
            Controls.Add(pnl_footer);
            Name = "f_ListScore";
            Text = "📊 Bảng điểm môn học";
            Load += f_ListScore_Load;
            ((System.ComponentModel.ISupportInitialize)dgvScores).EndInit();
            pnl_studentSelector.ResumeLayout(false);
            pnl_studentSelector.PerformLayout();
            pnl_header.ResumeLayout(false);
            pnl_header.PerformLayout();
            pnl_toolbar.ResumeLayout(false);
            pnl_toolbar.PerformLayout();
            pnl_footer.ResumeLayout(false);
            pnl_footer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

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
        private Label lblStudentInfo;
        private Label lblGPA;
        private Label label_Search;
    }
}