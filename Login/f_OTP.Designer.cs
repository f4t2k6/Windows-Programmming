namespace ProjectMonHoc
{
    partial class f_OTP
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
            lbl_Title = new Label();
            lbl_Info = new Label();
            txb_OTP = new TextBox();
            btn_Verify = new Button();
            btn_Resend = new Button();
            btn_Cancel_OTP = new Button();
            SuspendLayout();
            // 
            // lbl_Title
            // 
            lbl_Title.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Title.ForeColor = Color.SteelBlue;
            lbl_Title.Location = new Point(12, 19);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(476, 70);
            lbl_Title.TabIndex = 0;
            lbl_Title.Text = "XÁC THỰC OTP";
            lbl_Title.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Title.Click += lbl_Title_Click;
            // 
            // lbl_Info
            // 
            lbl_Info.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Info.ForeColor = Color.DimGray;
            lbl_Info.Location = new Point(12, 106);
            lbl_Info.Name = "lbl_Info";
            lbl_Info.Size = new Size(476, 84);
            lbl_Info.TabIndex = 2;
            lbl_Info.Text = "Mã xác thực đã được gửi đến email của bạn.\nVui lòng kiểm tra và nhập mã vào ô dưới đây:";
            lbl_Info.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txb_OTP
            // 
            txb_OTP.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txb_OTP.ForeColor = Color.MediumBlue;
            txb_OTP.Location = new Point(57, 206);
            txb_OTP.MaxLength = 6;
            txb_OTP.Name = "txb_OTP";
            txb_OTP.Size = new Size(368, 51);
            txb_OTP.TabIndex = 3;
            txb_OTP.TextAlign = HorizontalAlignment.Center;
            txb_OTP.KeyPress += txb_OTP_KeyPress;
            // 
            // btn_Verify
            // 
            btn_Verify.BackColor = Color.SteelBlue;
            btn_Verify.Cursor = Cursors.Hand;
            btn_Verify.FlatAppearance.BorderSize = 0;
            btn_Verify.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn_Verify.ForeColor = Color.White;
            btn_Verify.Location = new Point(57, 317);
            btn_Verify.Name = "btn_Verify";
            btn_Verify.Size = new Size(154, 70);
            btn_Verify.TabIndex = 4;
            btn_Verify.Text = "Xác nhận";
            btn_Verify.UseVisualStyleBackColor = false;
            btn_Verify.Click += btn_Verify_Click;
            // 
            // btn_Resend
            // 
            btn_Resend.BackColor = Color.White;
            btn_Resend.Cursor = Cursors.Hand;
            btn_Resend.FlatAppearance.BorderSize = 0;
            btn_Resend.FlatStyle = FlatStyle.Flat;
            btn_Resend.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            btn_Resend.ForeColor = Color.Gray;
            btn_Resend.Location = new Point(57, 263);
            btn_Resend.Name = "btn_Resend";
            btn_Resend.Size = new Size(116, 30);
            btn_Resend.TabIndex = 5;
            btn_Resend.Text = "Gửi lại mã OTP";
            btn_Resend.UseVisualStyleBackColor = false;
            btn_Resend.Click += btn_Resend_Click;
            // 
            // btn_Cancel_OTP
            // 
            btn_Cancel_OTP.BackColor = Color.IndianRed;
            btn_Cancel_OTP.FlatAppearance.BorderSize = 0;
            btn_Cancel_OTP.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn_Cancel_OTP.ForeColor = Color.White;
            btn_Cancel_OTP.Location = new Point(271, 317);
            btn_Cancel_OTP.Name = "btn_Cancel_OTP";
            btn_Cancel_OTP.Size = new Size(154, 70);
            btn_Cancel_OTP.TabIndex = 7;
            btn_Cancel_OTP.Text = "Hủy";
            btn_Cancel_OTP.UseVisualStyleBackColor = false;
            btn_Cancel_OTP.Click += btn_Cancel_OTP_Click;
            // 
            // f_OTP
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 643);
            Controls.Add(btn_Cancel_OTP);
            Controls.Add(btn_Resend);
            Controls.Add(btn_Verify);
            Controls.Add(txb_OTP);
            Controls.Add(lbl_Info);
            Controls.Add(lbl_Title);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "f_OTP";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xác Thực Email";
            Load += f_OTP_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Title;
        private Label lbl_Info;
        private TextBox txb_OTP;
        private Button btn_Verify;
        private Button btn_Resend;
        private Button btn_Cancel_OTP;
    }
}