namespace ProjectMonHoc
{
    partial class f_EditScore
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
            lblStudentId = new Label();
            txtStudentId = new TextBox();
            lblCourseId = new Label();
            txtCourseId = new TextBox();
            lblCourseName = new Label();
            txtCourseName = new TextBox();
            lblDiemQT = new Label();
            nudDiemQT = new NumericUpDown();
            lblDiemCK = new Label();
            nudDiemCK = new NumericUpDown();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblNote = new Label();
            ((System.ComponentModel.ISupportInitialize)nudDiemQT).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDiemCK).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkSlateBlue;
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(332, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chỉnh sửa điểm môn học";
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Font = new Font("Segoe UI", 11F);
            lblStudentId.Location = new Point(30, 80);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(65, 25);
            lblStudentId.TabIndex = 1;
            lblStudentId.Text = "MSSV:";
            // 
            // txtStudentId
            // 
            txtStudentId.BackColor = Color.LightGray;
            txtStudentId.Font = new Font("Segoe UI", 11F);
            txtStudentId.Location = new Point(180, 77);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(250, 32);
            txtStudentId.TabIndex = 2;
            // 
            // lblCourseId
            // 
            lblCourseId.AutoSize = true;
            lblCourseId.Font = new Font("Segoe UI", 11F);
            lblCourseId.Location = new Point(30, 130);
            lblCourseId.Name = "lblCourseId";
            lblCourseId.Size = new Size(122, 25);
            lblCourseId.TabIndex = 3;
            lblCourseId.Text = "Mã môn học:";
            // 
            // txtCourseId
            // 
            txtCourseId.BackColor = Color.LightGray;
            txtCourseId.Font = new Font("Segoe UI", 11F);
            txtCourseId.Location = new Point(180, 127);
            txtCourseId.Name = "txtCourseId";
            txtCourseId.Size = new Size(250, 32);
            txtCourseId.TabIndex = 4;
            // 
            // lblCourseName
            // 
            lblCourseName.AutoSize = true;
            lblCourseName.Font = new Font("Segoe UI", 11F);
            lblCourseName.Location = new Point(30, 180);
            lblCourseName.Name = "lblCourseName";
            lblCourseName.Size = new Size(124, 25);
            lblCourseName.TabIndex = 5;
            lblCourseName.Text = "Tên môn học:";
            // 
            // txtCourseName
            // 
            txtCourseName.Font = new Font("Segoe UI", 11F);
            txtCourseName.Location = new Point(180, 177);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(350, 32);
            txtCourseName.TabIndex = 6;
            txtCourseName.TextChanged += txtCourseName_TextChanged;
            // 
            // lblDiemQT
            // 
            lblDiemQT.AutoSize = true;
            lblDiemQT.Font = new Font("Segoe UI", 11F);
            lblDiemQT.Location = new Point(30, 230);
            lblDiemQT.Name = "lblDiemQT";
            lblDiemQT.Size = new Size(89, 25);
            lblDiemQT.TabIndex = 7;
            lblDiemQT.Text = "Điểm QT:";
            // 
            // nudDiemQT
            // 
            nudDiemQT.DecimalPlaces = 1;
            nudDiemQT.Font = new Font("Segoe UI", 11F);
            nudDiemQT.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudDiemQT.Location = new Point(180, 227);
            nudDiemQT.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudDiemQT.Name = "nudDiemQT";
            nudDiemQT.Size = new Size(90, 32);
            nudDiemQT.TabIndex = 8;
            // 
            // lblDiemCK
            // 
            lblDiemCK.AutoSize = true;
            lblDiemCK.Font = new Font("Segoe UI", 11F);
            lblDiemCK.Location = new Point(300, 230);
            lblDiemCK.Name = "lblDiemCK";
            lblDiemCK.Size = new Size(88, 25);
            lblDiemCK.TabIndex = 14;
            lblDiemCK.Text = "Điểm CK:";
            // 
            // nudDiemCK
            // 
            nudDiemCK.DecimalPlaces = 1;
            nudDiemCK.Font = new Font("Segoe UI", 11F);
            nudDiemCK.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudDiemCK.Location = new Point(440, 227);
            nudDiemCK.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudDiemCK.Name = "nudDiemCK";
            nudDiemCK.Size = new Size(90, 32);
            nudDiemCK.TabIndex = 15;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 11F);
            lblDescription.Location = new Point(30, 280);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(81, 25);
            lblDescription.TabIndex = 9;
            lblDescription.Text = "Ghi chú:";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 11F);
            txtDescription.Location = new Point(180, 277);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(350, 70);
            txtDescription.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.ForestGreen;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(180, 370);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 45);
            btnSave.TabIndex = 11;
            btnSave.Text = "💾 Lưu thay đổi";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Tomato;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(350, 370);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 45);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "✖ Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblNote.ForeColor = Color.Gray;
            lblNote.Location = new Point(30, 430);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(283, 20);
            lblNote.TabIndex = 13;
            lblNote.Text = "* MSSV và Mã môn học không thể thay đổi.";
            // 
            // f_EditScore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(580, 470);
            Controls.Add(nudDiemCK);
            Controls.Add(lblDiemCK);
            Controls.Add(nudDiemQT);
            Controls.Add(lblDiemQT);
            Controls.Add(lblNote);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(txtCourseName);
            Controls.Add(lblCourseName);
            Controls.Add(txtCourseId);
            Controls.Add(lblCourseId);
            Controls.Add(txtStudentId);
            Controls.Add(lblStudentId);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "f_EditScore";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chỉnh sửa điểm môn học";
            Load += f_EditScore_Load;
            ((System.ComponentModel.ISupportInitialize)nudDiemQT).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDiemCK).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Label lblCourseId;
        private System.Windows.Forms.TextBox txtCourseId;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.Label lblDiemQT;
        private System.Windows.Forms.NumericUpDown nudDiemQT;
        private System.Windows.Forms.Label lblDiemCK;
        private System.Windows.Forms.NumericUpDown nudDiemCK;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblNote;
    }
}