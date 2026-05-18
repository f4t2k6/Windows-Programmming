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
            btnLogout = new Button();
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
            cboSort.Location = new Point(503, 80);
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
            lblSort.Location = new Point(423, 87);
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
            btnAddStudent.Location = new Point(746, 73);
            btnAddStudent.Margin = new Padding(3, 4, 3, 4);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(157, 47);
            btnAddStudent.TabIndex = 3;
            btnAddStudent.Text = "+ Thêm sinh viên";
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.IndianRed;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(914, 73);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(114, 47);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // f_ListStudent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1097, 573);
            Controls.Add(lblCurrentUser);
            Controls.Add(txtSearch);
            Controls.Add(lblSort);
            Controls.Add(cboSort);
            Controls.Add(btnAddStudent);
            Controls.Add(btnLogout);
            Controls.Add(dgvStudents);
            Controls.Add(lblTotal);
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
        private Button btnLogout;
    }
}