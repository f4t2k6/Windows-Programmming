using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace YourApp
{
    //Bỏ lỗi CA1416
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_Contact : Form
    {
        // =============================================
        // TRẠNG THÁI FORM
        // =============================================
        private int _userId;          // UserID từ phiên đăng nhập
        private int _selectedId = -1; // ID contact đang chọn trên grid
        private bool _isAdding = false; // đang ở chế độ Add mới

        // =============================================
        // KHỞI TẠO
        // =============================================
        public f_Contact(int userId)
        {
            InitializeComponent();
            _userId = userId;

            // Vẽ avatar tròn
            picAvatar.Region = new Region(
                new System.Drawing.Drawing2D.GraphicsPath().Tap(p =>
                    p.AddEllipse(0, 0, picAvatar.Width, picAvatar.Height)));

            WireEvents();
        }

        /// <summary>Đăng ký tất cả event handler tập trung một chỗ.</summary>
        private void WireEvents()
        {
            this.Load += f_Contact_Load;
            cboGroup.SelectedIndexChanged += cboGroup_SelectedIndexChanged;
            btnFilter.Click += btnFilter_Click;
            txtSearch.KeyDown += txtSearch_KeyDown;
            dgvContacts.SelectionChanged += dgvContacts_SelectionChanged;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnPickImage.Click += btnPickImage_Click;
        }

        // =============================================
        // LOAD FORM
        // =============================================
        private void f_Contact_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGroupComboBoxes();
                LoadGrid();
                SetDetailReadOnly(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu Groups/Contact.\n\n" + ex.Message,
                    "Lỗi tải dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =============================================
        // LOAD DỮ LIỆU
        // =============================================

        /// <summary>
        /// Nạp cboGroup (lọc) và cboGroupEdit (form chi tiết).
        /// </summary>
        private void LoadGroupComboBoxes()
        {
            // Temporarily detach to avoid spurious SelectedIndexChanged during binding
            cboGroup.SelectedIndexChanged -= cboGroup_SelectedIndexChanged;

            DataTable dtGroups = Group.GetGroupsByUser(_userId);
            DataRow allRow = dtGroups.NewRow();
            allRow["ID"] = -1;
            allRow["Name"] = "— Tất cả nhóm —";
            dtGroups.Rows.InsertAt(allRow, 0);

            cboGroup.DataSource = dtGroups;
            cboGroup.DisplayMember = "Name";
            cboGroup.ValueMember = "ID";

            cboGroup.SelectedIndexChanged += cboGroup_SelectedIndexChanged;  // re-attach after binding

            // cboGroupEdit (no event to worry about)
            DataTable dtEdit = Group.GetGroupsByUser(_userId);
            cboGroupEdit.DataSource = dtEdit;
            cboGroupEdit.DisplayMember = "Name";
            cboGroupEdit.ValueMember = "ID";
        }

        /// <summary>Nạp grid theo nhóm đang chọn.</summary>
        private void LoadGrid(string keyword = "")
        {
            int groupId = GetSelectedGroupId();
            DataTable dt;

            if (!string.IsNullOrWhiteSpace(keyword))
                dt = Contact.Search(keyword, _userId, groupId);
            else if (groupId > 0)
                dt = Contact.GetByGroup(groupId, _userId);
            else
                dt = Contact.GetByUser(_userId);

            dgvContacts.DataSource = dt;
            StyleGrid();
            ClearDetail();
        }

        /// <summary>Thiết lập cột hiển thị đẹp sau mỗi lần bind.</summary>
        private void StyleGrid()
        {
            if (dgvContacts.Columns.Count == 0) return;

            // Ẩn các cột kỹ thuật
            foreach (string col in new[] { "ID", "Group_ID", "Pic" })
                if (dgvContacts.Columns.Contains(col))
                    dgvContacts.Columns[col].Visible = false;

            // Đặt tên header thân thiện
            var headers = new System.Collections.Generic.Dictionary<string, string>
            {
                ["HoTen"] = "Họ tên",
                ["Phone"] = "SĐT",
                ["Email"] = "Email",
                ["TenNhom"] = "Nhóm",
                ["Gender"] = "Giới tính",
                ["Dob"] = "Ngày sinh",
                ["Address"] = "Địa chỉ"
            };
            foreach (var kv in headers)
                if (dgvContacts.Columns.Contains(kv.Key))
                    dgvContacts.Columns[kv.Key].HeaderText = kv.Value;

            // Độ rộng cột
            if (dgvContacts.Columns.Contains("HoTen")) dgvContacts.Columns["HoTen"].FillWeight = 25;
            if (dgvContacts.Columns.Contains("Phone")) dgvContacts.Columns["Phone"].FillWeight = 15;
            if (dgvContacts.Columns.Contains("Email")) dgvContacts.Columns["Email"].FillWeight = 25;
            if (dgvContacts.Columns.Contains("TenNhom")) dgvContacts.Columns["TenNhom"].FillWeight = 15;
            if (dgvContacts.Columns.Contains("Gender")) dgvContacts.Columns["Gender"].FillWeight = 10;
            if (dgvContacts.Columns.Contains("Dob")) dgvContacts.Columns["Dob"].FillWeight = 10;
            if (dgvContacts.Columns.Contains("Address")) dgvContacts.Columns["Address"].Visible = false;
        }

        // =============================================
        // SỰ KIỆN LỌC
        // =============================================
        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Chỉ reload nếu không đang trong chế độ Add
            if (_isAdding) return;

            try
            {
                LoadGrid(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh bạ.\n\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGrid(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh bạ.\n\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            try
            {
                LoadGrid(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh bạ.\n\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =============================================
        // CHỌN DÒNG TRÊN GRID → hiển thị chi tiết
        // =============================================
        private void dgvContacts_SelectionChanged(object sender, EventArgs e)
        {
            if (_isAdding) return;
            if (dgvContacts.CurrentRow == null) return;
            if (!dgvContacts.Columns.Contains("ID")) return;

            try
            {
                int id = Convert.ToInt32(dgvContacts.CurrentRow.Cells["ID"].Value);
                _selectedId = id;

                Contact? c = Contact.GetById(id, _userId);
                if (c == null) return;

                FillDetail(c);
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể hiển thị chi tiết liên hệ.\n\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =============================================
        // FILL / CLEAR DETAIL PANEL
        // =============================================
        private void FillDetail(Contact c)
        {
            txtFname.Text = c.Fname;
            txtLname.Text = c.Lname;
            txtPhone.Text = c.Phone;
            txtEmail.Text = c.Email;
            txtAddress.Text = c.Address;

            if (c.Dob.HasValue) dtpDob.Value = c.Dob.Value;
            cboGender.Text = c.Gender;

            // Chọn đúng nhóm trong cboGroupEdit
            foreach (DataRowView item in cboGroupEdit.Items)
            {
                if (Convert.ToInt32(item["ID"]) == c.Group_ID)
                {
                    cboGroupEdit.SelectedItem = item;
                    break;
                }
            }

            // Hiển thị ảnh
            if (c.Pic != null && c.Pic.Length > 0)
            {
                using var ms = new MemoryStream(c.Pic);
                picAvatar.Image = Image.FromStream(ms);
            }
            else
            {
                picAvatar.Image = null;
            }
        }

        private void ClearDetail()
        {
            txtFname.Clear(); txtLname.Clear();
            txtPhone.Clear(); txtEmail.Clear(); txtAddress.Clear();
            dtpDob.Value = DateTime.Today;
            cboGender.SelectedIndex = -1;
            cboGroupEdit.SelectedIndex = cboGroupEdit.Items.Count > 0 ? 0 : -1;
            picAvatar.Image = null;
            _selectedId = -1;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void SetDetailReadOnly(bool readOnly)
        {
            txtFname.ReadOnly = readOnly;
            txtLname.ReadOnly = readOnly;
            txtPhone.ReadOnly = readOnly;
            txtEmail.ReadOnly = readOnly;
            txtAddress.ReadOnly = readOnly;
            dtpDob.Enabled = !readOnly;
            cboGender.Enabled = !readOnly;
            cboGroupEdit.Enabled = !readOnly;
            btnPickImage.Visible = !readOnly;
        }

        // =============================================
        // NÚT ADD
        // =============================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!_isAdding)
            {
                // Chuyển sang chế độ nhập mới
                _isAdding = true;
                ClearDetail();
                SetDetailReadOnly(false);
                btnAdd.Text = "✔ Lưu";
                btnAdd.BackColor = System.Drawing.Color.FromArgb(34, 155, 85);
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                txtFname.Focus();
            }
            else
            {
                // Đang ở chế độ nhập → thực hiện lưu
                SaveNewContact();
            }
        }

        private void SaveNewContact()
        {
            try
            {
                Contact c = ReadDetailForm();
                c.UserID = _userId;
                int newId = Contact.Add(c);

                if (newId > 0)
                {
                    MessageBox.Show("Thêm liên hệ thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ExitAddMode();
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại, vui lòng thử lại.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitAddMode()
        {
            _isAdding = false;
            btnAdd.Text = "Add";
            btnAdd.BackColor = System.Drawing.Color.FromArgb(30, 100, 200);
            SetDetailReadOnly(true);
        }

        // =============================================
        // NÚT EDIT
        // =============================================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedId < 0) return;

            if (btnEdit.Text == "Edit")
            {
                // Mở chế độ chỉnh sửa
                SetDetailReadOnly(false);
                btnEdit.Text = "✔ Cập nhật";
                btnDelete.Enabled = false;
                txtFname.Focus();
            }
            else
            {
                // Lưu thay đổi
                SaveEditContact();
            }
        }

        private void SaveEditContact()
        {
            try
            {
                Contact c = ReadDetailForm();
                c.ID = _selectedId;
                c.UserID = _userId;
                bool updated = Contact.Edit(c);

                if (updated)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnEdit.Text = "Edit";
                    SetDetailReadOnly(true);
                    btnDelete.Enabled = true;
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =============================================
        // NÚT DELETE
        // =============================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedId < 0) return;

            string name = $"{txtFname.Text} {txtLname.Text}".Trim();
            var confirm = MessageBox.Show(
                $"Xóa liên hệ \"{name}\"?\nHành động này không thể hoàn tác.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool deleted = Contact.Delete(_selectedId, _userId);
                if (deleted)
                {
                    MessageBox.Show("Đã xóa liên hệ.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearDetail();
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =============================================
        // CHỌN ẢNH ĐẠI DIỆN
        // =============================================
        private void btnPickImage_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Chọn ảnh đại diện",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;

            picAvatar.Image = Image.FromFile(dlg.FileName);
            picAvatar.Tag = dlg.FileName; // lưu đường dẫn để đọc bytes khi Save
        }

        // =============================================
        // HELPER: ĐỌC DỮ LIỆU TỪ FORM → Contact object
        // Form chỉ đọc control, không tự validate DB
        // =============================================
        private Contact ReadDetailForm()
        {
            byte[]? picBytes = null;
            if (picAvatar.Tag is string imgPath && File.Exists(imgPath))
                picBytes = File.ReadAllBytes(imgPath);

            return new Contact
            {
                Fname = txtFname.Text.Trim(),
                Lname = txtLname.Text.Trim(),
                Dob = dtpDob.Checked ? dtpDob.Value : null,
                Gender = cboGender.Text,
                Group_ID = cboGroupEdit.SelectedValue != null
                           ? Convert.ToInt32(cboGroupEdit.SelectedValue) : 0,
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Pic = picBytes
            };
        }

        // =============================================
        // HELPER: lấy GroupID đang chọn trên cboGroup
        // =============================================
        private int GetSelectedGroupId()
        {
            object? val = cboGroup.SelectedValue;
            if (val == null || val is DataRowView)
                return -1;
            return Convert.ToInt32(val);
        }

    }

    // =============================================
    // EXTENSION nhỏ để vẽ Region tròn gọn hơn
    // =============================================
    internal static class GraphicsPathExtension
    {
        public static System.Drawing.Drawing2D.GraphicsPath Tap(
            this System.Drawing.Drawing2D.GraphicsPath path,
            Action<System.Drawing.Drawing2D.GraphicsPath> action)
        {
            action(path);
            return path;
        }
    }
}