using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    //Bỏ lỗi CA1416
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]

    public partial class f_AddStudent : Form
    {
        public f_AddStudent()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtpDob_ValueChanged(object sender, EventArgs e) { }

        private void picStudent_Click(object sender, EventArgs e) { }

        private void f_AddStudent_Load(object sender, EventArgs e)
        {
            // Hiển thị người đang thao tác trên thanh tiêu đề
            this.Text = $"Thêm sinh viên — Thao tác bởi {Globals.GlobalUsername}";
        }

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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMSSV.Text = "Nhập MSSV";
            txtFname.Text = "Nhập họ và tên đệm";
            txtLname.Text = "Nhập tên";
            txtPhone.Text = "Nhập số điện thoại";
            txtAddress.Text = "Nhập địa chỉ";
            txtHometown.Text = "Nhập quê quán";
            txtEmail.Text = "Nhập email";
            cboGender.SelectedIndex = -1;
            dtpDob.Value = new DateTime(2008, 1, 1);
            picStudent.Image = null;
            studentImage = null;
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
    }
}