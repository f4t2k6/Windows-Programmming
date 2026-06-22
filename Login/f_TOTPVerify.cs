using System;
using System.Drawing;
using System.Windows.Forms;
using OtpNet;
using QRCoder;

namespace ProjectMonHoc
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class f_TOTPVerify : Form
    {
        public bool IsSetupMode { get; set; } = false;
        public string Username { get; set; } = "";
        public string Base32Secret { get; private set; } = "";
        
        // This will be called on successful verification
        public Action<string>? OnVerifySuccess { get; set; }

        private PictureBox picQR;
        private Label lblTitle;
        private Label lblInstruction;
        private TextBox txtCode;
        private Button btnVerify;
        private Button btnCancel;
        private Label lblSecret;

        public f_TOTPVerify(string username, string existingSecret = "")
        {
            InitializeComponent();
            this.Username = username;

            if (string.IsNullOrEmpty(existingSecret))
            {
                IsSetupMode = true;
                // Generate new secret for setup
                var key = KeyGeneration.GenerateRandomKey(20);
                this.Base32Secret = Base32Encoding.ToString(key);
            }
            else
            {
                IsSetupMode = false;
                this.Base32Secret = existingSecret;
            }
        }

        private void InitializeComponent()
        {
            this.picQR = new PictureBox();
            this.lblTitle = new Label();
            this.lblInstruction = new Label();
            this.txtCode = new TextBox();
            this.btnVerify = new Button();
            this.btnCancel = new Button();
            this.lblSecret = new Label();
            
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            
            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblTitle.Location = new Point(0, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(420, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Xác Thực 2 Yếu Tố (2FA)";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            
            // picQR
            this.picQR.Location = new Point(110, 70);
            this.picQR.Name = "picQR";
            this.picQR.Size = new Size(200, 200);
            this.picQR.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picQR.TabIndex = 1;
            this.picQR.TabStop = false;
            
            // lblSecret
            this.lblSecret.AutoSize = false;
            this.lblSecret.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblSecret.ForeColor = Color.DimGray;
            this.lblSecret.Location = new Point(0, 280);
            this.lblSecret.Name = "lblSecret";
            this.lblSecret.Size = new Size(420, 20);
            this.lblSecret.TabIndex = 2;
            this.lblSecret.TextAlign = ContentAlignment.MiddleCenter;
            
            // lblInstruction
            this.lblInstruction.AutoSize = false;
            this.lblInstruction.Font = new Font("Segoe UI", 10F);
            this.lblInstruction.Location = new Point(0, 310);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new Size(420, 45);
            this.lblInstruction.TabIndex = 3;
            this.lblInstruction.Text = "Nhập mã 6 số từ Google Authenticator:";
            this.lblInstruction.TextAlign = ContentAlignment.MiddleCenter;
            
            // txtCode
            this.txtCode.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.txtCode.Location = new Point(110, 360);
            this.txtCode.MaxLength = 6;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new Size(200, 43);
            this.txtCode.TabIndex = 4;
            this.txtCode.TextAlign = HorizontalAlignment.Center;
            this.txtCode.KeyPress += new KeyPressEventHandler(this.txtCode_KeyPress);
            
            // btnVerify
            this.btnVerify.BackColor = Color.FromArgb(52, 152, 219);
            this.btnVerify.FlatStyle = FlatStyle.Flat;
            this.btnVerify.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnVerify.ForeColor = Color.White;
            this.btnVerify.Location = new Point(70, 420);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new Size(130, 45);
            this.btnVerify.TabIndex = 5;
            this.btnVerify.Text = "Xác Nhận";
            this.btnVerify.UseVisualStyleBackColor = false;
            this.btnVerify.Click += new EventHandler(this.btnVerify_Click);
            
            // btnCancel
            this.btnCancel.BackColor = Color.FromArgb(231, 76, 60);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(220, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(130, 45);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            
            // f_TOTPVerify
            this.ClientSize = new Size(420, 500);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.lblSecret);
            this.Controls.Add(this.picQR);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_TOTPVerify";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Xác Thực 2 Yếu Tố";
            this.Load += new EventHandler(this.f_TOTPVerify_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void f_TOTPVerify_Load(object sender, EventArgs e)
        {
            if (IsSetupMode)
            {
                lblTitle.Text = "Thiết lập 2FA (Bắt buộc)";
                lblSecret.Text = $"Khóa dự phòng: {Base32Secret}";
                lblInstruction.Text = "Mở app Google Authenticator, quét mã QR\nvà nhập 6 số bên dưới để hoàn tất.";

                // Tạo QR Code
                string issuer = "HeThongQuanLySV";
                string otpUri = $"otpauth://totp/{issuer}:{Username}?secret={Base32Secret}&issuer={issuer}";

                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(otpUri, QRCodeGenerator.ECCLevel.Q))
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    picQR.Image = qrCode.GetGraphic(20);
                }
            }
            else
            {
                lblTitle.Text = "Nhập Mã 2FA";
                
                picQR.Visible = false;
                lblSecret.Visible = false;

                lblInstruction.Text = "Vui lòng mở Google Authenticator\nvà nhập mã 6 số hiện tại.";
                lblInstruction.Top = 100;
                
                txtCode.Top = 150;
                btnVerify.Top = 220;
                btnCancel.Top = 220;
                this.Height = 350;
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();
            if (string.IsNullOrEmpty(code) || code.Length != 6)
            {
                MessageBox.Show("Vui lòng nhập đủ mã 6 số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var bytes = Base32Encoding.ToBytes(Base32Secret);
                var totp = new Totp(bytes);

                long timeStepMatched;
                bool valid = totp.VerifyTotp(code, out timeStepMatched, new VerificationWindow(1, 1));

                if (valid)
                {
                    MessageBox.Show("Xác thực 2FA thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    OnVerifySuccess?.Invoke(Base32Secret);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mã xác thực không đúng hoặc đã hết hạn!", "Lỗi Xác Thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCode.Clear();
                    txtCode.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý TOTP: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
