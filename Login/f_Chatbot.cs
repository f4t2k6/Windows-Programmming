using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectMonHoc.Classes;

namespace ProjectMonHoc
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class f_Chatbot : Form
    {
        private RichTextBox rtbChatHistory;
        private TextBox txtMessage;
        private Button btnSend;
        private Label lblTitle;
        private Panel pnlTop;
        private Panel pnlBottom;

        private ChatbotService chatbotService;

        public f_Chatbot()
        {
            InitializeComponent();
            chatbotService = new ChatbotService();
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
            this.pnlTop.BackColor = Color.FromArgb(41, 128, 185);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 50;

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Text = "Trợ lý ảo AI - Hỗ trợ khôi phục mật khẩu";
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
            this.btnSend.BackColor = Color.FromArgb(52, 152, 219);
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

            // f_Chatbot
            this.ClientSize = new Size(390, 500);
            this.Controls.Add(this.rtbChatHistory);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "AI Chatbot";
            this.Load += F_Chatbot_Load;

            this.ResumeLayout(false);
        }

        private void F_Chatbot_Load(object sender, EventArgs e)
        {
            AppendMessage("AI", "Xin chào! Tôi là trợ lý ảo của Hệ Thống. Bạn đang gặp khó khăn trong việc khôi phục mật khẩu phải không? Hãy đặt câu hỏi cho tôi nhé!", Color.FromArgb(41, 128, 185));
        }

        private async void BtnSend_Click(object sender, EventArgs e)
        {
            await SendMessage();
        }

        private async void TxtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn tiếng 'bíp'
                await SendMessage();
            }
        }

        private async Task SendMessage()
        {
            string msg = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(msg)) return;

            // Hiển thị tin nhắn user
            AppendMessage("Bạn", msg, Color.FromArgb(44, 62, 80));
            txtMessage.Clear();
            btnSend.Enabled = false;
            txtMessage.Enabled = false;

            // Gọi API
            string reply = await chatbotService.SendMessageAsync(msg);

            // Hiển thị tin nhắn AI
            AppendMessage("AI", reply, Color.FromArgb(41, 128, 185));
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
