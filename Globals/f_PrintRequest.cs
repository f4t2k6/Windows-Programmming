using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    /// <summary>
    /// Form con mở trong pnl_Content_Student.
    /// Hiển thị thông tin cá nhân của sinh viên và cho phép gửi
    /// yêu cầu "In giấy xác nhận sinh viên" lên Admin.
    /// </summary>
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_PrintRequest : Form
    {
        // ── Dữ liệu sinh viên hiện tại ──────────────────────────────
        private readonly int _mssv;
        private readonly string _fullName;
        private string _currentStatus = ""; // trạng thái PrintRequest từ DB

        public f_PrintRequest(int mssv, string fullName)
        {
            _mssv = mssv;
            _fullName = fullName;
            InitializeComponent();
        }

        // ============================================================
        // LOAD FORM
        // ============================================================
        private void f_PrintRequest_Load(object sender, EventArgs e)
        {
            LoadStudentInfo();
        }

        // ============================================================
        // ĐỌC THÔNG TIN SINH VIÊN TỪ DB
        // ============================================================
        private void LoadStudentInfo()
        {
            MY_DB my_db = new MY_DB();
            try
            {
                my_db.openConnection();

                SqlConnection conn = my_db.conn;

                string sql = @"SELECT MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email,
                                      PrintRequest, PrintRequestDate
                               FROM   dbo.Student
                               WHERE  MSSV = @mssv";

                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mssv", _mssv);

                using SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    // Hiện thông tin lên labels
                    lbl_MSSV_Value.Text = dr["MSSV"].ToString();
                    lbl_Name_Value.Text = $"{dr["Fname"]} {dr["Lname"]}".Trim();
                    lbl_Dob_Value.Text = dr["Dob"] == DBNull.Value
                                                ? "—"
                                                : Convert.ToDateTime(dr["Dob"]).ToString("dd/MM/yyyy");
                    lbl_Gender_Value.Text = dr["Gder"] == DBNull.Value ? "—" : dr["Gder"].ToString()!;
                    lbl_Phone_Value.Text = dr["Phone"] == DBNull.Value ? "—" : dr["Phone"].ToString()!;
                    lbl_Address_Value.Text = dr["Address"] == DBNull.Value ? "—" : dr["Address"].ToString()!;
                    lbl_Htown_Value.Text = dr["Htown"] == DBNull.Value ? "—" : dr["Htown"].ToString()!;
                    lbl_Email_Value.Text = dr["Email"] == DBNull.Value ? "—" : dr["Email"].ToString()!;

                    // Trạng thái yêu cầu in
                    _currentStatus = dr["PrintRequest"] == DBNull.Value ? "" : dr["PrintRequest"].ToString()!;
                    UpdateStatusUI(_currentStatus,
                        dr["PrintRequestDate"] == DBNull.Value
                            ? (DateTime?)null
                            : Convert.ToDateTime(dr["PrintRequestDate"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin sinh viên:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                my_db.closeConnection();
            }
        }

        // ============================================================
        // CẬP NHẬT GIAO DIỆN THEO TRẠNG THÁI
        // ============================================================
        private void UpdateStatusUI(string status, DateTime? requestDate)
        {
            switch (status)
            {
                case "Pending":
                    lbl_Status.Text = "⏳ Đang chờ Admin xét duyệt";
                    lbl_Status.ForeColor = System.Drawing.Color.DarkOrange;
                    btn_SendRequest.Enabled = false;
                    btn_SendRequest.Text = "✅ Đã gửi yêu cầu";
                    if (requestDate.HasValue)
                        lbl_RequestDate.Text = $"Gửi lúc: {requestDate.Value:dd/MM/yyyy HH:mm}";
                    break;

                case "Approved":
                    lbl_Status.Text = "✅ Yêu cầu đã được DUYỆT";
                    lbl_Status.ForeColor = System.Drawing.Color.Green;
                    btn_SendRequest.Enabled = false;
                    btn_SendRequest.Text = "Đã được duyệt";
                    if (requestDate.HasValue)
                        lbl_RequestDate.Text = $"Duyệt lúc: {requestDate.Value:dd/MM/yyyy HH:mm}";
                    break;

                case "Declined":
                    lbl_Status.Text = "❌ Yêu cầu bị TỪ CHỐI — Bạn có thể gửi lại";
                    lbl_Status.ForeColor = System.Drawing.Color.Red;
                    btn_SendRequest.Enabled = true;
                    btn_SendRequest.Text = "🖨️ Gửi lại yêu cầu";
                    lbl_RequestDate.Text = "";
                    break;

                default: // "" hoặc NULL — chưa gửi lần nào
                    lbl_Status.Text = "Chưa gửi yêu cầu.";
                    lbl_Status.ForeColor = System.Drawing.Color.Gray;
                    btn_SendRequest.Enabled = true;
                    btn_SendRequest.Text = "🖨️ Gửi yêu cầu In giấy";
                    lbl_RequestDate.Text = "";
                    break;
            }
        }

        // ============================================================
        // NÚT GỬI YÊU CẦU
        // ============================================================
        private void btn_SendRequest_Click(object sender, EventArgs e)
        {
            MY_DB my_db = new MY_DB();

            var confirm = MessageBox.Show(
                "Bạn có chắc muốn gửi yêu cầu\n\"In giấy xác nhận sinh viên\" không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                my_db.openConnection();

                SqlConnection conn = my_db.conn;

                string sql = @"UPDATE dbo.Student
                               SET    PrintRequest     = 'Pending',
                                      PrintRequestDate = GETDATE()
                               WHERE  MSSV = @mssv";

                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mssv", _mssv);
                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Đã gửi yêu cầu thành công!\nAdmin sẽ xét duyệt sớm.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload để cập nhật UI
                LoadStudentInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi yêu cầu:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                my_db.closeConnection();
            }
        }

        private void lbl_MSSV_Value_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Dob_Click(object sender, EventArgs e)
        {

        }
    }
}
