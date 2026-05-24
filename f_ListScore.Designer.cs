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
            lblStudentInfo = new Label();
            lblSelectStudent = new Label();
            cboSelectStudent = new ComboBox();
            btnRefresh = new Button();
            lb_Notification = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvScores).BeginInit();
            SuspendLayout();
            // 
            // dgvScores
            // 
            dgvScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvScores.Location = new Point(31, 211);
            dgvScores.Margin = new Padding(3, 4, 3, 4);
            dgvScores.Name = "dgvScores";
            dgvScores.RowHeadersWidth = 51;
            dgvScores.Size = new Size(1027, 288);
            dgvScores.TabIndex = 0;
            dgvScores.CellContentClick += dgvScores_CellContentClick;
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
            cboSort.Location = new Point(178, 166);
            cboSort.Margin = new Padding(3, 4, 3, 4);
            cboSort.Name = "cboSort";
            cboSort.Size = new Size(250, 33);
            cboSort.TabIndex = 2;
            cboSort.SelectedIndexChanged += cboSort_SelectedIndexChanged;
            // 
            // lblSort
            // 
            lblSort.AutoSize = true;
            lblSort.Font = new Font("Segoe UI", 11F);
            lblSort.Location = new Point(31, 166);
            lblSort.Name = "lblSort";
            lblSort.Size = new Size(82, 25);
            lblSort.TabIndex = 3;
            lblSort.Text = "Sắp xếp:";
            lblSort.Click += lblSort_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotal.Location = new Point(31, 520);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(151, 25);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Tổng số môn: 0";
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
            lblCurrentUser.TabIndex = 5;
            lblCurrentUser.Text = "Đang đăng nhập: ...";
            // 
            // lblStudentInfo
            // 
            lblStudentInfo.AutoSize = true;
            lblStudentInfo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblStudentInfo.ForeColor = Color.DarkSlateBlue;
            lblStudentInfo.Location = new Point(468, 169);
            lblStudentInfo.Name = "lblStudentInfo";
            lblStudentInfo.Size = new Size(196, 30);
            lblStudentInfo.TabIndex = 6;
            lblStudentInfo.Text = "Bảng điểm của: ...";
            lblStudentInfo.Visible = false;
            lblStudentInfo.Click += lblStudentInfo_Click;
            // 
            // lblSelectStudent
            // 
            lblSelectStudent.AutoSize = true;
            lblSelectStudent.Font = new Font("Segoe UI", 11F);
            lblSelectStudent.Location = new Point(31, 126);
            lblSelectStudent.Name = "lblSelectStudent";
            lblSelectStudent.Size = new Size(141, 25);
            lblSelectStudent.TabIndex = 7;
            lblSelectStudent.Text = "Chọn sinh viên:";
            lblSelectStudent.Visible = false;
            // 
            // cboSelectStudent
            // 
            cboSelectStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSelectStudent.Font = new Font("Segoe UI", 11F);
            cboSelectStudent.Location = new Point(178, 118);
            cboSelectStudent.Name = "cboSelectStudent";
            cboSelectStudent.Size = new Size(250, 33);
            cboSelectStudent.TabIndex = 8;
            cboSelectStudent.Visible = false;
            cboSelectStudent.SelectedIndexChanged += cboSelectStudent_SelectedIndexChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Orange;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(909, 73);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(149, 47);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "Làm mới ↻";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lb_Notification
            // 
            lb_Notification.AutoSize = true;
            lb_Notification.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lb_Notification.Location = new Point(580, 520);
            lb_Notification.Name = "lb_Notification";
            lb_Notification.Size = new Size(337, 25);
            lb_Notification.TabIndex = 10;
            lb_Notification.Text = "Nhấn đúp để thay đổi điểm môn học";
            lb_Notification.Click += lb_Notification_Click;
            // 
            // f_ListScore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1097, 573);
            Controls.Add(lb_Notification);
            Controls.Add(lblStudentInfo);
            Controls.Add(lblSelectStudent);
            Controls.Add(cboSelectStudent);
            Controls.Add(lblCurrentUser);
            Controls.Add(txtSearch);
            Controls.Add(lblSort);
            Controls.Add(cboSort);
            Controls.Add(dgvScores);
            Controls.Add(lblTotal);
            Controls.Add(btnRefresh);
            Margin = new Padding(3, 4, 3, 4);
            Name = "f_ListScore";
            Text = "Bảng điểm môn học";
            Load += f_ListScore_Load;
            ((System.ComponentModel.ISupportInitialize)dgvScores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvScores;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboSort;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label lblStudentInfo;
        private System.Windows.Forms.Label lblSelectStudent;
        private System.Windows.Forms.ComboBox cboSelectStudent;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lb_Notification;
    }
}