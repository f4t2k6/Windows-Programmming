namespace ProjectMonHoc
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lb_accountlogin = new Label();
            lb_username = new Label();
            lb_password = new Label();
            tb_username = new TextBox();
            tb_password = new TextBox();
            pictureBox1 = new PictureBox();
            bt_cancel = new Button();
            bt_login = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lb_accountlogin
            // 
            lb_accountlogin.AutoSize = true;
            lb_accountlogin.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_accountlogin.ForeColor = Color.White;
            lb_accountlogin.Location = new Point(434, 31);
            lb_accountlogin.Name = "lb_accountlogin";
            lb_accountlogin.Size = new Size(251, 46);
            lb_accountlogin.TabIndex = 0;
            lb_accountlogin.Text = "Account Login";
            lb_accountlogin.Click += label1_Click;
            // 
            // lb_username
            // 
            lb_username.AutoSize = true;
            lb_username.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_username.ForeColor = Color.White;
            lb_username.Location = new Point(107, 163);
            lb_username.Name = "lb_username";
            lb_username.Size = new Size(148, 38);
            lb_username.TabIndex = 1;
            lb_username.Text = "Username:";
            // 
            // lb_password
            // 
            lb_password.AutoSize = true;
            lb_password.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_password.ForeColor = Color.White;
            lb_password.Location = new Point(107, 265);
            lb_password.Name = "lb_password";
            lb_password.Size = new Size(138, 38);
            lb_password.TabIndex = 2;
            lb_password.Text = "Password:";
            lb_password.Click += label1_Click_1;
            // 
            // tb_username
            // 
            tb_username.Location = new Point(309, 174);
            tb_username.Name = "tb_username";
            tb_username.Size = new Size(320, 27);
            tb_username.TabIndex = 3;
            // 
            // tb_password
            // 
            tb_password.Location = new Point(309, 276);
            tb_password.Name = "tb_password";
            tb_password.Size = new Size(320, 27);
            tb_password.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.hcmute;
            pictureBox1.Location = new Point(124, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 129);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // bt_cancel
            // 
            bt_cancel.BackColor = Color.IndianRed;
            bt_cancel.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bt_cancel.ForeColor = Color.White;
            bt_cancel.Location = new Point(151, 339);
            bt_cancel.Name = "bt_cancel";
            bt_cancel.Size = new Size(185, 70);
            bt_cancel.TabIndex = 6;
            bt_cancel.Text = "Cancel";
            bt_cancel.UseVisualStyleBackColor = false;
            bt_cancel.Click += bt_cancel_Click;
            // 
            // bt_login
            // 
            bt_login.BackColor = Color.ForestGreen;
            bt_login.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bt_login.ForeColor = Color.White;
            bt_login.Location = new Point(401, 339);
            bt_login.Name = "bt_login";
            bt_login.Size = new Size(185, 70);
            bt_login.TabIndex = 7;
            bt_login.Text = "Login";
            bt_login.UseVisualStyleBackColor = false;
            bt_login.Click += bt_login_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(bt_login);
            Controls.Add(bt_cancel);
            Controls.Add(pictureBox1);
            Controls.Add(tb_password);
            Controls.Add(tb_username);
            Controls.Add(lb_password);
            Controls.Add(lb_username);
            Controls.Add(lb_accountlogin);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_accountlogin;
        private Label lb_username;
        private Label lb_password;
        private TextBox tb_username;
        private TextBox tb_password;
        private PictureBox pictureBox1;
        private Button bt_cancel;
        private Button bt_login;
    }
}
