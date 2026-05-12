namespace Day01
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
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();

            // dgvStudents
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(27, 158);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.Size = new Size(899, 216);
            dgvStudents.TabIndex = 0;

            // txtSearch
            txtSearch.BackColor = SystemColors.ActiveCaption;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 20F);
            txtSearch.Location = new Point(27, 58);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(300, 36);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "Tìm kiếm...";
            txtSearch.TextChanged += txtSearch_TextChanged;

            // lblSort
            lblSort.AutoSize = true;
            lblSort.Location = new Point(370, 65);
            lblSort.Name = "lblSort";
            lblSort.Text = "Sắp xếp:";
            lblSort.Font = new Font("Segoe UI", 11F);

            // cboSort
            cboSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSort.Location = new Point(440, 60);
            cboSort.Name = "cboSort";
            cboSort.Size = new Size(180, 25);
            cboSort.TabIndex = 2;
            cboSort.Font = new Font("Segoe UI", 11F);
            cboSort.SelectedIndexChanged += cboSort_SelectedIndexChanged;

            // lblTotal
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(27, 385);
            lblTotal.Name = "lblTotal";
            lblTotal.Text = "Tổng số sinh viên: 0";
            lblTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            // f_ListStudent
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(960, 420);
            Controls.Add(txtSearch);
            Controls.Add(lblSort);
            Controls.Add(cboSort);
            Controls.Add(dgvStudents);
            Controls.Add(lblTotal);
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
    }
}