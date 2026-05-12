using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day01
{
    public partial class f_AddStudent : Form
    {
        public f_AddStudent()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }

        private void f_AddStudent_Load(object sender, EventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        byte[]? studentImage = null;

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picStudent.Image = Image.FromFile(ofd.FileName);
                MemoryStream ms = new MemoryStream();
                picStudent.Image.Save(ms, picStudent.Image.RawFormat);
                studentImage = ms.ToArray();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSSV.Text) || string.IsNullOrEmpty(txtLname.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ MSSV và Tên!", "Cảnh báo");
                return;
            }

            if (studentImage == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh đại diện cho sinh viên!", "Cảnh báo");
                return;
            }

            Student sv = new Student(
                int.Parse(txtMSSV.Text), txtFname.Text, txtLname.Text,
                dtpDob.Value, cboGender.Text, txtPhone.Text,
                txtAddress.Text, txtHometown.Text, txtEmail.Text, studentImage);

            if (sv.AddStudent())
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo");
            else
                MessageBox.Show("Thêm thất bại! MSSV có thể đã tồn tại.", "Lỗi");
        }

        private void txtMSSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtLname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void dtpDob_ValueChanged(object sender, EventArgs e) { }
    }
}