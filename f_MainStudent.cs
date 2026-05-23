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
    public partial class f_MainStudent : Form
    {
        private Form? activeForm = null;
        public f_MainStudent()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm, Panel targetPanel)
        {
            // 1. Nếu đang có một Form con khác mở, đóng hoàn toàn để giải phóng bộ nhớ
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            // 2. Gán Form con mới vào biến theo dõi
            activeForm = childForm;

            // 3. Thiết lập bộ 3 thuộc tính gác cổng quan trọng
            childForm.TopLevel = false;                      // Biến form thành control nội bộ
            childForm.FormBorderStyle = FormBorderStyle.None; // Xóa sạch khung viền và thanh tiêu đề
            childForm.Dock = DockStyle.Fill;                // Tự động kéo giãn khít theo kích thước Panel

            // 4. Dọn dẹp Panel và nạp Form con vào
            targetPanel.Controls.Clear();                    // Xóa sạch các điều khiển/giao diện cũ trong panel
            targetPanel.Controls.Add(childForm);            // Thêm form con vào panel
            targetPanel.Tag = childForm;                    // Lưu trữ tham chiếu nếu cần dùng sau này

            // 5. Hiển thị Form con lên màn hình
            childForm.BringToFront();                       // Đẩy lên lớp trên cùng để không bị che khuất
            childForm.Show();                               // Kích hoạt hiển thị
        }
    }
}
