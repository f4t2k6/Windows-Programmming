namespace YourApp
{
    partial class f_Contact
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
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlLeft = new Panel();
            btnFilter = new Button();
            lblGroupHint = new Label();
            lblSearchHint = new Label();
            cboGroup = new ComboBox();
            txtSearch = new TextBox();
            dgvContacts = new DataGridView();
            pnlRight = new Panel();
            picAvatar = new PictureBox();
            lblAvatarHint = new Label();
            btnPickImage = new Button();
            lblDetailHint = new Label();
            pnlDetail = new Panel();
            lblFname = new Label();
            txtFname = new TextBox();
            lblLname = new Label();
            txtLname = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDob = new Label();
            dtpDob = new DateTimePicker();
            lblGender = new Label();
            cboGender = new ComboBox();
            lblGroupEdit = new Label();
            cboGroupEdit = new ComboBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            pnlActions = new Panel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            pnlHeader.SuspendLayout();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContacts).BeginInit();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            pnlDetail.SuspendLayout();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(30, 100, 200);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1027, 48);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(182, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý danh bạ";
            // 
            // pnlLeft
            // 
            pnlLeft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlLeft.Controls.Add(lblGroupHint);
            pnlLeft.Controls.Add(lblSearchHint);
            pnlLeft.Controls.Add(cboGroup);
            pnlLeft.Controls.Add(txtSearch);
            pnlLeft.Controls.Add(dgvContacts);
            pnlLeft.Location = new Point(12, 56);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(625, 558);
            pnlLeft.TabIndex = 1;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(30, 100, 200);
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(9, 14);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(100, 36);
            btnFilter.TabIndex = 4;
            btnFilter.Text = "Lọc";
            btnFilter.UseVisualStyleBackColor = false;
            // 
            // lblGroupHint
            // 
            lblGroupHint.AutoSize = true;
            lblGroupHint.Font = new Font("Segoe UI", 8F);
            lblGroupHint.ForeColor = Color.Gray;
            lblGroupHint.Location = new Point(0, 3);
            lblGroupHint.Name = "lblGroupHint";
            lblGroupHint.Size = new Size(91, 19);
            lblGroupHint.TabIndex = 0;
            lblGroupHint.Text = "Nhóm liên hệ";
            // 
            // lblSearchHint
            // 
            lblSearchHint.AutoSize = true;
            lblSearchHint.Font = new Font("Segoe UI", 8F);
            lblSearchHint.ForeColor = Color.Gray;
            lblSearchHint.Location = new Point(310, 3);
            lblSearchHint.Name = "lblSearchHint";
            lblSearchHint.Size = new Size(149, 19);
            lblSearchHint.TabIndex = 1;
            lblSearchHint.Text = "Tìm kiếm tên hoặc SĐT";
            // 
            // cboGroup
            // 
            cboGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGroup.FlatStyle = FlatStyle.System;
            cboGroup.Font = new Font("Segoe UI", 10F);
            cboGroup.Location = new Point(0, 21);
            cboGroup.Name = "cboGroup";
            cboGroup.Size = new Size(290, 31);
            cboGroup.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(310, 21);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(302, 30);
            txtSearch.TabIndex = 3;
            // 
            // dgvContacts
            // 
            dgvContacts.AllowUserToAddRows = false;
            dgvContacts.AllowUserToDeleteRows = false;
            dgvContacts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContacts.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 242, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvContacts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvContacts.ColumnHeadersHeight = 36;
            dgvContacts.Font = new Font("Segoe UI", 10F);
            dgvContacts.GridColor = Color.FromArgb(220, 228, 240);
            dgvContacts.Location = new Point(0, 70);
            dgvContacts.MultiSelect = false;
            dgvContacts.Name = "dgvContacts";
            dgvContacts.ReadOnly = true;
            dgvContacts.RowHeadersVisible = false;
            dgvContacts.RowHeadersWidth = 51;
            dgvContacts.RowTemplate.Height = 34;
            dgvContacts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContacts.Size = new Size(622, 488);
            dgvContacts.TabIndex = 5;
            // 
            // pnlRight
            // 
            pnlRight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlRight.BorderStyle = BorderStyle.FixedSingle;
            pnlRight.Controls.Add(btnFilter);
            pnlRight.Controls.Add(picAvatar);
            pnlRight.Controls.Add(lblAvatarHint);
            pnlRight.Controls.Add(btnPickImage);
            pnlRight.Controls.Add(lblDetailHint);
            pnlRight.Controls.Add(pnlDetail);
            pnlRight.Controls.Add(pnlActions);
            pnlRight.Location = new Point(633, 56);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(382, 558);
            pnlRight.TabIndex = 2;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.FromArgb(220, 228, 245);
            picAvatar.Location = new Point(155, 16);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(110, 110);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // lblAvatarHint
            // 
            lblAvatarHint.Font = new Font("Segoe UI", 8F);
            lblAvatarHint.ForeColor = Color.Gray;
            lblAvatarHint.Location = new Point(140, 130);
            lblAvatarHint.Name = "lblAvatarHint";
            lblAvatarHint.Size = new Size(140, 34);
            lblAvatarHint.TabIndex = 1;
            lblAvatarHint.Text = "PictureBox\nẢnh đại diện";
            lblAvatarHint.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPickImage
            // 
            btnPickImage.Cursor = Cursors.Hand;
            btnPickImage.FlatStyle = FlatStyle.Flat;
            btnPickImage.Font = new Font("Segoe UI", 8F);
            btnPickImage.Location = new Point(155, 168);
            btnPickImage.Name = "btnPickImage";
            btnPickImage.Size = new Size(110, 26);
            btnPickImage.TabIndex = 2;
            btnPickImage.Text = "Chọn ảnh";
            btnPickImage.Visible = false;
            // 
            // lblDetailHint
            // 
            lblDetailHint.AutoSize = true;
            lblDetailHint.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDetailHint.ForeColor = Color.FromArgb(60, 60, 60);
            lblDetailHint.Location = new Point(10, 202);
            lblDetailHint.Name = "lblDetailHint";
            lblDetailHint.Size = new Size(129, 20);
            lblDetailHint.TabIndex = 3;
            lblDetailHint.Text = "Thông tin chi tiết";
            // 
            // pnlDetail
            // 
            pnlDetail.Controls.Add(lblFname);
            pnlDetail.Controls.Add(txtFname);
            pnlDetail.Controls.Add(lblLname);
            pnlDetail.Controls.Add(txtLname);
            pnlDetail.Controls.Add(lblPhone);
            pnlDetail.Controls.Add(txtPhone);
            pnlDetail.Controls.Add(lblEmail);
            pnlDetail.Controls.Add(txtEmail);
            pnlDetail.Controls.Add(lblDob);
            pnlDetail.Controls.Add(dtpDob);
            pnlDetail.Controls.Add(lblGender);
            pnlDetail.Controls.Add(cboGender);
            pnlDetail.Controls.Add(lblGroupEdit);
            pnlDetail.Controls.Add(cboGroupEdit);
            pnlDetail.Controls.Add(lblAddress);
            pnlDetail.Controls.Add(txtAddress);
            pnlDetail.Location = new Point(10, 222);
            pnlDetail.Name = "pnlDetail";
            pnlDetail.Size = new Size(406, 284);
            pnlDetail.TabIndex = 4;
            // 
            // lblFname
            // 
            lblFname.AutoSize = true;
            lblFname.Font = new Font("Segoe UI", 9F);
            lblFname.ForeColor = Color.FromArgb(80, 80, 80);
            lblFname.Location = new Point(0, 6);
            lblFname.Name = "lblFname";
            lblFname.Size = new Size(32, 20);
            lblFname.TabIndex = 0;
            lblFname.Text = "Họ:";
            // 
            // txtFname
            // 
            txtFname.Font = new Font("Segoe UI", 9.5F);
            txtFname.Location = new Point(110, 2);
            txtFname.MaxLength = 20;
            txtFname.Name = "txtFname";
            txtFname.Size = new Size(255, 29);
            txtFname.TabIndex = 1;
            // 
            // lblLname
            // 
            lblLname.AutoSize = true;
            lblLname.Font = new Font("Segoe UI", 9F);
            lblLname.ForeColor = Color.FromArgb(80, 80, 80);
            lblLname.Location = new Point(0, 40);
            lblLname.Name = "lblLname";
            lblLname.Size = new Size(35, 20);
            lblLname.TabIndex = 2;
            lblLname.Text = "Tên:";
            // 
            // txtLname
            // 
            txtLname.Font = new Font("Segoe UI", 9.5F);
            txtLname.Location = new Point(110, 36);
            txtLname.MaxLength = 20;
            txtLname.Name = "txtLname";
            txtLname.Size = new Size(255, 29);
            txtLname.TabIndex = 3;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9F);
            lblPhone.ForeColor = Color.FromArgb(80, 80, 80);
            lblPhone.Location = new Point(0, 74);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(39, 20);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "SĐT:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 9.5F);
            txtPhone.Location = new Point(110, 70);
            txtPhone.MaxLength = 10;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(255, 29);
            txtPhone.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.ForeColor = Color.FromArgb(80, 80, 80);
            lblEmail.Location = new Point(0, 108);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.Location = new Point(110, 104);
            txtEmail.MaxLength = 40;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(255, 29);
            txtEmail.TabIndex = 7;
            // 
            // lblDob
            // 
            lblDob.AutoSize = true;
            lblDob.Font = new Font("Segoe UI", 9F);
            lblDob.ForeColor = Color.FromArgb(80, 80, 80);
            lblDob.Location = new Point(0, 142);
            lblDob.Name = "lblDob";
            lblDob.Size = new Size(77, 20);
            lblDob.TabIndex = 8;
            lblDob.Text = "Ngày sinh:";
            // 
            // dtpDob
            // 
            dtpDob.Font = new Font("Segoe UI", 9.5F);
            dtpDob.Format = DateTimePickerFormat.Short;
            dtpDob.Location = new Point(110, 138);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(180, 29);
            dtpDob.TabIndex = 9;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 9F);
            lblGender.ForeColor = Color.FromArgb(80, 80, 80);
            lblGender.Location = new Point(0, 176);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(68, 20);
            lblGender.TabIndex = 10;
            lblGender.Text = "Giới tính:";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.Font = new Font("Segoe UI", 9.5F);
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGender.Location = new Point(110, 172);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(180, 29);
            cboGender.TabIndex = 11;
            // 
            // lblGroupEdit
            // 
            lblGroupEdit.AutoSize = true;
            lblGroupEdit.Font = new Font("Segoe UI", 9F);
            lblGroupEdit.ForeColor = Color.FromArgb(80, 80, 80);
            lblGroupEdit.Location = new Point(0, 210);
            lblGroupEdit.Name = "lblGroupEdit";
            lblGroupEdit.Size = new Size(53, 20);
            lblGroupEdit.TabIndex = 12;
            lblGroupEdit.Text = "Nhóm:";
            // 
            // cboGroupEdit
            // 
            cboGroupEdit.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGroupEdit.Font = new Font("Segoe UI", 9.5F);
            cboGroupEdit.Location = new Point(110, 206);
            cboGroupEdit.Name = "cboGroupEdit";
            cboGroupEdit.Size = new Size(255, 29);
            cboGroupEdit.TabIndex = 13;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 9F);
            lblAddress.ForeColor = Color.FromArgb(80, 80, 80);
            lblAddress.Location = new Point(0, 244);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(58, 20);
            lblAddress.TabIndex = 14;
            lblAddress.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 9.5F);
            txtAddress.Location = new Point(110, 240);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(255, 29);
            txtAddress.TabIndex = 15;
            // 
            // pnlActions
            // 
            pnlActions.Anchor = AnchorStyles.Bottom;
            pnlActions.Controls.Add(btnAdd);
            pnlActions.Controls.Add(btnEdit);
            pnlActions.Controls.Add(btnDelete);
            pnlActions.Location = new Point(-14, 506);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(406, 46);
            pnlActions.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(30, 100, 200);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(17, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 40);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(34, 155, 85);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Enabled = false;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(143, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 40);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(210, 50, 50);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Enabled = false;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(269, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // f_Contact
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 252);
            ClientSize = new Size(1027, 628);
            Controls.Add(pnlHeader);
            Controls.Add(pnlLeft);
            Controls.Add(pnlRight);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(1045, 675);
            Name = "f_Contact";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "f_Contact – Quản lý danh bạ";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContacts).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            pnlDetail.ResumeLayout(false);
            pnlDetail.PerformLayout();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader, pnlLeft, pnlRight, pnlDetail, pnlActions;
        private System.Windows.Forms.Label lblTitle, lblGroupHint, lblSearchHint, lblDetailHint, lblAvatarHint;
        private System.Windows.Forms.Label lblFname, lblLname, lblPhone, lblEmail, lblDob, lblGender, lblGroupEdit, lblAddress;
        private System.Windows.Forms.ComboBox cboGroup, cboGender, cboGroupEdit;
        private System.Windows.Forms.TextBox txtSearch, txtFname, txtLname, txtPhone, txtEmail, txtAddress;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Button btnFilter, btnAdd, btnEdit, btnDelete, btnPickImage;
        private System.Windows.Forms.DataGridView dgvContacts;
        private System.Windows.Forms.PictureBox picAvatar;
    }
}