namespace ProjectMonHoc
{
    partial class f_ManageCourse
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
            tabControl = new TabControl();
            tabAdd = new TabPage();
            lblAddMa = new Label();
            txtAddMa = new TextBox();
            lblAddTen = new Label();
            txtAddTen = new TextBox();
            lblAddTc = new Label();
            nudAddTc = new NumericUpDown();
            lblAddTuan = new Label();
            nudAddTuan = new NumericUpDown();
            lblAddHk = new Label();
            cboAddHk = new ComboBox();
            lblAddMota = new Label();
            txtAddMota = new TextBox();
            btnAdd = new Button();
            btnAddClear = new Button();
            tabEdit = new TabPage();
            lblEditSearch = new Label();
            txtEditSearch = new TextBox();
            btnEditLoad = new Button();
            dgvEdit = new DataGridView();
            lblEditMa = new Label();
            txtEditMa = new TextBox();
            lblEditTen = new Label();
            txtEditTen = new TextBox();
            lblEditTc = new Label();
            nudEditTc = new NumericUpDown();
            lblEditTuan = new Label();
            nudEditTuan = new NumericUpDown();
            lblEditHk = new Label();
            cboEditHk = new ComboBox();
            lblEditMota = new Label();
            txtEditMota = new TextBox();
            btnEdit = new Button();
            btnEditClear = new Button();
            tabDel = new TabPage();
            lblDelSearch = new Label();
            txtDelSearch = new TextBox();
            cboDelHk = new ComboBox();
            btnDelLoad = new Button();
            dgvDel = new DataGridView();
            lblDelSelected = new Label();
            txtDelMa = new TextBox();
            btnDel = new Button();
            tabControl.SuspendLayout();
            tabAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAddTc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAddTuan).BeginInit();
            tabEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEditTc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEditTuan).BeginInit();
            tabDel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDel).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabAdd);
            tabControl.Controls.Add(tabEdit);
            tabControl.Controls.Add(tabDel);
            tabControl.Location = new Point(10, 10);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(752, 457);
            tabControl.TabIndex = 0;
            // 
            // tabAdd
            // 
            tabAdd.Controls.Add(lblAddMa);
            tabAdd.Controls.Add(txtAddMa);
            tabAdd.Controls.Add(lblAddTen);
            tabAdd.Controls.Add(txtAddTen);
            tabAdd.Controls.Add(lblAddTc);
            tabAdd.Controls.Add(nudAddTc);
            tabAdd.Controls.Add(lblAddTuan);
            tabAdd.Controls.Add(nudAddTuan);
            tabAdd.Controls.Add(lblAddHk);
            tabAdd.Controls.Add(cboAddHk);
            tabAdd.Controls.Add(lblAddMota);
            tabAdd.Controls.Add(txtAddMota);
            tabAdd.Controls.Add(btnAdd);
            tabAdd.Controls.Add(btnAddClear);
            tabAdd.Location = new Point(4, 30);
            tabAdd.Name = "tabAdd";
            tabAdd.Padding = new Padding(10);
            tabAdd.Size = new Size(744, 423);
            tabAdd.TabIndex = 0;
            tabAdd.Text = "  ➕  Thêm môn học  ";
            // 
            // lblAddMa
            // 
            lblAddMa.Location = new Point(30, 23);
            lblAddMa.Name = "lblAddMa";
            lblAddMa.Size = new Size(145, 22);
            lblAddMa.TabIndex = 0;
            lblAddMa.Text = "Mã môn học *";
            lblAddMa.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtAddMa
            // 
            txtAddMa.Location = new Point(180, 20);
            txtAddMa.Name = "txtAddMa";
            txtAddMa.Size = new Size(200, 29);
            txtAddMa.TabIndex = 1;
            // 
            // lblAddTen
            // 
            lblAddTen.Location = new Point(30, 63);
            lblAddTen.Name = "lblAddTen";
            lblAddTen.Size = new Size(145, 22);
            lblAddTen.TabIndex = 2;
            lblAddTen.Text = "Tên môn học *";
            lblAddTen.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtAddTen
            // 
            txtAddTen.Location = new Point(180, 60);
            txtAddTen.Name = "txtAddTen";
            txtAddTen.Size = new Size(400, 29);
            txtAddTen.TabIndex = 3;
            // 
            // lblAddTc
            // 
            lblAddTc.Location = new Point(30, 103);
            lblAddTc.Name = "lblAddTc";
            lblAddTc.Size = new Size(145, 22);
            lblAddTc.TabIndex = 4;
            lblAddTc.Text = "Số tín chỉ *";
            lblAddTc.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nudAddTc
            // 
            nudAddTc.Location = new Point(180, 100);
            nudAddTc.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudAddTc.Name = "nudAddTc";
            nudAddTc.Size = new Size(80, 29);
            nudAddTc.TabIndex = 5;
            nudAddTc.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // lblAddTuan
            // 
            lblAddTuan.Location = new Point(30, 143);
            lblAddTuan.Name = "lblAddTuan";
            lblAddTuan.Size = new Size(145, 22);
            lblAddTuan.TabIndex = 6;
            lblAddTuan.Text = "Số tuần";
            lblAddTuan.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nudAddTuan
            // 
            nudAddTuan.Location = new Point(180, 140);
            nudAddTuan.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudAddTuan.Name = "nudAddTuan";
            nudAddTuan.Size = new Size(80, 29);
            nudAddTuan.TabIndex = 7;
            nudAddTuan.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // lblAddHk
            // 
            lblAddHk.Location = new Point(30, 183);
            lblAddHk.Name = "lblAddHk";
            lblAddHk.Size = new Size(145, 22);
            lblAddHk.TabIndex = 8;
            lblAddHk.Text = "Học kỳ *";
            lblAddHk.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboAddHk
            // 
            cboAddHk.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAddHk.Location = new Point(180, 180);
            cboAddHk.Name = "cboAddHk";
            cboAddHk.Size = new Size(120, 29);
            cboAddHk.TabIndex = 9;
            // 
            // lblAddMota
            // 
            lblAddMota.Location = new Point(30, 223);
            lblAddMota.Name = "lblAddMota";
            lblAddMota.Size = new Size(145, 22);
            lblAddMota.TabIndex = 10;
            lblAddMota.Text = "Mô tả";
            lblAddMota.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtAddMota
            // 
            txtAddMota.Location = new Point(180, 220);
            txtAddMota.Multiline = true;
            txtAddMota.Name = "txtAddMota";
            txtAddMota.ScrollBars = ScrollBars.Vertical;
            txtAddMota.Size = new Size(400, 70);
            txtAddMota.TabIndex = 11;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 120, 215);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(180, 310);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 32);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnAddClear
            // 
            btnAddClear.BackColor = Color.FromArgb(220, 220, 220);
            btnAddClear.FlatAppearance.BorderSize = 0;
            btnAddClear.FlatStyle = FlatStyle.Flat;
            btnAddClear.Location = new Point(300, 310);
            btnAddClear.Name = "btnAddClear";
            btnAddClear.Size = new Size(110, 32);
            btnAddClear.TabIndex = 13;
            btnAddClear.Text = "Làm mới";
            btnAddClear.UseVisualStyleBackColor = false;
            // 
            // tabEdit
            // 
            tabEdit.Controls.Add(lblEditSearch);
            tabEdit.Controls.Add(txtEditSearch);
            tabEdit.Controls.Add(btnEditLoad);
            tabEdit.Controls.Add(dgvEdit);
            tabEdit.Controls.Add(lblEditMa);
            tabEdit.Controls.Add(txtEditMa);
            tabEdit.Controls.Add(lblEditTen);
            tabEdit.Controls.Add(txtEditTen);
            tabEdit.Controls.Add(lblEditTc);
            tabEdit.Controls.Add(nudEditTc);
            tabEdit.Controls.Add(lblEditTuan);
            tabEdit.Controls.Add(nudEditTuan);
            tabEdit.Controls.Add(lblEditHk);
            tabEdit.Controls.Add(cboEditHk);
            tabEdit.Controls.Add(lblEditMota);
            tabEdit.Controls.Add(txtEditMota);
            tabEdit.Controls.Add(btnEdit);
            tabEdit.Controls.Add(btnEditClear);
            tabEdit.Location = new Point(4, 29);
            tabEdit.Name = "tabEdit";
            tabEdit.Size = new Size(738, 507);
            tabEdit.TabIndex = 1;
            tabEdit.Text = "  ✏️  Sửa môn học  ";
            // 
            // lblEditSearch
            // 
            lblEditSearch.Location = new Point(10, 18);
            lblEditSearch.Name = "lblEditSearch";
            lblEditSearch.Size = new Size(80, 22);
            lblEditSearch.TabIndex = 0;
            lblEditSearch.Text = "Tìm kiếm:";
            // 
            // txtEditSearch
            // 
            txtEditSearch.Location = new Point(100, 12);
            txtEditSearch.Name = "txtEditSearch";
            txtEditSearch.Size = new Size(280, 29);
            txtEditSearch.TabIndex = 1;
            // 
            // btnEditLoad
            // 
            btnEditLoad.BackColor = Color.FromArgb(220, 220, 220);
            btnEditLoad.FlatAppearance.BorderSize = 0;
            btnEditLoad.FlatStyle = FlatStyle.Flat;
            btnEditLoad.Location = new Point(395, 10);
            btnEditLoad.Name = "btnEditLoad";
            btnEditLoad.Size = new Size(130, 32);
            btnEditLoad.TabIndex = 2;
            btnEditLoad.Text = "Tải danh sách";
            btnEditLoad.UseVisualStyleBackColor = false;
            // 
            // dgvEdit
            // 
            dgvEdit.AllowUserToAddRows = false;
            dgvEdit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvEdit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEdit.BackgroundColor = Color.White;
            dgvEdit.ColumnHeadersHeight = 29;
            dgvEdit.Location = new Point(10, 50);
            dgvEdit.MultiSelect = false;
            dgvEdit.Name = "dgvEdit";
            dgvEdit.ReadOnly = true;
            dgvEdit.RowHeadersWidth = 51;
            dgvEdit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEdit.Size = new Size(716, 160);
            dgvEdit.TabIndex = 3;
            // 
            // lblEditMa
            // 
            lblEditMa.Location = new Point(30, 228);
            lblEditMa.Name = "lblEditMa";
            lblEditMa.Size = new Size(145, 22);
            lblEditMa.TabIndex = 4;
            lblEditMa.Text = "Mã môn học";
            lblEditMa.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtEditMa
            // 
            txtEditMa.BackColor = Color.FromArgb(240, 240, 240);
            txtEditMa.Location = new Point(180, 225);
            txtEditMa.Name = "txtEditMa";
            txtEditMa.ReadOnly = true;
            txtEditMa.Size = new Size(200, 29);
            txtEditMa.TabIndex = 5;
            // 
            // lblEditTen
            // 
            lblEditTen.Location = new Point(30, 268);
            lblEditTen.Name = "lblEditTen";
            lblEditTen.Size = new Size(145, 22);
            lblEditTen.TabIndex = 6;
            lblEditTen.Text = "Tên môn học *";
            lblEditTen.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtEditTen
            // 
            txtEditTen.Location = new Point(180, 265);
            txtEditTen.Name = "txtEditTen";
            txtEditTen.Size = new Size(400, 29);
            txtEditTen.TabIndex = 7;
            // 
            // lblEditTc
            // 
            lblEditTc.Location = new Point(30, 308);
            lblEditTc.Name = "lblEditTc";
            lblEditTc.Size = new Size(145, 22);
            lblEditTc.TabIndex = 8;
            lblEditTc.Text = "Số tín chỉ *";
            lblEditTc.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nudEditTc
            // 
            nudEditTc.Location = new Point(180, 305);
            nudEditTc.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudEditTc.Name = "nudEditTc";
            nudEditTc.Size = new Size(80, 29);
            nudEditTc.TabIndex = 9;
            nudEditTc.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // lblEditTuan
            // 
            lblEditTuan.Location = new Point(30, 348);
            lblEditTuan.Name = "lblEditTuan";
            lblEditTuan.Size = new Size(145, 22);
            lblEditTuan.TabIndex = 10;
            lblEditTuan.Text = "Số tuần";
            lblEditTuan.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nudEditTuan
            // 
            nudEditTuan.Location = new Point(180, 345);
            nudEditTuan.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudEditTuan.Name = "nudEditTuan";
            nudEditTuan.Size = new Size(80, 29);
            nudEditTuan.TabIndex = 11;
            nudEditTuan.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // lblEditHk
            // 
            lblEditHk.Location = new Point(30, 388);
            lblEditHk.Name = "lblEditHk";
            lblEditHk.Size = new Size(145, 22);
            lblEditHk.TabIndex = 12;
            lblEditHk.Text = "Học kỳ *";
            lblEditHk.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboEditHk
            // 
            cboEditHk.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEditHk.Location = new Point(180, 385);
            cboEditHk.Name = "cboEditHk";
            cboEditHk.Size = new Size(120, 29);
            cboEditHk.TabIndex = 13;
            // 
            // lblEditMota
            // 
            lblEditMota.Location = new Point(30, 428);
            lblEditMota.Name = "lblEditMota";
            lblEditMota.Size = new Size(145, 22);
            lblEditMota.TabIndex = 14;
            lblEditMota.Text = "Mô tả";
            lblEditMota.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtEditMota
            // 
            txtEditMota.Location = new Point(180, 425);
            txtEditMota.Multiline = true;
            txtEditMota.Name = "txtEditMota";
            txtEditMota.ScrollBars = ScrollBars.Vertical;
            txtEditMota.Size = new Size(400, 50);
            txtEditMota.TabIndex = 15;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(0, 120, 215);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(180, 480);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(130, 32);
            btnEdit.TabIndex = 16;
            btnEdit.Text = "Lưu thay đổi";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnEditClear
            // 
            btnEditClear.BackColor = Color.FromArgb(220, 220, 220);
            btnEditClear.FlatAppearance.BorderSize = 0;
            btnEditClear.FlatStyle = FlatStyle.Flat;
            btnEditClear.Location = new Point(320, 480);
            btnEditClear.Name = "btnEditClear";
            btnEditClear.Size = new Size(110, 32);
            btnEditClear.TabIndex = 17;
            btnEditClear.Text = "Bỏ chọn";
            btnEditClear.UseVisualStyleBackColor = false;
            // 
            // tabDel
            // 
            tabDel.Controls.Add(lblDelSearch);
            tabDel.Controls.Add(txtDelSearch);
            tabDel.Controls.Add(cboDelHk);
            tabDel.Controls.Add(btnDelLoad);
            tabDel.Controls.Add(dgvDel);
            tabDel.Controls.Add(lblDelSelected);
            tabDel.Controls.Add(txtDelMa);
            tabDel.Controls.Add(btnDel);
            tabDel.Location = new Point(4, 29);
            tabDel.Name = "tabDel";
            tabDel.Size = new Size(738, 507);
            tabDel.TabIndex = 2;
            tabDel.Text = "  🗑️  Xóa môn học  ";
            // 
            // lblDelSearch
            // 
            lblDelSearch.Location = new Point(10, 18);
            lblDelSearch.Name = "lblDelSearch";
            lblDelSearch.Size = new Size(80, 22);
            lblDelSearch.TabIndex = 0;
            lblDelSearch.Text = "Tìm kiếm:";
            // 
            // txtDelSearch
            // 
            txtDelSearch.Location = new Point(100, 12);
            txtDelSearch.Name = "txtDelSearch";
            txtDelSearch.Size = new Size(220, 29);
            txtDelSearch.TabIndex = 1;
            // 
            // cboDelHk
            // 
            cboDelHk.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDelHk.Location = new Point(335, 12);
            cboDelHk.Name = "cboDelHk";
            cboDelHk.Size = new Size(130, 29);
            cboDelHk.TabIndex = 2;
            // 
            // btnDelLoad
            // 
            btnDelLoad.BackColor = Color.FromArgb(220, 220, 220);
            btnDelLoad.FlatAppearance.BorderSize = 0;
            btnDelLoad.FlatStyle = FlatStyle.Flat;
            btnDelLoad.Location = new Point(478, 10);
            btnDelLoad.Name = "btnDelLoad";
            btnDelLoad.Size = new Size(130, 32);
            btnDelLoad.TabIndex = 3;
            btnDelLoad.Text = "Tải danh sách";
            btnDelLoad.UseVisualStyleBackColor = false;
            // 
            // dgvDel
            // 
            dgvDel.AllowUserToAddRows = false;
            dgvDel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDel.BackgroundColor = Color.White;
            dgvDel.ColumnHeadersHeight = 29;
            dgvDel.Location = new Point(10, 50);
            dgvDel.MultiSelect = false;
            dgvDel.Name = "dgvDel";
            dgvDel.ReadOnly = true;
            dgvDel.RowHeadersWidth = 51;
            dgvDel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDel.Size = new Size(716, 330);
            dgvDel.TabIndex = 4;
            // 
            // lblDelSelected
            // 
            lblDelSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblDelSelected.ForeColor = Color.Gray;
            lblDelSelected.Location = new Point(10, 392);
            lblDelSelected.Name = "lblDelSelected";
            lblDelSelected.Size = new Size(500, 24);
            lblDelSelected.TabIndex = 5;
            lblDelSelected.Text = "Chưa chọn môn học nào";
            // 
            // txtDelMa
            // 
            txtDelMa.Location = new Point(10, 390);
            txtDelMa.Name = "txtDelMa";
            txtDelMa.Size = new Size(0, 29);
            txtDelMa.TabIndex = 6;
            txtDelMa.Visible = false;
            // 
            // btnDel
            // 
            btnDel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDel.BackColor = Color.FromArgb(192, 0, 0);
            btnDel.FlatAppearance.BorderSize = 0;
            btnDel.FlatStyle = FlatStyle.Flat;
            btnDel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDel.ForeColor = Color.White;
            btnDel.Location = new Point(586, 388);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(140, 32);
            btnDel.TabIndex = 7;
            btnDel.Text = "Xóa môn học";
            btnDel.UseVisualStyleBackColor = false;
            // 
            // f_ManageCourse
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 478);
            Controls.Add(tabControl);
            Font = new Font("Segoe UI", 9.5F);
            Name = "f_ManageCourse";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Môn học";
            tabControl.ResumeLayout(false);
            tabAdd.ResumeLayout(false);
            tabAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAddTc).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAddTuan).EndInit();
            tabEdit.ResumeLayout(false);
            tabEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEditTc).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEditTuan).EndInit();
            tabDel.ResumeLayout(false);
            tabDel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDel).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAdd;
        private System.Windows.Forms.Label lblAddMa;
        private System.Windows.Forms.TextBox txtAddMa;
        private System.Windows.Forms.Label lblAddTen;
        private System.Windows.Forms.TextBox txtAddTen;
        private System.Windows.Forms.Label lblAddTc;
        private System.Windows.Forms.NumericUpDown nudAddTc;
        private System.Windows.Forms.Label lblAddTuan;
        private System.Windows.Forms.NumericUpDown nudAddTuan;
        private System.Windows.Forms.Label lblAddHk;
        private System.Windows.Forms.ComboBox cboAddHk;
        private System.Windows.Forms.Label lblAddMota;
        private System.Windows.Forms.TextBox txtAddMota;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddClear;
        private System.Windows.Forms.TabPage tabEdit;
        private System.Windows.Forms.Label lblEditSearch;
        private System.Windows.Forms.TextBox txtEditSearch;
        private System.Windows.Forms.Button btnEditLoad;
        private System.Windows.Forms.DataGridView dgvEdit;
        private System.Windows.Forms.Label lblEditMa;
        private System.Windows.Forms.TextBox txtEditMa;
        private System.Windows.Forms.Label lblEditTen;
        private System.Windows.Forms.TextBox txtEditTen;
        private System.Windows.Forms.Label lblEditTc;
        private System.Windows.Forms.NumericUpDown nudEditTc;
        private System.Windows.Forms.Label lblEditTuan;
        private System.Windows.Forms.NumericUpDown nudEditTuan;
        private System.Windows.Forms.Label lblEditHk;
        private System.Windows.Forms.ComboBox cboEditHk;
        private System.Windows.Forms.Label lblEditMota;
        private System.Windows.Forms.TextBox txtEditMota;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnEditClear;
        private System.Windows.Forms.TabPage tabDel;
        private System.Windows.Forms.Label lblDelSearch;
        private System.Windows.Forms.TextBox txtDelSearch;
        private System.Windows.Forms.ComboBox cboDelHk;
        private System.Windows.Forms.Button btnDelLoad;
        private System.Windows.Forms.DataGridView dgvDel;
        private System.Windows.Forms.Label lblDelSelected;
        private System.Windows.Forms.TextBox txtDelMa;
        private System.Windows.Forms.Button btnDel;
    }
}