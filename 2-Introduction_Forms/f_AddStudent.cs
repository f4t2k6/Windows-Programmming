using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Day01
{
    public partial class f_AddStudent : Form
    {
        public f_AddStudent()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void f_AddStudent_Load(object sender, EventArgs e)
        {
            cboGender.Items.Add("Nam");
            cboGender.Items.Add("Nữ");
            cboGender.Items.Add("Khác");
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        byte[] studentImage = null;
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picStudent.Image = Image.FromFile(ofd.FileName);
                // Chuyển ảnh sang byte array
                MemoryStream ms = new MemoryStream();
                picStudent.Image.Save(ms, picStudent.Image.RawFormat);
                studentImage = ms.ToArray();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMSSV.Text.Trim() == "" ||
                txtMSSV.Text == "Nhập MSSV" ||
                txtLname.Text.Trim() == "" ||
                txtLname.Text == "Nhập tên")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ MSSV và Tên!");
                return;
            }

            int mssv;

            if (!int.TryParse(txtMSSV.Text, out mssv))
            {
                MessageBox.Show("MSSV phải là số!");
                return;
            }

            // Nếu chưa nhập thì lưu rỗng
            string fname = txtFname.Text == "Nhập họ và tên đệm" ? "" : txtFname.Text;
            string lname = txtLname.Text == "Nhập tên" ? "" : txtLname.Text;
            string phone = txtPhone.Text == "Nhập số điện thoại" ? "" : txtPhone.Text;
            string address = txtAddress.Text == "Nhập địa chỉ" ? "" : txtAddress.Text;
            string hometown = txtHometown.Text == "Nhập quê quán" ? "" : txtHometown.Text;
            string email = txtEmail.Text == "Nhập Email" ? "" : txtEmail.Text;

            Student sv = new Student(
                mssv,
                fname,
                lname,
                dtpDob.Value,
                cboGender.Text,
                phone,
                address,
                hometown,
                email,
                studentImage);

            if (sv.AddStudent())
            {
                MessageBox.Show("Thêm sinh viên thành công!");
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMSSV.Text = "Nhập MSSV";
            txtFname.Text = "Nhập họ và tên đệm";
            txtLname.Text = "Nhập tên";
            txtPhone.Text = "Nhập số điện thoại";
            txtAddress.Text = "Nhập địa chỉ";
            txtHometown.Text = "Nhập quê quán";
            txtEmail.Text = "Nhập Email";
            picStudent.Image = null;

            txtMSSV.Focus();
        }

        private void txtMSSV_Click(object sender, EventArgs e)
        {
            txtMSSV.Text = "";
        }

        private void txtFname_Click(object sender, EventArgs e)
        {
            txtFname.Text = "";
        }

        private void txtLname_Click(object sender, EventArgs e)
        {
            txtLname.Text = "";
        }

        private void txtPhone_Click(object sender, EventArgs e)
        {
            txtPhone.Text = "";
        }

        private void txtAddress_Click(object sender, EventArgs e)
        {
            txtAddress.Text = "";
        }

        private void txtHometown_Click(object sender, EventArgs e)
        {
            txtHometown.Text = "";
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
        }

        private void dtpDob_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
