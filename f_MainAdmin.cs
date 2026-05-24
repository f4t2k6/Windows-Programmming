using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ProjectMonHoc
{
    public partial class f_MainAdmin : Form
    {
        private Form? activeForm = null;

        public f_MainAdmin()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm, Panel targetPanel)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            targetPanel.Controls.Clear();
            targetPanel.Controls.Add(childForm);
            targetPanel.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        private void btn_letter_MainAdmin_Click(object sender, EventArgs e)
        {
            // Ẩn panel con, hiện giao diện hộp thư
            pnl_content_MainAdmin.Visible = false;
            flp_requests_MainAdmin.Visible = true;
            flp_requests_MainAdmin.BringToFront();

            LoadRegistrationRequests();
        }

        // ============================================
        // 3 CHỨC NĂNG THÊM VÀO TỪ MAIN HR
        // ============================================
        private void btn_AddStudent_MainAdmin_Click(object sender, EventArgs e)
        {
            flp_requests_MainAdmin.Visible = false;
            pnl_content_MainAdmin.Visible = true;
            OpenChildForm(new f_AddStudent(), pnl_content_MainAdmin);
        }

        private void btn_StudentScore_MainAdmin_Click(object sender, EventArgs e)
        {
            flp_requests_MainAdmin.Visible = false;
            pnl_content_MainAdmin.Visible = true;
            string studentName = Globals.GlobalUsername;
            int studentMSSV = Globals.GlobalUserId;
            OpenChildForm(new f_ListScore(studentMSSV, studentName), pnl_content_MainAdmin);
        }

        private void btn_ListStudent_MainAdmin_Click(object sender, EventArgs e)
        {
            flp_requests_MainAdmin.Visible = false;
            pnl_content_MainAdmin.Visible = true;
            OpenChildForm(new f_ListStudent(), pnl_content_MainAdmin);
        }

        // ============================================
        // CÁC CHỨC NĂNG XỬ LÝ MAIL CŨ CỦA ADMIN
        // ============================================
        private void LoadRegistrationRequests()
        {
            flp_requests_MainAdmin.Controls.Clear();

            MY_DB my_db = new MY_DB();
            try
            {
                string query = "SELECT Id, Username, Fname, Lname, Email, Password, Status FROM register_HR";
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

                foreach (DataRow row in table.Rows)
                {
                    int hrId = Convert.ToInt32(row["Id"]);
                    string? username = row["Username"].ToString();
                    string? email = row["Email"].ToString();
                    string? fullName = row["Fname"].ToString() + " " + row["Lname"].ToString();
                    string? password = row["Password"].ToString();
                    bool isApproved = Convert.ToBoolean(row["Status"]);

                    Panel pnlItem = new Panel();
                    pnlItem.Size = new Size(flp_requests_MainAdmin.Width - 25, 70);
                    pnlItem.BorderStyle = BorderStyle.FixedSingle;
                    pnlItem.BackColor = Color.White;
                    pnlItem.Margin = new Padding(0, 5, 0, 5);

                    string statusText = isApproved ? "✔ Đã duyệt" : "⏳ Chờ duyệt";
                    Color statusColor = isApproved ? Color.ForestGreen : Color.DarkOrange;

                    Label lblInfo = new Label();
                    lblInfo.Text = $"ID: {hrId} | Tài khoản: {username}  [{statusText}]\nHọ tên: {fullName}\nEmail: {email}";
                    lblInfo.AutoSize = true;
                    lblInfo.Location = new Point(15, 10);
                    lblInfo.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                    lblInfo.ForeColor = Color.Black;

                    if (isApproved)
                        pnlItem.BackColor = Color.FromArgb(240, 255, 240);

                    Button btnAccept = new Button();
                    btnAccept.Text = "Accept";
                    btnAccept.BackColor = isApproved ? Color.Gray : Color.ForestGreen;
                    btnAccept.ForeColor = Color.White;
                    btnAccept.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    btnAccept.Size = new Size(85, 35);
                    btnAccept.Location = new Point(pnlItem.Width - 195, 16);
                    btnAccept.Cursor = Cursors.Hand;
                    btnAccept.Enabled = !isApproved;
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
            Button? btn = sender as Button;
            if (btn == null || btn.Tag == null) return;

            HRRequestData data = (HRRequestData)btn.Tag;

            MY_DB my_db = new MY_DB();
            SqlTransaction? transaction = null;

            try
            {
                my_db.openConnection();
                transaction = my_db.conn.BeginTransaction();

                string updateStatusQuery = "UPDATE register_HR SET Status = 1 WHERE Id = @id";
                SqlCommand cmdStatus = new SqlCommand(updateStatusQuery, my_db.conn, transaction);
                cmdStatus.Parameters.Add("@id", SqlDbType.Int).Value = data.Id;
                cmdStatus.ExecuteNonQuery();

                string insertQuery = "INSERT INTO login (Id, username, password, role, email, LoginAttempts) " +
                                     "VALUES (@id, @user, @pass, 'HR', @email, 0)";
                SqlCommand cmdInsert = new SqlCommand(insertQuery, my_db.conn, transaction);
                cmdInsert.Parameters.Add("@id", SqlDbType.Int).Value = data.Id;
                cmdInsert.Parameters.Add("@user", SqlDbType.VarChar).Value = data.Username;
                cmdInsert.Parameters.Add("@pass", SqlDbType.VarChar).Value = data.Password;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar).Value = data.Email;
                cmdInsert.ExecuteNonQuery();

                string deleteQuery = "DELETE FROM register_HR WHERE Id = @id";
                SqlCommand cmdDelete = new SqlCommand(deleteQuery, my_db.conn, transaction);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = data.Id;
                cmdDelete.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show($"Đã phê duyệt thành công! Tài khoản HR [{data.Username}] đã có thể đăng nhập.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRegistrationRequests();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Lỗi xử lý phê duyệt: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                my_db.closeConnection();
            }
        }

        private void BtnReject_Click(object? sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null || btn.Tag == null) return;

            int hrId = Convert.ToInt32(btn.Tag);

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn TỪ CHỐI và XÓA yêu cầu đăng ký của ID: {hrId}?",
                "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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
                        MessageBox.Show("Đã hủy bỏ và xóa yêu cầu đăng ký thành công.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Globals.GlobalUsername = string.Empty;
            this.Hide();

            f_Login formLogin = new f_Login();
            formLogin.ShowDialog();

            this.Close();
        }
    }

    public class HRRequestData
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}