using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_ListScore : Form
    {
        private int _studentMSSV;
        private string _studentName;

        private PrintDocument printDoc = new PrintDocument();
        private PrintPreviewDialog previewDialog = new PrintPreviewDialog();

        public f_ListScore(int studentMSSV, string studentName)
        {
            InitializeComponent();
            _studentMSSV = studentMSSV;
            _studentName = studentName;
            printDoc.PrintPage += new PrintPageEventHandler(PrintDoc_PrintPage);
        }

        private void f_ListScore_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = $"Đang đăng nhập: {Globals.GlobalUsername}  |  Vai trò: {Globals.GlobalRole}";

            cboSort.Items.Clear();
            cboSort.Items.Add("Mặc định");
            cboSort.Items.Add("Theo Mã môn (A-Z)");
            cboSort.Items.Add("Theo Điểm (Cao - Thấp)");
            cboSort.Items.Add("Theo Điểm (Thấp - Cao)");
            cboSort.SelectedIndex = 0;

            // Đảm bảo footer luôn hiển thị cho tất cả các Role
            pnl_footer.Visible = true;

            bool isAdminOrHR = Globals.GlobalRole.Trim() == "HR" || Globals.GlobalRole.Trim() == "Admin";

            if (isAdminOrHR)
            {
                pnl_studentSelector.Visible = true;
                lblStudentInfo.Visible = false;
                lblNotification.Text = "💡 Nhấn đúp vào dòng bất kỳ để chỉnh sửa điểm.";
                lblNotification.ForeColor = Color.White;

                LoadStudentComboBox();
                dgvScores.CellDoubleClick += dgvScores_CellDoubleClick;
            }
            else
            {
                pnl_studentSelector.Visible = false;
                lblStudentInfo.Visible = true;
                lblStudentInfo.Text = $"📋 Bảng điểm của: {_studentName}  (MSSV: {_studentMSSV})";
                lblNotification.Text = "🔒 Bạn chỉ có quyền xem điểm, không thể chỉnh sửa.";
                lblNotification.ForeColor = Color.LightCyan;

                RefreshData();
            }

        }

        // ─── Load danh sách sinh viên cho HR/Admin ───────────────────────────────

        private void LoadStudentComboBox()
        {
            DataTable dt = Student.GetStudents("", "Tất cả", "Theo MSSV");

            if (!dt.Columns.Contains("FullName"))
            {
                dt.Columns.Add("FullName", typeof(string));
                foreach (DataRow row in dt.Rows)
                    row["FullName"] = $"({row["MSSV"]}) {row["Fname"]} {row["Lname"]}".Trim();
            }

            DataRow defaultRow = dt.NewRow();
            defaultRow["MSSV"] = -1;
            defaultRow["FullName"] = "-- Chọn sinh viên --";
            dt.Rows.InsertAt(defaultRow, 0);

            cboSelectStudent.DisplayMember = "FullName";
            cboSelectStudent.ValueMember = "MSSV";
            cboSelectStudent.DataSource = dt;

            // Sửa lỗi tự động reset về -1
            if (_studentMSSV > 0)
            {
                cboSelectStudent.SelectedValue = _studentMSSV;
            }
            else
            {
                cboSelectStudent.SelectedIndex = 0;
            }
        }

        private void cboSelectStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSelectStudent.SelectedValue == null) return;
            if (!int.TryParse(cboSelectStudent.SelectedValue.ToString(), out int selectedMSSV)) return;

            if (selectedMSSV == -1)
            {
                dgvScores.DataSource = null;
                lblTotal.Text = "Tổng số môn: 0";
                UpdateGPALabel(0, 0);
                return;
            }

            _studentMSSV = selectedMSSV;
            DataRowView? drv = cboSelectStudent.SelectedItem as DataRowView;
            if (drv != null)
                _studentName = $"{drv["Fname"]} {drv["Lname"]}".Trim();

            RefreshData();
        }

        // ─── Load & hiển thị dữ liệu điểm ───────────────────────────────────────

        private void RefreshData()
        {
            if (_studentMSSV <= 0)
            {
                dgvScores.DataSource = null;
                lblTotal.Text = "Tổng số môn: 0";
                UpdateGPALabel(0, 0);
                return;
            }

            string keyword = (txtSearch.Text == "Tìm kiếm..." || string.IsNullOrWhiteSpace(txtSearch.Text))
                             ? "" : txtSearch.Text;
            string sortBy = cboSort.SelectedItem?.ToString() ?? "Mặc định";

            DataTable dt = Score.GetScores(_studentMSSV, keyword, sortBy);
            dgvScores.DataSource = dt;

            // Ẩn / đổi tên cột
            if (dgvScores.Columns.Count > 0)
            {
                HideColumn("student_id");
                RenameColumn("course_id", "Mã môn học");
                RenameColumn("course_name", "Tên môn học");
                RenameColumn("DiemQT", "Điểm QT (40%)");
                RenameColumn("DiemCK", "Điểm CK (60%)");
                RenameColumn("DiemTK", "Điểm TK");
                RenameColumn("XepLoai", "Xếp loại");
                RenameColumn("description", "Ghi chú");

                // Tô màu cột Xếp loại
                ColorXepLoaiColumn();
            }

            lblTotal.Text = $"Tổng số môn: {dt.Rows.Count}";

            // Cập nhật GPA
            var (gpa, totalTC) = Score.GetGPA(_studentMSSV);
            UpdateGPALabel(gpa, totalTC);
        }

        private void ColorXepLoaiColumn()
        {
            if (dgvScores.Columns["XepLoai"] == null) return;
            foreach (DataGridViewRow row in dgvScores.Rows)
            {
                var cell = row.Cells["XepLoai"];
                if (cell.Value == null) continue;
                cell.Style.ForeColor = cell.Value.ToString() switch
                {
                    "Xuất sắc" => Color.DarkBlue,
                    "Giỏi" => Color.DarkGreen,
                    "Khá" => Color.DarkOrange,
                    "Trung bình" => Color.Gray,
                    "Yếu" => Color.Red,
                    _ => Color.Black
                };
                cell.Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            }
        }

        private void UpdateGPALabel(double gpa, int totalTC)
        {
            if (totalTC > 0)
            {
                lblGPA.Text = $"GPA: {gpa:F2} / 10.0   |   Tổng TC tích lũy: {totalTC}";
                lblGPA.ForeColor = gpa >= 8.0 ? Color.DarkGreen
                                 : gpa >= 6.5 ? Color.DarkOrange
                                 : gpa >= 5.0 ? Color.Gray
                                 : Color.Red;

                string hocLuc;
                Color hocLucColor;
                if (gpa >= 9.0) { hocLuc = "Xuất sắc"; hocLucColor = Color.DarkBlue; }
                else if (gpa >= 8.0) { hocLuc = "Giỏi"; hocLucColor = Color.DarkGreen; }
                else if (gpa >= 6.5) { hocLuc = "Khá"; hocLucColor = Color.DarkOrange; }
                else if (gpa >= 5.0) { hocLuc = "Trung bình"; hocLucColor = Color.Gray; }
                else { hocLuc = "Yếu"; hocLucColor = Color.Red; }

                lblHocLuc.Text = $"🎓 Học lực: {hocLuc}";
                lblHocLuc.ForeColor = hocLucColor;
            }
            else
            {
                lblGPA.Text = "GPA: --   |   Tổng TC tích lũy: --";
                lblGPA.ForeColor = Color.Gray;
                lblHocLuc.Text = "🎓 Học lực: --";
                lblHocLuc.ForeColor = Color.Gray;
            }
        }

        private void HideColumn(string name)
        {
            if (dgvScores.Columns[name] != null)
                dgvScores.Columns[name].Visible = false;
        }

        private void RenameColumn(string name, string header)
        {
            if (dgvScores.Columns[name] != null)
                dgvScores.Columns[name].HeaderText = header;
        }

        // ─── Double click → mở form sửa điểm (chỉ HR/Admin) ────────────────────

        private void dgvScores_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvScores.Rows[e.RowIndex];
            f_EditScore editForm = new f_EditScore(row, _studentMSSV);
            editForm.FormClosed += (s, args) => RefreshData();
            editForm.ShowDialog();
        }

        // ─── Search / Sort / Refresh ─────────────────────────────────────────────

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm...")
            { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            { txtSearch.Text = "Tìm kiếm..."; txtSearch.ForeColor = Color.Gray; }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => RefreshData();
        private void cboSort_SelectedIndexChanged(object sender, EventArgs e) => RefreshData();

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "Tìm kiếm...";
            txtSearch.ForeColor = Color.Gray;
            if (cboSort.Items.Count > 0) cboSort.SelectedIndex = 0;

            bool isAdminOrHR = Globals.GlobalRole.Trim() == "HR" || Globals.GlobalRole.Trim() == "Admin";
            pnl_footer.Visible = true; // Giữ footer luôn hiện khi refresh

            if (isAdminOrHR)
            {
                if (cboSelectStudent.Items.Count > 0) cboSelectStudent.SelectedIndex = 0;
                dgvScores.DataSource = null;
                lblTotal.Text = "Tổng số môn: 0";
                UpdateGPALabel(0, 0);
            }
            else
            {
                RefreshData();
            }

            MessageBox.Show("Đã làm mới dữ liệu!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblStudentInfo_Click(object sender, EventArgs e) { }

        private void pnl_studentSelector_Paint(object sender, PaintEventArgs e) { }

        private void pnl_footer_Paint(object sender, PaintEventArgs e) { }

        // ─── In bảng điểm ────────────────────────────────────────────────────────

        private void SendPrintRequestToAdmin()
        {
            MY_DB my_db = new MY_DB();
            try
            {
                my_db.openConnection();
                string sql = @"UPDATE dbo.Student 
                               SET    PrintRequest     = 'Pending', 
                                      PrintRequestDate = GETDATE() 
                               WHERE  MSSV = @mssv";
                using var cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, my_db.conn);
                cmd.Parameters.AddWithValue("@mssv", _studentMSSV);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi yêu cầu in: " + ex.Message, "Lỗi SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { my_db.closeConnection(); }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (e.Graphics == null) return;

            Brush brush = Brushes.Black;
            Pen pen = new Pen(Color.Black, 1);
            Font fontTitle = new Font("Times New Roman", 18, FontStyle.Bold);
            Font fontHeader = new Font("Times New Roman", 12, FontStyle.Bold);
            Font fontContent = new Font("Times New Roman", 12, FontStyle.Regular);
            Font fontItalic = new Font("Times New Roman", 12, FontStyle.Italic);

            int startX = 50, startY = 50, offset = 0;

            e.Graphics.DrawString("TRƯỜNG ĐẠI HỌC SƯ PHẠM KĨ THUẬT", fontHeader, brush, startX, startY + offset);
            offset += 40;
            e.Graphics.DrawString("BẢNG ĐIỂM CHI TIẾT SINH VIÊN", fontTitle, brush, startX + 180, startY + offset);
            offset += 50;

            e.Graphics.DrawString($"Họ và tên: {_studentName}", fontContent, brush, startX, startY + offset);
            e.Graphics.DrawString($"MSSV: {_studentMSSV}", fontContent, brush, startX + 450, startY + offset);
            offset += 40;

            e.Graphics.DrawString("Mã MH", fontHeader, brush, startX, startY + offset);
            e.Graphics.DrawString("Tên môn học", fontHeader, brush, startX + 100, startY + offset);
            e.Graphics.DrawString("Điểm TK", fontHeader, brush, startX + 480, startY + offset);
            e.Graphics.DrawString("Xếp loại", fontHeader, brush, startX + 580, startY + offset);
            offset += 25;
            e.Graphics.DrawLine(pen, startX, startY + offset, startX + 700, startY + offset);
            offset += 15;

            foreach (DataGridViewRow row in dgvScores.Rows)
            {
                if (row.IsNewRow) continue;
                string maMH = row.Cells["course_id"]?.Value?.ToString() ?? "";
                string tenMH = row.Cells["course_name"]?.Value?.ToString() ?? "";
                string diemTK = row.Cells["DiemTK"]?.Value?.ToString() ?? "";
                string xepLoi = row.Cells["XepLoai"]?.Value?.ToString() ?? "";
                if (tenMH.Length > 40) tenMH = tenMH[..37] + "...";
                e.Graphics.DrawString(maMH, fontContent, brush, startX, startY + offset);
                e.Graphics.DrawString(tenMH, fontContent, brush, startX + 100, startY + offset);
                e.Graphics.DrawString(diemTK, fontContent, brush, startX + 480, startY + offset);
                e.Graphics.DrawString(xepLoi, fontContent, brush, startX + 580, startY + offset);
                offset += 30;
            }

            offset += 10;
            e.Graphics.DrawLine(pen, startX, startY + offset, startX + 700, startY + offset);
            offset += 40;
            string currentDate = $"TP.HCM, ngày {DateTime.Now:dd} tháng {DateTime.Now:MM} năm {DateTime.Now:yyyy}";
            e.Graphics.DrawString(currentDate, fontItalic, brush, startX + 450, startY + offset);
            offset += 25;
            e.Graphics.DrawString("Phòng Đào Tạo", fontHeader, brush, startX + 490, startY + offset);
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (_studentMSSV <= 0 || dgvScores.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu điểm để in!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            previewDialog.Document = printDoc;
            previewDialog.Width = 850;
            previewDialog.Height = 700;
            previewDialog.ShowDialog();

            if (Globals.GlobalRole.Trim() == "Student")
            {
                SendPrintRequestToAdmin();
                MessageBox.Show("Yêu cầu in đã được gửi đến Admin để chờ xét duyệt!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvScores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}