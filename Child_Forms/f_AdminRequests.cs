using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ProjectMonHoc
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_AdminRequests : Form
    {
        // ── Màu sắc chủ đạo ─────────────────────────────────────────
        private static readonly Color C_BG = Color.FromArgb(245, 246, 250);
        private static readonly Color C_CARD = Color.White;
        private static readonly Color C_BORDER = Color.FromArgb(220, 222, 235);
        private static readonly Color C_ACCENT = Color.FromArgb(67, 97, 238);  // xanh HR
        private static readonly Color C_ACCENT_SV = Color.FromArgb(14, 165, 233);  // xanh SV (sky-500)
        private static readonly Color C_ACCEPT_BG = Color.FromArgb(236, 253, 245);
        private static readonly Color C_ACCEPT_FG = Color.FromArgb(16, 150, 89);
        private static readonly Color C_REJECT_BG = Color.FromArgb(254, 242, 242);
        private static readonly Color C_REJECT_FG = Color.FromArgb(220, 38, 38);
        private static readonly Color C_TAG_HR_BG = Color.FromArgb(237, 242, 255);
        private static readonly Color C_TAG_HR_FG = Color.FromArgb(67, 97, 238);
        private static readonly Color C_TAG_SV_BG = Color.FromArgb(224, 247, 255);
        private static readonly Color C_TAG_SV_FG = Color.FromArgb(14, 165, 233);
        private static readonly Color C_TEXT_MAIN = Color.FromArgb(25, 25, 45);
        private static readonly Color C_TEXT_SUB = Color.FromArgb(110, 115, 140);

        public f_AdminRequests()
        {
            InitializeComponent();
        }

        private void f_AdminRequests_Load(object sender, EventArgs e)
        {
            pnl_empty.Resize += (s, ev) => CenterEmptyState();
            LoadInbox();
        }

        private void CenterEmptyState()
        {
            int w = pnl_empty.Width, h = pnl_empty.Height;
            lbl_empty_icon.Location = new Point(
                (w - lbl_empty_icon.Width) / 2,
                (h - lbl_empty_icon.Height - lbl_empty_text.Height - 10) / 2);
            lbl_empty_text.Location = new Point(
                (w - lbl_empty_text.Width) / 2,
                lbl_empty_icon.Bottom + 10);
        }

        // ============================================================
        // TẢI VÀ RENDER TOÀN BỘ HỘP THƯ (HR + SV)
        // ============================================================
        private void LoadInbox()
        {
            flp_inbox.Controls.Clear();

            int total = 0;

            // ── 1. HR requests (register_HR, Status = 0) ─────────────
            MY_DB my_db = new MY_DB();
            try
            {
                string sql = "SELECT Id, Username, Fname, Lname, Email, Password " +
                             "FROM register_HR WHERE Status = 0";
                SqlCommand cmd = new SqlCommand(sql, my_db.conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtHR = new DataTable();

                my_db.openConnection();
                da.Fill(dtHR);
                my_db.closeConnection();

                foreach (DataRow row in dtHR.Rows)
                {
                    var card = BuildHRCard(
                        Convert.ToInt32(row["Id"]),
                        row["Username"].ToString() ?? "",
                        row["Fname"].ToString() ?? "",
                        row["Lname"].ToString() ?? "",
                        row["Email"].ToString() ?? "",
                        row["Password"].ToString() ?? "");
                    flp_inbox.Controls.Add(card);
                    total++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải HR requests: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { my_db.closeConnection(); }

            // ── 2. Student print requests (PrintRequest = 'Pending') ─
            try
            {
                MY_DB my_db_sv = new MY_DB();
                my_db_sv.openConnection();

                string sql = @"SELECT MSSV,
                          CONCAT(Fname, ' ', Lname) AS HoTen,
                          Dob, Gder, Phone, Email, PrintRequestDate
                   FROM dbo.Student
                   WHERE PrintRequest = 'Pending'
                   ORDER BY PrintRequestDate ASC";

                SqlDataAdapter da = new SqlDataAdapter(sql, my_db_sv.conn);
                DataTable dtSV = new DataTable();
                da.Fill(dtSV);

                my_db_sv.closeConnection();

                foreach (DataRow row in dtSV.Rows)
                {
                    string requestDate = row["PrintRequestDate"] == DBNull.Value
                        ? ""
                        : Convert.ToDateTime(row["PrintRequestDate"]).ToString("dd/MM/yyyy HH:mm");

                    var card = BuildSVCard(
                        Convert.ToInt32(row["MSSV"]),
                        row["HoTen"].ToString() ?? "",
                        row["Email"].ToString() ?? "",
                        row["Phone"].ToString() ?? "",
                        requestDate);

                    flp_inbox.Controls.Add(card);
                    total++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải SV print requests: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // ── Empty state ──────────────────────────────────────────
            if (total == 0)
            {
                flp_inbox.Visible = false;
                pnl_empty.Visible = true;
                CenterEmptyState();
                lbl_subtitle.Text = "Hộp thư trống — không có yêu cầu nào đang chờ";
            }
            else
            {
                flp_inbox.Visible = true;
                pnl_empty.Visible = false;
                lbl_subtitle.Text = $"Có {total} yêu cầu đang chờ phê duyệt";
            }
        }

        // ============================================================
        // CARD HR
        // ============================================================
        private Panel BuildHRCard(int id, string username, string fname,
                                  string lname, string email, string password)
        {
            Panel card = MakeCardShell();

            // Avatar
            Panel avatar = MakeAvatar(fname, C_ACCENT);

            // Labels
            Label lbl_name = MakeLabel($"{fname} {lname}", 11f, FontStyle.Bold, C_TEXT_MAIN, new Point(90, 18));
            Label lbl_user = MakeLabel($"@{username}", 9f, FontStyle.Regular, C_TEXT_SUB, new Point(91, 43));
            Label lbl_email = MakeLabel(email, 9f, FontStyle.Regular, C_TEXT_SUB, new Point(91, 63));

            // Tag "HR"
            Panel tag = MakeTag("HR", C_TAG_HR_BG, C_TAG_HR_FG);
            card.HandleCreated += (s, e) => tag.Location = new Point(lbl_user.Right + 6, lbl_user.Top);

            // Nút
            Button btn_accept = MakeButton("✓  Phê Duyệt", 120, C_ACCEPT_BG, C_ACCEPT_FG,
                Color.FromArgb(167, 243, 208));
            Button btn_reject = MakeButton("✕  Từ Chối", 110, C_REJECT_BG, C_REJECT_FG,
                Color.FromArgb(254, 202, 202));

            btn_accept.Click += (s, e) => AcceptHRRequest(id, username, email, password);
            btn_reject.Click += (s, e) => RejectHRRequest(id, username);

            PositionButtons(card, btn_accept, btn_reject);
            card.SizeChanged += (s, e) => PositionButtons(card, btn_accept, btn_reject);

            card.Controls.AddRange(new Control[]
                { avatar, lbl_name, lbl_user, lbl_email, tag, btn_accept, btn_reject });

            HoverEffect(card);
            return card;
        }

        // ============================================================
        // CARD SINH VIÊN (Print Request)
        // ============================================================
        private Panel BuildSVCard(int mssv, string hoTen, string email,
                                  string phone, string requestDate)
        {
            Panel card = MakeCardShell();

            // Avatar — dùng chữ cái đầu của họ tên
            string initial = hoTen.Length > 0 ? hoTen[0].ToString().ToUpper() : "S";
            Panel avatar = MakeAvatar(initial[0].ToString(), C_ACCENT_SV);

            // Labels
            Label lbl_name = MakeLabel(hoTen, 11f, FontStyle.Bold, C_TEXT_MAIN, new Point(90, 12));
            Label lbl_mssv = MakeLabel($"MSSV: {mssv}", 9f, FontStyle.Regular, C_TEXT_SUB, new Point(91, 37));
            Label lbl_email = MakeLabel(string.IsNullOrEmpty(email) ? phone : email,
                                                                   9f, FontStyle.Regular, C_TEXT_SUB, new Point(91, 55));
            Label lbl_date = MakeLabel($"Gửi lúc: {requestDate}", 8.5f, FontStyle.Italic, C_TEXT_SUB, new Point(91, 73));

            // Tag "SV"
            Panel tag = MakeTag("SV", C_TAG_SV_BG, C_TAG_SV_FG);
            card.HandleCreated += (s, e) => tag.Location = new Point(lbl_mssv.Right + 6, lbl_mssv.Top);

            // Nút
            Button btn_accept = MakeButton("🖨️ Xác nhận In", 130, C_ACCEPT_BG, C_ACCEPT_FG,
                Color.FromArgb(167, 243, 208));
            Button btn_reject = MakeButton("✕  Từ Chối", 110, C_REJECT_BG, C_REJECT_FG,
                Color.FromArgb(254, 202, 202));

            btn_accept.Click += (s, e) => ApprovePrintRequest(mssv, hoTen);
            btn_reject.Click += (s, e) => DeclinePrintRequest(mssv, hoTen);

            PositionButtons(card, btn_accept, btn_reject);
            card.SizeChanged += (s, e) => PositionButtons(card, btn_accept, btn_reject);

            card.Controls.AddRange(new Control[]
                { avatar, lbl_name, lbl_mssv, lbl_email, lbl_date, tag, btn_accept, btn_reject });

            HoverEffect(card);
            return card;
        }

        // ============================================================
        // FACTORY HELPERS
        // ============================================================
        private Panel MakeCardShell()
        {
            int cardWidth = flp_inbox.ClientSize.Width - flp_inbox.Padding.Horizontal - 4;
            Panel card = new Panel
            {
                Width = Math.Max(cardWidth, 600),
                Height = 100,
                BackColor = C_CARD,
                Margin = new Padding(0, 0, 0, 10),
                Cursor = Cursors.Default
            };
            card.Paint += Card_Paint;
            flp_inbox.SizeChanged += (s, e) =>
            {
                int w = flp_inbox.ClientSize.Width - flp_inbox.Padding.Horizontal - 4;
                card.Width = Math.Max(w, 600);
            };
            return card;
        }

        private Panel MakeAvatar(string letter, Color bg)
        {
            Panel avatar = new Panel
            {
                Size = new Size(54, 54),
                Location = new Point(20, 23),
                BackColor = bg
            };
            avatar.Paint += Avatar_Paint;
            Label lbl = new Label
            {
                Text = letter.Length > 0 ? letter[0].ToString().ToUpper() : "?",
                Font = new Font("Segoe UI", 18f, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Tag = bg   // dùng lại màu nền trong Avatar_Paint
            };
            avatar.Controls.Add(lbl);
            // Lưu màu nền vào Tag của avatar để Avatar_Paint lấy đúng màu
            avatar.Tag = bg;
            return avatar;
        }

        private static Label MakeLabel(string text, float size, FontStyle style,
                                       Color fore, Point loc)
            => new Label
            {
                Text = text,
                Font = new Font("Segoe UI", size, style),
                ForeColor = fore,
                AutoSize = true,
                Location = loc
            };

        private Panel MakeTag(string text, Color bg, Color fg)
        {
            Panel tag = new Panel { Size = new Size(36, 20), BackColor = bg };
            tag.Paint += Tag_Paint;
            tag.Controls.Add(new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = fg,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            });
            return tag;
        }

        private static Button MakeButton(string text, int width,
                                         Color bg, Color fg, Color border)
        {
            var btn = new Button
            {
                Text = text,
                Size = new Size(width, 36),
                Font = new Font("Segoe UI Semibold", 9.5f),
                ForeColor = fg,
                BackColor = bg,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };
            btn.FlatAppearance.BorderColor = border;
            btn.FlatAppearance.BorderSize = 1;
            return btn;
        }

        private static void HoverEffect(Panel card)
        {
            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(252, 252, 255);
            card.MouseLeave += (s, e) => card.BackColor = Color.White;
        }

        private static void PositionButtons(Panel card, Button accept, Button reject)
        {
            int rightEdge = card.Width - 20;
            reject.Location = new Point(rightEdge - reject.Width, (card.Height - reject.Height) / 2);
            accept.Location = new Point(reject.Left - accept.Width - 10, (card.Height - accept.Height) / 2);
        }

        // ============================================================
        // CUSTOM PAINT
        // ============================================================
        private void Card_Paint(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var pen = new Pen(C_BORDER, 1f);
            DrawRoundRect(e.Graphics, pen, 0, 0, p.Width - 1, p.Height - 1, 10);
        }

        private void Avatar_Paint(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Color bg = p.Tag is Color c ? c : C_ACCENT;
            using var brush = new SolidBrush(bg);
            e.Graphics.FillEllipse(brush, 0, 0, p.Width - 1, p.Height - 1);
        }

        private void Tag_Paint(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(p.BackColor);
            DrawRoundRect(e.Graphics, null, 0, 0, p.Width - 1, p.Height - 1, 5, brush);
        }

        private static void DrawRoundRect(Graphics g, Pen? pen,
                                          int x, int y, int w, int h, int r,
                                          Brush? fill = null)
        {
            using var path = new GraphicsPath();
            path.AddArc(x, y, r * 2, r * 2, 180, 90);
            path.AddArc(x + w - r * 2, y, r * 2, r * 2, 270, 90);
            path.AddArc(x + w - r * 2, y + h - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(x, y + h - r * 2, r * 2, r * 2, 90, 90);
            path.CloseFigure();
            if (fill != null) g.FillPath(fill, path);
            if (pen != null) g.DrawPath(pen, path);
        }

        // ============================================================
        // XỬ LÝ HR — PHÊ DUYỆT / TỪ CHỐI
        // ============================================================
        private void AcceptHRRequest(int hrId, string username, string email, string password)
        {
            var confirm = MessageBox.Show(
                $"Phê duyệt tài khoản HR [{username}]?\nTài khoản sẽ được kích hoạt ngay lập tức.",
                "Xác Nhận Phê Duyệt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            MY_DB my_db = new MY_DB();
            SqlTransaction? tx = null;
            try
            {
                my_db.openConnection();
                tx = my_db.conn.BeginTransaction();

                string insertSQL = "INSERT INTO login (Id, username, password, role, email, LoginAttempts) " +
                                   "VALUES (@id, @user, @pass, 'HR', @email, 0)";
                SqlCommand cmdIns = new SqlCommand(insertSQL, my_db.conn, tx);
                cmdIns.Parameters.Add("@id", SqlDbType.Int).Value = hrId;
                cmdIns.Parameters.Add("@user", SqlDbType.VarChar).Value = username;
                cmdIns.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
                cmdIns.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmdIns.ExecuteNonQuery();

                string deleteSQL = "DELETE FROM register_HR WHERE Id = @id";
                SqlCommand cmdDel = new SqlCommand(deleteSQL, my_db.conn, tx);
                cmdDel.Parameters.Add("@id", SqlDbType.Int).Value = hrId;
                cmdDel.ExecuteNonQuery();

                tx.Commit();
                MessageBox.Show($"✅  Tài khoản HR [{username}] đã được phê duyệt!",
                    "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInbox();
            }
            catch (Exception ex)
            {
                tx?.Rollback();
                MessageBox.Show("Lỗi phê duyệt: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { my_db.closeConnection(); }
        }

        private void RejectHRRequest(int hrId, string username)
        {
            var confirm = MessageBox.Show(
                $"Từ chối và xóa yêu cầu của [{username}]?\nHành động này không thể hoàn tác.",
                "Xác Nhận Từ Chối", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            MY_DB my_db = new MY_DB();
            try
            {
                string sql = "DELETE FROM register_HR WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(sql, my_db.conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = hrId;

                my_db.openConnection();
                cmd.ExecuteNonQuery();
                MessageBox.Show($"Đã từ chối yêu cầu của [{username}].", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi từ chối: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { my_db.closeConnection(); }
        }

        // ============================================================
        // XỬ LÝ SV — XÁC NHẬN IN / TỪ CHỐI
        // ============================================================
        private void ApprovePrintRequest(int mssv, string hoTen)
        {
            var confirm = MessageBox.Show(
                $"Xác nhận DUYỆT yêu cầu in giấy của:\n\nMSSV: {mssv} — {hoTen}",
                "Xác Nhận Duyệt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            UpdatePrintStatus(mssv, "Approved");
            MessageBox.Show($"✅  Đã DUYỆT yêu cầu in giấy của {hoTen}.",
                "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadInbox();
        }

        private void DeclinePrintRequest(int mssv, string hoTen)
        {
            var confirm = MessageBox.Show(
                $"Xác nhận TỪ CHỐI yêu cầu in giấy của:\n\nMSSV: {mssv} — {hoTen}",
                "Xác Nhận Từ Chối", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            UpdatePrintStatus(mssv, "Declined");
            MessageBox.Show($"❌  Đã TỪ CHỐI yêu cầu in giấy của {hoTen}.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadInbox();
        }

        private static void UpdatePrintStatus(int mssv, string status)
        {
            MY_DB my_db = new MY_DB();

            try
            {
                string sql = @"UPDATE dbo.Student
                       SET PrintRequest = @status,
                           PrintRequestDate = GETDATE()
                       WHERE MSSV = @mssv";

                SqlCommand cmd = new SqlCommand(sql, my_db.conn);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@mssv", mssv);

                my_db.openConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi cập nhật trạng thái: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                my_db.closeConnection();
            }
        }
    }
}