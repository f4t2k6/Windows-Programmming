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
            panel_Line = new Panel();
            SuspendLayout();
            // 
            // lbl_Title
            // 
            lbl_Title.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Title.ForeColor = Color.MediumBlue;
            lbl_Title.Location = new Point(0, 20);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(400, 35);
            lbl_Title.TabIndex = 0;
            lbl_Title.Text = "XÁC THỰC OTP";
            lbl_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_Line
            // 
            panel_Line.BackColor = Color.LightGray;
            panel_Line.Location = new Point(40, 65);
            panel_Line.Name = "panel_Line";
            panel_Line.Size = new Size(320, 2);
            panel_Line.TabIndex = 1;
            // 
            // lbl_Info
            // 
            lbl_Info.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Info.ForeColor = Color.DimGray;
            lbl_Info.Location = new Point(30, 80);
            lbl_Info.Name = "lbl_Info";
            lbl_Info.Size = new Size(340, 50);
            lbl_Info.TabIndex = 2;
            lbl_Info.Text = "Mã xác thực đã được gửi đến email của bạn.\nVui lòng kiểm tra và nhập mã vào ô dưới đây:";
            lbl_Info.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txb_OTP
            // 
            txb_OTP.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            txb_OTP.ForeColor = Color.MediumBlue;
            txb_OTP.Location = new Point(100, 145);
            txb_OTP.MaxLength = 6;
            txb_OTP.Name = "txb_OTP";
            txb_OTP.Size = new Size(200, 47);
            txb_OTP.TabIndex = 3;
            txb_OTP.TextAlign = HorizontalAlignment.Center;
            txb_OTP.KeyPress += txb_OTP_KeyPress;
            // 
            // btn_Verify
            // 
            btn_Verify.BackColor = Color.MediumBlue;
            btn_Verify.Cursor = Cursors.Hand;
            btn_Verify.FlatAppearance.BorderSize = 0;
            btn_Verify.FlatStyle = FlatStyle.Flat;
            btn_Verify.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Verify.ForeColor = Color.White;
            btn_Verify.Location = new Point(50, 215);
            btn_Verify.Name = "btn_Verify";
            btn_Verify.Size = new Size(300, 40);
            btn_Verify.TabIndex = 4;
            btn_Verify.Text = "XÁC NHẬN";
            btn_Verify.UseVisualStyleBackColor = false;
            btn_Verify.Click += btn_Verify_Click;
            // 
            // btn_Resend
            // 
            btn_Resend.BackColor = Color.White;
            btn_Resend.Cursor = Cursors.Hand;
            btn_Resend.FlatAppearance.BorderSize = 0;
            btn_Resend.FlatStyle = FlatStyle.Flat;
            btn_Resend.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point);
            btn_Resend.ForeColor = Color.Gray;
            btn_Resend.Location = new Point(120, 265);
            btn_Resend.Name = "btn_Resend";
            btn_Resend.Size = new Size(160, 30);
            btn_Resend.TabIndex = 5;
            btn_Resend.Text = "Gửi lại mã OTP";
            btn_Resend.UseVisualStyleBackColor = false;
            btn_Resend.Click += btn_Resend_Click;
            // 
            // f_OTP
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(400, 315);
            Controls.Add(btn_Resend);
            Controls.Add(btn_Verify);
            Controls.Add(txb_OTP);
            Controls.Add(lbl_Info);
            Controls.Add(panel_Line);
            Controls.Add(lbl_Title);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "f_OTP";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Xác Thực Email";
            Load += f_OTP_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Title;
        private Panel panel_Line;
        private Label lbl_Info;
        private TextBox txb_OTP;
        private Button btn_Verify;
        private Button btn_Resend;
    }
}