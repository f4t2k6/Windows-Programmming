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
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(31, 211);
            dgvStudents.Margin = new Padding(3, 4, 3, 4);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.Size = new Size(1027, 288);
            dgvStudents.TabIndex = 0;
            dgvStudents.CellContentClick += dgvStudents_CellContentClick;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = SystemColors.ActiveCaption;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 20F);
            txtSearch.Location = new Point(31, 77);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(343, 45);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "Tìm kiếm...";
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cboSort
            // 
            cboSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSort.Font = new Font("Segoe UI", 11F);
            cboSort.Location = new Point(380, 142);
            cboSort.Margin = new Padding(3, 4, 3, 4);
            cboSort.Name = "cboSort";
            cboSort.Size = new Size(205, 33);
            cboSort.TabIndex = 2;
            cboSort.SelectedIndexChanged += cboSort_SelectedIndexChanged;
            // 
            // lblSort
            // 
            lblSort.AutoSize = true;
            lblSort.Font = new Font("Segoe UI", 11F);
            lblSort.Location = new Point(292, 145);
            lblSort.Name = "lblSort";
            lblSort.Size = new Size(82, 25);
            lblSort.TabIndex = 2;
            lblSort.Text = "Sắp xếp:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotal.Location = new Point(31, 520);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(188, 25);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "Tổng số sinh viên: 0";
            lblTotal.Click += lblTotal_Click;
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.AutoSize = true;
            lblCurrentUser.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblCurrentUser.ForeColor = Color.DarkSlateBlue;
            lblCurrentUser.Location = new Point(31, 24);
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(155, 23);
            lblCurrentUser.TabIndex = 0;
            lblCurrentUser.Text = "Đang đăng nhập: ...";
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.ForestGreen;
            btnAddStudent.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(734, 73);
            btnAddStudent.Margin = new Padding(3, 4, 3, 4);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(157, 47);
            btnAddStudent.TabIndex = 3;
            btnAddStudent.Text = "+ Thêm sinh viên";
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Orange;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(909, 73);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(149, 47);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Làm mới ↻";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // cboGenderFilter
            // 
            cboGenderFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGenderFilter.Font = new Font("Segoe UI", 11F);
            cboGenderFilter.Location = new Point(125, 142);
            cboGenderFilter.Name = "cboGenderFilter";
            cboGenderFilter.Size = new Size(150, 33);
            cboGenderFilter.TabIndex = 8;
            cboGenderFilter.SelectedIndexChanged += cboGenderFilter_SelectedIndexChanged;
            // 
            // lblGenderFilter
            // 
            lblGenderFilter.AutoSize = true;
            lblGenderFilter.Font = new Font("Segoe UI", 11F);
            lblGenderFilter.Location = new Point(31, 145);
            lblGenderFilter.Name = "lblGenderFilter";
            lblGenderFilter.Size = new Size(88, 25);
            lblGenderFilter.TabIndex = 7;
            lblGenderFilter.Text = "Giới tính:";
            // 
            // lb_Notification
            // 
            lb_Notification.AutoSize = true;
            lb_Notification.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lb_Notification.Location = new Point(682, 520);
            lb_Notification.Name = "lb_Notification";
            lb_Notification.Size = new Size(376, 25);
            lb_Notification.TabIndex = 9;
            lb_Notification.Text = "Nhấn đúp để thay đổi thông tin sinh viên";
            lb_Notification.Click += lb_Notification_Click;
            // 
            // f_ListStudent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1097, 573);
            Controls.Add(lb_Notification);
            Controls.Add(lblCurrentUser);
            Controls.Add(txtSearch);
            Controls.Add(lblSort);
            Controls.Add(cboSort);
            Controls.Add(btnAddStudent);
            Controls.Add(dgvStudents);
            Controls.Add(lblTotal);
            Controls.Add(btnRefresh);
            Controls.Add(lblGenderFilter);
            Controls.Add(cboGenderFilter);
            Margin = new Padding(3, 4, 3, 4);
            Name = "f_ListStudent";
            Text = "Danh sách sinh viên";
            Load += f_ListStudent_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvStudents;
        private TextBox txtSearch;
        private ComboBox cboSort;
        private Label lblSort;
        private Label lblTotal;
        private Label lblCurrentUser;
        private Button btnAddStudent;
        private System.Windows.Forms.ComboBox cboGenderFilter;
        private System.Windows.Forms.Label lblGenderFilter;
        private System.Windows.Forms.Button btnRefresh;
        private Label lb_Notification;
    }
}