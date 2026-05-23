using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // Sử dụng đúng thư viện như mẫu của bạn

namespace ProjectMonHoc
{
    public partial class f_MainAdmin : Form
    {
        private Panel? currentPanel = null;
        public f_MainAdmin()
        {
            InitializeComponent();
        }

        private void SwitchOptionPanel(Panel targetPanel)
        {
            // 1. Nếu nút bấm gọi chính cái Panel đang mở -> Có thể chọn ẩn nó đi (thành nút bật/tắt)
            if (currentPanel == targetPanel)
            {
                currentPanel.Visible = false;
                currentPanel = null;
                return;
            }

            // 2. Nếu đang có một Panel khác mở -> Ẩn nó đi
            if (currentPanel != null)
            {
                currentPanel.Visible = false;
            }

            // 3. Gán Panel mục tiêu thành Panel hiện tại
            currentPanel = targetPanel;

            // 4. Bật hiển thị Panel mới và đẩy nó lên lớp trên cùng để không bị che khuất
            currentPanel.Visible = true;
            currentPanel.BringToFront();
        }

        private void btn_letter_MainAdmin_Click(object sender, EventArgs e)
        {
            SwitchOptionPanel(pnl_letter_MainAdmin);
            // Bật/tắt ẩn hiện panel
            pnl_letter_MainAdmin.Visible = !pnl_letter_MainAdmin.Visible;

            // Nếu mở panel thì tiến hành quét DB và nạp danh sách yêu cầu mới nhất
            if (pnl_letter_MainAdmin.Visible)
            {
                LoadRegistrationRequests();
            }
        }

        private void LoadRegistrationRequests()
        {
            flp_requests_MainAdmin.Controls.Clear();

            MY_DB my_db = new MY_DB();
            try
            {
                string query = "SELECT Id, Username, Fname, Lname, Email, Password FROM register_HR";
                // Chú ý: dùng my_db.conn thay vì db.getConnection theo chuẩn file f_ForgetPass
                SqlCommand cmd = new SqlCommand(query, my_db.conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();

                my_db.openConnection();
                adapter.Fill(table);

                if (table.Rows.Count == 0)
                {
                    Label lblEmpty = new Label();
                    lblEmpty.Text = "Hiện tại không có yêu cầu đăng ký nào từ HR.";
                    lblEmpty.AutoSize = true;
                    lblEmpty.ForeColor = Color.DarkGray;
                    lblEmpty.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                    flp_requests_MainAdmin.Controls.Add(lblEmpty);
                    return;
                }

                // Vẽ giao diện động cho từng Request
                foreach (DataRow row in table.Rows)
                {
                    int hrId = Convert.ToInt32(row["Id"]);
                    string? username = row["Username"].ToString();
                    string? email = row["Email"].ToString();
                    string? fullName = row["Fname"].ToString() + " " + row["Lname"].ToString();
                    string? password = row["Password"].ToString();

                    Panel pnlItem = new Panel();
                    pnlItem.Size = new Size(flp_requests_MainAdmin.Width - 25, 70);
                    pnlItem.BorderStyle = BorderStyle.FixedSingle;
                    pnlItem.BackColor = Color.White;
                    pnlItem.Margin = new Padding(0, 5, 0, 5);

                    Label lblInfo = new Label();
                    lblInfo.Text = $"ID: {hrId} | Tài khoản: {username}\nHọ tên: {fullName}\nEmail: {email}";
                    lblInfo.AutoSize = true;
                    lblInfo.Location = new Point(15, 10);
                    lblInfo.Font = new Font("Segoe UI", 9, FontStyle.Regular);

                    Button btnAccept = new Button();
                    btnAccept.Text = "Accept";
                    btnAccept.BackColor = Color.ForestGreen;
                    btnAccept.ForeColor = Color.White;
                    btnAccept.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    btnAccept.Size = new Size(85, 35);
                    btnAccept.Location = new Point(pnlItem.Width - 195, 16);
                    btnAccept.Cursor = Cursors.Hand;
                    btnAccept.Tag = new HRRequestData { Id = hrId, Username = username, Email = email, Password = password };
                    btnAccept.Click += BtnAccept_Click;

                    Button btnReject = new Button();
                    btnReject.Text = "Reject";
                    btnReject.BackColor = Color.Firebrick;
                    btnReject.ForeColor = Color.White;
                    btnReject.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    btnReject.Size = new Size(85, 35);
                    btnReject.Location = new Point(pnlItem.Width - 95, 16);
                    btnReject.Cursor = Cursors.Hand;
                    btnReject.Tag = hrId;
                    btnReject.Click += BtnReject_Click;

                    pnlItem.Controls.Add(lblInfo);
                    pnlItem.Controls.Add(btnAccept);
                    pnlItem.Controls.Add(btnReject);

                    flp_requests_MainAdmin.Controls.Add(pnlItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách yêu cầu: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                my_db.closeConnection();
            }
        }

        private void BtnAccept_Click(object? sender, EventArgs e)
        {
            // 1. Ép kiểu an toàn bằng "as" và kiểm tra null để triệt tiêu hoàn toàn cảnh báo CS8600/CS8602
            Button? btn = sender as Button;
            if (btn == null || btn.Tag == null) return;

            // Lúc này trình biên dịch đã hiểu Tag chắc chắn có dữ liệu nên ép kiểu sẽ không bị cảnh báo
            HRRequestData data = (HRRequestData)btn.Tag;

            MY_DB my_db = new MY_DB();
            SqlTransaction? transaction = null; // Thêm dấu ? để biểu thị biến này có thể null ban đầu

            try
            {
                my_db.openConnection();

                // Bắt đầu Transaction để tránh lỗi nửa chừng
                transaction = my_db.conn.BeginTransaction();

                // Lệnh 1: Insert sang login
                string insertQuery = "INSERT INTO login (Id, username, password, role, email, LoginAttempts) " +
                                     "VALUES (@id, @user, @pass, 'HR', @email, 0)";
                SqlCommand cmdInsert = new SqlCommand(insertQuery, my_db.conn, transaction);
                cmdInsert.Parameters.Add("@id", SqlDbType.Int).Value = data.Id;
                cmdInsert.Parameters.Add("@user", SqlDbType.VarChar).Value = data.Username;
                cmdInsert.Parameters.Add("@pass", SqlDbType.VarChar).Value = data.Password;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar).Value = data.Email;
                cmdInsert.ExecuteNonQuery();

                // Lệnh 2: Xóa khỏi bảng tạm
                string deleteQuery = "DELETE FROM register_HR WHERE Id = @id";
                SqlCommand cmdDelete = new SqlCommand(deleteQuery, my_db.conn, transaction);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = data.Id;
                cmdDelete.ExecuteNonQuery();

                // Chốt giao dịch
                transaction.Commit();
                MessageBox.Show($"Đã phê duyệt thành công! Tài khoản HR [{data.Username}] đã có thể đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRegistrationRequests();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback(); // Hoàn tác nếu có lỗi
                }
                MessageBox.Show("Lỗi xử lý phê duyệt: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                my_db.closeConnection();
            }
        }

        private void BtnReject_Click(object? sender, EventArgs e)
        {
            // 1. Kiểm tra và ép kiểu an toàn thay vì ép thẳng (khắc phục lỗi Null Reference)
            Button? btn = sender as Button;
            if (btn == null || btn.Tag == null) return; // Nếu nút hoặc Tag bị null thì dừng hàm ngay lập tức

            // 2. Dùng Convert.ToInt32 thay vì (int) để tránh lỗi Unboxing dữ liệu
            int hrId = Convert.ToInt32(btn.Tag);

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn TỪ CHỐI và XÓA yêu cầu đăng ký của ID: {hrId}?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                MY_DB my_db = new MY_DB();
                try
                {
                    string query = "DELETE FROM register_HR WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, my_db.conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = hrId;

                    my_db.openConnection();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Đã hủy bỏ và xóa yêu cầu đăng ký thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRegistrationRequests();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa yêu cầu: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    my_db.closeConnection();
                }
            }
        }

        private void btn_Logout_MainAdmin_Click(object sender, EventArgs e)
        {
            // 1. Xóa trạng thái đăng nhập toàn cục để đảm bảo bảo mật
            Globals.GlobalUsername = string.Empty;
            // Nếu trong Globals.cs của bạn có lưu thêm biến Role, hãy xóa nó ở đây (VD: Globals.GlobalRole = string.Empty;)

            // 2. Ẩn form hiện tại đi
            this.Hide();

            // 3. Khởi tạo lại và hiển thị form Đăng nhập
            f_Login formLogin = new f_Login();
            formLogin.ShowDialog();

            // 4. Giải phóng hoàn toàn form cũ sau khi form login đóng
            this.Close();
        }
    }

    // Class phụ để đóng gói dữ liệu truyền qua Tag của nút bấm
    public class HRRequestData
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}