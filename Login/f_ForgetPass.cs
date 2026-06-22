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
        private int rolePosition;
        private f_Login loginForm;

        // Thêm các Callback để điều hướng linh hoạt
        public Action? onBackToLogin { get; set; }

        public f_ForgetPass(int positionFromLogin, f_Login loginForm)
        {
            InitializeComponent();
            this.rolePosition = positionFromLogin;
            this.loginForm = loginForm;
        }

        private void f_ForgetPass_Load(object sender, EventArgs e)
        {
            // Xác định tên vai trò dựa trên rolePosition (1 = Student, 2 = HR)
            string roleName = (rolePosition == 2) ? "HR" : "STUDENT";

            // Cập nhật lại tiêu đề với định dạng: "KHÔI PHỤC MẬT KHẨU [Role]"
            lbl_Title.Text = $"KHÔI PHỤC MẬT KHẨU\n{roleName}";
        }

        // =========================================================
        // SỰ KIỆN: NHẤN NÚT GỬI MÃ OTP
        // =========================================================
        private void btn_SendOTP_Click(object sender, EventArgs e)
        {
            string emailInput = txb_Email.Text.Trim();

            string emailPattern = @"^[^@\s]+@gmail\.com$";
            if (!Regex.IsMatch(emailInput, emailPattern))
            {
                MessageBox.Show("Định dạng Email không hợp lệ! Vui lòng nhập đúng đuôi @gmail.com.",
                                "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string targetRole = (rolePosition == 2) ? "HR" : "Student";

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
                    // Email hợp lệ -> Khởi tạo f_OTP
                    f_OTP frmOTP = new f_OTP();
                    frmOTP.to = emailInput;
                    frmOTP.targetRole = targetRole;

                    bool resetFlowStarted = false;

                    // THUẬN: Nếu OTP xác thực THÀNH CÔNG -> Chuyển sang ResetPass
                    frmOTP.onVerifySuccess = (email, role) => {
                        resetFlowStarted = true;

                        f_ResetPass frmReset = new f_ResetPass(email, role, loginForm);

                        // ResetPass thành công hoặc bấm hủy ở ResetPass -> Về thẳng Login gốc
                        frmReset.onDone = () => loginForm.RestoreLoginPanel();

                        loginForm.OpenChildForm(frmReset, loginForm.LoginPanel);
                    };

                    // ✅ SỬA LỖI MÀN HÌNH TRẮNG: dùng FormClosed thay vì onBackToForget,
                    // vì f_OTP chỉ Close() khi bấm Hủy mà KHÔNG gọi onBackToForget,
                    // khiến panel_Login không có form nào được nạp lại -> trắng trơn.
                    // FormClosed luôn được kích hoạt bất kể đóng bằng cách nào, nên đáng tin cậy hơn.
                    frmOTP.FormClosed += (s, args) =>
                    {
                        // Nếu đã xác thực thành công và chuyển sang ResetPass rồi thì không xử lý gì thêm
                        if (resetFlowStarted) return;

                        // NGHỊCH: Bấm 'Hủy' (hoặc đóng form bằng cách khác) -> quay lại f_ForgetPass
                        // Khởi tạo một thực thể mới tinh để nạp vào panel (vì instance cũ đã bị đóng)
                        f_ForgetPass newForgetPass = new f_ForgetPass(this.rolePosition, this.loginForm);

                        // Gán lại callback nút hủy cho thực thể mới này để nó có thể quay về Login tiếp
                        newForgetPass.onBackToLogin = () => loginForm.RestoreLoginPanel();

                        // Mở form mới lên panel
                        loginForm.OpenChildForm(newForgetPass, loginForm.LoginPanel);
                    };

                    // Đẩy f_OTP lên panel (bước này sẽ tự động giải phóng f_ForgetPass hiện tại)
                    loginForm.OpenChildForm(frmOTP, loginForm.LoginPanel);
                }
                else
                {
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

        private void btn_Cancel_ForgetPass_Click(object sender, EventArgs e)
        {
            onBackToLogin?.Invoke();
        }

        private void lbl_Title_Click(object sender, EventArgs e)
        {

        }

        private void llbl_Register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txb_Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_AskAI_Click(object sender, EventArgs e)
        {
            f_Chatbot chatbotForm = new f_Chatbot();
            chatbotForm.Show(this); // Hiển thị dưới dạng Tool Window đè lên form hiện tại nhưng không khóa nó
        }
    }
}