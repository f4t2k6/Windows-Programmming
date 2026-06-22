namespace ProjectMonHoc.Child_Forms
{
    partial class f_createTB_DB
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            flp_ChatHistory = new FlowLayoutPanel();
            pnl_InputBar    = new Panel();
            pnl_Buttons     = new Panel();
            btn_Send        = new Button();
            txt_Prompt      = new TextBox();

            pnl_InputBar.SuspendLayout();
            pnl_Buttons.SuspendLayout();
            SuspendLayout();

            // ══════════════════════════════════════════════════════════
            // flp_ChatHistory  —  vùng hiển thị lịch sử chat
            //   Dock = Fill  →  chiếm toàn bộ không gian còn lại
            //   WrapContents = false  →  items xếp dọc, KHÔNG tràn cột
            // ══════════════════════════════════════════════════════════
            flp_ChatHistory.AutoScroll    = true;
            flp_ChatHistory.WrapContents  = false;
            flp_ChatHistory.FlowDirection = FlowDirection.TopDown;
            flp_ChatHistory.Dock          = DockStyle.Fill;
            flp_ChatHistory.Name          = "flp_ChatHistory";
            flp_ChatHistory.BackColor     = Color.FromArgb(18, 20, 30);
            flp_ChatHistory.Padding       = new Padding(10, 10, 10, 10);
            flp_ChatHistory.TabIndex      = 0;

            // ══════════════════════════════════════════════════════════
            // btn_Send  —  nút gửi yêu cầu
            //   Dock = Right  →  bám phải trong pnl_Buttons, Width cố định
            // ══════════════════════════════════════════════════════════
            btn_Send.BackColor                 = Color.FromArgb(34, 130, 80);
            btn_Send.Cursor                    = Cursors.Hand;
            btn_Send.Dock                      = DockStyle.Right;
            btn_Send.FlatAppearance.BorderSize = 0;
            btn_Send.FlatStyle                 = FlatStyle.Flat;
            btn_Send.Font                      = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn_Send.ForeColor                 = Color.White;
            btn_Send.Name                      = "btn_Send";
            btn_Send.TabIndex                  = 1;
            btn_Send.Text                      = "🚀 Gửi Yêu Cầu";
            btn_Send.Width                     = 160;
            btn_Send.UseVisualStyleBackColor   = false;
            btn_Send.Click                    += btn_Send_Click;

            // ══════════════════════════════════════════════════════════
            // txt_Prompt  —  ô nhập liệu
            //   Dock = Fill  →  chiếm phần còn lại sau btn_Send
            // ══════════════════════════════════════════════════════════
            txt_Prompt.BackColor       = Color.FromArgb(38, 44, 62);
            txt_Prompt.BorderStyle     = BorderStyle.None;
            txt_Prompt.Dock            = DockStyle.Fill;
            txt_Prompt.Font            = new Font("Segoe UI", 10.5F);
            txt_Prompt.ForeColor       = Color.White;
            txt_Prompt.Multiline       = true;
            txt_Prompt.Name            = "txt_Prompt";
            txt_Prompt.PlaceholderText = "Nhập mô tả bảng cần tạo... (VD: Tạo bảng sinh viên gồm mã, họ tên, ngày sinh, email)";
            txt_Prompt.ScrollBars      = ScrollBars.Vertical;
            txt_Prompt.TabIndex        = 0;

            // ══════════════════════════════════════════════════════════
            // pnl_Buttons  —  container cho txt_Prompt + btn_Send
            //   Dock = Fill trong pnl_InputBar  →  chiếm toàn bộ InputBar
            //   Thêm btn_Send trước (Dock=Right bám phải trước)
            //   Sau đó txt_Prompt Dock=Fill chiếm phần còn lại
            // ══════════════════════════════════════════════════════════
            pnl_Buttons.BackColor = Color.FromArgb(28, 32, 48);
            pnl_Buttons.Dock      = DockStyle.Fill;
            pnl_Buttons.Name      = "pnl_Buttons";
            pnl_Buttons.Padding   = new Padding(0, 0, 8, 0);   // khoảng cách phải trước nút
            pnl_Buttons.TabIndex  = 0;
            // Thứ tự Add quyết định Dock: Right trước → Fill sau
            pnl_Buttons.Controls.Add(txt_Prompt);
            pnl_Buttons.Controls.Add(btn_Send);

            // ══════════════════════════════════════════════════════════
            // pnl_InputBar  —  thanh nhập liệu ở đáy form
            //   Dock = Bottom  →  tự bám đáy và kéo dài theo chiều ngang
            //   Height cố định = 80
            // ══════════════════════════════════════════════════════════
            pnl_InputBar.BackColor = Color.FromArgb(28, 32, 48);
            pnl_InputBar.Dock      = DockStyle.Bottom;
            pnl_InputBar.Height    = 80;
            pnl_InputBar.Name      = "pnl_InputBar";
            pnl_InputBar.Padding   = new Padding(10, 8, 10, 8);
            pnl_InputBar.TabIndex  = 1;
            pnl_InputBar.Controls.Add(pnl_Buttons);

            // ══════════════════════════════════════════════════════════
            // f_createTB_DB (Form)
            //   Thứ tự Add: pnl_InputBar (Dock=Bottom) phải add TRƯỚC
            //   flp_ChatHistory (Dock=Fill) add SAU → Fill lấy phần còn lại
            // ══════════════════════════════════════════════════════════
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(18, 20, 30);
            ClientSize          = new Size(1027, 680);
            Name                = "f_createTB_DB";
            Text                = "Tạo bảng Database bằng AI";
            // Dock=Bottom trước, sau đó Dock=Fill
            Controls.Add(flp_ChatHistory);
            Controls.Add(pnl_InputBar);

            pnl_Buttons.ResumeLayout(false);
            pnl_InputBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flp_ChatHistory;
        private Panel           pnl_InputBar;
        private Panel           pnl_Buttons;
        private Button          btn_Send;
        private TextBox         txt_Prompt;
    }
}