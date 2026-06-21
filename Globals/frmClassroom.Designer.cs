partial class frmClassroom
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
        pnlHeader = new Panel();
        lblTitle = new Label();
        pnlInput = new Panel();
        lblMaLop = new Label();
        txtMaLop = new TextBox();
        lblTenLop = new Label();
        txtTenLop = new TextBox();
        lblSiSo = new Label();
        nudSiSo = new NumericUpDown();
        lblGVCN = new Label();
        txtGVCN = new TextBox();
        btnAdd = new Button();
        btnEdit = new Button();
        btnDelete = new Button();
        btnClear = new Button();
        pnlSearch = new Panel();
        lblSearch = new Label();
        txtSearch = new TextBox();
        btnSearch = new Button();
        lblCount = new Label();
        dgvClassroom = new DataGridView();
        pnlHeader.SuspendLayout();
        pnlInput.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudSiSo).BeginInit();
        pnlSearch.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvClassroom).BeginInit();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(30, 80, 160);
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(1027, 56);
        pnlHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(0, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(1027, 56);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "🏫  QUẢN LÝ LỚP HỌC";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlInput
        // 
        pnlInput.BackColor = Color.FromArgb(240, 245, 255);
        pnlInput.BorderStyle = BorderStyle.FixedSingle;
        pnlInput.Controls.Add(txtTenLop);
        pnlInput.Controls.Add(lblMaLop);
        pnlInput.Controls.Add(txtMaLop);
        pnlInput.Controls.Add(lblTenLop);
        pnlInput.Controls.Add(lblSiSo);
        pnlInput.Controls.Add(nudSiSo);
        pnlInput.Controls.Add(lblGVCN);
        pnlInput.Controls.Add(txtGVCN);
        pnlInput.Controls.Add(btnAdd);
        pnlInput.Controls.Add(btnEdit);
        pnlInput.Controls.Add(btnDelete);
        pnlInput.Controls.Add(btnClear);
        pnlInput.Location = new Point(12, 68);
        pnlInput.Name = "pnlInput";
        pnlInput.Size = new Size(1003, 130);
        pnlInput.TabIndex = 1;
        // 
        // lblMaLop
        // 
        lblMaLop.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
        lblMaLop.Location = new Point(12, 20);
        lblMaLop.Name = "lblMaLop";
        lblMaLop.Size = new Size(70, 23);
        lblMaLop.TabIndex = 0;
        lblMaLop.Text = "Mã Lớp:";
        // 
        // txtMaLop
        // 
        txtMaLop.Location = new Point(83, 17);
        txtMaLop.Name = "txtMaLop";
        txtMaLop.Size = new Size(199, 30);
        txtMaLop.TabIndex = 1;
        // 
        // lblTenLop
        // 
        lblTenLop.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
        lblTenLop.Location = new Point(292, 20);
        lblTenLop.Name = "lblTenLop";
        lblTenLop.Size = new Size(80, 23);
        lblTenLop.TabIndex = 2;
        lblTenLop.Text = "Tên Lớp:";
        // 
        // txtTenLop
        // 
        txtTenLop.Location = new Point(364, 17);
        txtTenLop.Name = "txtTenLop";
        txtTenLop.Size = new Size(298, 30);
        txtTenLop.TabIndex = 3;
        // 
        // lblSiSo
        // 
        lblSiSo.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
        lblSiSo.Location = new Point(12, 88);
        lblSiSo.Name = "lblSiSo";
        lblSiSo.Size = new Size(70, 23);
        lblSiSo.TabIndex = 4;
        lblSiSo.Text = "Sĩ Số:";
        // 
        // nudSiSo
        // 
        nudSiSo.Font = new Font("Segoe UI", 10F);
        nudSiSo.Location = new Point(83, 85);
        nudSiSo.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
        nudSiSo.Name = "nudSiSo";
        nudSiSo.Size = new Size(80, 30);
        nudSiSo.TabIndex = 5;
        // 
        // lblGVCN
        // 
        lblGVCN.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
        lblGVCN.Location = new Point(292, 88);
        lblGVCN.Name = "lblGVCN";
        lblGVCN.Size = new Size(100, 23);
        lblGVCN.TabIndex = 6;
        lblGVCN.Text = "Giảng Viên:";
        // 
        // txtGVCN
        // 
        txtGVCN.Location = new Point(398, 83);
        txtGVCN.Name = "txtGVCN";
        txtGVCN.Size = new Size(264, 30);
        txtGVCN.TabIndex = 7;
        // 
        // btnAdd
        // 
        btnAdd.BackColor = Color.FromArgb(30, 130, 76);
        btnAdd.Cursor = Cursors.Hand;
        btnAdd.FlatAppearance.BorderSize = 0;
        btnAdd.FlatStyle = FlatStyle.Flat;
        btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnAdd.ForeColor = Color.White;
        btnAdd.Location = new Point(678, 14);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(117, 34);
        btnAdd.TabIndex = 8;
        btnAdd.Text = "＋ Thêm lớp";
        btnAdd.UseVisualStyleBackColor = false;
        btnAdd.Click += btnAdd_Click;
        // 
        // btnEdit
        // 
        btnEdit.BackColor = Color.Teal;
        btnEdit.Cursor = Cursors.Hand;
        btnEdit.FlatAppearance.BorderSize = 0;
        btnEdit.FlatStyle = FlatStyle.Flat;
        btnEdit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnEdit.ForeColor = Color.White;
        btnEdit.Location = new Point(836, 81);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(146, 34);
        btnEdit.TabIndex = 9;
        btnEdit.Text = "✎ Sửa thông tin";
        btnEdit.UseVisualStyleBackColor = false;
        btnEdit.Click += btnEdit_Click;
        // 
        // btnDelete
        // 
        btnDelete.BackColor = Color.FromArgb(192, 64, 0);
        btnDelete.Cursor = Cursors.Hand;
        btnDelete.FlatAppearance.BorderSize = 0;
        btnDelete.FlatStyle = FlatStyle.Flat;
        btnDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnDelete.ForeColor = Color.White;
        btnDelete.Location = new Point(678, 81);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(117, 34);
        btnDelete.TabIndex = 10;
        btnDelete.Text = "🗑  Xóa lớp";
        btnDelete.UseVisualStyleBackColor = false;
        btnDelete.Click += btnDelete_Click;
        // 
        // btnClear
        // 
        btnClear.BackColor = Color.Teal;
        btnClear.Cursor = Cursors.Hand;
        btnClear.FlatAppearance.BorderSize = 0;
        btnClear.FlatStyle = FlatStyle.Flat;
        btnClear.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnClear.ForeColor = Color.White;
        btnClear.Location = new Point(836, 14);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(146, 34);
        btnClear.TabIndex = 11;
        btnClear.Text = "❌ Hủy bỏ";
        btnClear.UseVisualStyleBackColor = false;
        btnClear.Click += btnClear_Click;
        // 
        // pnlSearch
        // 
        pnlSearch.BackColor = Color.White;
        pnlSearch.BorderStyle = BorderStyle.FixedSingle;
        pnlSearch.Controls.Add(lblSearch);
        pnlSearch.Controls.Add(txtSearch);
        pnlSearch.Controls.Add(btnSearch);
        pnlSearch.Controls.Add(lblCount);
        pnlSearch.Location = new Point(12, 210);
        pnlSearch.Name = "pnlSearch";
        pnlSearch.Size = new Size(1003, 44);
        pnlSearch.TabIndex = 2;
        // 
        // lblSearch
        // 
        lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblSearch.Location = new Point(12, 10);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(90, 23);
        lblSearch.TabIndex = 0;
        lblSearch.Text = "Tìm kiếm:";
        // 
        // txtSearch
        // 
        txtSearch.Font = new Font("Segoe UI", 10F);
        txtSearch.Location = new Point(106, 7);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "Nhập tên lớp hoặc mã lớp...";
        txtSearch.Size = new Size(340, 30);
        txtSearch.TabIndex = 1;
        txtSearch.TextChanged += txtSearch_TextChanged;
        // 
        // btnSearch
        // 
        btnSearch.BackColor = Color.FromArgb(30, 80, 160);
        btnSearch.Cursor = Cursors.Hand;
        btnSearch.FlatAppearance.BorderSize = 0;
        btnSearch.FlatStyle = FlatStyle.Flat;
        btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnSearch.ForeColor = Color.White;
        btnSearch.Location = new Point(452, 8);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(90, 28);
        btnSearch.TabIndex = 2;
        btnSearch.Text = "🔍  Tìm";
        btnSearch.UseVisualStyleBackColor = false;
        btnSearch.Click += btnSearch_Click;
        // 
        // lblCount
        // 
        lblCount.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
        lblCount.ForeColor = Color.FromArgb(80, 80, 80);
        lblCount.Location = new Point(692, 9);
        lblCount.Name = "lblCount";
        lblCount.Size = new Size(290, 24);
        lblCount.TabIndex = 3;
        lblCount.Text = "Tổng số lớp: 0";
        lblCount.TextAlign = ContentAlignment.MiddleRight;
        // 
        // dgvClassroom
        // 
        dgvClassroom.AllowUserToAddRows = false;
        dgvClassroom.AllowUserToDeleteRows = false;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 255);
        dgvClassroom.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        dgvClassroom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvClassroom.BackgroundColor = Color.White;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 80, 160);
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dataGridViewCellStyle2.ForeColor = Color.White;
        dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
        dgvClassroom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        dgvClassroom.ColumnHeadersHeight = 36;
        dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = SystemColors.Window;
        dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
        dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(198, 218, 255);
        dataGridViewCellStyle3.SelectionForeColor = Color.Black;
        dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
        dgvClassroom.DefaultCellStyle = dataGridViewCellStyle3;
        dgvClassroom.EnableHeadersVisualStyles = false;
        dgvClassroom.Font = new Font("Segoe UI", 10F);
        dgvClassroom.GridColor = Color.FromArgb(220, 225, 235);
        dgvClassroom.Location = new Point(12, 262);
        dgvClassroom.Name = "dgvClassroom";
        dgvClassroom.ReadOnly = true;
        dgvClassroom.RowHeadersVisible = false;
        dgvClassroom.RowHeadersWidth = 51;
        dgvClassroom.RowTemplate.Height = 30;
        dgvClassroom.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvClassroom.Size = new Size(1003, 354);
        dgvClassroom.TabIndex = 3;
        dgvClassroom.CellClick += dgvClassroom_CellClick;
        dgvClassroom.CellContentClick += dgvClassroom_CellContentClick;
        // 
        // frmClassroom
        // 
        BackColor = Color.White;
        ClientSize = new Size(1027, 628);
        Controls.Add(pnlHeader);
        Controls.Add(pnlInput);
        Controls.Add(pnlSearch);
        Controls.Add(dgvClassroom);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "frmClassroom";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Quản Lý Lớp Học";
        pnlHeader.ResumeLayout(false);
        pnlInput.ResumeLayout(false);
        pnlInput.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudSiSo).EndInit();
        pnlSearch.ResumeLayout(false);
        pnlSearch.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvClassroom).EndInit();
        ResumeLayout(false);
    }

    // ── Fields ───────────────────────────────────────────────
    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Panel pnlInput;
    private System.Windows.Forms.Label lblMaLop;
    private System.Windows.Forms.TextBox txtMaLop;
    private System.Windows.Forms.Label lblTenLop;
    private System.Windows.Forms.TextBox txtTenLop;
    private System.Windows.Forms.Label lblSiSo;
    private System.Windows.Forms.NumericUpDown nudSiSo;
    private System.Windows.Forms.Label lblGVCN;
    private System.Windows.Forms.TextBox txtGVCN;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnEdit;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Panel pnlSearch;
    private System.Windows.Forms.Label lblSearch;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.Label lblCount;
    private System.Windows.Forms.DataGridView dgvClassroom;

    #endregion
}