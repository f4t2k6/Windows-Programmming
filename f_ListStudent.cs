using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ProjectMonHoc
{
    public partial class f_ListStudent : Form
    {
        public f_ListStudent()
        {
            InitializeComponent();
        }

        private void f_ListStudent_Load(object sender, EventArgs e)
        {
            // Hiển thị người đang đăng nhập
            lblCurrentUser.Text = $"Đang đăng nhập: {Globals.GlobalUsername} ({Globals.GlobalRole})";

            // Thêm options sắp xếp
            cboSort.Items.Add("Mặc định");
            cboSort.Items.Add("Theo MSSV");
            cboSort.Items.Add("Theo Tên (A-Z)");
            cboSort.Items.Add("Theo Tên (Z-A)");
            cboSort.SelectedIndex = 0;

            LoadStudents();
        }

        private void LoadStudents(string search = "", string sortBy = "")
        {
            MY_DB db = new MY_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();

                string query = "SELECT MSSV, Fname, Lname, Dob, Gder FROM Student WHERE 1=1";

                if (!string.IsNullOrEmpty(search))
                {
                    query += " AND (CAST(MSSV AS NVARCHAR) LIKE @search OR Fname LIKE @search OR Lname LIKE @search)";
                }

                switch (sortBy)
                {
                    case "Theo MSSV":
                        query += " ORDER BY MSSV ASC"; break;
                    case "Theo Tên (A-Z)":
                        query += " ORDER BY Lname ASC, Fname ASC"; break;
                    case "Theo Tên (Z-A)":
                        query += " ORDER BY Lname DESC, Fname DESC"; break;
                    default:
                        query += " ORDER BY MSSV ASC"; break;
                }

                SqlCommand cmd = new SqlCommand(query, db.conn);
                if (!string.IsNullOrEmpty(search))
                    cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                dgvStudents.DataSource = dt;

                // Đặt tên cột tiếng Việt
                if (dgvStudents.Columns.Count > 0)
                {
                    dgvStudents.Columns["MSSV"].HeaderText = "Mã SV";
                    dgvStudents.Columns["Fname"].HeaderText = "Họ";
                    dgvStudents.Columns["Lname"].HeaderText = "Tên";
                    dgvStudents.Columns["Dob"].HeaderText = "Ngày sinh";
                    dgvStudents.Columns["Gder"].HeaderText = "Giới tính";
                }

                // Hiển thị tổng số sinh viên
                lblTotal.Text = $"Tổng số sinh viên: {dt.Rows.Count}";
            }
            finally { db.closeConnection(); }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text == "Tìm kiếm..." ? "" : txtSearch.Text;
            LoadStudents(keyword, cboSort.SelectedItem?.ToString());
        }

        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text == "Tìm kiếm..." ? "" : txtSearch.Text;
            LoadStudents(keyword, cboSort.SelectedItem?.ToString());
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            f_AddStudent addForm = new f_AddStudent();
            addForm.FormClosed += (s, args) => LoadStudents(); // Reload sau khi thêm
            addForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Globals.ClearSession();
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }
    }
}