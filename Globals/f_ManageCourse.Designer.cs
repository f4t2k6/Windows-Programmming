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
            // ── Khai báo controls ─────────────────────────────────
            tabControl = new TabControl();

            // Tab Thêm
            tabAdd = new TabPage();
            lblAddSearch = new Label();
            txtAddSearch = new TextBox();
            lblAddHkSearch = new Label();
            cboAddHkSearch = new ComboBox();
            btnAddLoad = new Button();
            dgvAdd = new DataGridView();
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

            // Tab Sửa
            tabEdit = new TabPage();
            lblEditSearch = new Label();
            txtEditSearch = new TextBox();
            lblEditHkSearch = new Label();
            cboEditHkSearch = new ComboBox();
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

            // Tab Xóa
            tabDel = new TabPage();
            lblDelSearch = new Label();
            txtDelSearch = new TextBox();
            lblDelHkSearch = new Label();
            cboDelHk = new ComboBox();
            btnDelLoad = new Button();
            dgvDel = new DataGridView();
            lblDelSelected = new Label();
            txtDelMa = new TextBox();
            btnDel = new Button();

            // ── BeginInit ─────────────────────────────────────────
            tabControl.SuspendLayout();
            tabAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAddTc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAddTuan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdd).BeginInit();
            tabEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEditTc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEditTuan).BeginInit();
            tabDel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDel).BeginInit();
            SuspendLayout();

            // ════════════════════════════════════════════════════════
            // tabControl
            // ════════════════════════════════════════════════════════
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabAdd);
            tabControl.Controls.Add(tabEdit);
            tabControl.Controls.Add(tabDel);
            tabControl.Location = new Point(10, 10);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(960, 660);
            tabControl.TabIndex = 0;

            // ════════════════════════════════════════════════════════
            // TAB THÊM
            // ════════════════════════════════════════════════════════
            tabAdd.Controls.Add(lblAddSearch);
            tabAdd.Controls.Add(txtAddSearch);
            tabAdd.Controls.Add(lblAddHkSearch);
            tabAdd.Controls.Add(cboAddHkSearch);
            tabAdd.Controls.Add(btnAddLoad);
            tabAdd.Controls.Add(dgvAdd);
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
            tabAdd.Size = new Size(952, 626);
            tabAdd.TabIndex = 0;
            tabAdd.Text = "  ➕  Thêm môn học  ";

            // -- Thanh tìm kiếm --
            lblAddSearch.Location = new Point(10, 15);
            lblAddSearch.Name = "lblAddSearch";
            lblAddSearch.Size = new Size(70, 22);
            lblAddSearch.TabIndex = 0;
            lblAddSearch.Text = "Tìm kiếm:";
            lblAddSearch.TextAlign = ContentAlignment.MiddleRight;

            txtAddSearch.Location = new Point(85, 12);
            txtAddSearch.Name = "txtAddSearch";
            txtAddSearch.Size = new Size(240, 29);
            txtAddSearch.TabIndex = 1;

            lblAddHkSearch.Location = new Point(335, 15);
            lblAddHkSearch.Name = "lblAddHkSearch";
            lblAddHkSearch.Size = new Size(60, 22);
            lblAddHkSearch.TabIndex = 2;
            lblAddHkSearch.Text = "Học kỳ:";
            lblAddHkSearch.TextAlign = ContentAlignment.MiddleRight;

            cboAddHkSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAddHkSearch.Location = new Point(400, 12);
            cboAddHkSearch.Name = "cboAddHkSearch";
            cboAddHkSearch.Size = new Size(110, 29);
            cboAddHkSearch.TabIndex = 3;

            btnAddLoad.BackColor = Color.FromArgb(220, 220, 220);
            btnAddLoad.FlatAppearance.BorderSize = 0;
            btnAddLoad.FlatStyle = FlatStyle.Flat;
            btnAddLoad.Location = new Point(522, 10);
            btnAddLoad.Name = "btnAddLoad";
            btnAddLoad.Size = new Size(120, 32);
            btnAddLoad.TabIndex = 4;
            btnAddLoad.Text = "Tải danh sách";
            btnAddLoad.UseVisualStyleBackColor = false;

            // -- DataGridView --
            dgvAdd.AllowUserToAddRows = false;
            dgvAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvAdd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAdd.BackgroundColor = Color.White;
            dgvAdd.ColumnHeadersHeight = 29;
            dgvAdd.Location = new Point(10, 50);
            dgvAdd.MultiSelect = false;
            dgvAdd.Name = "dgvAdd";
            dgvAdd.ReadOnly = true;
            dgvAdd.RowHeadersWidth = 51;
            dgvAdd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdd.Size = new Size(930, 280);
            dgvAdd.TabIndex = 5;

            // -- Form nhập liệu (bên dưới DGV, y bắt đầu từ 345) --
            lblAddMa.Location = new Point(30, 348);
            lblAddMa.Name = "lblAddMa";
            lblAddMa.Size = new Size(145, 22);
            lblAddMa.TabIndex = 6;
            lblAddMa.Text = "Mã môn học *";
            lblAddMa.TextAlign = ContentAlignment.MiddleRight;

            txtAddMa.Location = new Point(180, 345);
            txtAddMa.Name = "txtAddMa";
            txtAddMa.Size = new Size(200, 29);
            txtAddMa.TabIndex = 7;

            lblAddTen.Location = new Point(30, 388);
            lblAddTen.Name = "lblAddTen";
            lblAddTen.Size = new Size(145, 22);
            lblAddTen.TabIndex = 8;
            lblAddTen.Text = "Tên môn học *";
            lblAddTen.TextAlign = ContentAlignment.MiddleRight;

            txtAddTen.Location = new Point(180, 385);
            txtAddTen.Name = "txtAddTen";
            txtAddTen.Size = new Size(400, 29);
            txtAddTen.TabIndex = 9;

            lblAddTc.Location = new Point(30, 428);
            lblAddTc.Name = "lblAddTc";
            lblAddTc.Size = new Size(145, 22);
            lblAddTc.TabIndex = 10;
            lblAddTc.Text = "Số tín chỉ *";
            lblAddTc.TextAlign = ContentAlignment.MiddleRight;

            nudAddTc.Location = new Point(180, 425);
            nudAddTc.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudAddTc.Name = "nudAddTc";
            nudAddTc.Size = new Size(80, 29);
            nudAddTc.TabIndex = 11;
            nudAddTc.Value = new decimal(new int[] { 3, 0, 0, 0 });

            lblAddTuan.Location = new Point(280, 428);
            lblAddTuan.Name = "lblAddTuan";
            lblAddTuan.Size = new Size(80, 22);
            lblAddTuan.TabIndex = 12;
            lblAddTuan.Text = "Số tuần:";
            lblAddTuan.TextAlign = ContentAlignment.MiddleRight;

            nudAddTuan.Location = new Point(365, 425);
            nudAddTuan.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudAddTuan.Name = "nudAddTuan";
            nudAddTuan.Size = new Size(80, 29);
            nudAddTuan.TabIndex = 13;
            nudAddTuan.Value = new decimal(new int[] { 15, 0, 0, 0 });

            lblAddHk.Location = new Point(460, 428);
            lblAddHk.Name = "lblAddHk";
            lblAddHk.Size = new Size(70, 22);
            lblAddHk.TabIndex = 14;
            lblAddHk.Text = "Học kỳ *";
            lblAddHk.TextAlign = ContentAlignment.MiddleRight;

            cboAddHk.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAddHk.Location = new Point(535, 425);
            cboAddHk.Name = "cboAddHk";
            cboAddHk.Size = new Size(100, 29);
            cboAddHk.TabIndex = 15;

            lblAddMota.Location = new Point(30, 468);
            lblAddMota.Name = "lblAddMota";
            lblAddMota.Size = new Size(145, 22);
            lblAddMota.TabIndex = 16;
            lblAddMota.Text = "Mô tả";
            lblAddMota.TextAlign = ContentAlignment.MiddleRight;

            txtAddMota.Location = new Point(180, 465);
            txtAddMota.Multiline = true;
            txtAddMota.Name = "txtAddMota";
            txtAddMota.ScrollBars = ScrollBars.Vertical;
            txtAddMota.Size = new Size(455, 60);
            txtAddMota.TabIndex = 17;

            btnAdd.BackColor = Color.FromArgb(0, 120, 215);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(180, 540);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(130, 32);
            btnAdd.TabIndex = 18;
            btnAdd.Text = "➕  Thêm môn học";
            btnAdd.UseVisualStyleBackColor = false;

            btnAddClear.BackColor = Color.FromArgb(220, 220, 220);
            btnAddClear.FlatAppearance.BorderSize = 0;
            btnAddClear.FlatStyle = FlatStyle.Flat;
            btnAddClear.Location = new Point(322, 540);
            btnAddClear.Name = "btnAddClear";
            btnAddClear.Size = new Size(110, 32);
            btnAddClear.TabIndex = 19;
            btnAddClear.Text = "Làm mới";
            btnAddClear.UseVisualStyleBackColor = false;

            // ════════════════════════════════════════════════════════
            // TAB SỬA
            // ════════════════════════════════════════════════════════
            tabEdit.Controls.Add(lblEditSearch);
            tabEdit.Controls.Add(txtEditSearch);
            tabEdit.Controls.Add(lblEditHkSearch);
            tabEdit.Controls.Add(cboEditHkSearch);
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
            tabEdit.Location = new Point(4, 30);
            tabEdit.Name = "tabEdit";
            tabEdit.Size = new Size(952, 626);
            tabEdit.TabIndex = 1;
            tabEdit.Text = "  ✏️  Sửa môn học  ";

            lblEditSearch.Location = new Point(10, 15);
            lblEditSearch.Name = "lblEditSearch";
            lblEditSearch.Size = new Size(70, 22);
            lblEditSearch.TabIndex = 0;
            lblEditSearch.Text = "Tìm kiếm:";
            lblEditSearch.TextAlign = ContentAlignment.MiddleRight;

            txtEditSearch.Location = new Point(85, 12);
            txtEditSearch.Name = "txtEditSearch";
            txtEditSearch.Size = new Size(240, 29);
            txtEditSearch.TabIndex = 1;

            lblEditHkSearch.Location = new Point(335, 15);
            lblEditHkSearch.Name = "lblEditHkSearch";
            lblEditHkSearch.Size = new Size(60, 22);
            lblEditHkSearch.TabIndex = 2;
            lblEditHkSearch.Text = "Học kỳ:";
            lblEditHkSearch.TextAlign = ContentAlignment.MiddleRight;

            cboEditHkSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEditHkSearch.Location = new Point(400, 12);
            cboEditHkSearch.Name = "cboEditHkSearch";
            cboEditHkSearch.Size = new Size(110, 29);
            cboEditHkSearch.TabIndex = 3;

            btnEditLoad.BackColor = Color.FromArgb(220, 220, 220);
            btnEditLoad.FlatAppearance.BorderSize = 0;
            btnEditLoad.FlatStyle = FlatStyle.Flat;
            btnEditLoad.Location = new Point(522, 10);
            btnEditLoad.Name = "btnEditLoad";
            btnEditLoad.Size = new Size(120, 32);
            btnEditLoad.TabIndex = 4;
            btnEditLoad.Text = "Tải danh sách";
            btnEditLoad.UseVisualStyleBackColor = false;

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
            dgvEdit.Size = new Size(930, 280);
            dgvEdit.TabIndex = 5;
            dgvEdit.CellContentClick += dgvEdit_CellContentClick;

            lblEditMa.Location = new Point(30, 348);
            lblEditMa.Name = "lblEditMa";
            lblEditMa.Size = new Size(145, 22);
            lblEditMa.TabIndex = 6;
            lblEditMa.Text = "Mã môn học";
            lblEditMa.TextAlign = ContentAlignment.MiddleRight;

            txtEditMa.BackColor = Color.FromArgb(240, 240, 240);
            txtEditMa.Location = new Point(180, 345);
            txtEditMa.Name = "txtEditMa";
            txtEditMa.ReadOnly = true;
            txtEditMa.Size = new Size(200, 29);
            txtEditMa.TabIndex = 7;

            lblEditTen.Location = new Point(30, 388);
            lblEditTen.Name = "lblEditTen";
            lblEditTen.Size = new Size(145, 22);
            lblEditTen.TabIndex = 8;
            lblEditTen.Text = "Tên môn học *";
            lblEditTen.TextAlign = ContentAlignment.MiddleRight;

            txtEditTen.Location = new Point(180, 385);
            txtEditTen.Name = "txtEditTen";
            txtEditTen.Size = new Size(400, 29);
            txtEditTen.TabIndex = 9;

            lblEditTc.Location = new Point(30, 428);
            lblEditTc.Name = "lblEditTc";
            lblEditTc.Size = new Size(145, 22);
            lblEditTc.TabIndex = 10;
            lblEditTc.Text = "Số tín chỉ *";
            lblEditTc.TextAlign = ContentAlignment.MiddleRight;

            nudEditTc.Location = new Point(180, 425);
            nudEditTc.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudEditTc.Name = "nudEditTc";
            nudEditTc.Size = new Size(80, 29);
            nudEditTc.TabIndex = 11;
            nudEditTc.Value = new decimal(new int[] { 3, 0, 0, 0 });

            lblEditTuan.Location = new Point(280, 428);
            lblEditTuan.Name = "lblEditTuan";
            lblEditTuan.Size = new Size(80, 22);
            lblEditTuan.TabIndex = 12;
            lblEditTuan.Text = "Số tuần:";
            lblEditTuan.TextAlign = ContentAlignment.MiddleRight;

            nudEditTuan.Location = new Point(365, 425);
            nudEditTuan.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudEditTuan.Name = "nudEditTuan";
            nudEditTuan.Size = new Size(80, 29);
            nudEditTuan.TabIndex = 13;
            nudEditTuan.Value = new decimal(new int[] { 15, 0, 0, 0 });

            lblEditHk.Location = new Point(460, 428);
            lblEditHk.Name = "lblEditHk";
            lblEditHk.Size = new Size(70, 22);
            lblEditHk.TabIndex = 14;
            lblEditHk.Text = "Học kỳ *";
            lblEditHk.TextAlign = ContentAlignment.MiddleRight;

            cboEditHk.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEditHk.Location = new Point(535, 425);
            cboEditHk.Name = "cboEditHk";
            cboEditHk.Size = new Size(100, 29);
            cboEditHk.TabIndex = 15;

            lblEditMota.Location = new Point(30, 468);
            lblEditMota.Name = "lblEditMota";
            lblEditMota.Size = new Size(145, 22);
            lblEditMota.TabIndex = 16;
            lblEditMota.Text = "Mô tả";
            lblEditMota.TextAlign = ContentAlignment.MiddleRight;

            txtEditMota.Location = new Point(180, 465);
            txtEditMota.Multiline = true;
            txtEditMota.Name = "txtEditMota";
            txtEditMota.ScrollBars = ScrollBars.Vertical;
            txtEditMota.Size = new Size(455, 60);
            txtEditMota.TabIndex = 17;

            btnEdit.BackColor = Color.FromArgb(0, 120, 215);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(180, 540);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(130, 32);
            btnEdit.TabIndex = 18;
            btnEdit.Text = "💾  Lưu thay đổi";
            btnEdit.UseVisualStyleBackColor = false;

            btnEditClear.BackColor = Color.FromArgb(220, 220, 220);
            btnEditClear.FlatAppearance.BorderSize = 0;
            btnEditClear.FlatStyle = FlatStyle.Flat;
            btnEditClear.Location = new Point(322, 540);
            btnEditClear.Name = "btnEditClear";
            btnEditClear.Size = new Size(110, 32);
            btnEditClear.TabIndex = 19;
            btnEditClear.Text = "Bỏ chọn";
            btnEditClear.UseVisualStyleBackColor = false;

            // ════════════════════════════════════════════════════════
            // TAB XÓA
            // ════════════════════════════════════════════════════════
            tabDel.Controls.Add(lblDelSearch);
            tabDel.Controls.Add(txtDelSearch);
            tabDel.Controls.Add(lblDelHkSearch);
            tabDel.Controls.Add(cboDelHk);
            tabDel.Controls.Add(btnDelLoad);
            tabDel.Controls.Add(dgvDel);
            tabDel.Controls.Add(lblDelSelected);
            tabDel.Controls.Add(txtDelMa);
            tabDel.Controls.Add(btnDel);
            tabDel.Location = new Point(4, 30);
            tabDel.Name = "tabDel";
            tabDel.Size = new Size(952, 626);
            tabDel.TabIndex = 2;
            tabDel.Text = "  🗑️  Xóa môn học  ";

            lblDelSearch.Location = new Point(10, 15);
            lblDelSearch.Name = "lblDelSearch";
            lblDelSearch.Size = new Size(70, 22);
            lblDelSearch.TabIndex = 0;
            lblDelSearch.Text = "Tìm kiếm:";
            lblDelSearch.TextAlign = ContentAlignment.MiddleRight;

            txtDelSearch.Location = new Point(85, 12);
            txtDelSearch.Name = "txtDelSearch";
            txtDelSearch.Size = new Size(240, 29);
            txtDelSearch.TabIndex = 1;

            lblDelHkSearch.Location = new Point(335, 15);
            lblDelHkSearch.Name = "lblDelHkSearch";
            lblDelHkSearch.Size = new Size(60, 22);
            lblDelHkSearch.TabIndex = 2;
            lblDelHkSearch.Text = "Học kỳ:";
            lblDelHkSearch.TextAlign = ContentAlignment.MiddleRight;

            cboDelHk.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDelHk.Location = new Point(400, 12);
            cboDelHk.Name = "cboDelHk";
            cboDelHk.Size = new Size(110, 29);
            cboDelHk.TabIndex = 3;

            btnDelLoad.BackColor = Color.FromArgb(220, 220, 220);
            btnDelLoad.FlatAppearance.BorderSize = 0;
            btnDelLoad.FlatStyle = FlatStyle.Flat;
            btnDelLoad.Location = new Point(522, 10);
            btnDelLoad.Name = "btnDelLoad";
            btnDelLoad.Size = new Size(120, 32);
            btnDelLoad.TabIndex = 4;
            btnDelLoad.Text = "Tải danh sách";
            btnDelLoad.UseVisualStyleBackColor = false;

            dgvDel.AllowUserToAddRows = false;
            dgvDel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvDel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDel.BackgroundColor = Color.White;
            dgvDel.ColumnHeadersHeight = 29;
            dgvDel.Location = new Point(10, 50);
            dgvDel.MultiSelect = false;
            dgvDel.Name = "dgvDel";
            dgvDel.ReadOnly = true;
            dgvDel.RowHeadersWidth = 51;
            dgvDel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDel.Size = new Size(930, 280);
            dgvDel.TabIndex = 5;

            lblDelSelected.Location = new Point(10, 348);
            lblDelSelected.Name = "lblDelSelected";
            lblDelSelected.Size = new Size(700, 24);
            lblDelSelected.TabIndex = 6;
            lblDelSelected.Text = "Chưa chọn môn học nào";
            lblDelSelected.ForeColor = Color.Gray;
            lblDelSelected.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);

            txtDelMa.Location = new Point(10, 390);
            txtDelMa.Name = "txtDelMa";
            txtDelMa.Size = new Size(0, 29);
            txtDelMa.TabIndex = 7;
            txtDelMa.Visible = false;

            btnDel.BackColor = Color.FromArgb(192, 0, 0);
            btnDel.FlatAppearance.BorderSize = 0;
            btnDel.FlatStyle = FlatStyle.Flat;
            btnDel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDel.ForeColor = Color.White;
            btnDel.Location = new Point(180, 380);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(160, 36);
            btnDel.TabIndex = 8;
            btnDel.Text = "🗑️  Xóa môn học đã chọn";
            btnDel.UseVisualStyleBackColor = false;

            // ════════════════════════════════════════════════════════
            // f_ManageCourse (Form)
            // ════════════════════════════════════════════════════════
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 680);
            Controls.Add(tabControl);
            Font = new Font("Segoe UI", 9.5F);
            Name = "f_ManageCourse";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Môn học";

            // ── EndInit ───────────────────────────────────────────
            tabControl.ResumeLayout(false);
            tabAdd.ResumeLayout(false);
            tabAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAddTc).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAddTuan).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdd).EndInit();
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

        // ── Field declarations ────────────────────────────────────
        private TabControl tabControl;

        private TabPage tabAdd;
        private Label lblAddSearch;
        private TextBox txtAddSearch;
        private Label lblAddHkSearch;
        private ComboBox cboAddHkSearch;
        private Button btnAddLoad;
        private DataGridView dgvAdd;
        private Label lblAddMa;
        private TextBox txtAddMa;
        private Label lblAddTen;
        private TextBox txtAddTen;
        private Label lblAddTc;
        private NumericUpDown nudAddTc;
        private Label lblAddTuan;
        private NumericUpDown nudAddTuan;
        private Label lblAddHk;
        private ComboBox cboAddHk;
        private Label lblAddMota;
        private TextBox txtAddMota;
        private Button btnAdd;
        private Button btnAddClear;

        private TabPage tabEdit;
        private Label lblEditSearch;
        private TextBox txtEditSearch;
        private Label lblEditHkSearch;
        private ComboBox cboEditHkSearch;
        private Button btnEditLoad;
        private DataGridView dgvEdit;
        private Label lblEditMa;
        private TextBox txtEditMa;
        private Label lblEditTen;
        private TextBox txtEditTen;
        private Label lblEditTc;
        private NumericUpDown nudEditTc;
        private Label lblEditTuan;
        private NumericUpDown nudEditTuan;
        private Label lblEditHk;
        private ComboBox cboEditHk;
        private Label lblEditMota;
        private TextBox txtEditMota;
        private Button btnEdit;
        private Button btnEditClear;

        private TabPage tabDel;
        private Label lblDelSearch;
        private TextBox txtDelSearch;
        private Label lblDelHkSearch;
        private ComboBox cboDelHk;
        private Button btnDelLoad;
        private DataGridView dgvDel;
        private Label lblDelSelected;
        private TextBox txtDelMa;
        private Button btnDel;
    }
}