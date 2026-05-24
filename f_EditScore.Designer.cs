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
            lblTitle = new System.Windows.Forms.Label();
            lblStudentId = new System.Windows.Forms.Label();
            txtStudentId = new System.Windows.Forms.TextBox();
            lblCourseId = new System.Windows.Forms.Label();
            txtCourseId = new System.Windows.Forms.TextBox();
            lblCourseName = new System.Windows.Forms.Label();
            txtCourseName = new System.Windows.Forms.TextBox();
            lblScore = new System.Windows.Forms.Label();
            nudScore = new System.Windows.Forms.NumericUpDown();
            lblDescription = new System.Windows.Forms.Label();
            txtDescription = new System.Windows.Forms.TextBox();
            btnSave = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            lblNote = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)nudScore).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.DarkSlateBlue;
            lblTitle.Location = new System.Drawing.Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(280, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chỉnh sửa điểm môn học";
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblStudentId.Location = new System.Drawing.Point(30, 80);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.TabIndex = 1;
            lblStudentId.Text = "MSSV:";
            // 
            // txtStudentId
            // 
            txtStudentId.BackColor = System.Drawing.Color.LightGray;
            txtStudentId.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtStudentId.Location = new System.Drawing.Point(180, 77);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new System.Drawing.Size(250, 32);
            txtStudentId.TabIndex = 2;
            // 
            // lblCourseId
            // 
            lblCourseId.AutoSize = true;
            lblCourseId.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblCourseId.Location = new System.Drawing.Point(30, 130);
            lblCourseId.Name = "lblCourseId";
            lblCourseId.TabIndex = 3;
            lblCourseId.Text = "Mã môn học:";
            // 
            // txtCourseId
            // 
            txtCourseId.BackColor = System.Drawing.Color.LightGray;
            txtCourseId.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtCourseId.Location = new System.Drawing.Point(180, 127);
            txtCourseId.Name = "txtCourseId";
            txtCourseId.Size = new System.Drawing.Size(250, 32);
            txtCourseId.TabIndex = 4;
            // 
            // lblCourseName
            // 
            lblCourseName.AutoSize = true;
            lblCourseName.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblCourseName.Location = new System.Drawing.Point(30, 180);
            lblCourseName.Name = "lblCourseName";
            lblCourseName.TabIndex = 5;
            lblCourseName.Text = "Tên môn học:";
            // 
            // txtCourseName
            // 
            txtCourseName.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtCourseName.Location = new System.Drawing.Point(180, 177);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new System.Drawing.Size(350, 32);
            txtCourseName.TabIndex = 6;
            txtCourseName.TextChanged += txtCourseName_TextChanged;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblScore.Location = new System.Drawing.Point(30, 230);
            lblScore.Name = "lblScore";
            lblScore.TabIndex = 7;
            lblScore.Text = "Điểm số (0 - 10):";
            // 
            // nudScore
            // 
            nudScore.DecimalPlaces = 1;
            nudScore.Font = new System.Drawing.Font("Segoe UI", 11F);
            nudScore.Increment = new decimal(new int[] { 1, 0, 0, 65536 }); // 0.1
            nudScore.Location = new System.Drawing.Point(180, 227);
            nudScore.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudScore.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nudScore.Name = "nudScore";
            nudScore.Size = new System.Drawing.Size(120, 32);
            nudScore.TabIndex = 8;
            nudScore.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblDescription.Location = new System.Drawing.Point(30, 280);
            lblDescription.Name = "lblDescription";
            lblDescription.TabIndex = 9;
            lblDescription.Text = "Ghi chú:";
            // 
            // txtDescription
            // 
            txtDescription.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtDescription.Location = new System.Drawing.Point(180, 277);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new System.Drawing.Size(350, 70);
            txtDescription.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.ForestGreen;
            btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Location = new System.Drawing.Point(180, 370);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(150, 45);
            btnSave.TabIndex = 11;
            btnSave.Text = "💾 Lưu thay đổi";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = System.Drawing.Color.Tomato;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Location = new System.Drawing.Point(350, 370);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(120, 45);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "✖ Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblNote.ForeColor = System.Drawing.Color.Gray;
            lblNote.Location = new System.Drawing.Point(30, 430);
            lblNote.Name = "lblNote";
            lblNote.Size = new System.Drawing.Size(350, 20);
            lblNote.TabIndex = 13;
            lblNote.Text = "* MSSV và Mã môn học không thể thay đổi.";
            // 
            // f_EditScore
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ActiveCaption;
            ClientSize = new System.Drawing.Size(580, 470);
            Controls.Add(lblNote);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(nudScore);
            Controls.Add(lblScore);
            Controls.Add(txtCourseName);
            Controls.Add(lblCourseName);
            Controls.Add(txtCourseId);
            Controls.Add(lblCourseId);
            Controls.Add(txtStudentId);
            Controls.Add(lblStudentId);
            Controls.Add(lblTitle);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "f_EditScore";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Chỉnh sửa điểm môn học";
            Load += f_EditScore_Load;
            ((System.ComponentModel.ISupportInitialize)nudScore).EndInit();
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
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.NumericUpDown nudScore;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblNote;
    }
}
