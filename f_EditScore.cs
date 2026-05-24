using System;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    public partial class f_EditScore : Form
    {
        private DataGridViewRow _scoreRow;

        // Constructor nhận dòng điểm được chọn từ danh sách
        public f_EditScore(DataGridViewRow row)
        {
            InitializeComponent();
            _scoreRow = row;
        }

        private void f_EditScore_Load(object sender, EventArgs e)
        {
            // Điền dữ liệu cũ lên giao diện
            txtStudentId.Text = _scoreRow.Cells["student_id"].Value?.ToString();
            txtStudentId.Enabled = false; // Không cho sửa MSSV

            txtCourseId.Text = _scoreRow.Cells["course_id"].Value?.ToString();
            txtCourseId.Enabled = false; // Không cho sửa mã môn (là khóa chính)

            txtCourseName.Text = _scoreRow.Cells["course_name"].Value?.ToString();
            txtDescription.Text = _scoreRow.Cells["description"].Value?.ToString();

            // Xử lý điểm số an toàn
            if (_scoreRow.Cells["score"].Value != null &&
                double.TryParse(_scoreRow.Cells["score"].Value.ToString(), out double scoreVal))
            {
                nudScore.Value = (decimal)scoreVal;
            }
            else
            {
                nudScore.Value = 0;
            }
        }

        // XỬ LÝ LƯU ĐIỂM (UPDATE)
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int studentId = int.Parse(txtStudentId.Text);
                string courseId = txtCourseId.Text.Trim();
                string courseName = txtCourseName.Text.Trim();
                double score = (double)nudScore.Value;
                string description = txtDescription.Text.Trim();

                // Kiểm tra điểm hợp lệ
                if (score < 0 || score > 10)
                {
                    MessageBox.Show("Điểm số phải nằm trong khoảng 0.0 đến 10.0!", "Lỗi dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(courseName))
                {
                    MessageBox.Show("Tên môn học không được để trống!", "Lỗi dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

        // XỬ LÝ HỦY
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCourseName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
