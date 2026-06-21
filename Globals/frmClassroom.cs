using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

//Bỏ lỗi CA1416
[System.Runtime.Versioning.SupportedOSPlatform("windows")]

public partial class frmClassroom : Form
{
    // Lưu MaLop của dòng đang được chọn
    private string _selectedMaLop = "";

    public frmClassroom()
    {
        InitializeComponent();
        LoadClassrooms();
        SetButtonState(false); // Sửa/Xóa disabled khi chưa chọn dòng
    }

    // -------------------------------------------------------
    // Load / Tìm kiếm danh sách lớp
    // -------------------------------------------------------
    private void LoadClassrooms(string search = "")
    {
        DataTable dt = Classroom.GetClassrooms(search);
        dgvClassroom.DataSource = dt;

        if (dgvClassroom.Columns.Count > 0)
        {
            dgvClassroom.Columns["MaLop"].HeaderText = "Mã Lớp";
            dgvClassroom.Columns["TenLop"].HeaderText = "Tên Lớp";
            dgvClassroom.Columns["SiSo"].HeaderText = "Sĩ Số";
            dgvClassroom.Columns["GVCN"].HeaderText = "GVCN";
        }

        lblCount.Text = $"Tổng số lớp: {dt.Rows.Count}";
    }

    // -------------------------------------------------------
    // Nút THÊM
    // -------------------------------------------------------
    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        Classroom c = new Classroom(
            txtMaLop.Text.Trim(),
            txtTenLop.Text.Trim(),
            (int)nudSiSo.Value,
            txtGVCN.Text.Trim()
        );

        if (c.AddClassroom())
        {
            MessageBox.Show("Thêm lớp học thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInputs();
            LoadClassrooms(txtSearch.Text.Trim());
        }
        else
        {
            MessageBox.Show("Thêm thất bại! Mã lớp có thể đã tồn tại.", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // -------------------------------------------------------
    // Nút SỬA — cập nhật dòng đang được chọn
    // -------------------------------------------------------
    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_selectedMaLop)) return;
        if (!ValidateInput()) return;

        Classroom c = new Classroom(
            _selectedMaLop,           // MaLop giữ nguyên (PK)
            txtTenLop.Text.Trim(),
            (int)nudSiSo.Value,
            txtGVCN.Text.Trim()
        );

        if (c.EditClassroom())
        {
            MessageBox.Show("Cập nhật lớp học thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInputs();
            LoadClassrooms(txtSearch.Text.Trim());
        }
        else
        {
            MessageBox.Show("Cập nhật thất bại! Vui lòng thử lại.", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // -------------------------------------------------------
    // Nút XÓA — xác nhận rồi mới xóa dòng đang được chọn
    // -------------------------------------------------------
    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_selectedMaLop)) return;

        string tenLop = txtTenLop.Text.Trim();
        DialogResult confirm = MessageBox.Show(
            $"Bạn có chắc muốn xóa lớp học:\n\n  Mã lớp : {_selectedMaLop}\n  Tên lớp: {tenLop}\n\nHành động này không thể hoàn tác!",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2   // Mặc định focus vào "Không"
        );

        if (confirm != DialogResult.Yes) return;

        if (Classroom.DelClassroom(_selectedMaLop))
        {
            MessageBox.Show("Đã xóa lớp học thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInputs();
            LoadClassrooms(txtSearch.Text.Trim());
        }
        else
        {
            MessageBox.Show("Xóa thất bại! Vui lòng thử lại.", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // -------------------------------------------------------
    // Nút TÌM KIẾM
    // -------------------------------------------------------
    private void btnSearch_Click(object sender, EventArgs e)
    {
        LoadClassrooms(txtSearch.Text.Trim());
    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        LoadClassrooms(txtSearch.Text.Trim());
    }

    // -------------------------------------------------------
    // Nút XÓA INPUT (Clear form)
    // -------------------------------------------------------
    private void btnClear_Click(object sender, EventArgs e)
    {
        ClearInputs();
    }

    // -------------------------------------------------------
    // Click vào hàng trong DataGridView → điền lên form
    // -------------------------------------------------------
    private void dgvClassroom_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        DataGridViewRow row = dgvClassroom.Rows[e.RowIndex];
        _selectedMaLop = row.Cells["MaLop"].Value?.ToString();
        txtMaLop.Text = _selectedMaLop;
        txtTenLop.Text = row.Cells["TenLop"].Value?.ToString();
        nudSiSo.Value = Convert.ToInt32(row.Cells["SiSo"].Value ?? 0);
        txtGVCN.Text = row.Cells["GVCN"].Value?.ToString();
        txtMaLop.ReadOnly = true;   // Khóa PK

        SetButtonState(true);        // Mở khóa nút Sửa / Xóa
    }

    // -------------------------------------------------------
    // Helpers
    // -------------------------------------------------------
    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtMaLop.Text))
        {
            MessageBox.Show("Vui lòng nhập Mã Lớp.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtMaLop.Focus();
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtTenLop.Text))
        {
            MessageBox.Show("Vui lòng nhập Tên Lớp.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenLop.Focus();
            return false;
        }
        return true;
    }

    private void ClearInputs()
    {
        _selectedMaLop = "";
        txtMaLop.Text = "";
        txtTenLop.Text = "";
        nudSiSo.Value = 0;
        txtGVCN.Text = "";
        txtMaLop.ReadOnly = false;
        SetButtonState(false);
        txtMaLop.Focus();
    }

    // Bật/tắt nút Sửa và Xóa tùy có chọn dòng hay không
    private void SetButtonState(bool hasSelection)
    {
        btnEdit.Enabled = hasSelection;
        btnDelete.Enabled = hasSelection;
        btnEdit.BackColor = hasSelection
            ? System.Drawing.Color.FromArgb(30, 100, 180)
            : System.Drawing.Color.FromArgb(160, 160, 160);
        btnDelete.BackColor = hasSelection
            ? System.Drawing.Color.FromArgb(192, 57, 43)
            : System.Drawing.Color.FromArgb(160, 160, 160);
    }

    private void dgvClassroom_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
}