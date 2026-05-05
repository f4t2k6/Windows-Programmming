using Microsoft.Data.SqlClient;
using System.Data;

namespace Day01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            MY_DB db = new MY_DB();
            db.openConnection();

            SqlCommand command = new SqlCommand(
                "SELECT * FROM login WHERE username = @User AND password = @Pass",
                db.getConnection
            );
            command.Parameters.Add("@User", SqlDbType.VarChar).Value = tb_username.Text;
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = tb_password.Text;

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
                MessageBox.Show("Ok, next time will be go to Main Menu of App");
            else
                MessageBox.Show("Invalid Username Or Password", "Login Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            db.closeConnection();
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
