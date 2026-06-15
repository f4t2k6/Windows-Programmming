using OfficeOpenXml;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;

namespace ProjectMonHoc
{
    //Bỏ lỗi CA1416
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_ListStudent : Form
    {
        public f_ListStudent()
        {
            InitializeComponent();
        }

        private void f_ListStudent_Load(object sender, EventArgs e)
        {
            // Hiển thị người đang đăng nhập
            lblCurrentUser.Text = $"Đang đăng nhập: {Globals.GlobalUsername} ({Globals.GlobalRole})"; //

            // Khởi tạo ComboBox Sắp xếp
            cboSort.Items.Clear(); //
            cboSort.Items.Add("Mặc định"); //
            cboSort.Items.Add("Theo MSSV"); //
            cboSort.Items.Add("Theo Tên (A-Z)"); //
            cboSort.Items.Add("Theo Tên (Z-A)"); //
            cboSort.SelectedIndex = 0; //

            // Khởi tạo ComboBox Lọc Giới tính (Bài tập tự làm)
            cboGenderFilter.Items.Clear(); //
            cboGenderFilter.Items.Add("Tất cả"); //
            cboGenderFilter.Items.Add("Nam"); //
            cboGenderFilter.Items.Add("Nữ"); //
            cboGenderFilter.SelectedIndex = 0; //

            RefreshData(); //
            dgvStudents.CellDoubleClick += dgvStudents_CellDoubleClick; //
        }

        // Hàm trung gian gom tất cả các tham số từ giao diện để tải lại dữ liệu
        private void RefreshData()
        {
            string keyword = (txtSearch.Text == "Tìm kiếm..." || string.IsNullOrEmpty(txtSearch.Text)) ? "" : txtSearch.Text;
            string sortBy = cboSort.SelectedItem?.ToString() ?? "Mặc định";
            string genderFilter = cboGenderFilter.SelectedItem?.ToString() ?? "Tất cả";

            // Gọi hàm từ lớp Student theo đúng chuẩn OOP
            DataTable dt = Student.GetStudents(keyword, genderFilter, sortBy);
            dgvStudents.DataSource = dt;

            // ==========================================================
            // CẤU HÌNH GIAO DIỆN LẤP ĐẦY BẢNG & TỐI ƯU GIAO DIỆN CHUẨN ĐẸP
            // ==========================================================

            // 1. Kích hoạt Double Buffered giúp cuộn chuột cực mượt, không bị giật lag
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, dgvStudents, new object[] { true });

            // 2. ẨN DÒNG TRỐNG THỪA Ở CUỐI BẢNG
            dgvStudents.AllowUserToAddRows = false;

            // 3. Ẩn cột dư (mũi tên chọn dòng) bên trái giúp bảng gọn gàng hơn
            dgvStudents.RowHeadersVisible = false;

            // 4. Bật thanh cuộn dọc (nếu danh sách dài)
            dgvStudents.ScrollBars = ScrollBars.Vertical;

            // 5. FILL CỘT ĐỀU NHAU: Tự động dãn các cột chữ lấp đầy bề ngang bảng
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 6. KHÓA CHIỀU CAO DÒNG: Đặt kích thước 70px cố định để cuộn mượt và ảnh to rõ
            dgvStudents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvStudents.RowTemplate.Height = 70;

            // Áp dụng đồng bộ chiều cao 70px cho mọi dòng đang hiển thị
            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                row.Height = 70;
            }

            // Đặt tên cột tiếng Việt và ẩn các cột không cần thiết
            if (dgvStudents.Columns.Count > 0)
            {
                dgvStudents.Columns["MSSV"].HeaderText = "Mã SV";
                dgvStudents.Columns["Fname"].HeaderText = "Họ";
                dgvStudents.Columns["Lname"].HeaderText = "Tên";
                dgvStudents.Columns["Dob"].HeaderText = "Ngày sinh";
                dgvStudents.Columns["Gder"].HeaderText = "Giới tính";

                // Cấu hình ảnh to + lấp đầy ô chứa
                if (dgvStudents.Columns["Pture"] != null)
                {
                    dgvStudents.Columns["Pture"].HeaderText = "Ảnh đại diện";

                    if (dgvStudents.Columns["Pture"] is DataGridViewImageColumn imgColumn)
                    {
                        imgColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                        imgColumn.Width = 70;
                        imgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    }
                }

                // Các cột chi tiết ẩn đi trên danh sách tổng quan
                if (dgvStudents.Columns["Phone"] != null) dgvStudents.Columns["Phone"].Visible = false;
                if (dgvStudents.Columns["Address"] != null) dgvStudents.Columns["Address"].Visible = false;
                if (dgvStudents.Columns["Htown"] != null) dgvStudents.Columns["Htown"].Visible = false;
                if (dgvStudents.Columns["Email"] != null) dgvStudents.Columns["Email"].Visible = false;
            }

            // Hiển thị tổng số sinh viên
            lblTotal.Text = $"Tổng số sinh viên: {dt.Rows.Count}";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshData(); //
        }

        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData(); //
        }

        private void cboGenderFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData(); //
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            f_AddStudent addForm = new f_AddStudent(); //
            addForm.FormClosed += (s, args) => RefreshData(); // Reload sau khi thêm mới thành công
            addForm.ShowDialog(); //
        }

        private void dgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo người dùng click trúng dòng có dữ liệu hợp lệ (không phải hàng tiêu đề)
            if (e.RowIndex >= 0) //
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex]; //

                // Truyền dòng dữ liệu hiện tại sang Form Sửa/Xóa
                f_EditDeleteStudent editForm = new f_EditDeleteStudent(row); //

                // Khi đóng Form Sửa/Xóa thì tự động làm mới lại bảng danh sách
                editForm.FormClosed += (s, args) => RefreshData(); //
                editForm.ShowDialog(); //
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Đưa các thanh tìm kiếm và bộ lọc về trạng thái ban đầu
            txtSearch.Text = "Tìm kiếm..."; //
            if (cboSort.Items.Count > 0) cboSort.SelectedIndex = 0; //
            if (cboGenderFilter.Items.Count > 0) cboGenderFilter.SelectedIndex = 0; //

            // Gọi lại hàm load dữ liệu
            RefreshData(); // Hoặc RefreshData() tùy theo tên hàm hiện tại của bạn
            MessageBox.Show("Danh sách sinh viên đã được cập nhật mới nhất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); //
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblTotal_Click(object sender, EventArgs e) { }
        private void lb_Notification_Click(object sender, EventArgs e) { }

        private void btn_ExportExcelStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu sinh viên để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel (*.xlsx)|*.xlsx",
                FileName = "DanhSachSinhVien.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Khai báo bản quyền EPPlus 8
                    ExcelPackage.License.SetNonCommercialPersonal("TenCuaBan");

                    using (ExcelPackage package = new ExcelPackage())
                    {
                        ExcelWorksheet ws = package.Workbook.Worksheets.Add("Danh sách SV");

                        // 1. TẠO HEADER ĐÚNG YÊU CẦU TÀI LIỆU
                        string[] headers = { "MSSV", "Họ", "Tên", "Ngày sinh", "Giới tính", "SĐT", "Email" };
                        for (int i = 0; i < headers.Length; i++)
                        {
                            ws.Cells[1, i + 1].Value = headers[i];
                            ws.Cells[1, i + 1].Style.Font.Bold = true; // In đậm
                                                                       // Đổ nền cho Header dễ nhìn
                            ws.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSkyBlue);
                        }

                        // 2. DUYỆT DATAGRIDVIEW ĐỂ ĐỔ DỮ LIỆU VÀO ĐÚNG CỘT
                        int rowExcel = 2;
                        foreach (DataGridViewRow row in dgvStudents.Rows)
                        {
                            if (row.IsNewRow) continue;

                            ws.Cells[rowExcel, 1].Value = row.Cells["MSSV"].Value?.ToString();
                            ws.Cells[rowExcel, 2].Value = row.Cells["Fname"].Value?.ToString();
                            ws.Cells[rowExcel, 3].Value = row.Cells["Lname"].Value?.ToString();

                            // Cột 4: Ngày sinh (Định dạng lại cho đẹp)
                            if (row.Cells["Dob"].Value != null && DateTime.TryParse(row.Cells["Dob"].Value.ToString(), out DateTime dob))
                            {
                                ws.Cells[rowExcel, 4].Value = dob.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                ws.Cells[rowExcel, 4].Value = row.Cells["Dob"].Value?.ToString();
                            }

                            ws.Cells[rowExcel, 5].Value = row.Cells["Gder"].Value?.ToString();
                            ws.Cells[rowExcel, 6].Value = row.Cells["Phone"].Value?.ToString();
                            ws.Cells[rowExcel, 7].Value = row.Cells["Email"].Value?.ToString();

                            rowExcel++;
                        }

                        // 3. AUTOFIT VÀ LƯU FILE
                        ws.Cells[ws.Dimension.Address].AutoFitColumns();
                        package.SaveAs(new FileInfo(sfd.FileName));

                        MessageBox.Show("Xuất danh sách sinh viên ra Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}