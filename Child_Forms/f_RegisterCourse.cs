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

            // Wire events ở constructor — đảm bảo chạy trước khi form hiện
            this.Load += f_RegisterCourse_Load;
            cboStudent.SelectedIndexChanged += cboStudent_SelectedIndexChanged;
            btnRegister.Click += btnRegister_Click;
            btnNewDK.Click += btnNewDK_Click;
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

        private void LoadRegisteredCourses()
        {
            if (cboStudent.SelectedValue == null) return;
            int mssv = Convert.ToInt32(cboStudent.SelectedValue);
            dgvRegistered.DataSource = Registration.GetRegisteredCourses(mssv);

            int count = dgvRegistered.Rows.Count;
            SetStatus($"Sinh viên đã đăng ký {count} môn học.");
        }

        private void btnRegister_Click(object sender, EventArgs e)
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
            dgvRegistered.DataSource = null;
            SetStatus("Đã làm mới.");
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