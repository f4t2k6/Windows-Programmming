namespace ProjectMonHoc
{
    partial class f_PrintRequest
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnl_Header = new Panel();
            lbl_Title = new Label();
            pnl_Body = new Panel();
            lbl_MSSV_Value = new Label();
            lbl_MSSV = new Label();
            lbl_Name = new Label();
            lbl_Name_Value = new Label();
            lbl_Dob = new Label();
            lbl_Dob_Value = new Label();
            lbl_Gender = new Label();
            lbl_Gender_Value = new Label();
            lbl_Phone = new Label();
            lbl_Phone_Value = new Label();
            lbl_Address = new Label();
            lbl_Address_Value = new Label();
            lbl_Htown = new Label();
            lbl_Htown_Value = new Label();
            lbl_Email = new Label();
            lbl_Email_Value = new Label();
            pnl_Footer = new Panel();
            lbl_StatusCaption = new Label();
            lbl_Status = new Label();
            lbl_RequestDate = new Label();
            btn_SendRequest = new Button();
            pnl_Header.SuspendLayout();
            pnl_Body.SuspendLayout();
            pnl_Footer.SuspendLayout();
            SuspendLayout();
            // 
            // pnl_Header
            // 
            pnl_Header.BackColor = Color.SteelBlue;
            pnl_Header.Controls.Add(lbl_Title);
            pnl_Header.Dock = DockStyle.Top;
            pnl_Header.Location = new Point(0, 0);
            pnl_Header.Name = "pnl_Header";
            pnl_Header.Size = new Size(1027, 64);
            pnl_Header.TabIndex = 0;
            // 
            // lbl_Title
            // 
            lbl_Title.Dock = DockStyle.Fill;
            lbl_Title.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lbl_Title.ForeColor = Color.White;
            lbl_Title.Location = new Point(0, 0);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Padding = new Padding(20, 0, 0, 0);
            lbl_Title.Size = new Size(1027, 64);
            lbl_Title.TabIndex = 0;
            lbl_Title.Text = "🖨️  Yêu cầu In giấy Xác nhận Sinh viên";
            lbl_Title.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnl_Body
            // 
            pnl_Body.Controls.Add(lbl_MSSV_Value);
            pnl_Body.Controls.Add(lbl_MSSV);
            pnl_Body.Controls.Add(lbl_Name);
            pnl_Body.Controls.Add(lbl_Name_Value);
            pnl_Body.Controls.Add(lbl_Dob);
            pnl_Body.Controls.Add(lbl_Dob_Value);
            pnl_Body.Controls.Add(lbl_Gender);
            pnl_Body.Controls.Add(lbl_Gender_Value);
            pnl_Body.Controls.Add(lbl_Phone);
            pnl_Body.Controls.Add(lbl_Phone_Value);
            pnl_Body.Controls.Add(lbl_Address);
            pnl_Body.Controls.Add(lbl_Address_Value);
            pnl_Body.Controls.Add(lbl_Htown);
            pnl_Body.Controls.Add(lbl_Htown_Value);
            pnl_Body.Controls.Add(lbl_Email);
            pnl_Body.Controls.Add(lbl_Email_Value);
            pnl_Body.Location = new Point(12, 70);
            pnl_Body.Name = "pnl_Body";
            pnl_Body.Size = new Size(1003, 452);
            pnl_Body.TabIndex = 1;
            // 
            // lbl_MSSV_Value
            // 
            lbl_MSSV_Value.BackColor = Color.WhiteSmoke;
            lbl_MSSV_Value.BorderStyle = BorderStyle.FixedSingle;
            lbl_MSSV_Value.Location = new Point(173, 13);
            lbl_MSSV_Value.Name = "lbl_MSSV_Value";
            lbl_MSSV_Value.Size = new Size(620, 30);
            lbl_MSSV_Value.TabIndex = 0;
            // 
            // lbl_MSSV
            // 
            lbl_MSSV.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_MSSV.Location = new Point(13, 13);
            lbl_MSSV.Name = "lbl_MSSV";
            lbl_MSSV.Size = new Size(150, 30);
            lbl_MSSV.TabIndex = 1;
            lbl_MSSV.Text = "Mã số sinh viên:";
            // 
            // lbl_Name
            // 
            lbl_Name.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_Name.Location = new Point(13, 65);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new Size(150, 30);
            lbl_Name.TabIndex = 2;
            lbl_Name.Text = "Họ và tên:";
            // 
            // lbl_Name_Value
            // 
            lbl_Name_Value.BackColor = Color.WhiteSmoke;
            lbl_Name_Value.BorderStyle = BorderStyle.FixedSingle;
            lbl_Name_Value.Location = new Point(173, 65);
            lbl_Name_Value.Name = "lbl_Name_Value";
            lbl_Name_Value.Size = new Size(620, 30);
            lbl_Name_Value.TabIndex = 3;
            // 
            // lbl_Dob
            // 
            lbl_Dob.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_Dob.Location = new Point(13, 120);
            lbl_Dob.Name = "lbl_Dob";
            lbl_Dob.Size = new Size(150, 30);
            lbl_Dob.TabIndex = 4;
            lbl_Dob.Text = "Ngày sinh:";
            // 
            // lbl_Dob_Value
            // 
            lbl_Dob_Value.BackColor = Color.WhiteSmoke;
            lbl_Dob_Value.BorderStyle = BorderStyle.FixedSingle;
            lbl_Dob_Value.Location = new Point(173, 120);
            lbl_Dob_Value.Name = "lbl_Dob_Value";
            lbl_Dob_Value.Size = new Size(620, 30);
            lbl_Dob_Value.TabIndex = 5;
            // 
            // lbl_Gender
            // 
            lbl_Gender.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_Gender.Location = new Point(13, 175);
            lbl_Gender.Name = "lbl_Gender";
            lbl_Gender.Size = new Size(150, 30);
            lbl_Gender.TabIndex = 6;
            lbl_Gender.Text = "Giới tính:";
            // 
            // lbl_Gender_Value
            // 
            lbl_Gender_Value.BackColor = Color.WhiteSmoke;
            lbl_Gender_Value.BorderStyle = BorderStyle.FixedSingle;
            lbl_Gender_Value.Location = new Point(173, 175);
            lbl_Gender_Value.Name = "lbl_Gender_Value";
            lbl_Gender_Value.Size = new Size(620, 30);
            lbl_Gender_Value.TabIndex = 7;
            // 
            // lbl_Phone
            // 
            lbl_Phone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_Phone.Location = new Point(13, 229);
            lbl_Phone.Name = "lbl_Phone";
            lbl_Phone.Size = new Size(150, 30);
            lbl_Phone.TabIndex = 8;
            lbl_Phone.Text = "Số điện thoại:";
            // 
            // lbl_Phone_Value
            // 
            lbl_Phone_Value.BackColor = Color.WhiteSmoke;
            lbl_Phone_Value.BorderStyle = BorderStyle.FixedSingle;
            lbl_Phone_Value.Location = new Point(173, 229);
            lbl_Phone_Value.Name = "lbl_Phone_Value";
            lbl_Phone_Value.Size = new Size(620, 30);
            lbl_Phone_Value.TabIndex = 9;
            // 
            // lbl_Address
            // 
            lbl_Address.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_Address.Location = new Point(13, 281);
            lbl_Address.Name = "lbl_Address";
            lbl_Address.Size = new Size(150, 30);
            lbl_Address.TabIndex = 10;
            lbl_Address.Text = "Địa chỉ:";
            // 
            // lbl_Address_Value
            // 
            lbl_Address_Value.BackColor = Color.WhiteSmoke;
            lbl_Address_Value.BorderStyle = BorderStyle.FixedSingle;
            lbl_Address_Value.Location = new Point(173, 281);
            lbl_Address_Value.Name = "lbl_Address_Value";
            lbl_Address_Value.Size = new Size(620, 30);
            lbl_Address_Value.TabIndex = 11;
            // 
            // lbl_Htown
            // 
            lbl_Htown.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_Htown.Location = new Point(13, 333);
            lbl_Htown.Name = "lbl_Htown";
            lbl_Htown.Size = new Size(150, 30);
            lbl_Htown.TabIndex = 12;
            lbl_Htown.Text = "Quê quán:";
            // 
            // lbl_Htown_Value
            // 
            lbl_Htown_Value.BackColor = Color.WhiteSmoke;
            lbl_Htown_Value.BorderStyle = BorderStyle.FixedSingle;
            lbl_Htown_Value.Location = new Point(173, 333);
            lbl_Htown_Value.Name = "lbl_Htown_Value";
            lbl_Htown_Value.Size = new Size(620, 30);
            lbl_Htown_Value.TabIndex = 13;
            // 
            // lbl_Email
            // 
            lbl_Email.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_Email.Location = new Point(13, 385);
            lbl_Email.Name = "lbl_Email";
            lbl_Email.Size = new Size(150, 30);
            lbl_Email.TabIndex = 14;
            lbl_Email.Text = "Email:";
            // 
            // lbl_Email_Value
            // 
            lbl_Email_Value.BackColor = Color.WhiteSmoke;
            lbl_Email_Value.BorderStyle = BorderStyle.FixedSingle;
            lbl_Email_Value.Location = new Point(173, 385);
            lbl_Email_Value.Name = "lbl_Email_Value";
            lbl_Email_Value.Size = new Size(620, 30);
            lbl_Email_Value.TabIndex = 15;
            // 
            // pnl_Footer
            // 
            pnl_Footer.BackColor = Color.FromArgb(240, 240, 245);
            pnl_Footer.Controls.Add(lbl_StatusCaption);
            pnl_Footer.Controls.Add(lbl_Status);
            pnl_Footer.Controls.Add(lbl_RequestDate);
            pnl_Footer.Controls.Add(btn_SendRequest);
            pnl_Footer.Dock = DockStyle.Bottom;
            pnl_Footer.Location = new Point(0, 528);
            pnl_Footer.Name = "pnl_Footer";
            pnl_Footer.Size = new Size(1027, 100);
            pnl_Footer.TabIndex = 2;
            // 
            // lbl_StatusCaption
            // 
            lbl_StatusCaption.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_StatusCaption.ForeColor = Color.DimGray;
            lbl_StatusCaption.Location = new Point(30, 12);
            lbl_StatusCaption.Name = "lbl_StatusCaption";
            lbl_StatusCaption.Size = new Size(120, 24);
            lbl_StatusCaption.TabIndex = 0;
            lbl_StatusCaption.Text = "Trạng thái:";
            // 
            // lbl_Status
            // 
            lbl_Status.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl_Status.ForeColor = Color.Gray;
            lbl_Status.Location = new Point(155, 12);
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new Size(460, 24);
            lbl_Status.TabIndex = 1;
            lbl_Status.Text = "Chưa gửi yêu cầu.";
            // 
            // lbl_RequestDate
            // 
            lbl_RequestDate.Font = new Font("Segoe UI", 8.5F);
            lbl_RequestDate.ForeColor = Color.DimGray;
            lbl_RequestDate.Location = new Point(155, 38);
            lbl_RequestDate.Name = "lbl_RequestDate";
            lbl_RequestDate.Size = new Size(460, 22);
            lbl_RequestDate.TabIndex = 2;
            // 
            // btn_SendRequest
            // 
            btn_SendRequest.BackColor = Color.SteelBlue;
            btn_SendRequest.FlatAppearance.BorderSize = 0;
            btn_SendRequest.FlatStyle = FlatStyle.Flat;
            btn_SendRequest.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn_SendRequest.ForeColor = Color.White;
            btn_SendRequest.Location = new Point(660, 22);
            btn_SendRequest.Name = "btn_SendRequest";
            btn_SendRequest.Size = new Size(210, 46);
            btn_SendRequest.TabIndex = 3;
            btn_SendRequest.Text = "🖨️ Gửi yêu cầu In giấy";
            btn_SendRequest.UseVisualStyleBackColor = false;
            btn_SendRequest.Click += btn_SendRequest_Click;
            // 
            // f_PrintRequest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1027, 628);
            Controls.Add(pnl_Header);
            Controls.Add(pnl_Body);
            Controls.Add(pnl_Footer);
            Name = "f_PrintRequest";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Yêu cầu In giấy Xác nhận Sinh viên";
            Load += f_PrintRequest_Load;
            pnl_Header.ResumeLayout(false);
            pnl_Body.ResumeLayout(false);
            pnl_Footer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // ── Controls ─────────────────────────────────────────────────
        private System.Windows.Forms.Panel  pnl_Header;
        private System.Windows.Forms.Label  lbl_Title;
        private System.Windows.Forms.Panel  pnl_Body;

        private System.Windows.Forms.Label  lbl_MSSV;
        private System.Windows.Forms.Label  lbl_Name;
        private System.Windows.Forms.Label  lbl_Dob;
        private System.Windows.Forms.Label  lbl_Gender;
        private System.Windows.Forms.Label  lbl_Phone;
        private System.Windows.Forms.Label  lbl_Address;
        private System.Windows.Forms.Label  lbl_Htown;
        private System.Windows.Forms.Label  lbl_Email;

        private System.Windows.Forms.Label  lbl_MSSV_Value;
        private System.Windows.Forms.Label  lbl_Name_Value;
        private System.Windows.Forms.Label  lbl_Dob_Value;
        private System.Windows.Forms.Label  lbl_Gender_Value;
        private System.Windows.Forms.Label  lbl_Phone_Value;
        private System.Windows.Forms.Label  lbl_Address_Value;
        private System.Windows.Forms.Label  lbl_Htown_Value;
        private System.Windows.Forms.Label  lbl_Email_Value;

        private System.Windows.Forms.Panel  pnl_Footer;
        private System.Windows.Forms.Label  lbl_StatusCaption;
        private System.Windows.Forms.Label  lbl_Status;
        private System.Windows.Forms.Label  lbl_RequestDate;
        private System.Windows.Forms.Button btn_SendRequest;
    }
}
