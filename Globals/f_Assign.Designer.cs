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
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlContent = new Panel();
            pnlGrid = new Panel();
            dgvAssign = new DataGridView();
            pnlToolbar = new Panel();
            btnRefresh = new Button();
            btnRemove = new Button();
            btnAssign = new Button();
            cboCourse = new ComboBox();
            lblCourse = new Label();
            cboHR = new ComboBox();
            lblHR = new Label();
            pnlFooter = new Panel();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAssign).BeginInit();
            pnlToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(26, 95, 205);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1045, 52);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(24, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(231, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Phân công giảng dạy";
            lblTitle.Click += lblTitle_Click;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(245, 247, 252);
            pnlContent.Controls.Add(pnlGrid);
            pnlContent.Controls.Add(pnlToolbar);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 52);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(24, 20, 24, 0);
            pnlContent.Size = new Size(1045, 567);
            pnlContent.TabIndex = 0;
            // 
            // pnlGrid
            // 
            pnlGrid.BackColor = Color.White;
            pnlGrid.Controls.Add(dgvAssign);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Location = new Point(24, 130);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Padding = new Padding(1);
            pnlGrid.Size = new Size(997, 437);
            pnlGrid.TabIndex = 0;
            // 
            // dgvAssign
            // 
            dgvAssign.AllowUserToAddRows = false;
            dgvAssign.AllowUserToDeleteRows = false;
            dgvAssign.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 255);
            dgvAssign.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAssign.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAssign.BackgroundColor = Color.White;
            dgvAssign.BorderStyle = BorderStyle.None;
            dgvAssign.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(235, 242, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(26, 95, 205);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAssign.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAssign.ColumnHeadersHeight = 42;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(210, 228, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(20, 60, 160);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvAssign.DefaultCellStyle = dataGridViewCellStyle3;
            dgvAssign.Dock = DockStyle.Fill;
            dgvAssign.EnableHeadersVisualStyles = false;
            dgvAssign.Font = new Font("Segoe UI", 9F);
            dgvAssign.GridColor = Color.FromArgb(226, 232, 245);
            dgvAssign.Location = new Point(1, 1);
            dgvAssign.MultiSelect = false;
            dgvAssign.Name = "dgvAssign";
            dgvAssign.ReadOnly = true;
            dgvAssign.RowHeadersVisible = false;
            dgvAssign.RowHeadersWidth = 51;
            dgvAssign.RowTemplate.Height = 38;
            dgvAssign.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAssign.Size = new Size(995, 435);
            dgvAssign.TabIndex = 0;
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.Transparent;
            pnlToolbar.Controls.Add(btnRefresh);
            pnlToolbar.Controls.Add(btnRemove);
            pnlToolbar.Controls.Add(btnAssign);
            pnlToolbar.Controls.Add(cboCourse);
            pnlToolbar.Controls.Add(lblCourse);
            pnlToolbar.Controls.Add(cboHR);
            pnlToolbar.Controls.Add(lblHR);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(24, 20);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(997, 110);
            pnlToolbar.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.White;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(200, 210, 230);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.FromArgb(26, 95, 205);
            btnRefresh.Location = new Point(16, 67);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(107, 37);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "⟳ Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.FromArgb(210, 43, 43);
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(876, 64);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(114, 38);
            btnRemove.TabIndex = 1;
            btnRemove.Text = "Hủy";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnAssign
            // 
            btnAssign.BackColor = Color.FromArgb(26, 95, 205);
            btnAssign.Cursor = Cursors.Hand;
            btnAssign.FlatAppearance.BorderSize = 0;
            btnAssign.FlatStyle = FlatStyle.Flat;
            btnAssign.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAssign.ForeColor = Color.White;
            btnAssign.Location = new Point(876, 7);
            btnAssign.Name = "btnAssign";
            btnAssign.Size = new Size(114, 38);
            btnAssign.TabIndex = 2;
            btnAssign.Text = "Phân công";
            btnAssign.UseVisualStyleBackColor = false;
            btnAssign.Click += btnAssign_Click;
            // 
            // cboCourse
            // 
            cboCourse.BackColor = Color.White;
            cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCourse.FlatStyle = FlatStyle.Flat;
            cboCourse.Font = new Font("Segoe UI", 10F);
            cboCourse.ForeColor = Color.FromArgb(40, 40, 40);
            cboCourse.Location = new Point(448, 28);
            cboCourse.Name = "cboCourse";
            cboCourse.Size = new Size(397, 31);
            cboCourse.TabIndex = 3;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Font = new Font("Segoe UI", 8.5F);
            lblCourse.ForeColor = Color.FromArgb(100, 116, 139);
            lblCourse.Location = new Point(448, 5);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(105, 20);
            lblCourse.TabIndex = 4;
            lblCourse.Text = "Chọn môn học";
            // 
            // cboHR
            // 
            cboHR.BackColor = Color.White;
            cboHR.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHR.FlatStyle = FlatStyle.Flat;
            cboHR.Font = new Font("Segoe UI", 10F);
            cboHR.ForeColor = Color.FromArgb(40, 40, 40);
            cboHR.Location = new Point(16, 28);
            cboHR.Name = "cboHR";
            cboHR.Size = new Size(380, 31);
            cboHR.TabIndex = 5;
            // 
            // lblHR
            // 
            lblHR.AutoSize = true;
            lblHR.Font = new Font("Segoe UI", 8.5F);
            lblHR.ForeColor = Color.FromArgb(100, 116, 139);
            lblHR.Location = new Point(16, 5);
            lblHR.Name = "lblHR";
            lblHR.Size = new Size(181, 20);
            lblHR.TabIndex = 6;
            lblHR.Text = "Chọn nhân sự / giảng viên";
            lblHR.Click += lblHR_Click;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(235, 242, 255);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 619);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Padding = new Padding(24, 10, 24, 10);
            pnlFooter.Size = new Size(1045, 56);
            pnlFooter.TabIndex = 1;
            // 
            // f_Assign
            // 
            BackColor = Color.FromArgb(245, 247, 252);
            ClientSize = new Size(1045, 675);
            Controls.Add(pnlContent);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "f_Assign";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Phân công giảng dạy";
            Load += f_Assign_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAssign).EndInit();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblHR;
        private System.Windows.Forms.ComboBox cboHR;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.ComboBox cboCourse;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvAssign;
        private Panel pnlFooter;
    }
}