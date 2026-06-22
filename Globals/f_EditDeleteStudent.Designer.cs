namespace ProjectMonHoc
{
    partial class f_EditDeleteStudent
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
            lblTitle = new Label();
            lblMSSV = new Label();
            txtMSSV = new TextBox();
            lblFname = new Label();
            txtFname = new TextBox();
            lblLname = new Label();
            txtLname = new TextBox();
            lblDob = new Label();
            dtpDob = new DateTimePicker();
            lblGender = new Label();
            cboGender = new ComboBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblHtown = new Label();
            txtHtown = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            picAvatar = new PictureBox();
            btnUpload = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            pnl_header = new Panel();
            lblSubtitle = new Label();
            pnl_headerAccent = new Panel();
            pnl_body = new Panel();
            pnl_avatar = new Panel();
            lbl_AvatarTitle = new Label();
            pnl_footer = new Panel();
            pnl_footerTop = new Panel();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            pnl_header.SuspendLayout();
            pnl_body.SuspendLayout();
            pnl_avatar.SuspendLayout();
            pnl_footer.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(700, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "✏️  Chỉnh Sửa / Xóa Sinh Viên";
            // 
            // lblMSSV
            // 
            lblMSSV.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblMSSV.ForeColor = Color.FromArgb(60, 80, 110);
            lblMSSV.Location = new Point(30, 18);
            lblMSSV.Name = "lblMSSV";
            lblMSSV.Size = new Size(200, 22);
            lblMSSV.TabIndex = 0;
            lblMSSV.Text = "Mã số sinh viên (MSSV)";
            // 
            // txtMSSV
            // 
            txtMSSV.BackColor = Color.White;
            txtMSSV.BorderStyle = BorderStyle.FixedSingle;
            txtMSSV.Font = new Font("Segoe UI", 10.5F);
            txtMSSV.ForeColor = Color.White;
            txtMSSV.Location = new Point(30, 42);
            txtMSSV.Name = "txtMSSV";
            txtMSSV.Size = new Size(200, 31);
            txtMSSV.TabIndex = 20;
            txtMSSV.TextChanged += txtMSSV_TextChanged;
            // 
            // lblFname
            // 
            lblFname.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFname.ForeColor = Color.FromArgb(60, 80, 110);
            lblFname.Location = new Point(30, 86);
            lblFname.Name = "lblFname";
            lblFname.Size = new Size(200, 22);
            lblFname.TabIndex = 21;
            lblFname.Text = "Họ và tên đệm";
            // 
            // txtFname
            // 
            txtFname.BackColor = Color.White;
            txtFname.BorderStyle = BorderStyle.FixedSingle;
            txtFname.Font = new Font("Segoe UI", 10.5F);
            txtFname.Location = new Point(30, 110);
            txtFname.Name = "txtFname";
            txtFname.Size = new Size(200, 31);
            txtFname.TabIndex = 18;
            // 
            // lblLname
            // 
            lblLname.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblLname.ForeColor = Color.FromArgb(60, 80, 110);
            lblLname.Location = new Point(30, 154);
            lblLname.Name = "lblLname";
            lblLname.Size = new Size(200, 22);
            lblLname.TabIndex = 22;
            lblLname.Text = "Tên";
            // 
            // txtLname
            // 
            txtLname.BackColor = Color.White;
            txtLname.BorderStyle = BorderStyle.FixedSingle;
            txtLname.Font = new Font("Segoe UI", 10.5F);
            txtLname.Location = new Point(30, 178);
            txtLname.Name = "txtLname";
            txtLname.Size = new Size(200, 31);
            txtLname.TabIndex = 16;
            // 
            // lblDob
            // 
            lblDob.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDob.ForeColor = Color.FromArgb(60, 80, 110);
            lblDob.Location = new Point(30, 222);
            lblDob.Name = "lblDob";
            lblDob.Size = new Size(200, 22);
            lblDob.TabIndex = 23;
            lblDob.Text = "Ngày sinh";
            // 
            // dtpDob
            // 
            dtpDob.CustomFormat = "dd/MM/yyyy";
            dtpDob.Font = new Font("Segoe UI", 10.5F);
            dtpDob.Format = DateTimePickerFormat.Custom;
            dtpDob.Location = new Point(30, 246);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(200, 31);
            dtpDob.TabIndex = 14;
            // 
            // lblGender
            // 
            lblGender.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(60, 80, 110);
            lblGender.Location = new Point(30, 290);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(200, 22);
            lblGender.TabIndex = 24;
            lblGender.Text = "Giới tính";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.FlatStyle = FlatStyle.Flat;
            cboGender.Font = new Font("Segoe UI", 10.5F);
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGender.Location = new Point(30, 314);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(200, 31);
            cboGender.TabIndex = 12;
            // 
            // lblPhone
            // 
            lblPhone.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(60, 80, 110);
            lblPhone.Location = new Point(280, 18);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(220, 22);
            lblPhone.TabIndex = 25;
            lblPhone.Text = "Số điện thoại";
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.White;
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 10.5F);
            txtPhone.Location = new Point(280, 42);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(220, 31);
            txtPhone.TabIndex = 10;
            txtPhone.TextChanged += txtPhone_TextChanged;
            // 
            // lblAddress
            // 
            lblAddress.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(60, 80, 110);
            lblAddress.Location = new Point(280, 86);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(220, 22);
            lblAddress.TabIndex = 26;
            lblAddress.Text = "Địa chỉ";
            // 
            // txtAddress
            // 
            txtAddress.BackColor = Color.White;
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Font = new Font("Segoe UI", 10.5F);
            txtAddress.Location = new Point(280, 110);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(220, 31);
            txtAddress.TabIndex = 8;
            // 
            // lblHtown
            // 
            lblHtown.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblHtown.ForeColor = Color.FromArgb(60, 80, 110);
            lblHtown.Location = new Point(280, 154);
            lblHtown.Name = "lblHtown";
            lblHtown.Size = new Size(220, 22);
            lblHtown.TabIndex = 27;
            lblHtown.Text = "Quê quán";
            // 
            // txtHtown
            // 
            txtHtown.BackColor = Color.White;
            txtHtown.BorderStyle = BorderStyle.FixedSingle;
            txtHtown.Font = new Font("Segoe UI", 10.5F);
            txtHtown.Location = new Point(280, 178);
            txtHtown.Name = "txtHtown";
            txtHtown.Size = new Size(220, 31);
            txtHtown.TabIndex = 6;
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(60, 80, 110);
            lblEmail.Location = new Point(280, 222);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(220, 22);
            lblEmail.TabIndex = 28;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10.5F);
            txtEmail.Location = new Point(280, 246);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 31);
            txtEmail.TabIndex = 4;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.FromArgb(240, 244, 252);
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(0, 26);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(160, 180);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 3;
            picAvatar.TabStop = false;
            // 
            // btnUpload
            // 
            btnUpload.BackColor = Color.FromArgb(242, 246, 252);
            btnUpload.Cursor = Cursors.Hand;
            btnUpload.FlatAppearance.BorderColor = Color.FromArgb(180, 200, 230);
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.Font = new Font("Segoe UI", 9.5F);
            btnUpload.ForeColor = Color.FromArgb(31, 97, 141);
            btnUpload.Location = new Point(0, 214);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(160, 30);
            btnUpload.TabIndex = 2;
            btnUpload.Text = "🖼  Thay đổi ảnh";
            btnUpload.UseVisualStyleBackColor = false;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(31, 97, 141);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(334, 10);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(185, 40);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "💾  Lưu thay đổi";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(192, 57, 43);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(525, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(185, 40);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "🗑  Xóa sinh viên";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // pnl_header
            // 
            pnl_header.BackColor = Color.FromArgb(31, 97, 141);
            pnl_header.Controls.Add(lblTitle);
            pnl_header.Controls.Add(lblSubtitle);
            pnl_header.Controls.Add(pnl_headerAccent);
            pnl_header.Dock = DockStyle.Top;
            pnl_header.Location = new Point(0, 0);
            pnl_header.Name = "pnl_header";
            pnl_header.Size = new Size(745, 76);
            pnl_header.TabIndex = 10;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblSubtitle.ForeColor = Color.FromArgb(200, 225, 255);
            lblSubtitle.Location = new Point(22, 46);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(700, 22);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Chỉnh sửa thông tin rồi nhấn \"Lưu thay đổi\", hoặc nhấn \"Xóa\" để xóa sinh viên khỏi hệ thống";
            // 
            // pnl_headerAccent
            // 
            pnl_headerAccent.BackColor = Color.FromArgb(192, 57, 43);
            pnl_headerAccent.Dock = DockStyle.Bottom;
            pnl_headerAccent.Location = new Point(0, 72);
            pnl_headerAccent.Name = "pnl_headerAccent";
            pnl_headerAccent.Size = new Size(745, 4);
            pnl_headerAccent.TabIndex = 10;
            // 
            // pnl_body
            // 
            pnl_body.BackColor = Color.White;
            pnl_body.Controls.Add(lblMSSV);
            pnl_body.Controls.Add(txtMSSV);
            pnl_body.Controls.Add(lblFname);
            pnl_body.Controls.Add(txtFname);
            pnl_body.Controls.Add(lblLname);
            pnl_body.Controls.Add(txtLname);
            pnl_body.Controls.Add(lblDob);
            pnl_body.Controls.Add(dtpDob);
            pnl_body.Controls.Add(lblGender);
            pnl_body.Controls.Add(cboGender);
            pnl_body.Controls.Add(lblPhone);
            pnl_body.Controls.Add(txtPhone);
            pnl_body.Controls.Add(lblAddress);
            pnl_body.Controls.Add(txtAddress);
            pnl_body.Controls.Add(lblHtown);
            pnl_body.Controls.Add(txtHtown);
            pnl_body.Controls.Add(lblEmail);
            pnl_body.Controls.Add(txtEmail);
            pnl_body.Controls.Add(pnl_avatar);
            pnl_body.Dock = DockStyle.Fill;
            pnl_body.Location = new Point(0, 76);
            pnl_body.Name = "pnl_body";
            pnl_body.Size = new Size(745, 364);
            pnl_body.TabIndex = 11;
            // 
            // pnl_avatar
            // 
            pnl_avatar.BackColor = Color.White;
            pnl_avatar.Controls.Add(lbl_AvatarTitle);
            pnl_avatar.Controls.Add(picAvatar);
            pnl_avatar.Controls.Add(btnUpload);
            pnl_avatar.Location = new Point(550, 18);
            pnl_avatar.Name = "pnl_avatar";
            pnl_avatar.Size = new Size(160, 248);
            pnl_avatar.TabIndex = 30;
            // 
            // lbl_AvatarTitle
            // 
            lbl_AvatarTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_AvatarTitle.ForeColor = Color.FromArgb(60, 80, 110);
            lbl_AvatarTitle.Location = new Point(0, 0);
            lbl_AvatarTitle.Name = "lbl_AvatarTitle";
            lbl_AvatarTitle.Size = new Size(160, 22);
            lbl_AvatarTitle.TabIndex = 0;
            lbl_AvatarTitle.Text = "Ảnh đại diện";
            // 
            // pnl_footer
            // 
            pnl_footer.BackColor = Color.FromArgb(242, 246, 252);
            pnl_footer.Controls.Add(pnl_footerTop);
            pnl_footer.Controls.Add(btnEdit);
            pnl_footer.Controls.Add(btnDelete);
            pnl_footer.Dock = DockStyle.Bottom;
            pnl_footer.Location = new Point(0, 440);
            pnl_footer.Name = "pnl_footer";
            pnl_footer.Size = new Size(745, 60);
            pnl_footer.TabIndex = 12;
            // 
            // pnl_footerTop
            // 
            pnl_footerTop.BackColor = Color.FromArgb(192, 57, 43);
            pnl_footerTop.Dock = DockStyle.Top;
            pnl_footerTop.Location = new Point(0, 0);
            pnl_footerTop.Name = "pnl_footerTop";
            pnl_footerTop.Size = new Size(745, 3);
            pnl_footerTop.TabIndex = 10;
            // 
            // f_EditDeleteStudent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(745, 500);
            Controls.Add(pnl_body);
            Controls.Add(pnl_header);
            Controls.Add(pnl_footer);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "f_EditDeleteStudent";
            StartPosition = FormStartPosition.CenterParent;
            Text = "✏️ Chỉnh Sửa / Xóa Sinh Viên";
            Load += f_EditDeleteStudent_Load;
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            pnl_header.ResumeLayout(false);
            pnl_body.ResumeLayout(false);
            pnl_body.PerformLayout();
            pnl_avatar.ResumeLayout(false);
            pnl_footer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // Input controls
        private Label lblTitle;
        private Label lblMSSV;
        private TextBox txtMSSV;
        private Label lblFname;
        private TextBox txtFname;
        private Label lblLname;
        private TextBox txtLname;
        private Label lblDob;
        private DateTimePicker dtpDob;
        private Label lblGender;
        private ComboBox cboGender;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblHtown;
        private TextBox txtHtown;
        private Label lblEmail;
        private TextBox txtEmail;
        private PictureBox picAvatar;
        private Button btnUpload;
        private Button btnEdit;
        private Button btnDelete;

        // Layout
        private Panel pnl_header;
        private Panel pnl_headerAccent;
        private Panel pnl_body;
        private Panel pnl_footer;
        private Panel pnl_footerTop;
        private Panel pnl_avatar;
        private Label lblSubtitle;
        private Label lbl_AvatarTitle;
    }
}