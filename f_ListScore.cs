using System;
using System.Data;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    //Bỏ lỗi CA1416
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_ListScore : Form
    {
        private int _studentMSSV;
        private string _studentName;

        public f_ListScore(int studentMSSV, string studentName)
        {
            InitializeComponent();
            _studentMSSV = studentMSSV;
            _studentName = studentName;
        }

        private void f_ListScore_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = $"Đang đăng nhập: {Globals.GlobalUsername} ({Globals.GlobalRole})";

            // Khởi tạo ComboBox Sắp xếp
            cboSort.Items.Clear();
            cboSort.Items.Add("Mặc định");
            cboSort.Items.Add("Theo Mã môn (A-Z)");
            cboSort.Items.Add("Theo Điểm (Cao - Thấp)");
            cboSort.Items.Add("Theo Điểm (Thấp - Cao)");
            cboSort.SelectedIndex = 0;

            if (Globals.GlobalRole == "HR" || Globals.GlobalRole == "Admin")
            {
                // HR / Admin: hiện combobox chọn sinh viên, ẩn label tên cố định
                lblStudentInfo.Visible = false;
                lblSelectStudent.Visible = true;
                cboSelectStudent.Visible = true;

                // Chưa chọn sinh viên → bảng trống, chờ chọn
                _studentMSSV = -1;

                LoadStudentComboBox();

                lb_Notification.Text = "Nhấn đúp để thay đổi điểm môn học";
                lb_Notification.ForeColor = System.Drawing.Color.DarkGreen;
                dgvScores.CellDoubleClick += dgvScores_CellDoubleClick;
            }
            else
            {
                // Student: ẩn combobox, hiện tên sinh viên cố định và load điểm luôn
                lblStudentInfo.Visible = true;
                lblStudentInfo.Text = $"Bảng điểm của: {_studentName} (MSSV: {_studentMSSV})";
                lblSelectStudent.Visible = false;
                cboSelectStudent.Visible = false;

                lb_Notification.Text = "Bạn chỉ có quyền xem điểm (không thể chỉnh sửa)";
                lb_Notification.ForeColor = System.Drawing.Color.Gray;

                RefreshData();
            }
        }

        // Load danh sách sinh viên vào ComboBox cho HR/Admin
        private void LoadStudentComboBox()
        {
            DataTable dt = Student.GetStudents("", "Tất cả", "Theo MSSV");

            // Tạo cột FullName để hiển thị
            if (!dt.Columns.Contains("FullName"))
            {
                dt.Columns.Add("FullName", typeof(string));
                foreach (DataRow row in dt.Rows)
                    row["FullName"] = $"({row["MSSV"]}) {row["Fname"]} {row["Lname"]}".Trim();
            }

            // Thêm item mặc định ở đầu
            DataRow defaultRow = dt.NewRow();
            defaultRow["MSSV"] = -1;
            defaultRow["FullName"] = "-- Chọn sinh viên --";
            dt.Rows.InsertAt(defaultRow, 0);

            cboSelectStudent.DisplayMember = "FullName";
            cboSelectStudent.ValueMember = "MSSV";
            cboSelectStudent.DataSource = dt;
            cboSelectStudent.SelectedIndex = 0;
        }

        private void cboSelectStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSelectStudent.SelectedValue == null) return;
            if (!int.TryParse(cboSelectStudent.SelectedValue.ToString(), out int selectedMSSV)) return;
            if (selectedMSSV == -1)
            {
                // Reset bảng khi chọn item mặc định
                dgvScores.DataSource = null;
                lblTotal.Text = "Tổng số môn: 0";
                return;
            }

            _studentMSSV = selectedMSSV;
            _studentName = cboSelectStudent.Text;
            RefreshData();
        }

        private void RefreshData()
        {
            if (_studentMSSV <= 0) return; // Chưa chọn sinh viên

            string keyword = (txtSearch.Text == "Tìm kiếm..." || string.IsNullOrEmpty(txtSearch.Text)) ? "" : txtSearch.Text;
            string sortBy = cboSort.SelectedItem?.ToString() ?? "Mặc định";

            DataTable dt = Score.GetScores(_studentMSSV, keyword, sortBy);
            dgvScores.DataSource = dt;

            if (dgvScores.Columns.Count > 0)
            {
                if (dgvScores.Columns["student_id"] != null)
                    dgvScores.Columns["student_id"].Visible = false;
                if (dgvScores.Columns["course_id"] != null)
                    dgvScores.Columns["course_id"].HeaderText = "Mã môn học";
                if (dgvScores.Columns["course_name"] != null)
                    dgvScores.Columns["course_name"].HeaderText = "Tên môn học";
                if (dgvScores.Columns["score"] != null)
                    dgvScores.Columns["score"].HeaderText = "Điểm số";
                if (dgvScores.Columns["description"] != null)
                    dgvScores.Columns["description"].HeaderText = "Ghi chú";
            }

            lblTotal.Text = $"Tổng số môn: {dt.Rows.Count}";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "Tìm kiếm...";
            if (cboSort.Items.Count > 0) cboSort.SelectedIndex = 0;

            // HR/Admin: reset về chưa chọn sinh viên
            if (Globals.GlobalRole == "HR" || Globals.GlobalRole == "Admin")
            {
                cboSelectStudent.SelectedIndex = 0;
                dgvScores.DataSource = null;
                lblTotal.Text = "Tổng số môn: 0";
            }
            else
            {
                RefreshData();
            }

            MessageBox.Show("Bảng điểm đã được cập nhật mới nhất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvScores_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (Globals.GlobalRole != "HR" && Globals.GlobalRole != "Admin")
            {
                MessageBox.Show("Bạn không có quyền chỉnh sửa điểm!", "Từ chối truy cập",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (e.RowIndex < 0) return; // Bỏ qua click vào header

            DataGridViewRow row = dgvScores.Rows[e.RowIndex];
            // Truyền thêm _studentMSSV để đảm bảo luôn có MSSV đúng
            f_EditScore editForm = new f_EditScore(row, _studentMSSV);
            editForm.FormClosed += (s, args) => RefreshData();
            editForm.ShowDialog();
        }

        private void dgvScores_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblTotal_Click(object sender, EventArgs e) { }
        private void lb_Notification_Click(object sender, EventArgs e) { }
        private void lblSort_Click(object sender, EventArgs e) { }
        private void lblStudentInfo_Click(object sender, EventArgs e) { }
    }
}