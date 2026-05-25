namespace ProjectMonHoc
{
    partial class f_EditDeleteStudent
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
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Navy;
            lblTitle.Location = new Point(230, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(393, 37);
            lblTitle.TabIndex = 22;
            lblTitle.Text = "CHỈNH SỬA / XÓA SINH VIÊN";
            // 
            // lblMSSV
            // 
            lblMSSV.AutoSize = true;
            lblMSSV.Font = new Font("Segoe UI", 10F);
            lblMSSV.Location = new Point(40, 90);
            lblMSSV.Name = "lblMSSV";
            lblMSSV.Size = new Size(58, 23);
            lblMSSV.TabIndex = 21;
            lblMSSV.Text = "MSSV:";
            // 
            // txtMSSV
            // 
            txtMSSV.Font = new Font("Segoe UI", 10F);
            txtMSSV.Location = new Point(140, 87);
            txtMSSV.Name = "txtMSSV";
            txtMSSV.Size = new Size(220, 30);
            txtMSSV.TabIndex = 20;
            txtMSSV.TextChanged += txtMSSV_TextChanged;
            // 
            // lblFname
            // 
            lblFname.AutoSize = true;
            lblFname.Font = new Font("Segoe UI", 10F);
            lblFname.Location = new Point(40, 140);
            lblFname.Name = "lblFname";
            lblFname.Size = new Size(36, 23);
            lblFname.TabIndex = 19;
            lblFname.Text = "Họ:";
            // 
            // txtFname
            // 
            txtFname.Font = new Font("Segoe UI", 10F);
            txtFname.Location = new Point(140, 137);
            txtFname.Name = "txtFname";
            txtFname.Size = new Size(220, 30);
            txtFname.TabIndex = 18;
            // 
            // lblLname
            // 
            lblLname.AutoSize = true;
            lblLname.Font = new Font("Segoe UI", 10F);
            lblLname.Location = new Point(40, 190);
            lblLname.Name = "lblLname";
            lblLname.Size = new Size(40, 23);
            lblLname.TabIndex = 17;
            lblLname.Text = "Tên:";
            // 
            // txtLname
            // 
            txtLname.Font = new Font("Segoe UI", 10F);
            txtLname.Location = new Point(140, 187);
            txtLname.Name = "txtLname";
            txtLname.Size = new Size(220, 30);
            txtLname.TabIndex = 16;
            // 
            // lblDob
            // 
            lblDob.AutoSize = true;
            lblDob.Font = new Font("Segoe UI", 10F);
            lblDob.Location = new Point(40, 240);
            lblDob.Name = "lblDob";
            lblDob.Size = new Size(90, 23);
            lblDob.TabIndex = 15;
            lblDob.Text = "Ngày sinh:";
            // 
            // dtpDob
            // 
            dtpDob.Font = new Font("Segoe UI", 10F);
            dtpDob.Format = DateTimePickerFormat.Short;
            dtpDob.Location = new Point(140, 237);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(220, 30);
            dtpDob.TabIndex = 14;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 10F);
            lblGender.Location = new Point(40, 290);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(79, 23);
            lblGender.TabIndex = 13;
            lblGender.Text = "Giới tính:";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.Font = new Font("Segoe UI", 10F);
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.Location = new Point(140, 287);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(220, 31);
            cboGender.TabIndex = 12;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10F);
            lblPhone.Location = new Point(410, 90);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(93, 23);
            lblPhone.TabIndex = 11;
            lblPhone.Text = "Điện thoại:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(520, 87);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(220, 30);
            txtPhone.TabIndex = 10;
            txtPhone.TextChanged += txtPhone_TextChanged;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 10F);
            lblAddress.Location = new Point(410, 140);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(66, 23);
            lblAddress.TabIndex = 9;
            lblAddress.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(520, 137);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(220, 30);
            txtAddress.TabIndex = 8;
            // 
            // lblHtown
            // 
            lblHtown.AutoSize = true;
            lblHtown.Font = new Font("Segoe UI", 10F);
            lblHtown.Location = new Point(410, 190);
            lblHtown.Name = "lblHtown";
            lblHtown.Size = new Size(90, 23);
            lblHtown.TabIndex = 7;
            lblHtown.Text = "Quê quán:";
            // 
            // txtHtown
            // 
            txtHtown.Font = new Font("Segoe UI", 10F);
            txtHtown.Location = new Point(520, 187);
            txtHtown.Name = "txtHtown";
            txtHtown.Size = new Size(220, 30);
            txtHtown.TabIndex = 6;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(410, 240);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(55, 23);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(520, 237);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 30);
            txtEmail.TabIndex = 4;
            // 
            // picAvatar
            // 
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(780, 87);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(160, 180);
            picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            picAvatar.TabIndex = 3;
            picAvatar.TabStop = false;
            // 
            // btnUpload
            // 
            btnUpload.Font = new Font("Segoe UI", 9F);
            btnUpload.Location = new Point(780, 285);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(160, 33);
            btnUpload.TabIndex = 2;
            btnUpload.Text = "Thay đổi ảnh";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.ForestGreen;
            btnEdit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(260, 360);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(180, 45);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "LƯU THAY ĐỔI";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Firebrick;
            btnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(490, 360);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(180, 45);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "XÓA SINH VIÊN";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // f_EditDeleteStudent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(982, 440);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnUpload);
            Controls.Add(picAvatar);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtHtown);
            Controls.Add(lblHtown);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(cboGender);
            Controls.Add(lblGender);
            Controls.Add(dtpDob);
            Controls.Add(lblDob);
            Controls.Add(txtLname);
            Controls.Add(lblLname);
            Controls.Add(txtFname);
            Controls.Add(lblFname);
            Controls.Add(txtMSSV);
            Controls.Add(lblMSSV);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "f_EditDeleteStudent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin chi tiết Sinh viên";
            Load += f_EditDeleteStudent_Load;
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.Label lblFname;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label lblLname;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblHtown;
        private System.Windows.Forms.TextBox txtHtown;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}