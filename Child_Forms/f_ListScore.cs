using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using Font = System.Drawing.Font;
using Image = System.Drawing.Image;

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

        }

        private void btn_ExportPDF_Click(object sender, EventArgs e)
        {
            if (dgvScores.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = $"BangDiem_{_studentMSSV}.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Khởi tạo tài liệu A4
                    Document pdfDoc = new Document(PageSize.A4, 30, 30, 40, 40);
                    PdfWriter.GetInstance(pdfDoc, new FileStream(sfd.FileName, FileMode.Create));
                    pdfDoc.Open();

                    // 1. CHÈN LOGO TRƯỜNG (Thay "logo_HCMUTE_Login.jpg" bằng tên file thực tế của bạn)
                    if (File.Exists("logo_HCMUTE_Login.jpg"))
                    {
                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("logo.png");
                        logo.ScaleToFit(80f, 80f);
                        logo.Alignment = Element.ALIGN_CENTER;
                        pdfDoc.Add(logo);
                    }

                    // Cấu hình Font chữ (Sử dụng font mặc định hỗ trợ tiếng Việt cơ bản hoặc load font Arial)
                    string fontPath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\\arial.ttf";
                    BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font fontItalic = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.ITALIC);

                    // 2. CHÈN HEADER (TÊN TRƯỜNG, KHOA VÀ TIÊU ĐỀ)
                    Paragraph header = new Paragraph("TRƯỜNG ĐẠI HỌC SƯ PHẠM KĨ THUẬT\n\nBẢNG ĐIỂM TỔNG HỢP SINH VIÊN\n\n", fontTitle)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    pdfDoc.Add(header);

                    // 3. THÔNG TIN SINH VIÊN
                    pdfDoc.Add(new Paragraph($"Họ và tên: {_studentName}", fontNormal));
                    pdfDoc.Add(new Paragraph($"MSSV: {_studentMSSV}\n\n", fontNormal));

                    // 4. TẠO BẢNG (TABLE) CHỨA ĐIỂM
                    PdfPTable pdfTable = new PdfPTable(dgvScores.Columns.Count);
                    pdfTable.WidthPercentage = 100;

                    // Thêm Header cho bảng
                    foreach (DataGridViewColumn column in dgvScores.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, fontNormal));
                        cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240); // Màu nền xám nhạt
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfTable.AddCell(cell);
                    }

                    // Đổ dữ liệu từng dòng vào bảng
                    foreach (DataGridViewRow row in dgvScores.Rows)
                    {
                        if (row.IsNewRow) continue;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            string cellValue = cell.Value?.ToString() ?? "";
                            PdfPCell pdfCell = new PdfPCell(new Phrase(cellValue, fontNormal));
                            pdfTable.AddCell(pdfCell);
                        }
                    }
                    pdfDoc.Add(pdfTable);

                    // 5. CHÈN FOOTER (NGÀY XUẤT BÁO CÁO)
                    string currentDate = $"\n\nTP.HCM, ngày {DateTime.Now:dd} tháng {DateTime.Now:MM} năm {DateTime.Now:yyyy}";
                    Paragraph footer = new Paragraph(currentDate, fontItalic)
                    {
                        Alignment = Element.ALIGN_RIGHT
                    };
                    pdfDoc.Add(footer);

                    // Đóng file
                    pdfDoc.Close();

                    MessageBox.Show("Đã xuất file PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblHocLuc_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void inBảngĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void xuấtRaPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvScores.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = $"BangDiem_{_studentMSSV}.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Khởi tạo tài liệu A4
                    Document pdfDoc = new Document(PageSize.A4, 30, 30, 40, 40);
                    PdfWriter.GetInstance(pdfDoc, new FileStream(sfd.FileName, FileMode.Create));
                    pdfDoc.Open();

                    // 1. CHÈN LOGO TRƯỜNG (Thay "logo_HCMUTE_Login.jpg" bằng tên file thực tế của bạn)
                    if (File.Exists("logo_HCMUTE_Login.jpg"))
                    {
                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("logo.png");
                        logo.ScaleToFit(80f, 80f);
                        logo.Alignment = Element.ALIGN_CENTER;
                        pdfDoc.Add(logo);
                    }

                    // Cấu hình Font chữ (Sử dụng font mặc định hỗ trợ tiếng Việt cơ bản hoặc load font Arial)
                    string fontPath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\\arial.ttf";
                    BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font fontItalic = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.ITALIC);

                    // 2. CHÈN HEADER (TÊN TRƯỜNG, KHOA VÀ TIÊU ĐỀ)
                    Paragraph header = new Paragraph("TRƯỜNG ĐẠI HỌC SƯ PHẠM KĨ THUẬT\n\nBẢNG ĐIỂM TỔNG HỢP SINH VIÊN\n\n", fontTitle)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    pdfDoc.Add(header);

                    // 3. THÔNG TIN SINH VIÊN
                    pdfDoc.Add(new Paragraph($"Họ và tên: {_studentName}", fontNormal));
                    pdfDoc.Add(new Paragraph($"MSSV: {_studentMSSV}\n\n", fontNormal));

                    // 4. TẠO BẢNG (TABLE) CHỨA ĐIỂM
                    PdfPTable pdfTable = new PdfPTable(dgvScores.Columns.Count);
                    pdfTable.WidthPercentage = 100;

                    // Thêm Header cho bảng
                    foreach (DataGridViewColumn column in dgvScores.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, fontNormal));
                        cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240); // Màu nền xám nhạt
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfTable.AddCell(cell);
                    }

                    // Đổ dữ liệu từng dòng vào bảng
                    foreach (DataGridViewRow row in dgvScores.Rows)
                    {
                        if (row.IsNewRow) continue;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            string cellValue = cell.Value?.ToString() ?? "";
                            PdfPCell pdfCell = new PdfPCell(new Phrase(cellValue, fontNormal));
                            pdfTable.AddCell(pdfCell);
                        }
                    }
                    pdfDoc.Add(pdfTable);

                    // 5. CHÈN FOOTER (NGÀY XUẤT BÁO CÁO)
                    string currentDate = $"\n\nTP.HCM, ngày {DateTime.Now:dd} tháng {DateTime.Now:MM} năm {DateTime.Now:yyyy}";
                    Paragraph footer = new Paragraph(currentDate, fontItalic)
                    {
                        Alignment = Element.ALIGN_RIGHT
                    };
                    pdfDoc.Add(footer);

                    // Đóng file
                    pdfDoc.Close();

                    MessageBox.Show("Đã xuất file PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btn_Export, new Point(0, btn_Export.Height));
        }

        private void xuấtRaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem bảng có dữ liệu không
            if (dgvScores.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở hộp thoại chọn nơi lưu file
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel (*.xlsx)|*.xlsx",
                FileName = $"ThongKeDiem_{_studentMSSV}.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // [CẬP NHẬT MỚI CHO EPPLUS 8] - Khai báo bản quyền phi thương mại
                    ExcelPackage.License.SetNonCommercialPersonal("SinhVienHCMUTE");

                    using (ExcelPackage excel = new ExcelPackage())
                    {
                        // Tạo một sheet mới
                        var sheet = excel.Workbook.Worksheets.Add("Thống Kê Điểm");

                        // ==========================================
                        // PHẦN 1: ĐỔ DỮ LIỆU TỪ BẢNG VÀO EXCEL
                        // ==========================================

                        // 1.1 Tạo dòng Tiêu đề cột
                        for (int j = 0; j < dgvScores.Columns.Count; j++)
                        {
                            sheet.Cells[1, j + 1].Value = dgvScores.Columns[j].HeaderText;
                            sheet.Cells[1, j + 1].Style.Font.Bold = true; // In đậm
                            sheet.Cells[1, j + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            sheet.Cells[1, j + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue); // Đổ nền xanh
                        }

                        // 1.2 Đổ dữ liệu từng dòng
                        int rowExcel = 2; // Dữ liệu bắt đầu từ dòng 2
                        foreach (DataGridViewRow row in dgvScores.Rows)
                        {
                            if (row.IsNewRow) continue;

                            for (int j = 0; j < dgvScores.Columns.Count; j++)
                            {
                                string cellValue = row.Cells[j].Value?.ToString() ?? "";

                                // Để vẽ được biểu đồ, cột Điểm TK phải được ép kiểu về dạng số (double)
                                if (dgvScores.Columns[j].Name == "DiemTK")
                                {
                                    if (double.TryParse(cellValue, out double diem))
                                        sheet.Cells[rowExcel, j + 1].Value = diem;
                                    else
                                        sheet.Cells[rowExcel, j + 1].Value = cellValue;
                                }
                                else
                                {
                                    sheet.Cells[rowExcel, j + 1].Value = cellValue;
                                }
                            }
                            rowExcel++;
                        }

                        // Tự động dãn độ rộng các cột cho đẹp
                        sheet.Cells[sheet.Dimension.Address].AutoFitColumns();


                        // ==========================================
                        // PHẦN 2: TỰ ĐỘNG VẼ BIỂU ĐỒ CỘT (CHART)
                        // ==========================================

                        int lastDataRow = rowExcel - 1;

                        // Tìm vị trí của cột "Tên môn học" (trục X) và "Điểm TK" (trục Y)
                        int tenMhColIndex = dgvScores.Columns["course_name"].Index + 1;
                        int diemTkColIndex = dgvScores.Columns["DiemTK"].Index + 1;

                        // Khởi tạo một biểu đồ cột (Column Clustered)
                        var chart = sheet.Drawings.AddChart("ChartDiem", eChartType.ColumnClustered);
                        chart.Title.Text = $"Biểu đồ Thống kê Điểm - {_studentName}";

                        // Đặt biểu đồ nằm ngay bên phải bảng dữ liệu
                        chart.SetPosition(1, 0, dgvScores.Columns.Count + 2, 0);
                        chart.SetSize(600, 400); // Kích thước: Rộng 600px, Cao 400px

                        // Cấp dữ liệu cho biểu đồ: Series.Add(Vùng_Dữ_Liệu_Điểm, Vùng_Dữ_Liệu_Tên_Môn)
                        var serie = chart.Series.Add(
                            ExcelRange.GetAddress(2, diemTkColIndex, lastDataRow, diemTkColIndex),
                            ExcelRange.GetAddress(2, tenMhColIndex, lastDataRow, tenMhColIndex)
                        );
                        serie.Header = "Điểm Tổng Kết";

                        // ==========================================
                        // LƯU FILE
                        // ==========================================
                        FileInfo excelFile = new FileInfo(sfd.FileName);
                        excel.SaveAs(excelFile);

                        MessageBox.Show("Đã xuất file Excel và vẽ biểu đồ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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