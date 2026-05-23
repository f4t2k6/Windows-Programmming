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
            panel1 = new Panel();
            lbl_ResetPass = new Label();
            pic_Logo_HCMUTE_FPass = new PictureBox();
            txb_NewPass = new TextBox();
            txb_ConfirmPass = new TextBox();
            lbl_ConfirmPass_Reset = new Label();
            btn_Update = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Logo_HCMUTE_FPass).BeginInit();
            SuspendLayout();
            // 
            // lbl_NewPass_Reset
            // 
            lbl_NewPass_Reset.AutoSize = true;
            lbl_NewPass_Reset.BackColor = SystemColors.InactiveCaption;
            lbl_NewPass_Reset.Font = new Font("Segoe UI", 11F);
            lbl_NewPass_Reset.Location = new Point(49, 176);
            lbl_NewPass_Reset.Name = "lbl_NewPass_Reset";
            lbl_NewPass_Reset.Size = new Size(128, 25);
            lbl_NewPass_Reset.TabIndex = 0;
            lbl_NewPass_Reset.Text = "Mật khẩu mới";
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Controls.Add(lbl_ResetPass);
            panel1.Controls.Add(pic_Logo_HCMUTE_FPass);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(582, 100);
            panel1.TabIndex = 1;
            // 
            // lbl_ResetPass
            // 
            lbl_ResetPass.AutoSize = true;
            lbl_ResetPass.Font = new Font("Segoe UI Historic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_ResetPass.ForeColor = SystemColors.Window;
            lbl_ResetPass.Location = new Point(261, 29);
            lbl_ResetPass.Name = "lbl_ResetPass";
            lbl_ResetPass.Size = new Size(223, 38);
            lbl_ResetPass.TabIndex = 1;
            lbl_ResetPass.Text = "Reset Password";
            // 
            // pic_Logo_HCMUTE_FPass
            // 
            pic_Logo_HCMUTE_FPass.BackColor = Color.DarkBlue;
            pic_Logo_HCMUTE_FPass.Image = Properties.Resources.logo_HCMUTE_MainMenu;
            pic_Logo_HCMUTE_FPass.Location = new Point(0, -81);
            pic_Logo_HCMUTE_FPass.Name = "pic_Logo_HCMUTE_FPass";
            pic_Logo_HCMUTE_FPass.Size = new Size(177, 262);
            pic_Logo_HCMUTE_FPass.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Logo_HCMUTE_FPass.TabIndex = 0;
            pic_Logo_HCMUTE_FPass.TabStop = false;
            // 
            // txb_NewPass
            // 
            txb_NewPass.Location = new Point(253, 174);
            txb_NewPass.Name = "txb_NewPass";
            txb_NewPass.Size = new Size(231, 27);
            txb_NewPass.TabIndex = 2;
            // 
            // txb_ConfirmPass
            // 
            txb_ConfirmPass.Location = new Point(253, 243);
            txb_ConfirmPass.Name = "txb_ConfirmPass";
            txb_ConfirmPass.Size = new Size(231, 27);
            txb_ConfirmPass.TabIndex = 4;
            // 
            // lbl_ConfirmPass_Reset
            // 
            lbl_ConfirmPass_Reset.AutoSize = true;
            lbl_ConfirmPass_Reset.BackColor = SystemColors.InactiveCaption;
            lbl_ConfirmPass_Reset.Font = new Font("Segoe UI", 11F);
            lbl_ConfirmPass_Reset.Location = new Point(49, 245);
            lbl_ConfirmPass_Reset.Name = "lbl_ConfirmPass_Reset";
            lbl_ConfirmPass_Reset.Size = new Size(171, 25);
            lbl_ConfirmPass_Reset.TabIndex = 3;
            lbl_ConfirmPass_Reset.Text = "Nhập lại mật khẩu ";
            // 
            // btn_Update
            // 
            btn_Update.BackColor = Color.Peru;
            btn_Update.Font = new Font("Segoe UI", 12F);
            btn_Update.Location = new Point(207, 334);
            btn_Update.Name = "btn_Update";
            btn_Update.Size = new Size(132, 52);
            btn_Update.TabIndex = 5;
            btn_Update.Text = "Cập nhật ";
            btn_Update.UseVisualStyleBackColor = false;
            btn_Update.Click += btn_Update_Click;
            // 
            // f_ResetPass
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(582, 453);
            Controls.Add(btn_Update);
            Controls.Add(txb_ConfirmPass);
            Controls.Add(lbl_ConfirmPass_Reset);
            Controls.Add(txb_NewPass);
            Controls.Add(panel1);
            Controls.Add(lbl_NewPass_Reset);
            Name = "f_ResetPass";
            Text = "f_ResetPass";
            Load += f_ResetPass_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Logo_HCMUTE_FPass).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_NewPass_Reset;
        private Panel panel1;
        private Label lbl_ResetPass;
        private PictureBox pic_Logo_HCMUTE_FPass;
        private TextBox txb_NewPass;
        private TextBox txb_ConfirmPass;
        private Label lbl_ConfirmPass_Reset;
        private Button btn_Update;
    }
}