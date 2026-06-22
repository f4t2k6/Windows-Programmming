using System;
using System.Data;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    //Bỏ lỗi CA1416
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_RegisterCourse : Form
    {
        public f_RegisterCourse()
        {
            InitializeComponent();
            StyleDataGridView(dgvRegistered);
            StyleDataGridView(dgvHuy);

            this.Load += f_RegisterCourse_Load;
            cboStudent.SelectedIndexChanged += cboStudent_SelectedIndexChanged;
            cboCourse.SelectedIndexChanged += cboCourse_SelectedIndexChanged;
            btnRegister.Click += btnRegister_Click;
            btnNewDK.Click += btnNewDK_Click;
            btnAISuggest.Click += btnAISuggest_Click;
            btnLoadHuy.Click += btnLoadHuy_Click;
            btnUnregister.Click += btnUnregister_Click;
        }

        // ════════════════════════════════════════════════════════════════
        // FORM LOAD
        // ════════════════════════════════════════════════════════════════
        private void f_RegisterCourse_Load(object sender, EventArgs e)
        {
            LoadStudentCombo();
            LoadCourseCombo();

            // Alternating row color
            dgvRegistered.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvRegistered.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 249, 255);
            dgvHuy.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvHuy.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 249, 255);
        }

        // ════════════════════════════════════════════════════════════════
        // LOAD COMBOS
        // ════════════════════════════════════════════════════════════════
        private void LoadStudentCombo()
        {
            // Ngắt event tránh trigger khi set DataSource
            cboStudent.SelectedIndexChanged -= cboStudent_SelectedIndexChanged;

            var dt = Student.GetStudentsForCombo();
            cboStudent.DataSource = dt;
            cboStudent.DisplayMember = "HoTen";
            cboStudent.ValueMember = "MSSV";

            // Sync tab Hủy
            cboStudentHuy.DataSource = Student.GetStudentsForCombo();
            cboStudentHuy.DisplayMember = "HoTen";
            cboStudentHuy.ValueMember = "MSSV";

            // Kết nối lại event sau khi bind xong
            cboStudent.SelectedIndexChanged += cboStudent_SelectedIndexChanged;

            // Load môn cho sinh viên đầu tiên
            LoadRegisteredCourses();
        }

        private void LoadCourseCombo()
        {
            var dt = Course.GetCourse();           // gọi không tham số → lấy tất cả
            cboCourse.DataSource = dt;
            cboCourse.DisplayMember = "TenMH";
            cboCourse.ValueMember = "MaMH";
        }

        // ════════════════════════════════════════════════════════════════
        // TAB ĐĂNG KÝ
        // ════════════════════════════════════════════════════════════════
        private void cboStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRegisteredCourses();
        }

        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCourse.SelectedValue == null) return;
            string mamh = cboCourse.SelectedValue.ToString();
            
            // Lấy thông tin từ DB (có thể query trực tiếp hoặc lấy từ DataSource hiện tại)
            // Lấy trực tiếp từ DB để đảm bảo độ chính xác theo yêu cầu
            try
            {
                MY_DB db = new MY_DB();
                db.openConnection();
                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand("SELECT SoTC, Tuan FROM Course WHERE MaMH = @ma", db.conn);
                cmd.Parameters.AddWithValue("@ma", mamh);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int tc = reader.GetInt32(0);
                        int tuan = reader.GetInt32(1);
                        lblCourseInfo.Text = $"Thông tin: {tc} Tín chỉ | {tuan} Tuần";
                    }
                    else
                    {
                        lblCourseInfo.Text = "Không tìm thấy thông tin";
                    }
                }
                db.closeConnection();
            }
            catch
            {
                lblCourseInfo.Text = "Lỗi tải thông tin";
            }
        }

        private void LoadRegisteredCourses()
        {
            if (cboStudent.SelectedValue == null) return;
            int mssv = Convert.ToInt32(cboStudent.SelectedValue);
            dgvRegistered.DataSource = Registration.GetRegisteredCourses(mssv);

            int count = dgvRegistered.Rows.Count;
            SetStatus($"Sinh viên đã đăng ký {count} môn học.");
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue == null || cboCourse.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên và môn học!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int mssv = Convert.ToInt32(cboStudent.SelectedValue);
            string mamh = cboCourse.SelectedValue.ToString().Trim();
            string tenMH = cboCourse.Text;

            // ── Lấy thông tin môn học cần đăng ký ──
            var dtCourse = Course.GetCourse();
            DataRow[] rows = dtCourse.Select($"MaMH = '{mamh}'");
            if (rows.Length == 0) return;

            int soTC = Convert.ToInt32(rows[0]["SoTC"]);
            int hocky = Convert.ToInt32(rows[0]["Hky"]);
            string lichHocMoi = rows[0]["LichHoc"]?.ToString();

            // ── Kiểm tra giới hạn 24 TC / học kỳ ──
            const int MAX_TC = 24;
            int currentTC = Registration.GetTotalCredits(mssv, hocky);

            if (currentTC + soTC > MAX_TC)
            {
                MessageBox.Show(
                    $"Không thể đăng ký!\n\n" +
                    $"Môn \"{tenMH}\" có {soTC} TC.\n" +
                    $"Học kỳ {hocky} đã đăng ký: {currentTC} TC.\n" +
                    $"Tổng sẽ vượt giới hạn {MAX_TC} TC/học kỳ.",
                    "Vượt giới hạn tín chỉ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ── [AI] Kiểm tra trùng lịch ──
            if (!string.IsNullOrWhiteSpace(lichHocMoi))
            {
                btnRegister.Text = "⏳ Đang kiểm tra...";
                btnRegister.Enabled = false;

                try
                {
                    var registeredDt = Registration.GetRegisteredCourses(mssv);
                    var currentSchedules = new List<string>();
                    
                    // Cần lấy LichHoc của các môn đã đăng ký
                    // Vì GetRegisteredCourses hiện tại chưa lấy LichHoc, ta có thể lấy từ dtCourse
                    foreach (DataRow r in registeredDt.Rows)
                    {
                        string maDaDk = r["MaMH"].ToString();
                        DataRow[] cr = dtCourse.Select($"MaMH = '{maDaDk}'");
                        if (cr.Length > 0 && cr[0]["LichHoc"] != DBNull.Value && !string.IsNullOrWhiteSpace(cr[0]["LichHoc"].ToString()))
                        {
                            currentSchedules.Add(cr[0]["LichHoc"].ToString());
                        }
                    }

                    var chatbot = new ProjectMonHoc.Classes.ChatbotService();
                    string conflictWarn = await chatbot.CheckScheduleConflictAsync(lichHocMoi, currentSchedules);

                    if (!string.IsNullOrEmpty(conflictWarn))
                    {
                        var confirm = MessageBox.Show(
                            $"⚠️ AI Cảnh Báo Trùng Lịch!\n\n{conflictWarn}\n\nBạn có vẫn muốn tiếp tục đăng ký không?",
                            "Cảnh báo trùng lịch", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        
                        if (confirm == DialogResult.No)
                        {
                            btnRegister.Text = "✚  Đăng ký";
                            btnRegister.Enabled = true;
                            return;
                        }
                    }
                }
                finally
                {
                    btnRegister.Text = "✚  Đăng ký";
                    btnRegister.Enabled = true;
                }
            }

            // ── Tiến hành đăng ký ──
            if (Registration.RegisterCourse(mssv, mamh))
            {
                SetStatus($"✔  Đăng ký thành công môn: {tenMH} ({soTC} TC). " +
                          $"Tổng HK{hocky}: {currentTC + soTC}/{MAX_TC} TC");
                MessageBox.Show(
                    $"Đăng ký thành công!\nMôn: {tenMH}\n" +
                    $"Tổng TC học kỳ {hocky}: {currentTC + soTC}/{MAX_TC}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRegisteredCourses();
            }
            else
            {
                SetStatus("✖  Đăng ký thất bại.");
                MessageBox.Show("Đăng ký thất bại!\nSinh viên có thể đã đăng ký môn này.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNewDK_Click(object sender, EventArgs e)
        {
            cboStudent.SelectedIndex = -1;
            cboCourse.SelectedIndex = -1;
            lblCourseInfo.Text = "Chọn môn học để xem thông tin";
            dgvRegistered.DataSource = null;
            SetStatus("Đã làm mới.");
        }

        private async void btnAISuggest_Click(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên để nhận gợi ý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int mssv = Convert.ToInt32(cboStudent.SelectedValue);
            string tenSV = cboStudent.Text;
            
            btnAISuggest.Text = "⏳ Đang phân tích...";
            btnAISuggest.Enabled = false;

            try
            {
                var chatbot = new ProjectMonHoc.Classes.ChatbotService();
                string suggestion = await chatbot.SuggestCourseAsync(mssv, tenSV);
                MessageBox.Show(suggestion, "💡 AI Gợi Ý Môn Học", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối AI: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAISuggest.Text = "💡 Gợi ý AI";
                btnAISuggest.Enabled = true;
            }
        }

        // ════════════════════════════════════════════════════════════════
        // TAB HỦY ĐĂNG KÝ
        // ════════════════════════════════════════════════════════════════
        private void btnLoadHuy_Click(object sender, EventArgs e)
        {
            if (cboStudentHuy.SelectedValue == null) return;
            int mssv = Convert.ToInt32(cboStudentHuy.SelectedValue);
            dgvHuy.DataSource = Registration.GetRegisteredCourses(mssv);

            int count = dgvHuy.Rows.Count;
            SetStatus($"Tải {count} môn đã đăng ký.");
        }

        private void btnUnregister_Click(object sender, EventArgs e)
        {
            if (dgvHuy.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn môn học cần hủy!", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int mssv = Convert.ToInt32(cboStudentHuy.SelectedValue);
            string mamh = dgvHuy.SelectedRows[0].Cells["MaMH"].Value.ToString();
            string tenMH = dgvHuy.SelectedRows[0].Cells["TenMH"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Xác nhận hủy đăng ký môn:\n\"{tenMH}\"?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            if (Registration.UnregisterCourse(mssv, mamh))
            {
                SetStatus($"✔  Đã hủy đăng ký môn: {tenMH}");
                MessageBox.Show("Hủy đăng ký thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLoadHuy_Click(null, null); // reload
            }
            else
            {
                SetStatus("✖  Hủy thất bại.");
                MessageBox.Show("Hủy thất bại! Vui lòng thử lại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════════
        // HELPERS
        // ════════════════════════════════════════════════════════════════
        private void SetStatus(string msg)
        {
            lblStatus.Text = msg;
        }

        /// <summary>Áp dụng style chung cho DataGridView</summary>
        private static void StyleDataGridView(DataGridView dgv)
        {
            dgv.GridColor = System.Drawing.Color.FromArgb(220, 220, 220);
            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 114, 188);
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
        }
    }
}