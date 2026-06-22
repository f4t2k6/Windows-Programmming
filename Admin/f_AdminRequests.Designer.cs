namespace ProjectMonHoc
{
    partial class f_AdminRequests
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
            pnl_root = new Panel();
            pnl_header = new Panel();
            lbl_title = new Label();
            lbl_subtitle = new Label();
            pnl_divider = new Panel();
            pnl_empty = new Panel();
            lbl_empty_icon = new Label();
            lbl_empty_text = new Label();
            flp_inbox = new FlowLayoutPanel();

            SuspendLayout();

            // pnl_root
            pnl_root.Dock = DockStyle.Fill;
            pnl_root.BackColor = Color.FromArgb(245, 246, 250);
            pnl_root.Controls.Add(flp_inbox);
            pnl_root.Controls.Add(pnl_empty);
            pnl_root.Controls.Add(pnl_divider);
            pnl_root.Controls.Add(pnl_header);

            // pnl_header
            pnl_header.Dock = DockStyle.Top;
            pnl_header.Height = 80;
            pnl_header.BackColor = Color.White;
            pnl_header.Controls.Add(lbl_title);
            pnl_header.Controls.Add(lbl_subtitle);

            // lbl_title
            lbl_title.AutoSize = false;
            lbl_title.Location = new Point(30, 14);
            lbl_title.Size = new Size(500, 30);
            lbl_title.Text = "📬  Hộp Thư Yêu Cầu";
            lbl_title.Font = new Font("Segoe UI Semibold", 16f, FontStyle.Bold);
            lbl_title.ForeColor = Color.FromArgb(30, 30, 50);

            // lbl_subtitle
            lbl_subtitle.AutoSize = false;
            lbl_subtitle.Location = new Point(32, 46);
            lbl_subtitle.Size = new Size(600, 22);
            lbl_subtitle.Text = "Phê duyệt hoặc từ chối yêu cầu đăng ký tài khoản HR";
            lbl_subtitle.Font = new Font("Segoe UI", 9f);
            lbl_subtitle.ForeColor = Color.FromArgb(130, 130, 150);

            // pnl_divider
            pnl_divider.Dock = DockStyle.Top;
            pnl_divider.Height = 1;
            pnl_divider.BackColor = Color.FromArgb(220, 222, 235);

            // pnl_empty
            pnl_empty.Dock = DockStyle.Fill;
            pnl_empty.BackColor = Color.Transparent;
            pnl_empty.Visible = false;
            pnl_empty.Controls.Add(lbl_empty_icon);
            pnl_empty.Controls.Add(lbl_empty_text);

            // lbl_empty_icon
            lbl_empty_icon.AutoSize = false;
            lbl_empty_icon.Size = new Size(600, 80);
            lbl_empty_icon.Text = "✉️";
            lbl_empty_icon.Font = new Font("Segoe UI", 48f);
            lbl_empty_icon.TextAlign = ContentAlignment.MiddleCenter;
            lbl_empty_icon.Anchor = AnchorStyles.None;

            // lbl_empty_text
            lbl_empty_text.AutoSize = false;
            lbl_empty_text.Size = new Size(600, 40);
            lbl_empty_text.Text = "Hộp thư trống — Không có yêu cầu nào đang chờ duyệt";
            lbl_empty_text.Font = new Font("Segoe UI", 12f);
            lbl_empty_text.ForeColor = Color.FromArgb(160, 160, 180);
            lbl_empty_text.TextAlign = ContentAlignment.MiddleCenter;
            lbl_empty_text.Anchor = AnchorStyles.None;

            // flp_inbox
            flp_inbox.Dock = DockStyle.Fill;
            flp_inbox.FlowDirection = FlowDirection.TopDown;
            flp_inbox.WrapContents = false;
            flp_inbox.AutoScroll = true;
            flp_inbox.BackColor = Color.Transparent;
            flp_inbox.Padding = new Padding(24, 18, 24, 18);

            // f_AdminRequests
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1027, 628);
            Controls.Add(pnl_root);
            Name = "f_AdminRequests";
            Text = "Hộp Thư Yêu Cầu";
            Load += new EventHandler(f_AdminRequests_Load);

            ResumeLayout(false);
        }

        #endregion

        private Panel pnl_root;
        private Panel pnl_header;
        private Panel pnl_divider;
        private Panel pnl_empty;
        private Label lbl_title;
        private Label lbl_subtitle;
        private Label lbl_empty_icon;
        private Label lbl_empty_text;
        private FlowLayoutPanel flp_inbox;
    }
}