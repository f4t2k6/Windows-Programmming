using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    /// <summary>
    /// Popup cảnh báo phiên đăng nhập sắp hết hạn, hiển thị đồng hồ đếm ngược.
    /// DialogResult.OK     = người dùng nhấn "Tôi vẫn ở đây" → tiếp tục phiên.
    /// DialogResult.Cancel = hết giờ hoặc nhấn "Đăng xuất ngay" → thực hiện logout.
    /// Form được xây dựng hoàn toàn bằng code (không có file .Designer.cs).
    /// </summary>
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    internal sealed class f_SessionWarning : Form
    {
        // =============================================
        // FIELDS
        // =============================================
        private int _remaining;
        private System.Windows.Forms.Timer? _tick;
        private Label? _lblCountdown;

        // =============================================
        // CONSTRUCTOR
        // =============================================
        public f_SessionWarning(int warningSeconds)
        {
            _remaining = warningSeconds;
            BuildUI();
            StartCountdown();
        }

        // =============================================
        // XÂY DỰNG GIAO DIỆN BẰNG CODE
        // =============================================
        private void BuildUI()
        {
            // ── Thuộc tính Form ───────────────────────────────────
            this.Text            = "⏱️  Phiên Đăng Nhập Sắp Hết Hạn";
            this.Size            = new Size(440, 260);
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.TopMost         = true;
            this.BackColor       = Color.FromArgb(30, 30, 46);   // Catppuccin Mocha – base

            // ── Icon đồng hồ ──────────────────────────────────────
            var lblIcon = new Label
            {
                Text      = "⏱️",
                Font      = new Font("Segoe UI Emoji", 32f),
                ForeColor = Color.FromArgb(249, 226, 175),        // Catppuccin yellow
                Location  = new Point(18, 18),
                Size      = new Size(65, 65),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // ── Thông báo ─────────────────────────────────────────
            var lblMsg = new Label
            {
                Text      = "Phát hiện không có hoạt động trong một thời gian.\n" +
                            "Hệ thống sẽ tự động đăng xuất sau:",
                Font      = new Font("Segoe UI", 10.5f),
                ForeColor = Color.FromArgb(205, 214, 244),        // Catppuccin text
                Location  = new Point(92, 22),
                Size      = new Size(325, 60),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // ── Đồng hồ đếm ngược (lớn, đỏ) ─────────────────────
            _lblCountdown = new Label
            {
                Text      = FormatTime(_remaining),
                Font      = new Font("Segoe UI", 30f, FontStyle.Bold),
                ForeColor = Color.FromArgb(243, 139, 168),        // Catppuccin red
                Location  = new Point(0, 90),
                Size      = new Size(440, 60),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // ── Nút "Tôi vẫn ở đây" (xanh lá) ───────────────────
            var btnStay = new Button
            {
                Text      = "✅  Tôi vẫn ở đây",
                Font      = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 46),
                BackColor = Color.FromArgb(166, 227, 161),        // Catppuccin green
                FlatStyle = FlatStyle.Flat,
                Location  = new Point(28, 175),
                Size      = new Size(185, 46),
                Cursor    = Cursors.Hand
            };
            btnStay.FlatAppearance.BorderSize = 0;
            btnStay.Click += (_, _) =>
            {
                _tick?.Stop();
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            // ── Nút "Đăng xuất ngay" (đỏ) ────────────────────────
            var btnOut = new Button
            {
                Text      = "🚪  Đăng xuất ngay",
                Font      = new Font("Segoe UI", 10f),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(243, 139, 168),        // Catppuccin pink-red
                FlatStyle = FlatStyle.Flat,
                Location  = new Point(228, 175),
                Size      = new Size(185, 46),
                Cursor    = Cursors.Hand
            };
            btnOut.FlatAppearance.BorderSize = 0;
            btnOut.Click += (_, _) =>
            {
                _tick?.Stop();
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            this.Controls.AddRange(new Control[]
                { lblIcon, lblMsg, _lblCountdown, btnStay, btnOut });
        }

        // =============================================
        // COUNTDOWN TIMER (1 giây / tick)
        // =============================================
        private void StartCountdown()
        {
            _tick = new System.Windows.Forms.Timer { Interval = 1_000 };
            _tick.Tick += (_, _) =>
            {
                _remaining--;

                if (_lblCountdown != null)
                {
                    _lblCountdown.Text = FormatTime(_remaining);

                    // Đổi màu về đỏ đậm khi còn ≤ 10 giây
                    if (_remaining <= 10)
                        _lblCountdown.ForeColor = Color.FromArgb(210, 70, 100);
                }

                if (_remaining <= 0)
                {
                    _tick.Stop();
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            };
            _tick.Start();
        }

        // =============================================
        // HELPERS
        // =============================================

        /// <summary>Định dạng mm:ss cho đồng hồ đếm ngược.</summary>
        private static string FormatTime(int seconds) =>
            seconds > 0
                ? $"{seconds / 60:D2}:{seconds % 60:D2}"
                : "00:00";

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tick?.Stop();
                _tick?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
