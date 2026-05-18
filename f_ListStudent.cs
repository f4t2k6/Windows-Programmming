using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    public partial class f_ListStudent : Form
    {
        public f_ListStudent()
        {
            InitializeComponent();
        }

        private void f_ListStudent_Load(object sender, EventArgs e)
        {
            // Hiển thị người đang đăng nhập
            lblCurrentUser.Text = $"Đang đăng nhập: {Globals.GlobalUsername} ({Globals.GlobalRole})";

            // Khởi tạo ComboBox Sắp xếp
            cboSort.Items.Clear();
            cboSort.Items.Add("Mặc định");
            cboSort.Items.Add("Theo MSSV");
            cboSort.Items.Add("Theo Tên (A-Z)");
            cboSort.Items.Add("Theo Tên (Z-A)");
            cboSort.SelectedIndex = 0;

            // Khởi tạo ComboBox Lọc Giới tính (Bài tập tự làm)
            cboGenderFilter.Items.Clear();
            cboGenderFilter.Items.Add("Tất cả");
            cboGenderFilter.Items.Add("Nam");
            cboGenderFilter.Items.Add("Nữ");
            cboGenderFilter.SelectedIndex = 0;

            RefreshData();
            dgvStudents.CellDoubleClick += dgvStudents_CellDoubleClick;
        }

        // Hàm trung gian gom tất cả các tham số từ giao diện để tải lại dữ liệu
        private void RefreshData()
        {
            string keyword = (txtSearch.Text == "Tìm kiếm..." || string.IsNullOrEmpty(txtSearch.Text)) ? "" : txtSearch.Text;
            string sortBy = cboSort.SelectedItem?.ToString() ?? "Mặc định";
            string genderFilter = cboGenderFilter.SelectedItem?.ToString() ?? "Tất cả";

            // Gọi hàm từ lớp Student theo đúng chuẩn OOP (Đã có sẵn cột Picture)
            DataTable dt = Student.GetStudents(keyword, genderFilter, sortBy);
            dgvStudents.DataSource = dt;

            // Đặt tên cột tiếng Việt và ẩn các cột không cần thiết hiển thị trên bảng lớn
            if (dgvStudents.Columns.Count > 0)
            {
                dgvStudents.Columns["MSSV"].HeaderText = "Mã SV";
                dgvStudents.Columns["Fname"].HeaderText = "Họ";
                dgvStudents.Columns["Lname"].HeaderText = "Tên";
                dgvStudents.Columns["Dob"].HeaderText = "Ngày sinh";
                dgvStudents.Columns["Gder"].HeaderText = "Giới tính";

                // Đặt tiêu đề tiếng Việt riêng cho cột ảnh đại diện
                if (dgvStudents.Columns["Picture"] != null)
                    dgvStudents.Columns["Picture"].HeaderText = "Ảnh đại diện";

                // Các cột chi tiết có thể ẩn đi trên danh sách tổng quan
                if (dgvStudents.Columns["Phone"] != null) dgvStudents.Columns["Phone"].Visible = false;
                if (dgvStudents.Columns["Address"] != null) dgvStudents.Columns["Address"].Visible = false;
                if (dgvStudents.Columns["Htown"] != null) dgvStudents.Columns["Htown"].Visible = false;
                if (dgvStudents.Columns["Email"] != null) dgvStudents.Columns["Email"].Visible = false;

                // DÒNG NÀY ĐÃ ĐƯỢC XÓA HOẶC COMMENT ĐỂ CỘT ẢNH HIỆN LÊN:
                // if (dgvStudents.Columns["Picture"] != null) dgvStudents.Columns["Picture"].Visible = false;
            }

            // Hiển thị tổng số sinh viên
            lblTotal.Text = $"Tổng số sinh viên: {dt.Rows.Count}";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cboGenderFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            f_AddStudent addForm = new f_AddStudent();
            addForm.FormClosed += (s, args) => RefreshData(); // Reload sau khi thêm mới thành công
            addForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Globals.ClearSession();
            // Đảm bảo trỏ đúng tên Form đăng nhập của bạn (f_Login)
            f_Login loginForm = new f_Login();
            loginForm.Show();
            this.Close();
        }
        private void dgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo người dùng click trúng dòng có dữ liệu hợp lệ (không phải hàng tiêu đề)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];

                // Truyền dòng dữ liệu hiện tại sang Form Sửa/Xóa
                f_EditDeleteStudent editForm = new f_EditDeleteStudent(row);

                // Khi đóng Form Sửa/Xóa thì tự động làm mới lại bảng danh sách
                editForm.FormClosed += (s, args) => RefreshData();
                editForm.ShowDialog();
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Đưa các thanh tìm kiếm và bộ lọc về trạng thái ban đầu
            txtSearch.Text = "Tìm kiếm...";
            if (cboSort.Items.Count > 0) cboSort.SelectedIndex = 0;
            if (cboGenderFilter.Items.Count > 0) cboGenderFilter.SelectedIndex = 0;

            // Gọi lại hàm load dữ liệu
            RefreshData(); // Hoặc RefreshData() tùy theo tên hàm hiện tại của bạn
            MessageBox.Show("Danh sách sinh viên đã được cập nhật mới nhất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}