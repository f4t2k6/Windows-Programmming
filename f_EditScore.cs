using System;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    //Bỏ lỗi CA1416
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]

    public partial class f_EditScore : Form
    {
        private DataGridViewRow _scoreRow;
        private int _studentMSSV; // Nhận từ f_ListScore để đảm bảo đúng

        public f_EditScore(DataGridViewRow row, int studentMSSV)
        {
            InitializeComponent();
            _scoreRow = row;
            _studentMSSV = studentMSSV;
        }

        private void f_EditScore_Load(object sender, EventArgs e)
        {
            // MSSV luôn lấy từ tham số truyền vào (tránh lỗi cột bị ẩn)
            txtStudentId.Text = _studentMSSV.ToString();
            txtStudentId.ReadOnly = true; // Hiển thị nhưng không cho sửa
            txtStudentId.BackColor = System.Drawing.Color.LightGray;

            // Mã môn học là khóa chính, không cho sửa
            txtCourseId.Text = _scoreRow.Cells["course_id"].Value?.ToString() ?? "";
            txtCourseId.ReadOnly = true;
            txtCourseId.BackColor = System.Drawing.Color.LightGray;

            // Các trường được phép sửa
            txtCourseName.Text = _scoreRow.Cells["course_name"].Value?.ToString() ?? "";
            txtDescription.Text = _scoreRow.Cells["description"].Value?.ToString() ?? "";

            // Điểm số
            if (_scoreRow.Cells["score"].Value != null &&
                double.TryParse(_scoreRow.Cells["score"].Value.ToString(), out double scoreVal))
            {
                nudScore.Value = (decimal)Math.Max(0, Math.Min(10, scoreVal));
            }
            else
            {
                nudScore.Value = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // --- Lấy dữ liệu ---
                int studentId = _studentMSSV;                 // Luôn dùng giá trị gốc
                string courseId = txtCourseId.Text.Trim();      // Khóa chính, không đổi
                string courseName = txtCourseName.Text.Trim();
                double score = (double)nudScore.Value;
                string description = txtDescription.Text.Trim();

                // --- Validate ---
                if (studentId <= 0)
                {
                    MessageBox.Show("MSSV không hợp lệ!", "Lỗi dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(courseId))
                {
                    MessageBox.Show("Mã môn học không được để trống!", "Lỗi dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(courseName))
                {
                    MessageBox.Show("Tên môn học không được để trống!", "Lỗi dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // nudScore đã giới hạn 0–10 ở Designer nhưng vẫn kiểm tra thêm
                if (score < 0 || score > 10)
                {
                    MessageBox.Show("Điểm số phải nằm trong khoảng 0.0 đến 10.0!",
                        "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (description.Length > 500)
                {
                    MessageBox.Show("Ghi chú không được vượt quá 500 ký tự!",
                        "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // --- Xác nhận trước khi lưu ---
                var confirm = MessageBox.Show(
                    $"Xác nhận cập nhật điểm môn \"{courseName}\" thành {score:F1}?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                // --- Lưu ---
                Score scoreObj = new Score(studentId, courseId, courseName, score, description);
                if (scoreObj.EditScore())
                {
                    MessageBox.Show("Cập nhật điểm thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại dữ liệu.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}", "Thông báo lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void txtCourseName_TextChanged(object sender, EventArgs e) { }
    }
}