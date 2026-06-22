namespace ProjectMonHoc
{
    partial class f_AddStudent
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
            txtMSSV = new TextBox();
            txtFname = new TextBox();
            txtLname = new TextBox();
            txtHometown = new TextBox();
            txtAddress = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            cboGender = new ComboBox();
            dtpDob = new DateTimePicker();
            picStudent = new PictureBox();
            btnChooseImage = new Button();
            btnAdd = new Button();
            btnClear = new Button();

            pnl_header = new Panel();
            pnl_headerAccent = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();

            pnl_body = new Panel();

            // Labels – left column
            lbl_MSSV = new Label();
            lbl_Fname = new Label();
            lbl_Lname = new Label();
            lbl_Photo = new Label();

            // Labels – right column
            lbl_Dob = new Label();
            lbl_Gender = new Label();
            lbl_Phone = new Label();
            lbl_Address = new Label();
            lbl_Hometown = new Label();
            lbl_Email = new Label();

            pnl_footer = new Panel();
            pnl_footerTop = new Panel();

            ((System.ComponentModel.ISupportInitialize)picStudent).BeginInit();
            pnl_header.SuspendLayout();
            pnl_body.SuspendLayout();
            pnl_footer.SuspendLayout();
            pnl_footerTop.SuspendLayout();
            SuspendLayout();

            // ── Shared field style helpers (applied inline below) ──────────────────
            // Fields: BackColor White, BorderStyle FixedSingle, Font Segoe UI 10.5

            // ═══════════════════════════════════════════════════════════════════════
            // pnl_header
            // ═══════════════════════════════════════════════════════════════════════
            pnl_headerAccent.BackColor = Color.FromArgb(192, 57, 43);
            pnl_headerAccent.Dock = DockStyle.Bottom;
            pnl_headerAccent.Name = "pnl_headerAccent";
            pnl_headerAccent.Size = new Size(800, 4);
            pnl_headerAccent.TabIndex = 10;

            lblTitle.AutoSize = false;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(560, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "➕  Thêm Sinh Viên Mới";

            lblSubtitle.AutoSize = false;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblSubtitle.ForeColor = Color.FromArgb(200, 225, 255);
            lblSubtitle.Location = new Point(22, 46);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(560, 22);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Điền đầy đủ thông tin bên dưới rồi nhấn \"Thêm sinh viên\"";

            pnl_header.BackColor = Color.FromArgb(31, 97, 141);
            pnl_header.Controls.Add(lblTitle);
            pnl_header.Controls.Add(lblSubtitle);
            pnl_header.Controls.Add(pnl_headerAccent);
            pnl_header.Dock = DockStyle.Top;
            pnl_header.Location = new Point(0, 0);
            pnl_header.Name = "pnl_header";
            pnl_header.Size = new Size(800, 76);
            pnl_header.TabIndex = 10;

            // ═══════════════════════════════════════════════════════════════════════
            // pnl_body  (white content area, absolute layout)
            // ═══════════════════════════════════════════════════════════════════════

            // ── LEFT COLUMN ────────────────────────────────────────────────────────
            // Photo box
            lbl_Photo.AutoSize = false;
            lbl_Photo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_Photo.ForeColor = Color.FromArgb(60, 80, 110);
            lbl_Photo.Location = new Point(30, 20);
            lbl_Photo.Name = "lbl_Photo";
            lbl_Photo.Size = new Size(130, 22);
            lbl_Photo.Text = "Ảnh đại diện";

            picStudent.BackColor = Color.FromArgb(240, 244, 252);
            picStudent.BorderStyle = BorderStyle.FixedSingle;
            picStudent.Location = new Point(30, 46);
            picStudent.Name = "picStudent";
            picStudent.Size = new Size(110, 110);
            picStudent.SizeMode = PictureBoxSizeMode.Zoom;
            picStudent.TabIndex = 18;
            picStudent.TabStop = false;
            picStudent.Click += picStudent_Click;

            btnChooseImage.BackColor = Color.FromArgb(242, 246, 252);
            btnChooseImage.FlatAppearance.BorderColor = Color.FromArgb(180, 200, 230);
            btnChooseImage.FlatAppearance.BorderSize = 1;
            btnChooseImage.FlatStyle = FlatStyle.Flat;
            btnChooseImage.Cursor = Cursors.Hand;
            btnChooseImage.Font = new Font("Segoe UI", 9.5F);
            btnChooseImage.ForeColor = Color.FromArgb(31, 97, 141);
            btnChooseImage.Location = new Point(30, 164);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(110, 30);
            btnChooseImage.TabIndex = 23;
            btnChooseImage.Text = "🖼 Chọn ảnh";
            btnChooseImage.UseVisualStyleBackColor = false;
            btnChooseImage.Click += btnChooseImage_Click;

            // MSSV
            lbl_MSSV.AutoSize = false;
            lbl_MSSV.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_MSSV.ForeColor = Color.FromArgb(60, 80, 110);
            lbl_MSSV.Location = new Point(165, 20);
            lbl_MSSV.Name = "lbl_MSSV";
            lbl_MSSV.Size = new Size(200, 22);
            lbl_MSSV.Text = "Mã số sinh viên (MSSV) *";

            txtMSSV.BackColor = Color.White;
            txtMSSV.BorderStyle = BorderStyle.FixedSingle;
            txtMSSV.Font = new Font("Segoe UI", 10.5F);
            txtMSSV.Location = new Point(165, 44);
            txtMSSV.Name = "txtMSSV";
            txtMSSV.Size = new Size(200, 30);
            txtMSSV.TabIndex = 1;
            txtMSSV.Text = "Nhập MSSV";
            txtMSSV.ForeColor = Color.Gray;
            txtMSSV.KeyPress += txtMSSV_KeyPress;

            // Họ và tên đệm
            lbl_Fname.AutoSize = false;
            lbl_Fname.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_Fname.ForeColor = Color.FromArgb(60, 80, 110);
            lbl_Fname.Location = new Point(165, 88);
            lbl_Fname.Name = "lbl_Fname";
            lbl_Fname.Size = new Size(200, 22);
            lbl_Fname.Text = "Họ và tên đệm";

            txtFname.BackColor = Color.White;
            txtFname.BorderStyle = BorderStyle.FixedSingle;
            txtFname.Font = new Font("Segoe UI", 10.5F);
            txtFname.Location = new Point(165, 112);
            txtFname.Name = "txtFname";
            txtFname.Size = new Size(200, 30);
            txtFname.TabIndex = 3;
            txtFname.Text = "Nhập họ và tên đệm";
            txtFname.ForeColor = Color.Gray;
            txtFname.KeyPress += txtFname_KeyPress;

            // Tên
            lbl_Lname.AutoSize = false;
            lbl_Lname.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_Lname.ForeColor = Color.FromArgb(60, 80, 110);
            lbl_Lname.Location = new Point(165, 156);
            lbl_Lname.Name = "lbl_Lname";
            lbl_Lname.Size = new Size(200, 22);
            lbl_Lname.Text = "Tên *";

            txtLname.BackColor = Color.White;
            txtLname.BorderStyle = BorderStyle.FixedSingle;
            txtLname.Font = new Font("Segoe UI", 10.5F);
            txtLname.Location = new Point(165, 180);
            txtLname.Name = "txtLname";
            txtLname.Size = new Size(200, 30);
            txtLname.TabIndex = 5;
            txtLname.Text = "Nhập tên";
            txtLname.ForeColor = Color.Gray;
            txtLname.KeyPress += txtLname_KeyPress;

            // ── RIGHT COLUMN ───────────────────────────────────────────────────────
            int rx = 420; // right column X

            // Ngày sinh
            lbl_Dob.AutoSize = false;
            lbl_Dob.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_Dob.ForeColor = Color.FromArgb(60, 80, 110);
            lbl_Dob.Location = new Point(rx, 20);
            lbl_Dob.Name = "lbl_Dob";
            lbl_Dob.Size = new Size(200, 22);
            lbl_Dob.Text = "Ngày sinh";

            dtpDob.CustomFormat = "dd/MM/yyyy";
            dtpDob.Format = DateTimePickerFormat.Custom;
            dtpDob.Font = new Font("Segoe UI", 10.5F);
            dtpDob.Location = new Point(rx, 44);
            dtpDob.MaxDate = new DateTime(2008, 12, 31);
            dtpDob.MinDate = new DateTime(1900, 1, 1);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(200, 30);
            dtpDob.TabIndex = 20;
            dtpDob.Value = new DateTime(2008, 1, 1);
            dtpDob.ValueChanged += dtpDob_ValueChanged;

            // Giới tính
            lbl_Gender.AutoSize = false;
            lbl_Gender.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_Gender.ForeColor = Color.FromArgb(60, 80, 110);
            lbl_Gender.Location = new Point(rx, 88);
            lbl_Gender.Name = "lbl_Gender";
            lbl_Gender.Size = new Size(200, 22);
            lbl_Gender.Text = "Giới tính";

            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.FlatStyle = FlatStyle.Flat;
            cboGender.Font = new Font("Segoe UI", 10.5F);
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGender.Location = new Point(rx, 112);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(200, 30);
            cboGender.TabIndex = 22;
            cboGender.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            // Số điện thoại
            lbl_Phone.AutoSize = false;
            lbl_Phone.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_Phone.ForeColor = Color.FromArgb(60, 80, 110);
            lbl_Phone.Location = new Point(rx, 156);
            lbl_Phone.Name = "lbl_Phone";
            lbl_Phone.Size = new Size(200, 22);
            lbl_Phone.Text = "Số điện thoại";

            txtPhone.BackColor = Color.White;
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 10.5F);
            txtPhone.Location = new Point(rx, 180);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(200, 30);
            txtPhone.TabIndex = 9;
            txtPhone.Text = "Nhập số điện thoại";
            txtPhone.ForeColor = Color.Gray;
            txtPhone.KeyPress += txtMSSV_KeyPress;

            // Địa chỉ
            lbl_Address.AutoSize = false;
            lbl_Address.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_Address.ForeColor = Color.FromArgb(60, 80, 110);
            lbl_Address.Location = new Point(rx, 224);
            lbl_Address.Name = "lbl_Address";
            lbl_Address.Size = new Size(200, 22);
            lbl_Address.Text = "Địa chỉ";

            txtAddress.BackColor = Color.White;
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Font = new Font("Segoe UI", 10.5F);
            txtAddress.Location = new Point(rx, 248);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(200, 30);
            txtAddress.TabIndex = 11;
            txtAddress.Text = "Nhập địa chỉ";
            txtAddress.ForeColor = Color.Gray;

            // Quê quán
            lbl_Hometown.AutoSize = false;
            lbl_Hometown.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_Hometown.ForeColor = Color.FromArgb(60, 80, 110);
            lbl_Hometown.Location = new Point(rx, 292);
            lbl_Hometown.Name = "lbl_Hometown";
            lbl_Hometown.Size = new Size(200, 22);
            lbl_Hometown.Text = "Quê quán";

            txtHometown.BackColor = Color.White;
            txtHometown.BorderStyle = BorderStyle.FixedSingle;
            txtHometown.Font = new Font("Segoe UI", 10.5F);
            txtHometown.Location = new Point(rx, 316);
            txtHometown.Name = "txtHometown";
            txtHometown.Size = new Size(200, 30);
            txtHometown.TabIndex = 13;
            txtHometown.Text = "Nhập quê quán";
            txtHometown.ForeColor = Color.Gray;

            // Email  (spans below left column gap)
            lbl_Email.AutoSize = false;
            lbl_Email.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_Email.ForeColor = Color.FromArgb(60, 80, 110);
            lbl_Email.Location = new Point(165, 224);
            lbl_Email.Name = "lbl_Email";
            lbl_Email.Size = new Size(200, 22);
            lbl_Email.Text = "Email";

            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10.5F);
            txtEmail.Location = new Point(165, 248);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 30);
            txtEmail.TabIndex = 21;
            txtEmail.Text = "Nhập email";
            txtEmail.ForeColor = Color.Gray;

            // ── pnl_body ──────────────────────────────────────────────────────────
            pnl_body.BackColor = Color.White;
            pnl_body.Controls.Add(lbl_Photo);
            pnl_body.Controls.Add(picStudent);
            pnl_body.Controls.Add(btnChooseImage);
            pnl_body.Controls.Add(lbl_MSSV);
            pnl_body.Controls.Add(txtMSSV);
            pnl_body.Controls.Add(lbl_Fname);
            pnl_body.Controls.Add(txtFname);
            pnl_body.Controls.Add(lbl_Lname);
            pnl_body.Controls.Add(txtLname);
            pnl_body.Controls.Add(lbl_Email);
            pnl_body.Controls.Add(txtEmail);
            pnl_body.Controls.Add(lbl_Dob);
            pnl_body.Controls.Add(dtpDob);
            pnl_body.Controls.Add(lbl_Gender);
            pnl_body.Controls.Add(cboGender);
            pnl_body.Controls.Add(lbl_Phone);
            pnl_body.Controls.Add(txtPhone);
            pnl_body.Controls.Add(lbl_Address);
            pnl_body.Controls.Add(txtAddress);
            pnl_body.Controls.Add(lbl_Hometown);
            pnl_body.Controls.Add(txtHometown);
            pnl_body.Dock = DockStyle.Fill;
            pnl_body.Padding = new Padding(0, 10, 0, 0);
            pnl_body.Name = "pnl_body";
            pnl_body.TabIndex = 11;

            // ═══════════════════════════════════════════════════════════════════════
            // pnl_footer  (buttons)
            // ═══════════════════════════════════════════════════════════════════════
            pnl_footerTop.BackColor = Color.FromArgb(192, 57, 43);
            pnl_footerTop.Dock = DockStyle.Top;
            pnl_footerTop.Name = "pnl_footerTop";
            pnl_footerTop.Size = new Size(800, 3);
            pnl_footerTop.TabIndex = 10;

            btnAdd.BackColor = Color.FromArgb(31, 97, 141);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(440, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(170, 40);
            btnAdd.TabIndex = 24;
            btnAdd.Text = "✔  Thêm sinh viên";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;

            btnClear.BackColor = Color.FromArgb(230, 126, 34);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(624, 10);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(148, 40);
            btnClear.TabIndex = 25;
            btnClear.Text = "✖  Xóa trắng";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;

            pnl_footer.BackColor = Color.FromArgb(242, 246, 252);
            pnl_footer.Controls.Add(pnl_footerTop);
            pnl_footer.Controls.Add(btnAdd);
            pnl_footer.Controls.Add(btnClear);
            pnl_footer.Dock = DockStyle.Bottom;
            pnl_footer.Location = new Point(0, 390);
            pnl_footer.Name = "pnl_footer";
            pnl_footer.Size = new Size(800, 60);
            pnl_footer.TabIndex = 12;

            // ═══════════════════════════════════════════════════════════════════════
            // f_AddStudent (Form)
            // ═══════════════════════════════════════════════════════════════════════
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 530);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Controls.Add(pnl_body);
            Controls.Add(pnl_header);
            Controls.Add(pnl_footer);
            Name = "f_AddStudent";
            StartPosition = FormStartPosition.CenterParent;
            Text = "➕ Thêm Sinh Viên Mới";
            Load += f_AddStudent_Load;
            ((System.ComponentModel.ISupportInitialize)picStudent).EndInit();
            pnl_header.ResumeLayout(false);
            pnl_header.PerformLayout();
            pnl_body.ResumeLayout(false);
            pnl_body.PerformLayout();
            pnl_footer.ResumeLayout(false);
            pnl_footerTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // Input controls
        private TextBox txtMSSV;
        private TextBox txtFname;
        private TextBox txtLname;
        private TextBox txtHometown;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private ComboBox cboGender;
        private DateTimePicker dtpDob;
        private PictureBox picStudent;
        private Button btnChooseImage;
        private Button btnAdd;
        private Button btnClear;

        // Layout panels
        private Panel pnl_header;
        private Panel pnl_headerAccent;
        private Panel pnl_body;
        private Panel pnl_footer;
        private Panel pnl_footerTop;

        // Labels
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lbl_Photo;
        private Label lbl_MSSV;
        private Label lbl_Fname;
        private Label lbl_Lname;
        private Label lbl_Email;
        private Label lbl_Dob;
        private Label lbl_Gender;
        private Label lbl_Phone;
        private Label lbl_Address;
        private Label lbl_Hometown;
    }
}