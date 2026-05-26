using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    public partial class f_ManageCourse : Form
    {
        // Mã môn học đang được chọn trên tab Sửa
        private string _selectedMaMH = null;

        public f_ManageCourse()
        {
            InitializeComponent();
            InitComboBoxes();
            WireEvents();
            LoadEditGrid();
            LoadDelGrid();
        }

        // ════════════════════════════════════════════════════════════
        //  KHỞI TẠO LOGIC & EVENT HANDLERS
        // ════════════════════════════════════════════════════════════

        private void InitComboBoxes()
        {
            string[] hkItems = { "Tất cả", "1", "2", "3" };
            cboAddHk.Items.AddRange(new object[] { "1", "2", "3" });
            cboAddHk.SelectedIndex = 0;

            cboEditHk.Items.AddRange(new object[] { "1", "2", "3" });
            cboEditHk.SelectedIndex = 0;

            cboDelHk.Items.AddRange(hkItems);
            cboDelHk.SelectedIndex = 0;
        }

        private void WireEvents()
        {
            btnAdd.Click += btnAdd_Click;
            btnAddClear.Click += (s, e) => ClearAddForm();

            btnEditLoad.Click += (s, e) => LoadEditGrid();
            txtEditSearch.TextChanged += (s, e) => LoadEditGrid();
            dgvEdit.SelectionChanged += dgvEdit_SelectionChanged;
            btnEdit.Click += btnEdit_Click;
            btnEditClear.Click += (s, e) => ClearEditForm();

            btnDelLoad.Click += (s, e) => LoadDelGrid();
            txtDelSearch.TextChanged += (s, e) => LoadDelGrid();
            cboDelHk.SelectedIndexChanged += (s, e) => LoadDelGrid();
            dgvDel.SelectionChanged += dgvDel_SelectionChanged;
            btnDel.Click += btnDel_Click;
        }

        // ════════════════════════════════════════════════════════════
        //  TAB 1 – THÊM MÔN HỌC
        // ════════════════════════════════════════════════════════════
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateAddForm()) return;

            Course c = new Course(
                mamh: txtAddMa.Text.Trim().ToUpper(),
                tenmh: txtAddTen.Text.Trim(),
                sotc: (int)nudAddTc.Value,
                tuan: (int)nudAddTuan.Value,
                hocky: int.Parse(cboAddHk.SelectedItem.ToString()),
                decription: txtAddMota.Text.Trim()
            );

            if (c.AddCourse())
            {
                MessageBox.Show("✅ Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAddForm();
                LoadEditGrid();
                LoadDelGrid();
            }
            else
            {
                MessageBox.Show("❌ Thêm thất bại!\nMã môn học có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearAddForm()
        {
            txtAddMa.Clear();
            txtAddTen.Clear();
            nudAddTc.Value = 3;
            nudAddTuan.Value = 15;
            cboAddHk.SelectedIndex = 0;
            txtAddMota.Clear();
            txtAddMa.Focus();
        }

        // ════════════════════════════════════════════════════════════
        //  TAB 2 – SỬA MÔN HỌC
        // ════════════════════════════════════════════════════════════
        private void LoadEditGrid()
        {
            string search = txtEditSearch.Text.Trim();
            DataTable dt = Course.GetCourse(search: search);

            dgvEdit.SelectionChanged -= dgvEdit_SelectionChanged;
            dgvEdit.DataSource = dt;
            StyleGrid(dgvEdit);
            dgvEdit.SelectionChanged += dgvEdit_SelectionChanged;

            ClearEditForm();
        }

        private void dgvEdit_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEdit.CurrentRow == null || dgvEdit.CurrentRow.Index < 0 || dgvEdit.CurrentRow.Cells["MaMH"].Value == null)
                return;

            DataGridViewRow row = dgvEdit.CurrentRow;
            try
            {
                _selectedMaMH = row.Cells["MaMH"].Value?.ToString();
                txtEditMa.Text = _selectedMaMH;
                txtEditTen.Text = row.Cells["TenMH"].Value?.ToString();
                nudEditTc.Value = row.Cells["SoTC"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["SoTC"].Value) : 3;
                nudEditTuan.Value = row.Cells["Tuan"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["Tuan"].Value) : 15;
                cboEditHk.Text = row.Cells["Hky"].Value?.ToString();
                txtEditMota.Text = row.Cells["Mota"].Value?.ToString();
            }
            catch { }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMaMH))
            {
                MessageBox.Show("Vui lòng chọn một môn học từ danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateEditForm()) return;

            Course c = new Course(
                mamh: _selectedMaMH,
                tenmh: txtEditTen.Text.Trim(),
                sotc: (int)nudEditTc.Value,
                tuan: (int)nudEditTuan.Value,
                hocky: int.Parse(cboEditHk.SelectedItem.ToString()),
                decription: txtEditMota.Text.Trim()
            );

            if (c.EditCourse())
            {
                MessageBox.Show("✅ Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEditGrid();
                LoadDelGrid();
            }
            else
            {
                MessageBox.Show("❌ Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearEditForm()
        {
            _selectedMaMH = null;
            txtEditMa.Clear();
            txtEditTen.Clear();
            nudEditTc.Value = 3;
            nudEditTuan.Value = 15;
            if (cboEditHk.Items.Count > 0) cboEditHk.SelectedIndex = 0;
            txtEditMota.Clear();

            dgvEdit.SelectionChanged -= dgvEdit_SelectionChanged;
            dgvEdit.ClearSelection();
            dgvEdit.SelectionChanged += dgvEdit_SelectionChanged;
        }

        // ════════════════════════════════════════════════════════════
        //  TAB 3 – XÓA MÔN HỌC
        // ════════════════════════════════════════════════════════════
        private void LoadDelGrid()
        {
            string search = txtDelSearch.Text.Trim();
            string hkFilter = cboDelHk.SelectedItem?.ToString() ?? "Tất cả";
            DataTable dt = Course.GetCourse(search: search, hockyFilter: hkFilter);

            dgvDel.SelectionChanged -= dgvDel_SelectionChanged;
            dgvDel.DataSource = dt;
            StyleGrid(dgvDel);
            dgvDel.SelectionChanged += dgvDel_SelectionChanged;

            txtDelMa.Clear();
            lblDelSelected.Text = "Chưa chọn môn học nào";
            lblDelSelected.ForeColor = Color.Gray;
        }

        private void dgvDel_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDel.CurrentRow == null || dgvDel.CurrentRow.Index < 0 || dgvDel.CurrentRow.Cells["MaMH"].Value == null) return;

            string ma = dgvDel.CurrentRow.Cells["MaMH"].Value?.ToString();
            string ten = dgvDel.CurrentRow.Cells["TenMH"].Value?.ToString();

            txtDelMa.Text = ma;
            lblDelSelected.Text = $"Đã chọn: [{ma}] {ten}";
            lblDelSelected.ForeColor = Color.FromArgb(0, 80, 160);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string ma = txtDelMa.Text.Trim();
            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Vui lòng chọn một môn học cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ten = dgvDel.CurrentRow?.Cells["TenMH"].Value?.ToString();
            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa môn học:\n[{ma}] {ten}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            if (Course.DelCourse(ma))
            {
                MessageBox.Show("✅ Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDelGrid();
                LoadEditGrid();
            }
            else
            {
                MessageBox.Show("❌ Không thể xóa!\nMôn học này đã có sinh viên đăng ký.", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  VALIDATION & HELPERS
        // ════════════════════════════════════════════════════════════
        private bool ValidateAddForm()
        {
            if (string.IsNullOrWhiteSpace(txtAddMa.Text)) { ShowError("Mã môn học trống.", txtAddMa); return false; }
            if (txtAddMa.Text.Trim().Length > 10) { ShowError("Mã môn học tối đa 10 ký tự.", txtAddMa); return false; }
            if (string.IsNullOrWhiteSpace(txtAddTen.Text)) { ShowError("Tên môn học trống.", txtAddTen); return false; }
            if (nudAddTc.Value <= 0) { ShowError("Tín chỉ phải > 0.", nudAddTc); return false; }
            return true;
        }

        private bool ValidateEditForm()
        {
            if (string.IsNullOrWhiteSpace(txtEditTen.Text)) { ShowError("Tên môn học trống.", txtEditTen); return false; }
            if (nudEditTc.Value <= 0) { ShowError("Tín chỉ phải > 0.", nudEditTc); return false; }
            return true;
        }

        private void ShowError(string message, Control focusControl)
        {
            MessageBox.Show(message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focusControl.Focus();
        }

        private void StyleGrid(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 30;
            dgv.RowTemplate.Height = 26;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 216, 230);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            if (dgv.Columns.Contains("MaMH")) dgv.Columns["MaMH"].HeaderText = "Mã MH";
            if (dgv.Columns.Contains("TenMH")) dgv.Columns["TenMH"].HeaderText = "Tên môn học";
            if (dgv.Columns.Contains("SoTC")) dgv.Columns["SoTC"].HeaderText = "Tín chỉ";
            if (dgv.Columns.Contains("Tuan")) dgv.Columns["Tuan"].HeaderText = "Số tuần";
            if (dgv.Columns.Contains("Hky")) dgv.Columns["Hky"].HeaderText = "Học kỳ";
            if (dgv.Columns.Contains("Mota")) dgv.Columns["Mota"].HeaderText = "Mô tả";
        }
    }
}