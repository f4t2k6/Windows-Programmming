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
    // =========================================================
    // PHẦN 1: LỚP GIAO DIỆN FORM CỦA BẠN (PHẢI ĐỂ LÊN TRÊN CÙNG)
    // =========================================================
    public partial class complex_number : Form
    {
        // Khai báo 2 biến để lưu Số phức 1 và Số phức 2
        ComplexNumber x = new ComplexNumber();
        ComplexNumber y = new ComplexNumber();

        public complex_number()
        {
            InitializeComponent();
        }

        // Các hàm có sẵn khi bạn lỡ click nhầm vào giao diện
        private void label3_Click(object sender, EventArgs e) { }
        private void ImaginaryLabel_Click(object sender, EventArgs e) { }
        private void complex_number_Load(object sender, EventArgs e) { }

        // =========================================================
        // PHẦN LOGIC CHO CÁC NÚT BẤM
        // =========================================================

        private void FirstButton_Click(object sender, EventArgs e)
        {
            x.Real = int.Parse(RealTextBox.Text);
            x.Imaginary = int.Parse(ImaginaryTextBox.Text);

            RealTextBox.Clear();
            ImaginaryTextBox.Clear();

            StatusLabel.Text = "Notice: Đã lưu số thứ 1 là " + x.ToString();
        }

        private void SecondButton_Click(object sender, EventArgs e)
        {
            y.Real = int.Parse(RealTextBox.Text);
            y.Imaginary = int.Parse(ImaginaryTextBox.Text);

            RealTextBox.Clear();
            ImaginaryTextBox.Clear();

            StatusLabel.Text = "Notice: Đã lưu số thứ 2 là " + y.ToString();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = "Notice: " + x.ToString() + " + " + y.ToString() + " = " + (x + y).ToString();
        }

        private void SubstractButton_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = "Notice: " + x.ToString() + " - " + y.ToString() + " = " + (x - y).ToString();
        }

        private void MultifyButton_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = "Notice: " + x.ToString() + " * " + y.ToString() + " = " + (x * y).ToString();
        }
    }

    // =========================================================
    // PHẦN 2: LỚP SỐ PHỨC (ĐÃ CHUYỂN XUỐNG DƯỚI)
    // =========================================================
    public class ComplexNumber
    {
        public int Real { get; set; }
        public int Imaginary { get; set; }

        public ComplexNumber(int r = 0, int i = 0)
        {
            Real = r;
            Imaginary = i;
        }

        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }

        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
        {
            int r = (c1.Real * c2.Real) - (c1.Imaginary * c2.Imaginary);
            int i = (c1.Real * c2.Imaginary) + (c1.Imaginary * c2.Real);
            return new ComplexNumber(r, i);
        }

        public override string ToString()
        {
            if (Imaginary >= 0)
                return $"({Real} + {Imaginary}i)";
            else
                return $"({Real} - {Math.Abs(Imaginary)}i)";
        }
    }
}