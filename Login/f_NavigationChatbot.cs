using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectMonHoc.Classes;

namespace ProjectMonHoc
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class f_NavigationChatbot : Form
    {
        private RichTextBox rtbChatHistory;
        private TextBox txtMessage;
        private Button btnSend;
        private Label lblTitle;
        private Panel pnlTop;
        private Panel pnlBottom;

        private ChatbotService chatbotService;
        public Action<string> onNavigate { get; set; }

        public f_NavigationChatbot(string studentName)
        {
            InitializeComponent();
            chatbotService = new ChatbotService();

            string prompt = $@"Bạn là Trợ lý AI Điều hướng thông minh của Hệ Thống Quản Lý Sinh Viên. Sinh viên đang nói chuyện với bạn tên là {studentName}.
Nhiệm vụ của bạn là nhận diện ý định của sinh viên và trả về ĐÚNG định dạng JSON.

Các ý định (Intent) hợp lệ:
- SCORE: xem điểm, điểm thi, bảng điểm.
- INFO: xem thông tin cá nhân, sửa thông tin, hồ sơ.
- TIMETABLE: xem thời khóa biểu, lịch học.
- COURSE_REGISTER: đăng ký môn học, chọn môn, hủy môn.
- PRINT_REQUEST: in giấy xác nhận, xin giấy xác nhận sinh viên.
- UNKNOWN: các câu hỏi không liên quan hoặc chào hỏi.

BẠN CHỈ ĐƯỢC PHÉP TRẢ VỀ JSON có cấu trúc sau:
{{
  ""intent"": ""MÃ_INTENT"",
  ""message"": ""Câu trả lời thân thiện của bạn dành cho {studentName}""
}}

Ví dụ 1: Sinh viên nói 'cho xem điểm môn Toán'
{{
  ""intent"": ""SCORE"",
  ""message"": ""Dạ vâng, em đang mở bảng điểm cho {studentName} xem nhé!""
}}

Ví dụ 2: Sinh viên nói 'xin chào'
{{
  ""intent"": ""UNKNOWN"",
  ""message"": ""Chào {studentName}! Bạn cần mình mở chức năng nào (Xem điểm, Đăng ký môn, Lịch học...)? Mình sẽ mở tự động giúp bạn luôn!""
}}
";
            chatbotService.SetSystemPrompt(prompt);
        }

        private void InitializeComponent()
        {
            this.rtbChatHistory = new RichTextBox();
            this.txtMessage = new TextBox();
            this.btnSend = new Button();
            this.lblTitle = new Label();
            this.pnlTop = new Panel();
            this.pnlBottom = new Panel();

            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = Color.FromArgb(46, 204, 113); // Màu xanh lá cho khác biệt
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 50;

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Text = "Trợ lý AI - Điều hướng tự động";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // pnlBottom
            this.pnlBottom.BackColor = Color.White;
            this.pnlBottom.Controls.Add(this.txtMessage);
            this.pnlBottom.Controls.Add(this.btnSend);
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Height = 60;

            // txtMessage
            this.txtMessage.Font = new Font("Segoe UI", 11F);
            this.txtMessage.Location = new Point(10, 15);
            this.txtMessage.Width = 300;
            this.txtMessage.KeyDown += TxtMessage_KeyDown;

            // btnSend
            this.btnSend.BackColor = Color.FromArgb(39, 174, 96);
            this.btnSend.FlatStyle = FlatStyle.Flat;
            this.btnSend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSend.ForeColor = Color.White;
            this.btnSend.Location = new Point(320, 14);
            this.btnSend.Size = new Size(60, 30);
            this.btnSend.Text = "Gửi";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += BtnSend_Click;

            // rtbChatHistory
            this.rtbChatHistory.BackColor = Color.FromArgb(243, 244, 246);
            this.rtbChatHistory.BorderStyle = BorderStyle.None;
            this.rtbChatHistory.Dock = DockStyle.Fill;
            this.rtbChatHistory.Font = new Font("Segoe UI", 11F);
            this.rtbChatHistory.ReadOnly = true;
            this.rtbChatHistory.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.rtbChatHistory.Padding = new Padding(10);

            // f_NavigationChatbot
            this.ClientSize = new Size(390, 500);
            this.Controls.Add(this.rtbChatHistory);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "AI Điều hướng";
            this.Load += F_NavigationChatbot_Load;

            this.ResumeLayout(false);
        }

        private void F_NavigationChatbot_Load(object sender, EventArgs e)
        {
            AppendMessage("AI", "Xin chào! Mình là AI Điều hướng. Bạn muốn mở tính năng nào cứ gõ tự nhiên nhé (ví dụ: 'Cho xem điểm' hoặc 'Đăng ký môn học nha')!", Color.FromArgb(39, 174, 96));
        }

        private async void BtnSend_Click(object sender, EventArgs e)
        {
            await SendMessage();
        }

        private async void TxtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await SendMessage();
            }
        }

        private async Task SendMessage()
        {
            string msg = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(msg)) return;

            AppendMessage("Bạn", msg, Color.FromArgb(44, 62, 80));
            txtMessage.Clear();
            btnSend.Enabled = false;
            txtMessage.Enabled = false;

            // Gọi API dạng JSON
            NavigationResult result = await chatbotService.SendNavigationMessageAsync(msg);

            // Hiển thị tin nhắn AI
            AppendMessage("AI", result.Message, Color.FromArgb(39, 174, 96));
            
            // Nếu Intent không phải UNKNOWN hoặc ERROR, thì báo lên MainForm
            if (result.Intent != "UNKNOWN" && result.Intent != "ERROR")
            {
                onNavigate?.Invoke(result.Intent);
            }

            btnSend.Enabled = true;
            txtMessage.Enabled = true;
            txtMessage.Focus();
        }

        private void AppendMessage(string sender, string message, Color color)
        {
            rtbChatHistory.SelectionStart = rtbChatHistory.TextLength;
            rtbChatHistory.SelectionLength = 0;
            
            rtbChatHistory.SelectionFont = new Font(rtbChatHistory.Font, FontStyle.Bold);
            rtbChatHistory.SelectionColor = color;
            rtbChatHistory.AppendText(sender + ":\n");

            rtbChatHistory.SelectionFont = new Font(rtbChatHistory.Font, FontStyle.Regular);
            rtbChatHistory.SelectionColor = Color.Black;
            rtbChatHistory.AppendText(message + "\n\n");

            rtbChatHistory.SelectionStart = rtbChatHistory.TextLength;
            rtbChatHistory.ScrollToCaret();
        }
    }
}
