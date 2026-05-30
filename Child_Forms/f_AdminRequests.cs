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
        // ── Màu sắc chủ đạo ─────────────────────────────────────
        private static readonly Color C_BG = Color.FromArgb(245, 246, 250);
        private static readonly Color C_CARD = Color.White;
        private static readonly Color C_BORDER = Color.FromArgb(220, 222, 235);
        private static readonly Color C_ACCENT = Color.FromArgb(67, 97, 238);   // xanh chủ
        private static readonly Color C_ACCEPT_BG = Color.FromArgb(236, 253, 245);
        private static readonly Color C_ACCEPT_FG = Color.FromArgb(16, 150, 89);
        private static readonly Color C_REJECT_BG = Color.FromArgb(254, 242, 242);
        private static readonly Color C_REJECT_FG = Color.FromArgb(220, 38, 38);
        private static readonly Color C_TAG_BG = Color.FromArgb(237, 242, 255);
        private static readonly Color C_TAG_FG = Color.FromArgb(67, 97, 238);
        private static readonly Color C_TEXT_MAIN = Color.FromArgb(25, 25, 45);
        private static readonly Color C_TEXT_SUB = Color.FromArgb(110, 115, 140);

        public f_AdminRequests()
        {
            InitializeComponent();
        }

        private void f_AdminRequests_Load(object sender, EventArgs e)
        {
            // Căn giữa empty state khi resize — đặt ở đây thay vì Designer
            pnl_empty.Resize += (s, ev) => CenterEmptyState();
            LoadInbox();
        }

        private void CenterEmptyState()
        {
            int w = pnl_empty.Width;
            int h = pnl_empty.Height;
            lbl_empty_icon.Location = new Point(
                (w - lbl_empty_icon.Width) / 2,
                (h - lbl_empty_icon.Height - lbl_empty_text.Height - 10) / 2);
            lbl_empty_text.Location = new Point(
                (w - lbl_empty_text.Width) / 2,
                lbl_empty_icon.Bottom + 10);
        }

        // =========================================================
        // TẢI VÀ RENDER DANH SÁCH THƯ
        // =========================================================
        private void LoadInbox()
        {
            flp_inbox.Controls.Clear();

            MY_DB my_db = new MY_DB();
            DataTable table = new DataTable();

            try
            {
                string query = "SELECT Id, Username, Fname, Lname, Email, Password FROM register_HR WHERE Status = 0";
                SqlCommand cmd = new SqlCommand(query, my_db.conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                my_db.openConnection();
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                my_db.closeConnection();
            }

            if (table.Rows.Count == 0)
            {
                flp_inbox.Visible = false;
                pnl_empty.Visible = true;
                CenterEmptyState();
                return;
            }

            flp_inbox.Visible = true;
            pnl_empty.Visible = false;

            // Cập nhật subtitle đếm số thư
            lbl_subtitle.Text = $"Có {table.Rows.Count} yêu cầu đang chờ phê duyệt";

            foreach (DataRow row in table.Rows)
            {
                int id = Convert.ToInt32(row["Id"]);
                string username = row["Username"].ToString() ?? "";
                string fname = row["Fname"].ToString() ?? "";
                string lname = row["Lname"].ToString() ?? "";
                string email = row["Email"].ToString() ?? "";
                string password = row["Password"].ToString() ?? "";

                Panel card = BuildCard(id, username, fname, lname, email, password);
                flp_inbox.Controls.Add(card);
            }
        }

        // =========================================================
        // XÂY DỰNG MỘT CARD THƯ
        // =========================================================
        private Panel BuildCard(int id, string username, string fname, string lname, string email, string password)
        {
            int cardWidth = flp_inbox.ClientSize.Width - flp_inbox.Padding.Horizontal - 4;

            // ── Vỏ card ──────────────────────────────────────────
            Panel card = new Panel
            {
                Width = Math.Max(cardWidth, 600),
                Height = 100,
                BackColor = C_CARD,
                Margin = new Padding(0, 0, 0, 10),
                Cursor = Cursors.Default,
                Tag = id
            };
            card.Paint += Card_Paint;

            // Resize card theo flp
            flp_inbox.SizeChanged += (s, e) =>
            {
                int w = flp_inbox.ClientSize.Width - flp_inbox.Padding.Horizontal - 4;
                card.Width = Math.Max(w, 600);
            };

            // ── Avatar chữ cái ────────────────────────────────────
            Panel avatar = new Panel
            {
                Size = new Size(54, 54),
                Location = new Point(20, 23),
                BackColor = C_ACCENT
            };
            avatar.Paint += Avatar_Paint;

            Label lbl_initial = new Label
            {
                Text = fname.Length > 0 ? fname[0].ToString().ToUpper() : "?",
                Font = new Font("Segoe UI", 18f, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            avatar.Controls.Add(lbl_initial);

            // ── Thông tin ─────────────────────────────────────────
            Label lbl_name = new Label
            {
                Text = $"{fname} {lname}",
                Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold),
                ForeColor = C_TEXT_MAIN,
                AutoSize = true,
                Location = new Point(90, 18)
            };

            Label lbl_user = new Label
            {
                Text = $"@{username}",
                Font = new Font("Segoe UI", 9f),
                ForeColor = C_TEXT_SUB,
                AutoSize = true,
                Location = new Point(91, 43)
            };

            Label lbl_email = new Label
            {
                Text = email,
                Font = new Font("Segoe UI", 9f),
                ForeColor = C_TEXT_SUB,
                AutoSize = true,
                Location = new Point(91, 63)
            };

            // Tag "HR"
            Panel tag = new Panel
            {
                Size = new Size(36, 20),
                BackColor = C_TAG_BG,
                Location = new Point(90, 43)   // sẽ reposition sau
            };
            tag.Paint += Tag_Paint;
            Label lbl_tag = new Label
            {
                Text = "HR",
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = C_TAG_FG,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            tag.Controls.Add(lbl_tag);

            // Reposition tag sau khi lbl_user đã được đo kích thước (HandleCreated đảm bảo layout xong)
            card.HandleCreated += (s, e) =>
            {
                tag.Location = new Point(lbl_user.Right + 6, lbl_user.Top);
            };

            // ── Nút Phê Duyệt ─────────────────────────────────────
            Button btn_accept = new Button
            {
                Text = "✓  Phê Duyệt",
                Size = new Size(120, 36),
                Font = new Font("Segoe UI Semibold", 9.5f),
                ForeColor = C_ACCEPT_FG,
                BackColor = C_ACCEPT_BG,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };
            btn_accept.FlatAppearance.BorderColor = Color.FromArgb(167, 243, 208);
            btn_accept.FlatAppearance.BorderSize = 1;
            btn_accept.Click += (s, e) => AcceptRequest(id, username, email, password);

            // ── Nút Từ Chối ───────────────────────────────────────
            Button btn_reject = new Button
            {
                Text = "✕  Từ Chối",
                Size = new Size(110, 36),
                Font = new Font("Segoe UI Semibold", 9.5f),
                ForeColor = C_REJECT_FG,
                BackColor = C_REJECT_BG,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };
            btn_reject.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            btn_reject.FlatAppearance.BorderSize = 1;
            btn_reject.Click += (s, e) => RejectRequest(id, username);

            // Đặt vị trí nút bên phải (cố định từ phải)
            PositionButtons(card, btn_accept, btn_reject);
            card.SizeChanged += (s, e) => PositionButtons(card, btn_accept, btn_reject);

            // ── Ghép vào card ─────────────────────────────────────
            card.Controls.AddRange(new Control[]
            {
                avatar, lbl_name, lbl_user, lbl_email, tag, btn_accept, btn_reject
            });

            // Hover highlight nhẹ
            card.MouseEnter += (s, e) => { card.BackColor = Color.FromArgb(252, 252, 255); };
            card.MouseLeave += (s, e) => { card.BackColor = C_CARD; };

            return card;
        }

        private static void PositionButtons(Panel card, Button accept, Button reject)
        {
            int rightEdge = card.Width - 20;
            reject.Location = new Point(rightEdge - reject.Width, (card.Height - reject.Height) / 2);
            accept.Location = new Point(reject.Left - accept.Width - 10, (card.Height - accept.Height) / 2);
        }

        // ── Custom paint: card shadow + border radius ─────────────
        private void Card_Paint(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Border
            using var pen = new Pen(C_BORDER, 1f);
            DrawRoundRect(e.Graphics, pen, 0, 0, p.Width - 1, p.Height - 1, 10);
        }

        private void Avatar_Paint(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(C_ACCENT);
            e.Graphics.FillEllipse(brush, 0, 0, p.Width - 1, p.Height - 1);
        }

        private void Tag_Paint(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(C_TAG_BG);
            DrawRoundRect(e.Graphics, null, 0, 0, p.Width - 1, p.Height - 1, 5, brush);
        }

        private static void DrawRoundRect(Graphics g, Pen? pen, int x, int y, int w, int h, int r,
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

        // =========================================================
        // XỬ LÝ PHÊ DUYỆT
        // =========================================================
        private void AcceptRequest(int hrId, string username, string email, string password)
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
                MessageBox.Show($"✅  Tài khoản HR [{username}] đã được phê duyệt thành công!",
                    "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInbox();
            }
            catch (Exception ex)
            {
                tx?.Rollback();
                MessageBox.Show("Lỗi phê duyệt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { my_db.closeConnection(); }
        }

        // =========================================================
        // XỬ LÝ TỪ CHỐI
        // =========================================================
        private void RejectRequest(int hrId, string username)
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
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show($"Đã từ chối yêu cầu của [{username}].",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInbox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi từ chối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { my_db.closeConnection(); }
        }
    }
}