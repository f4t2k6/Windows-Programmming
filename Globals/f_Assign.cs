using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    //Bỏ lỗi CA1416
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_Assign : Form
    {
        private readonly MY_DB db = new MY_DB();

        public f_Assign()
        {
            InitializeComponent();
        }

        // ─── LOAD ───────────────────────────────────────────────
        private void f_Assign_Load(object sender, EventArgs e)
        {
            LoadHRComboBox();
            LoadCourseComboBox();
            LoadAssignGrid();
        }

        // ─── LOAD DỮ LIỆU ───────────────────────────────────────
        private void LoadHRComboBox()
        {
            try
            {
                db.openConnection();
                string sql = "SELECT MSGV, Fname + N' ' + Lname AS HoTen FROM [dbo].[HR] WHERE VALID = 1 ORDER BY Fname";
                SqlDataAdapter da = new SqlDataAdapter(sql, db.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboHR.DataSource = dt;
                cboHR.DisplayMember = "HoTen";
                cboHR.ValueMember = "MSGV";
                cboHR.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách HR: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }

        private void LoadCourseComboBox()
        {
            try
            {
                db.openConnection();
                string sql = "SELECT MaMH, TenMH FROM [dbo].[Course] ORDER BY TenMH";
                SqlDataAdapter da = new SqlDataAdapter(sql, db.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboCourse.DataSource = dt;
                cboCourse.DisplayMember = "TenMH";
                cboCourse.ValueMember = "MaMH";
                cboCourse.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách môn học: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }

        private void LoadAssignGrid()
        {
            try
            {
                db.openConnection();
                string sql = @"
                    SELECT
                        h.MSGV,
                        h.Fname + N' ' + h.Lname AS [Họ tên HR],
                        RTRIM(c.MaMH)             AS [Mã MH],
                        c.TenMH                   AS [Tên môn],
                        c.SoTC                    AS [Số TC]
                    FROM [dbo].[Assign] a
                    JOIN [dbo].[HR]     h ON a.MSGV  = h.MSGV
                    JOIN [dbo].[Course] c ON a.MaMH  = c.MaMH
                    ORDER BY h.MSGV, c.MaMH";

                SqlDataAdapter da = new SqlDataAdapter(sql, db.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAssign.DataSource = dt;

                StyleGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phân công: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }

        private void StyleGrid()
        {
            dgvAssign.ReadOnly = true;
            dgvAssign.AllowUserToAddRows = false;
            dgvAssign.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAssign.MultiSelect = false;
            dgvAssign.RowHeadersVisible = false;
            dgvAssign.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Header style
            dgvAssign.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235, 242, 255);
            dgvAssign.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 80, 180);
            dgvAssign.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvAssign.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAssign.ColumnHeadersHeight = 40;
            dgvAssign.EnableHeadersVisualStyles = false;

            // Row style
            dgvAssign.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            dgvAssign.DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);
            dgvAssign.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 228, 255);
            dgvAssign.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 60, 160);
            dgvAssign.RowTemplate.Height = 36;
            dgvAssign.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 255);

            // Column alignment
            if (dgvAssign.Columns.Contains("MSGV"))
                dgvAssign.Columns["MSGV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgvAssign.Columns.Contains("Số TC"))
                dgvAssign.Columns["Số TC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgvAssign.Columns.Contains("Mã MH"))
                dgvAssign.Columns["Mã MH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // ─── NÚT PHÂN CÔNG ──────────────────────────────────────
        private void btnAssign_Click(object sender, EventArgs e)
        {
            string msgv = cboHR.SelectedValue?.ToString()?.Trim();
            string mamh = cboCourse.SelectedValue?.ToString()?.Trim();

            if (string.IsNullOrWhiteSpace(msgv) || cboHR.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân sự / giảng viên.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(mamh) || cboCourse.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn môn học.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CountAssignedCourses(msgv) >= 5)
            {
                MessageBox.Show("Giảng viên này đã phụ trách tối đa 5 môn học.", "Giới hạn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                db.openConnection();
                // Lấy MaMH đúng format CHAR(10) từ DB để tránh lỗi trùng khoảng trắng
                string sqlInsert = "INSERT INTO [dbo].[Assign] (MSGV, MaMH) VALUES (@msgv, @mamh)";
                SqlCommand cmd = new SqlCommand(sqlInsert, db.conn);
                cmd.Parameters.AddWithValue("@msgv", msgv);
                cmd.Parameters.AddWithValue("@mamh", cboCourse.SelectedValue.ToString());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Phân công thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                cboHR.SelectedIndex = -1;
                cboCourse.SelectedIndex = -1;
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show("Phân công này đã tồn tại (trùng cặp HR – Môn học).", "Trùng dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể phân công: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
                LoadAssignGrid();
            }
        }

        // ─── NÚT HỦY PHÂN CÔNG ──────────────────────────────────
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvAssign.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần hủy phân công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string msgv = dgvAssign.CurrentRow.Cells["MSGV"].Value?.ToString()?.Trim();
            string maMH = dgvAssign.CurrentRow.Cells["Mã MH"].Value?.ToString()?.Trim();
            string tenMH = dgvAssign.CurrentRow.Cells["Tên môn"].Value?.ToString();

            var confirm = MessageBox.Show(
                $"Hủy phân công môn \"{tenMH}\" khỏi giảng viên {msgv}?",
                "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                db.openConnection();
                // Dùng RTRIM để khớp với CHAR(10) trong DB
                string sql = "DELETE FROM [dbo].[Assign] WHERE RTRIM(MSGV)=@msgv AND RTRIM(MaMH)=@mamh";
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                cmd.Parameters.AddWithValue("@msgv", msgv);
                cmd.Parameters.AddWithValue("@mamh", maMH);
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    MessageBox.Show("Đã hủy phân công thành công.", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Không tìm thấy bản ghi để xóa.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hủy phân công: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
                LoadAssignGrid();
            }
        }

        // ─── NÚT REFRESH ────────────────────────────────────────
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAssignGrid();
        }

        // ─── HELPER ─────────────────────────────────────────────
        private int CountAssignedCourses(string msgv)
        {
            try
            {
                db.openConnection();
                string sql = "SELECT COUNT(*) FROM [dbo].[Assign] WHERE RTRIM(MSGV) = @msgv";
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                cmd.Parameters.AddWithValue("@msgv", msgv);
                return (int)cmd.ExecuteScalar();
            }
            catch { return 0; }
            finally { db.closeConnection(); }
        }

        private void lblHR_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}