namespace ProjectMonHoc
{
    partial class f_ResetPass
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
            lbl_NewPass_Reset = new Label();
            txb_NewPass = new TextBox();
            ptb_ShowNewPass = new PictureBox();
            txb_ConfirmPass = new TextBox();
            ptb_ShowConfirmPass = new PictureBox();
            lbl_ConfirmPass_Reset = new Label();
            lbl_PassStatus = new Label();
            btn_Update = new Button();
            lbl_ResetPass = new Label();
            btn_Cancel_ResetPass = new Button();
            ((System.ComponentModel.ISupportInitialize)ptb_ShowNewPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptb_ShowConfirmPass).BeginInit();
            SuspendLayout();
            // 
            // lbl_NewPass_Reset
            // 
            lbl_NewPass_Reset.AutoSize = true;
            lbl_NewPass_Reset.BackColor = Color.Transparent;
            lbl_NewPass_Reset.Font = new Font("Segoe UI", 10.2F);
            lbl_NewPass_Reset.ForeColor = SystemColors.GrayText;
            lbl_NewPass_Reset.Location = new Point(45, 136);
            lbl_NewPass_Reset.Name = "lbl_NewPass_Reset";
            lbl_NewPass_Reset.Size = new Size(116, 23);
            lbl_NewPass_Reset.TabIndex = 0;
            lbl_NewPass_Reset.Text = "Mật khẩu mới";
            lbl_NewPass_Reset.Click += lbl_NewPass_Reset_Click;
            // 
            // txb_NewPass
            // 
            txb_NewPass.Font = new Font("Segoe UI", 12F);
            txb_NewPass.Location = new Point(45, 162);
            txb_NewPass.Name = "txb_NewPass";
            txb_NewPass.PasswordChar = '●';
            txb_NewPass.Size = new Size(361, 34);
            txb_NewPass.TabIndex = 2;
            txb_NewPass.TextChanged += txb_NewPass_TextChanged;
            // 
            // ptb_ShowNewPass
            // 
            ptb_ShowNewPass.Cursor = Cursors.Hand;
            ptb_ShowNewPass.Location = new Point(412, 162);
            ptb_ShowNewPass.Name = "ptb_ShowNewPass";
            ptb_ShowNewPass.Size = new Size(34, 34);
            ptb_ShowNewPass.SizeMode = PictureBoxSizeMode.Zoom;
            ptb_ShowNewPass.TabIndex = 3;
            ptb_ShowNewPass.TabStop = false;
            ptb_ShowNewPass.Click += ptb_ShowNewPass_Click;
            // 
            // txb_ConfirmPass
            // 
            txb_ConfirmPass.Font = new Font("Segoe UI", 12F);
            txb_ConfirmPass.Location = new Point(45, 260);
            txb_ConfirmPass.Name = "txb_ConfirmPass";
            txb_ConfirmPass.PasswordChar = '●';
            txb_ConfirmPass.Size = new Size(361, 34);
            txb_ConfirmPass.TabIndex = 4;
            txb_ConfirmPass.TextChanged += txb_ConfirmPass_TextChanged;
            // 
            // ptb_ShowConfirmPass
            // 
            ptb_ShowConfirmPass.Cursor = Cursors.Hand;
            ptb_ShowConfirmPass.Location = new Point(412, 260);
            ptb_ShowConfirmPass.Name = "ptb_ShowConfirmPass";
            ptb_ShowConfirmPass.Size = new Size(34, 34);
            ptb_ShowConfirmPass.SizeMode = PictureBoxSizeMode.Zoom;
            ptb_ShowConfirmPass.TabIndex = 5;
            ptb_ShowConfirmPass.TabStop = false;
            ptb_ShowConfirmPass.Click += ptb_ShowConfirmPass_Click;
            // 
            // lbl_ConfirmPass_Reset
            // 
            lbl_ConfirmPass_Reset.AutoSize = true;
            lbl_ConfirmPass_Reset.BackColor = Color.Transparent;
            lbl_ConfirmPass_Reset.Font = new Font("Segoe UI", 10.2F);
            lbl_ConfirmPass_Reset.ForeColor = SystemColors.GrayText;
            lbl_ConfirmPass_Reset.Location = new Point(45, 234);
            lbl_ConfirmPass_Reset.Name = "lbl_ConfirmPass_Reset";
            lbl_ConfirmPass_Reset.Size = new Size(156, 23);
            lbl_ConfirmPass_Reset.TabIndex = 3;
            lbl_ConfirmPass_Reset.Text = "Nhập lại mật khẩu ";
            lbl_ConfirmPass_Reset.Click += lbl_ConfirmPass_Reset_Click;
            // 
            // lbl_PassStatus
            // 
            lbl_PassStatus.AutoSize = true;
            lbl_PassStatus.BackColor = Color.Transparent;
            lbl_PassStatus.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_PassStatus.ForeColor = Color.SeaGreen;
            lbl_PassStatus.Location = new Point(450, 260);
            lbl_PassStatus.Name = "lbl_PassStatus";
            lbl_PassStatus.Size = new Size(38, 37);
            lbl_PassStatus.TabIndex = 6;
            lbl_PassStatus.Text = "✓";
            lbl_PassStatus.Visible = false;
            // 
            // btn_Update
            // 
            btn_Update.BackColor = Color.Peru;
            btn_Update.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn_Update.ForeColor = Color.White;
            btn_Update.Location = new Point(45, 347);
            btn_Update.Name = "btn_Update";
            btn_Update.Size = new Size(154, 70);
            btn_Update.TabIndex = 7;
            btn_Update.Text = "Cập nhật";
            btn_Update.UseVisualStyleBackColor = false;
            btn_Update.Click += btn_Update_Click;
            // 
            // lbl_ResetPass
            // 
            lbl_ResetPass.Anchor = AnchorStyles.None;
            lbl_ResetPass.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lbl_ResetPass.ForeColor = Color.SteelBlue;
            lbl_ResetPass.Location = new Point(12, 9);
            lbl_ResetPass.Name = "lbl_ResetPass";
            lbl_ResetPass.Size = new Size(476, 103);
            lbl_ResetPass.TabIndex = 1;
            lbl_ResetPass.Text = "ĐẶT LẠI MẬT KHẨU";
            lbl_ResetPass.TextAlign = ContentAlignment.MiddleCenter;
            lbl_ResetPass.Click += lbl_ResetPass_Click;
            // 
            // btn_Cancel_ResetPass
            // 
            btn_Cancel_ResetPass.BackColor = Color.IndianRed;
            btn_Cancel_ResetPass.FlatAppearance.BorderSize = 0;
            btn_Cancel_ResetPass.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn_Cancel_ResetPass.ForeColor = Color.White;
            btn_Cancel_ResetPass.Location = new Point(299, 347);
            btn_Cancel_ResetPass.Name = "btn_Cancel_ResetPass";
            btn_Cancel_ResetPass.Size = new Size(154, 70);
            btn_Cancel_ResetPass.TabIndex = 8;
            btn_Cancel_ResetPass.Text = "Hủy";
            btn_Cancel_ResetPass.UseVisualStyleBackColor = false;
            btn_Cancel_ResetPass.Click += btn_Cancel_ResetPass_Click;
            // 
            // f_ResetPass
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 643);
            Controls.Add(btn_Cancel_ResetPass);
            Controls.Add(lbl_ResetPass);
            Controls.Add(btn_Update);
            Controls.Add(lbl_PassStatus);
            Controls.Add(ptb_ShowConfirmPass);
            Controls.Add(txb_ConfirmPass);
            Controls.Add(lbl_ConfirmPass_Reset);
            Controls.Add(ptb_ShowNewPass);
            Controls.Add(txb_NewPass);
            Controls.Add(lbl_NewPass_Reset);
            FormBorderStyle = FormBorderStyle.None;
            Name = "f_ResetPass";
            Text = "f_ResetPass";
            Load += f_ResetPass_Load;
            ((System.ComponentModel.ISupportInitialize)ptb_ShowNewPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptb_ShowConfirmPass).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_NewPass_Reset;
        private TextBox txb_NewPass;
        private PictureBox ptb_ShowNewPass;
        private TextBox txb_ConfirmPass;
        private PictureBox ptb_ShowConfirmPass;
        private Label lbl_ConfirmPass_Reset;
        private Label lbl_PassStatus;
        private Button btn_Update;
        private Label lbl_ResetPass;
        private Button btn_Cancel_ResetPass;
    }
}