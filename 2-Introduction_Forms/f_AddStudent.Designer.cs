namespace Day01
{
    partial class f_AddStudent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtMSSV = new TextBox();
            txtFname = new TextBox();
            txtLname = new TextBox();
            txtHometown = new TextBox();
            txtAddress = new TextBox();
            txtPhone = new TextBox();
            picStudent = new PictureBox();
            dtpDob = new DateTimePicker();
            txtEmail = new TextBox();
            cboGender = new ComboBox();
            btnChooseImage = new Button();
            btnAdd = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)picStudent).BeginInit();
            SuspendLayout();
            // 
            // txtMSSV
            // 
            txtMSSV.Location = new Point(88, 192);
            txtMSSV.Name = "txtMSSV";
            txtMSSV.Size = new Size(178, 27);
            txtMSSV.TabIndex = 1;
            txtMSSV.Text = "Nhập MSSV";
<<<<<<< Updated upstream
=======
            txtMSSV.Click += txtMSSV_Click;
>>>>>>> Stashed changes
            txtMSSV.KeyPress += txtMSSV_KeyPress;
            // 
            // txtFname
            // 
            txtFname.Location = new Point(88, 239);
            txtFname.Name = "txtFname";
            txtFname.Size = new Size(178, 27);
            txtFname.TabIndex = 3;
            txtFname.Text = "Nhập họ và tên đệm";
<<<<<<< Updated upstream
            txtFname.TextChanged += textBox2_TextChanged;
=======
            txtFname.Click += txtFname_Click;
>>>>>>> Stashed changes
            txtFname.KeyPress += txtFname_KeyPress;
            // 
            // txtLname
            // 
<<<<<<< Updated upstream
            txtLname.Location = new Point(88, 286);
=======
            txtLname.Location = new Point(88, 285);
>>>>>>> Stashed changes
            txtLname.Name = "txtLname";
            txtLname.Size = new Size(178, 27);
            txtLname.TabIndex = 5;
            txtLname.Text = "Nhập tên";
<<<<<<< Updated upstream
            txtLname.KeyPress += txtLname_KeyPress;
=======
            txtLname.Click += txtLname_Click;
            txtLname.KeyPress += txtFname_KeyPress;
>>>>>>> Stashed changes
            // 
            // txtHometown
            // 
            txtHometown.Location = new Point(461, 239);
            txtHometown.Name = "txtHometown";
            txtHometown.Size = new Size(178, 27);
            txtHometown.TabIndex = 13;
            txtHometown.Text = "Nhập quê quán";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(461, 192);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(178, 27);
            txtAddress.TabIndex = 11;
            txtAddress.Text = "Nhập địa chỉ";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(461, 144);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(178, 27);
            txtPhone.TabIndex = 9;
            txtPhone.Text = "Nhập số điện thoại";
<<<<<<< Updated upstream
=======
            txtPhone.Click += txtPhone_Click;
>>>>>>> Stashed changes
            txtPhone.KeyPress += txtMSSV_KeyPress;
            // 
            // picStudent
            // 
            picStudent.AccessibleName = "picStudent";
<<<<<<< Updated upstream
            picStudent.BackColor = SystemColors.HighlightText;
            picStudent.BackgroundImageLayout = ImageLayout.Center;
            picStudent.BorderStyle = BorderStyle.FixedSingle;
            picStudent.Location = new Point(126, 33);
            picStudent.Name = "picStudent";
            picStudent.Size = new Size(90, 90);
=======
            picStudent.BorderStyle = BorderStyle.FixedSingle;
            picStudent.Location = new Point(126, 33);
            picStudent.Name = "picStudent";
            picStudent.Size = new Size(90, 91);
>>>>>>> Stashed changes
            picStudent.SizeMode = PictureBoxSizeMode.Zoom;
            picStudent.TabIndex = 18;
            picStudent.TabStop = false;
            // 
            // dtpDob
            // 
<<<<<<< Updated upstream
            dtpDob.CustomFormat = "dd/MM/yyyy";
            dtpDob.Format = DateTimePickerFormat.Custom;
=======
            dtpDob.Format = DateTimePickerFormat.Short;
>>>>>>> Stashed changes
            dtpDob.Location = new Point(461, 48);
            dtpDob.MaxDate = new DateTime(2008, 12, 31, 0, 0, 0, 0);
            dtpDob.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(178, 27);
            dtpDob.TabIndex = 20;
            dtpDob.Value = new DateTime(2008, 1, 1, 0, 0, 0, 0);
            dtpDob.ValueChanged += dtpDob_ValueChanged;
            // 
            // txtEmail
            // 
<<<<<<< Updated upstream
            txtEmail.Location = new Point(461, 286);
=======
            txtEmail.Location = new Point(461, 285);
>>>>>>> Stashed changes
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(178, 27);
            txtEmail.TabIndex = 21;
            txtEmail.Text = "Nhập email";
            // 
            // cboGender
            // 
            cboGender.FormattingEnabled = true;
<<<<<<< Updated upstream
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
=======
>>>>>>> Stashed changes
            cboGender.Location = new Point(461, 95);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(178, 28);
            cboGender.TabIndex = 22;
            cboGender.Text = "Items: Nam, Nữ, Khác";
            cboGender.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // btnChooseImage
            // 
<<<<<<< Updated upstream
            btnChooseImage.BackColor = SystemColors.ScrollBar;
=======
>>>>>>> Stashed changes
            btnChooseImage.Location = new Point(88, 144);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(178, 29);
            btnChooseImage.TabIndex = 23;
            btnChooseImage.Text = "Chọn ảnh từ máy tính";
            btnChooseImage.UseVisualStyleBackColor = false;
            btnChooseImage.Click += btnChooseImage_Click;
            // 
            // btnAdd
            // 
<<<<<<< Updated upstream
            btnAdd.BackColor = SystemColors.ScrollBar;
            btnAdd.Location = new Point(427, 346);
=======
            btnAdd.BackColor = Color.Transparent;
            btnAdd.Location = new Point(427, 347);
>>>>>>> Stashed changes
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(101, 72);
            btnAdd.TabIndex = 24;
            btnAdd.Text = "Thêm sinh viên";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClear
            // 
<<<<<<< Updated upstream
            btnClear.BackColor = SystemColors.ControlLight;
            btnClear.Location = new Point(574, 346);
=======
            btnClear.Location = new Point(574, 347);
>>>>>>> Stashed changes
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(101, 72);
            btnClear.TabIndex = 25;
            btnClear.Text = "Xóa trắng form";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // f_AddStudent
            // 
            AccessibleDescription = "";
            AccessibleName = "";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
<<<<<<< Updated upstream
            ClientSize = new Size(800, 450);
=======
            ClientSize = new Size(743, 427);
>>>>>>> Stashed changes
            Controls.Add(btnClear);
            Controls.Add(btnAdd);
            Controls.Add(btnChooseImage);
            Controls.Add(cboGender);
            Controls.Add(txtEmail);
            Controls.Add(dtpDob);
            Controls.Add(picStudent);
            Controls.Add(txtHometown);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(txtLname);
            Controls.Add(txtFname);
            Controls.Add(txtMSSV);
            Name = "f_AddStudent";
            Text = "f_AddStudent";
            Load += f_AddStudent_Load;
            ((System.ComponentModel.ISupportInitialize)picStudent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtMSSV;
        private TextBox txtFname;
        private TextBox txtLname;
        private TextBox txtHometown;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private PictureBox picStudent;
        private DateTimePicker dtpDob;
        private TextBox txtEmail;
        private ComboBox cboGender;
        private Button btnChooseImage;
        private Button btnAdd;
        private Button btnClear;
    }
}