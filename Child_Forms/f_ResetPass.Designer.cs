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
            txb_ConfirmPass = new TextBox();
            lbl_ConfirmPass_Reset = new Label();
            btn_Update = new Button();
            lbl_ResetPass = new Label();
            btn_Cancel_ResetPass = new Button();
            SuspendLayout();
            // 
            // lbl_NewPass_Reset
            // 
            lbl_NewPass_Reset.AutoSize = true;
            lbl_NewPass_Reset.BackColor = Color.Transparent;
            lbl_NewPass_Reset.Font = new Font("Segoe UI", 13F);
            lbl_NewPass_Reset.ForeColor = SystemColors.GrayText;
            lbl_NewPass_Reset.Location = new Point(78, 182);
            lbl_NewPass_Reset.Name = "lbl_NewPass_Reset";
            lbl_NewPass_Reset.Size = new Size(146, 30);
            lbl_NewPass_Reset.TabIndex = 0;
            lbl_NewPass_Reset.Text = "Mật khẩu mới";
            lbl_NewPass_Reset.Click += this.lbl_NewPass_Reset_Click;
            // 
            // txb_NewPass
            // 
            txb_NewPass.Font = new Font("Segoe UI", 12F);
            txb_NewPass.Location = new Point(312, 180);
            txb_NewPass.Name = "txb_NewPass";
            txb_NewPass.PasswordChar = '*';
            txb_NewPass.Size = new Size(231, 34);
            txb_NewPass.TabIndex = 2;
            txb_NewPass.TextChanged += txb_NewPass_TextChanged;
            // 
            // txb_ConfirmPass
            // 
            txb_ConfirmPass.Font = new Font("Segoe UI", 12F);
            txb_ConfirmPass.Location = new Point(312, 247);
            txb_ConfirmPass.Name = "txb_ConfirmPass";
            txb_ConfirmPass.PasswordChar = '*';
            txb_ConfirmPass.Size = new Size(231, 34);
            txb_ConfirmPass.TabIndex = 4;
            // 
            // lbl_ConfirmPass_Reset
            // 
            lbl_ConfirmPass_Reset.AutoSize = true;
            lbl_ConfirmPass_Reset.BackColor = Color.Transparent;
            lbl_ConfirmPass_Reset.Font = new Font("Segoe UI", 13F);
            lbl_ConfirmPass_Reset.ForeColor = SystemColors.GrayText;
            lbl_ConfirmPass_Reset.Location = new Point(78, 249);
            lbl_ConfirmPass_Reset.Name = "lbl_ConfirmPass_Reset";
            lbl_ConfirmPass_Reset.Size = new Size(193, 30);
            lbl_ConfirmPass_Reset.TabIndex = 3;
            lbl_ConfirmPass_Reset.Text = "Nhập lại mật khẩu ";
            lbl_ConfirmPass_Reset.Click += this.lbl_ConfirmPass_Reset_Click;
            // 
            // btn_Update
            // 
            btn_Update.BackColor = Color.Peru;
            btn_Update.FlatStyle = FlatStyle.Flat;
            btn_Update.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btn_Update.ForeColor = Color.White;
            btn_Update.Location = new Point(78, 345);
            btn_Update.Name = "btn_Update";
            btn_Update.Size = new Size(154, 70);
            btn_Update.TabIndex = 5;
            btn_Update.Text = "Cập nhật";
            btn_Update.UseVisualStyleBackColor = false;
            btn_Update.Click += btn_Update_Click;
            // 
            // lbl_ResetPass
            // 
            lbl_ResetPass.AutoSize = true;
            lbl_ResetPass.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lbl_ResetPass.ForeColor = Color.SteelBlue;
            lbl_ResetPass.Location = new Point(127, 65);
            lbl_ResetPass.Name = "lbl_ResetPass";
            lbl_ResetPass.Size = new Size(401, 54);
            lbl_ResetPass.TabIndex = 1;
            lbl_ResetPass.Text = "ĐẶT LẠI MẬT KHẨU";
            lbl_ResetPass.Click += lbl_ResetPass_Click;
            // 
            // btn_Cancel_ResetPass
            // 
            btn_Cancel_ResetPass.BackColor = Color.IndianRed;
            btn_Cancel_ResetPass.FlatAppearance.BorderSize = 0;
            btn_Cancel_ResetPass.FlatStyle = FlatStyle.Flat;
            btn_Cancel_ResetPass.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btn_Cancel_ResetPass.ForeColor = Color.White;
            btn_Cancel_ResetPass.Location = new Point(389, 345);
            btn_Cancel_ResetPass.Name = "btn_Cancel_ResetPass";
            btn_Cancel_ResetPass.Size = new Size(154, 70);
            btn_Cancel_ResetPass.TabIndex = 22;
            btn_Cancel_ResetPass.Text = "Hủy";
            btn_Cancel_ResetPass.UseVisualStyleBackColor = false;
            btn_Cancel_ResetPass.Click += btn_Cancel_ResetPass_Click;
            // 
            // f_ResetPass
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(622, 673);
            Controls.Add(btn_Cancel_ResetPass);
            Controls.Add(lbl_ResetPass);
            Controls.Add(btn_Update);
            Controls.Add(txb_ConfirmPass);
            Controls.Add(lbl_ConfirmPass_Reset);
            Controls.Add(txb_NewPass);
            Controls.Add(lbl_NewPass_Reset);
            Name = "f_ResetPass";
            Text = "f_ResetPass";
            Load += f_ResetPass_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_NewPass_Reset;
        private TextBox txb_NewPass;
        private TextBox txb_ConfirmPass;
        private Label lbl_ConfirmPass_Reset;
        private Button btn_Update;
        private Label lbl_ResetPass;
        private Button btn_Cancel_ResetPass;
    }
}