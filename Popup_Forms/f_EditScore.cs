using System;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_EditScore : Form
    {
        private DataGridViewRow _scoreRow;
        private int _studentMSSV;

        public f_EditScore(DataGridViewRow row, int studentMSSV)
        {
            InitializeComponent();
            _scoreRow = row;
            _studentMSSV = studentMSSV;
        }

        private void f_EditScore_Load(object sender, EventArgs e)
        {
            // MSSV luôn lấy từ tham số truyền vào
            txtStudentId.Text = _studentMSSV.ToString();
            txtStudentId.ReadOnly = true;
            txtStudentId.BackColor = System.Drawing.Color.LightGray;

            // Mã môn học không cho sửa
            txtCourseId.Text = _scoreRow.Cells["course_id"].Value?.ToString() ?? "";
            txtCourseId.ReadOnly = true;
            txtCourseId.BackColor = System.Drawing.Color.LightGray;

            // Các trường thông tin khác
            txtCourseName.Text = _scoreRow.Cells["course_name"].Value?.ToString() ?? "";
            txtDescription.Text = _scoreRow.Cells["description"].Value?.ToString() ?? "";

            // Đổ dữ liệu Điểm quá trình
            if (_scoreRow.Cells["DiemQT"].Value != null &&
                double.TryParse(_scoreRow.Cells["DiemQT"].Value.ToString(), out double qtVal))
            {
                nudDiemQT.Value = (decimal)Math.Max(0, Math.Min(10, qtVal));
            }
            else nudDiemQT.Value = 0;

            // Đổ dữ liệu Điểm cuối kỳ
            if (_scoreRow.Cells["DiemCK"].Value != null &&
                double.TryParse(_scoreRow.Cells["DiemCK"].Value.ToString(), out double ckVal))
            {
                nudDiemCK.Value = (decimal)Math.Max(0, Math.Min(10, ckVal));
            }
            else nudDiemCK.Value = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int studentId = _studentMSSV;
                string courseId = txtCourseId.Text.Trim();
                string courseName = txtCourseName.Text.Trim();
                double diemQT = (double)nudDiemQT.Value;
                double diemCK = (double)nudDiemCK.Value;
                string description = txtDescription.Text.Trim();

                // --- Kiểm tra hợp lệ dữ liệu ---
                if (studentId <= 0)
                {
                    MessageBox.Show("MSSV không hợp lệ!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(courseId))
                {
                    MessageBox.Show("Mã môn học không được để trống!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(courseName))
                {
                    MessageBox.Show("Tên môn học không được để trống!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (description.Length > 500)
                {
                    MessageBox.Show("Ghi chú không được vượt quá 500 ký tự!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // --- Xác nhận trước khi lưu ---
                double diemTK_DuKien = Math.Round(diemQT * 0.4 + diemCK * 0.6, 2);
                var confirm = MessageBox.Show(
                    $"Xác nhận cập nhật điểm môn \"{courseName}\"?\n- Điểm QT: {diemQT}\n- Điểm CK: {diemCK}\n=> Tổng kết dự kiến: {diemTK_DuKien}",
                    "Xác nhận thay đổi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                // --- Gán dữ liệu vào đối tượng Score bằng Object Initializer ---
                Score scoreObj = new Score()
                {
                    StudentId = studentId,
                    CourseId = courseId,
                    CourseName = courseName,
                    DiemQT = diemQT,
                    DiemCK = diemCK,
                    Description = description
                };

                // Gọi hàm EditScore của lớp Score để cập nhật vào Database
                if (scoreObj.EditScore())
                {
                    MessageBox.Show("Cập nhật điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Đặt trạng thái thành công để form danh sách cập nhật lại grid
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra kết nối CSDL hoặc dữ liệu đầu vào.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void txtCourseName_TextChanged(object sender, EventArgs e)
        {
            // Để trống hoặc xử lý logic nếu bạn muốn thực hiện hành động khi tên môn học thay đổi
        }
    }

}