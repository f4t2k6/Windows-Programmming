using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // Bắt buộc thêm thư viện này để thao tác DB

namespace ProjectMonHoc
{
    //Bỏ lỗi CA1416
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_ForgetPass : Form
    {
        // Nhận giá trị từ f_Login (1 = Student, 2 = HR)
        private int rolePosition;

        public f_ForgetPass(int positionFromLogin)
        {
            InitializeComponent();
            this.rolePosition = positionFromLogin;
        }

        private void f_ForgetPass_Load(object sender, EventArgs e)
        {

        }

        private void lbl_ForgetPass_Click(object sender, EventArgs e)
        {

        }

        private void lbl_ForgetPass_1_Click(object sender, EventArgs e)
        {

        }

        // =========================================================
        // SỰ KIỆN: NHẤN NÚT GỬI MÃ OTP
        // =========================================================
        private void btn_SendOTP_Click(object sender, EventArgs e)
        {
            string emailInput = txb_Email.Text.Trim();

            // 1. Kiểm tra định dạng Email (@gmail.com)
            string emailPattern = @"^[^@\s]+@gmail\.com$";
            if (!Regex.IsMatch(emailInput, emailPattern))
            {
                MessageBox.Show("Định dạng Email không hợp lệ! Vui lòng nhập đúng đuôi @gmail.com.",
                                "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Chuyển đổi số position thành chuỗi Role để truy vấn DB
            string targetRole = (rolePosition == 2) ? "HR" : "Student";

            // 3. Truy vấn xem Email có tồn tại với Role tương ứng không
            MY_DB my_db = new MY_DB();
            try
            {
                string query = "SELECT COUNT(*) FROM login WHERE email = @email AND role = @role";
                SqlCommand cmd = new SqlCommand(query, my_db.conn);
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = emailInput;
                cmd.Parameters.Add("@role", SqlDbType.VarChar).Value = targetRole;

                my_db.openConnection();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    // Email TỒN TẠI -> Gọi Form OTP
                    f_OTP frmOTP = new f_OTP();
                    frmOTP.to = emailInput; // Truyền email sang form OTP

                    this.Hide(); // Ẩn form nhập Email đi

                    if (frmOTP.ShowDialog() == DialogResult.OK)
                    {
                        // Xác nhận OTP đúng -> Gọi Form Đặt lại mật khẩu
                        f_ResetPass frmReset = new f_ResetPass(emailInput, targetRole);
                        frmReset.ShowDialog();

                        // Sau khi xong xuôi bên ResetPass, đóng hoàn toàn luồng này
                        this.Close();
                    }
                    else
                    {
                        // Nếu người dùng hủy hoặc tắt form OTP, hiện lại form nhập Email
                        this.Show();
                    }
                }
                else
                {
                    // Email KHÔNG TỒN TẠI
                    MessageBox.Show($"Email này không tồn tại trong hệ thống đối với vai trò {targetRole}!",
                                    "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                my_db.closeConnection();
            }
        }
    }
}