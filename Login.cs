using Microsoft.Data.SqlClient;
using System.Data;

namespace ProjectMonHoc
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void bt_login_Click(object sender, EventArgs e)
        {
            MY_DB db = new MY_DB();
            db.openConnection();

            SqlCommand command = new SqlCommand(
                "SELECT Id, username, role, email FROM login WHERE username = @User AND password = @Pass",
                db.conn
            );
            command.Parameters.Add("@User", SqlDbType.VarChar).Value = tb_username.Text;
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = tb_password.Text;

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                string username = reader["username"].ToString() ?? "";
                string role = reader["role"].ToString() ?? "";
                string email = reader["email"].ToString() ?? "";
                db.closeConnection();

                Globals.SetSession(id, username, role, email);

                f_ListStudent listForm = new f_ListStudent();
                listForm.Show();
                this.Hide();
            }
            else
            {
                db.closeConnection();
                MessageBox.Show("Invalid Username Or Password", "Login Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}