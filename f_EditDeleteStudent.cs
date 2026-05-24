using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    public partial class f_EditDeleteStudent : Form
    {
        private DataGridViewRow studentRow;

        // Constructor nhận vào dòng dữ liệu được chọn từ bảng danh sách
        public f_EditDeleteStudent(DataGridViewRow row)
        {
            InitializeComponent();
            this.studentRow = row;
        }

        private void f_EditDeleteStudent_Load(object sender, EventArgs e)
        {
            // Điền dữ liệu cũ lên các điều khiển giao diện
            txtMSSV.Text = studentRow.Cells["MSSV"].Value.ToString();
            txtMSSV.Enabled = false; // Bài tập: Không cho phép sửa khóa chính MSSV

            txtFname.Text = studentRow.Cells["Fname"].Value?.ToString();
            txtLname.Text = studentRow.Cells["Lname"].Value?.ToString();
            dtpDob.Value = Convert.ToDateTime(studentRow.Cells["Dob"].Value);
            cboGender.Text = studentRow.Cells["Gder"].Value?.ToString();
            txtPhone.Text = studentRow.Cells["Phone"].Value?.ToString();
            txtAddress.Text = studentRow.Cells["Address"].Value?.ToString();
            txtHtown.Text = studentRow.Cells["Htown"].Value?.ToString();
            txtEmail.Text = studentRow.Cells["Email"].Value?.ToString();

            // Cấu hình định dạng hiển thị cho DateTimePicker tránh bị trống dữ liệu như trong ảnh
            dtpDob.Format = DateTimePickerFormat.Custom;
            dtpDob.CustomFormat = "dd/MM/yyyy";

            // Kiểm tra và nạp ngày sinh an toàn
            if (studentRow.Cells["Dob"].Value != DBNull.Value && studentRow.Cells["Dob"].Value != null)
            {
                dtpDob.Value = Convert.ToDateTime(studentRow.Cells["Dob"].Value);
            }
            else
            {
                dtpDob.Value = DateTime.Now; // Ngày mặc định nếu DB bị trống
            }

            // Xử lý hiển thị ảnh đại diện cũ (nếu có)
            if (studentRow.Cells["Pture"].Value != DBNull.Value && studentRow.Cells["Pture"].Value != null)
            {
                try
                {
                    byte[] imgData = (byte[])studentRow.Cells["Pture"].Value;
                    if (imgData.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imgData))
                        {
                            picAvatar.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch
                {
                    picAvatar.Image = null;
                }
            }
            else
            {
                picAvatar.Image = null;
            }
        }

        // Nút bấm chọn ảnh mới
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                picAvatar.Image = Image.FromFile(opf.FileName);
            }
        }

        // XỬ LÝ SỬA THÔNG TIN (UPDATE)
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int mssv = int.Parse(txtMSSV.Text);
                string fname = txtFname.Text;
                string lname = txtLname.Text;
                DateTime dob = dtpDob.Value; // Lấy ngày sinh từ điều khiển đã sửa ở Bước 1
                string gender = cboGender.Text;
                string phone = txtPhone.Text;
                string address = txtAddress.Text;
                string htown = txtHtown.Text;
                string email = txtEmail.Text;

                // Xử lý ảnh đại diện an toàn chống lỗi dữ liệu
                byte[] pic = null;
                if (picAvatar.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Tạo một bản sao mới (Bitmap) của ảnh để không bị lock file/bộ nhớ
                        using (Bitmap bmp = new Bitmap(picAvatar.Image))
                        {
                            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        pic = ms.ToArray();
                    }
                }

                // Tạo đối tượng và thực hiện cập nhật dữ liệu
                Student student = new Student(mssv, fname, lname, dob, gender, phone, address, htown, email, pic);

                if (student.EditStudent())
                {
                    MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Thêm dòng này để nếu có lỗi hệ thống, bạn sẽ nhìn thấy trực tiếp nguyên nhân (như sai tên cột, sai kiểu dữ liệu...)
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // XỬ LÝ XÓA SINH VIÊN (DELETE)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSSV.Text)) return;

            int mssv = int.Parse(txtMSSV.Text);

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sinh viên mang mã số {mssv} ra khỏi hệ thống?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                // Gọi hàm xóa đã có logic kiểm tra bảng Score
                if (Student.DeleteStudent(mssv))
                {
                    MessageBox.Show("Đã xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    // Thông báo lỗi ràng buộc dữ liệu bảng điểm
                    MessageBox.Show("Không thể xóa sinh viên này vì sinh viên đã có điểm trong hệ thống (Bảng Score) hoặc mã số không tồn tại!",
                                    "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void txtMSSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}