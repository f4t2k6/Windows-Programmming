using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    //Bỏ lỗi CA1416
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class FormThongKe : Form
    {
        // ─── Màu sắc chủ đề ────────────────────────────────────────────────────
        private static readonly Color[] PALETTE = {
            Color.FromArgb(255, 99,  132),   // Hồng  – Yếu
            Color.FromArgb(255, 159,  64),   // Cam   – Trung bình
            Color.FromArgb(255, 205,  86),   // Vàng  – Khá
            Color.FromArgb( 75, 192, 192),   // Cyan  – Giỏi
            Color.FromArgb( 54, 162, 235),   // Xanh  – Xuất sắc
            Color.FromArgb(153, 102, 255),   // Tím
            Color.FromArgb(201, 203, 207),   // Xám
        };

        private static readonly Color CLR_BG = Color.FromArgb(245, 247, 250);
        private static readonly Color CLR_CARD = Color.White;
        private static readonly Color CLR_HEADER = Color.FromArgb(41, 98, 255);
        private static readonly Color CLR_TEXT_DARK = Color.FromArgb(30, 30, 46);
        private static readonly Color CLR_TEXT_LIGHT = Color.FromArgb(100, 110, 130);

        // ─── Data cache ────────────────────────────────────────────────────────
        private DataTable _dtXepLoai;   // xếp loại học lực
        private DataTable _dtTopGPA;    // top SV GPA
        private DataTable _dtMonHoc;    // điểm TB theo môn
        private DataTable _dtDangKy;    // số SV đăng ký theo môn

        // ─── Summary cards ─────────────────────────────────────────────────────
        private int _totalStudents, _totalCourses, _totalScores;
        private double _avgGPA;

        public FormThongKe()
        {
            InitializeComponent();
            this.Load += FormThongKe_Load;
        }

        // ════════════════════════════════════════════════════════════════════════
        //  LOAD
        // ════════════════════════════════════════════════════════════════════════
        private void FormThongKe_Load(object sender, EventArgs e)
        {
            // Bật DoubleBuffered cho các panel biểu đồ (chống flickering)
            SetDoubleBuffered(pnlChartXepLoai);
            SetDoubleBuffered(pnlChartTopGPA);
            SetDoubleBuffered(pnlChartMonHoc);
            SetDoubleBuffered(pnlChartDangKy);

            // Bo góc cho các summary card
            SetRoundedCorners(cardSV);
            SetRoundedCorners(cardMH);
            SetRoundedCorners(cardDiem);
            SetRoundedCorners(cardGPA);

            LoadAllData();
            UpdateSummaryCards();

            // Hook Paint cho từng panel biểu đồ
            pnlChartXepLoai.Paint += PnlChartXepLoai_Paint;
            pnlChartTopGPA.Paint += PnlChartTopGPA_Paint;
            pnlChartMonHoc.Paint += PnlChartMonHoc_Paint;
            pnlChartDangKy.Paint += PnlChartDangKy_Paint;

            pnlChartXepLoai.Invalidate();
            pnlChartTopGPA.Invalidate();
            pnlChartMonHoc.Invalidate();
            pnlChartDangKy.Invalidate();
        }

        private static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            typeof(System.Windows.Forms.Control)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance)
                ?.SetValue(c, true);
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern System.IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        private static void SetRoundedCorners(System.Windows.Forms.Panel p, int radius = 12)
        {
            p.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, p.Width, p.Height, radius, radius));
        }

        // ════════════════════════════════════════════════════════════════════════
        //  DATA LOADING
        // ════════════════════════════════════════════════════════════════════════
        private void LoadAllData()
        {
            MY_DB db = new MY_DB();
            try
            {
                db.openConnection();

                // ── Summary counts ──────────────────────────────────────────────
                _totalStudents = (int)(ExecuteScalar(db, "SELECT COUNT(*) FROM Student") ?? 0);
                _totalCourses = (int)(ExecuteScalar(db, "SELECT COUNT(*) FROM Course") ?? 0);
                _totalScores = (int)(ExecuteScalar(db, "SELECT COUNT(*) FROM Score WHERE DiemTK IS NOT NULL") ?? 0);

                object avgObj = ExecuteScalar(db,
                    @"SELECT ISNULL(AVG(CAST(DiemTK AS FLOAT)),0) FROM Score WHERE DiemTK IS NOT NULL");
                _avgGPA = Math.Round(Convert.ToDouble(avgObj), 2);

                // ── 1. Xếp loại học lực ────────────────────────────────────────
                _dtXepLoai = Fill(db, @"
                    SELECT
                        CASE
                            WHEN DiemTK >= 9.0 THEN N'Xuất sắc'
                            WHEN DiemTK >= 8.0 THEN N'Giỏi'
                            WHEN DiemTK >= 6.5 THEN N'Khá'
                            WHEN DiemTK >= 5.0 THEN N'Trung bình'
                            ELSE N'Yếu'
                        END AS XepLoai,
                        COUNT(*) AS SoLuong
                    FROM Score
                    WHERE DiemTK IS NOT NULL
                    GROUP BY
                        CASE
                            WHEN DiemTK >= 9.0 THEN N'Xuất sắc'
                            WHEN DiemTK >= 8.0 THEN N'Giỏi'
                            WHEN DiemTK >= 6.5 THEN N'Khá'
                            WHEN DiemTK >= 5.0 THEN N'Trung bình'
                            ELSE N'Yếu'
                        END");

                // ── 2. Top 10 SV GPA cao nhất ──────────────────────────────────
                _dtTopGPA = Fill(db, @"
                    SELECT TOP 10
                        st.MSSV,
                        st.Lname + N' ' + st.Fname AS HoTen,
                        ROUND(SUM(sc.DiemTK * c.SoTC) / NULLIF(SUM(c.SoTC), 0), 2) AS GPA
                    FROM Score sc
                    INNER JOIN Student st ON sc.student_id = st.MSSV
                    INNER JOIN Course  c  ON sc.course_id  = c.MaMH
                    WHERE sc.DiemTK IS NOT NULL
                    GROUP BY st.MSSV, st.Lname, st.Fname
                    ORDER BY GPA DESC");

                // ── 3. Điểm TB theo môn ────────────────────────────────────────
                _dtMonHoc = Fill(db, @"
                    SELECT
                        sc.course_id                                   AS MaMH,
                        sc.course_name                                  AS TenMH,
                        ROUND(AVG(CAST(sc.DiemTK AS FLOAT)), 2)        AS DiemTB,
                        ROUND(MIN(CAST(sc.DiemTK AS FLOAT)), 2)        AS DiemMin,
                        ROUND(MAX(CAST(sc.DiemTK AS FLOAT)), 2)        AS DiemMax,
                        COUNT(*)                                        AS SoSV
                    FROM Score sc
                    WHERE sc.DiemTK IS NOT NULL
                    GROUP BY sc.course_id, sc.course_name
                    ORDER BY DiemTB DESC");

                // ── 4. Số SV đăng ký theo môn ─────────────────────────────────
                _dtDangKy = Fill(db, @"
                    SELECT
                        c.MaMH,
                        c.TenMH,
                        COUNT(d.MSSV) AS SoSVDangKy
                    FROM Course c
                    LEFT JOIN DKMH d ON c.MaMH = d.MaMH
                    GROUP BY c.MaMH, c.TenMH
                    ORDER BY SoSVDangKy DESC");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }

        private object ExecuteScalar(MY_DB db, string sql)
        {
            using var cmd = new SqlCommand(sql, db.conn);
            return cmd.ExecuteScalar();
        }

        private DataTable Fill(MY_DB db, string sql)
        {
            var dt = new DataTable();
            using var adapter = new SqlDataAdapter(sql, db.conn);
            adapter.Fill(dt);
            return dt;
        }

        // ════════════════════════════════════════════════════════════════════════
        //  SUMMARY CARDS
        // ════════════════════════════════════════════════════════════════════════
        private void UpdateSummaryCards()
        {
            lblCardSVCount.Text = _totalStudents.ToString();
            lblCardMHCount.Text = _totalCourses.ToString();
            lblCardDiemCount.Text = _totalScores.ToString();
            lblCardGPAAvg.Text = _avgGPA.ToString("0.00");
        }

        // ════════════════════════════════════════════════════════════════════════
        //  BIỂU ĐỒ 1 – PIE: XẾP LOẠI HỌC LỰC
        // ════════════════════════════════════════════════════════════════════════
        private void PnlChartXepLoai_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rc = pnlChartXepLoai.ClientRectangle;
            g.Clear(CLR_CARD);

            if (_dtXepLoai == null || _dtXepLoai.Rows.Count == 0)
            { DrawEmpty(g, rc, "Chưa có dữ liệu điểm"); return; }

            // Thứ tự cố định
            string[] order = { "Xuất sắc", "Giỏi", "Khá", "Trung bình", "Yếu" };
            int[] counts = order.Select(xl =>
            {
                foreach (DataRow r in _dtXepLoai.Rows)
                    if (r["XepLoai"].ToString() == xl)
                        return Convert.ToInt32(r["SoLuong"]);
                return 0;
            }).ToArray();

            int total = counts.Sum();
            if (total == 0) { DrawEmpty(g, rc, "Chưa có dữ liệu điểm"); return; }

            // Pie area
            int size = Math.Min(rc.Width - 220, rc.Height - 60);
            int pieX = 20;
            int pieY = (rc.Height - size) / 2;
            var pieRc = new Rectangle(pieX, pieY, size, size);

            float startAngle = -90f;
            for (int i = 0; i < order.Length; i++)
            {
                if (counts[i] == 0) continue;
                float sweep = 360f * counts[i] / total;
                using var br = new SolidBrush(PALETTE[i]);
                g.FillPie(br, pieRc, startAngle, sweep);
                using var pen = new Pen(Color.White, 2);
                g.DrawPie(pen, pieRc, startAngle, sweep);

                // % label inside slice
                float midAngle = (startAngle + sweep / 2) * (float)Math.PI / 180f;
                float r = size * 0.32f;
                float lx = pieX + size / 2f + r * (float)Math.Cos(midAngle) - 18;
                float ly = pieY + size / 2f + r * (float)Math.Sin(midAngle) - 8;
                double pct = 100.0 * counts[i] / total;
                if (pct > 4)
                    g.DrawString($"{pct:0.0}%", new Font("Segoe UI", 8f, FontStyle.Bold),
                        Brushes.White, lx, ly);

                startAngle += sweep;
            }

            // Legend
            int lgX = pieX + size + 24;
            int lgY = pieY;
            using var fntTitle = new Font("Segoe UI", 9f, FontStyle.Bold);
            using var fntItem = new Font("Segoe UI", 9f);
            g.DrawString("Xếp loại", fntTitle, new SolidBrush(CLR_TEXT_DARK), lgX, lgY - 20);

            for (int i = 0; i < order.Length; i++)
            {
                int iy = lgY + i * 34;
                using var br = new SolidBrush(PALETTE[i]);
                g.FillRectangle(br, lgX, iy + 2, 16, 16);
                g.DrawString($"{order[i]}", fntItem, new SolidBrush(CLR_TEXT_DARK), lgX + 22, iy);
                g.DrawString($"{counts[i]} sv", fntItem, new SolidBrush(CLR_TEXT_LIGHT), lgX + 22, iy + 16);
            }
        }

        // ════════════════════════════════════════════════════════════════════════
        //  BIỂU ĐỒ 2 – HORIZONTAL BAR: TOP 10 GPA
        // ════════════════════════════════════════════════════════════════════════
        private void PnlChartTopGPA_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rc = pnlChartTopGPA.ClientRectangle;
            g.Clear(CLR_CARD);

            if (_dtTopGPA == null || _dtTopGPA.Rows.Count == 0)
            { DrawEmpty(g, rc, "Chưa có dữ liệu GPA"); return; }

            int count = _dtTopGPA.Rows.Count;
            int padL = 160, padR = 60, padT = 20, padB = 30;
            int plotW = rc.Width - padL - padR;
            int plotH = rc.Height - padT - padB;
            float rowH = (float)plotH / count;
            float barH = rowH * 0.55f;

            using var fntLabel = new Font("Segoe UI", 8.5f);
            using var fntVal = new Font("Segoe UI", 8.5f, FontStyle.Bold);

            // X-axis: 0 → 10
            float xScale = plotW / 10f;
            // Grid lines
            for (int v = 0; v <= 10; v += 2)
            {
                int gx = padL + (int)(v * xScale);
                using var gPen = new Pen(Color.FromArgb(220, 220, 230));
                g.DrawLine(gPen, gx, padT, gx, padT + plotH);
                g.DrawString(v.ToString(), fntLabel, new SolidBrush(CLR_TEXT_LIGHT),
                    gx - 6, padT + plotH + 4);
            }

            for (int i = 0; i < count; i++)
            {
                var row = _dtTopGPA.Rows[i];
                string name = row["HoTen"].ToString();
                double gpa = Convert.ToDouble(row["GPA"]);

                float y = padT + i * rowH + (rowH - barH) / 2f;
                float w = (float)(gpa * xScale);

                // Gradient bar
                var barRc = new RectangleF(padL, y, Math.Max(w, 2), barH);
                using var lgBr = new LinearGradientBrush(
                    new PointF(padL, y), new PointF(padL + Math.Max(w, 2), y),
                    PALETTE[4], PALETTE[1]);
                g.FillRectangle(lgBr, barRc);

                // GPA value
                g.DrawString($"{gpa:0.00}", fntVal, Brushes.White,
                    padL + w - 36, y + (barH - 14) / 2f);

                // Name label
                var nameSz = g.MeasureString(name, fntLabel);
                float nx = padL - nameSz.Width - 8;
                g.DrawString(name, fntLabel, new SolidBrush(CLR_TEXT_DARK),
                    Math.Max(4, nx), y + (barH - nameSz.Height) / 2f);
            }
        }

        // ════════════════════════════════════════════════════════════════════════
        //  BIỂU ĐỒ 3 – GROUPED BAR: ĐIỂM TB / MIN / MAX THEO MÔN
        // ════════════════════════════════════════════════════════════════════════
        private void PnlChartMonHoc_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rc = pnlChartMonHoc.ClientRectangle;
            g.Clear(CLR_CARD);

            if (_dtMonHoc == null || _dtMonHoc.Rows.Count == 0)
            { DrawEmpty(g, rc, "Chưa có dữ liệu môn học"); return; }

            int n = _dtMonHoc.Rows.Count;
            int padL = 50, padR = 20, padT = 30, padB = 70;
            int plotW = rc.Width - padL - padR;
            int plotH = rc.Height - padT - padB;

            float groupW = (float)plotW / n;
            float barW = groupW * 0.22f;
            float gap = barW * 0.25f;
            float groupPad = (groupW - 3 * barW - 2 * gap) / 2f;

            float yScale = plotH / 10f;

            using var fntSmall = new Font("Segoe UI", 7.5f);
            using var fntAxis = new Font("Segoe UI", 8f);

            // Y-axis grid
            for (int v = 0; v <= 10; v += 2)
            {
                int gy = padT + plotH - (int)(v * yScale);
                using var gPen = new Pen(Color.FromArgb(220, 220, 230));
                g.DrawLine(gPen, padL, gy, padL + plotW, gy);
                g.DrawString(v.ToString(), fntAxis, new SolidBrush(CLR_TEXT_LIGHT), 4, gy - 7);
            }

            Color[] barColors = { PALETTE[4], PALETTE[1], PALETTE[0] };
            string[] labels = { "TB", "Max", "Min" };

            for (int i = 0; i < n; i++)
            {
                var row = _dtMonHoc.Rows[i];
                string code = row["MaMH"].ToString();
                double[] vals = {
                    Convert.ToDouble(row["DiemTB"]),
                    Convert.ToDouble(row["DiemMax"]),
                    Convert.ToDouble(row["DiemMin"])
                };

                float gx = padL + i * groupW + groupPad;

                for (int j = 0; j < 3; j++)
                {
                    float bh = (float)(vals[j] * yScale);
                    float bx = gx + j * (barW + gap);
                    float by = padT + plotH - bh;

                    using var br = new SolidBrush(barColors[j]);
                    g.FillRectangle(br, bx, by, barW, bh);

                    g.DrawString($"{vals[j]:0.0}", fntSmall, new SolidBrush(CLR_TEXT_DARK),
                        bx, by - 14);
                }

                // X-axis label
                var sz = g.MeasureString(code, fntAxis);
                g.DrawString(code, fntAxis, new SolidBrush(CLR_TEXT_DARK),
                    padL + i * groupW + groupW / 2f - sz.Width / 2f,
                    padT + plotH + 6);
            }

            // Legend
            int legY = padT + plotH + 44;
            for (int j = 0; j < 3; j++)
            {
                int lx = padL + j * 90;
                using var br = new SolidBrush(barColors[j]);
                g.FillRectangle(br, lx, legY, 14, 14);
                g.DrawString(labels[j], fntAxis, new SolidBrush(CLR_TEXT_DARK), lx + 18, legY);
            }
        }

        // ════════════════════════════════════════════════════════════════════════
        //  BIỂU ĐỒ 4 – VERTICAL BAR: SỐ SV ĐĂNG KÝ THEO MÔN
        // ════════════════════════════════════════════════════════════════════════
        private void PnlChartDangKy_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rc = pnlChartDangKy.ClientRectangle;
            g.Clear(CLR_CARD);

            if (_dtDangKy == null || _dtDangKy.Rows.Count == 0)
            { DrawEmpty(g, rc, "Chưa có dữ liệu đăng ký"); return; }

            int n = _dtDangKy.Rows.Count;
            int padL = 50, padR = 20, padT = 20, padB = 80;
            int plotW = rc.Width - padL - padR;
            int plotH = rc.Height - padT - padB;

            int maxVal = _dtDangKy.AsEnumerable()
                             .Max(r => Convert.ToInt32(r["SoSVDangKy"]));
            if (maxVal == 0) { DrawEmpty(g, rc, "Chưa có sinh viên đăng ký"); return; }

            float yScale = (float)plotH / (maxVal + 1);
            float barW = (float)plotW / n * 0.6f;
            float step = (float)plotW / n;

            using var fntSmall = new Font("Segoe UI", 8f);
            using var fntAxis = new Font("Segoe UI", 7.5f);

            // Y-axis grid
            int tickStep = Math.Max(1, (maxVal + 1) / 5);
            for (int v = 0; v <= maxVal + 1; v += tickStep)
            {
                int gy = padT + plotH - (int)(v * yScale);
                using var gPen = new Pen(Color.FromArgb(220, 220, 230));
                g.DrawLine(gPen, padL, gy, padL + plotW, gy);
                g.DrawString(v.ToString(), fntAxis, new SolidBrush(CLR_TEXT_LIGHT), 4, gy - 7);
            }

            for (int i = 0; i < n; i++)
            {
                var row = _dtDangKy.Rows[i];
                string code = row["MaMH"].ToString();
                int cnt = Convert.ToInt32(row["SoSVDangKy"]);

                float bh = cnt * yScale;
                float bx = padL + i * step + (step - barW) / 2f;
                float by = padT + plotH - bh;

                // Gradient fill
                using var lgBr = new LinearGradientBrush(
                    new PointF(bx, by), new PointF(bx, padT + plotH),
                    PALETTE[i % PALETTE.Length],
                    Color.FromArgb(80, PALETTE[i % PALETTE.Length]));
                g.FillRectangle(lgBr, bx, by, barW, bh);

                // Count above bar
                g.DrawString(cnt.ToString(), fntSmall, new SolidBrush(CLR_TEXT_DARK),
                    bx + barW / 2f - 6, by - 16);

                // X-axis code label
                var sz = g.MeasureString(code, fntAxis);
                g.DrawString(code, fntAxis, new SolidBrush(CLR_TEXT_DARK),
                    bx + barW / 2f - sz.Width / 2f, padT + plotH + 5);
            }
        }

        // ════════════════════════════════════════════════════════════════════════
        //  HELPER
        // ════════════════════════════════════════════════════════════════════════
        private void DrawEmpty(Graphics g, Rectangle rc, string msg)
        {
            using var f = new Font("Segoe UI", 11f, FontStyle.Italic);
            var sz = g.MeasureString(msg, f);
            g.DrawString(msg, f, new SolidBrush(CLR_TEXT_LIGHT),
                (rc.Width - sz.Width) / 2f, (rc.Height - sz.Height) / 2f);
        }

        // ════════════════════════════════════════════════════════════════════════
        //  BUTTON EVENTS
        // ════════════════════════════════════════════════════════════════════════
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllData();
            UpdateSummaryCards();
            pnlChartXepLoai.Invalidate();
            pnlChartTopGPA.Invalidate();
            pnlChartMonHoc.Invalidate();
            pnlChartDangKy.Invalidate();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Xuất báo cáo sang Excel (cần thêm thư viện ClosedXML hoặc EPPlus)
            MessageBox.Show(
                "Tính năng xuất Excel sẽ được hoàn thiện ở bài tập tự làm.\n" +
                "Gợi ý: dùng ClosedXML để xuất DataTable ra .xlsx",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        // ════════════════════════════════════════════════════════════════════════
        //  TAB SELECTION – cập nhật tiêu đề biểu đồ đang hiển thị
        // ════════════════════════════════════════════════════════════════════════
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0: lblChartTitle.Text = "📊  Phân bố Xếp loại Học lực"; break;
                case 1: lblChartTitle.Text = "🏆  Top 10 Sinh viên GPA cao nhất"; break;
                case 2: lblChartTitle.Text = "📚  Điểm Trung bình / Min / Max theo Môn học"; break;
                case 3: lblChartTitle.Text = "📋  Số Sinh viên Đăng ký theo Môn học"; break;
            }
        }
    }
}