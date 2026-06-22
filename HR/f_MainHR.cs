using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using YourApp;

namespace ProjectMonHoc
{
    //Bỏ lỗi CA1416
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]

    public partial class f_MainHR : Form
    {
        private Form? activeForm = null;
        public f_MainHR()
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

        private void btn_Logout_MainHR_Click(object sender, EventArgs e)
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

        private void btn_ListStudent_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_ListStudent(), pnl_content_MainHR);
        }

        private void btn_ListScore_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_ListScore(-1, ""), pnl_content_MainHR);
        }

        private void btn_ManageCourse_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_ManageCourse(), pnl_content_MainHR);
        }

        private void pnl_content_MainHR_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_MainHR_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pb_Logo_HR_Click(object sender, EventArgs e)
        {

        }

        private void button_Classroom_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmClassroom(), pnl_content_MainHR);
        }

        private void button_Chart_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormThongKe(), pnl_content_MainHR);
        }

        private void button_Assign_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_Assign("HR", Globals.GlobalUserId.ToString()), pnl_content_MainHR);
        }

        private void button_Contact_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_Contact(Globals.GlobalUserId), pnl_content_MainHR);
        }

        private void pictureBox_Quanlylophoc_Click(object sender, EventArgs e)
        {

        }

        // ============================================================
        // MỚI: Hiển thị ảnh đại diện (bo tròn) + thông tin người dùng từ bảng HR
        // ============================================================
        private void f_MainHR_Load(object sender, EventArgs e)
        {
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            // ── Admin: chỉ hiện chữ "Admin", dùng ảnh mặc định ──────
            if (Globals.GlobalRole == "Admin")
            {
                label_Info.Text = "Admin";
                LoadAvatarImage(null);
                return;
            }

            // ── HR: lấy họ tên + ảnh đại diện từ bảng HR theo MSGV đang đăng nhập ──
            MY_DB my_db = new MY_DB();
            try
            {
                my_db.openConnection();

                string sql = "SELECT Fname, Lname, Pic FROM HR WHERE MSGV = @msgv";
                SqlCommand cmd = new SqlCommand(sql, my_db.conn);
                cmd.Parameters.Add("@msgv", SqlDbType.NVarChar, 20).Value = Globals.GlobalUserId.ToString();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string fullName = $"{reader["Fname"]} {reader["Lname"]}".Trim();
                        label_Info.Text = $"{fullName}\nID: {Globals.GlobalUserId}";

                        byte[]? picBytes = reader["Pic"] != DBNull.Value
                            ? (byte[])reader["Pic"]
                            : null;

                        LoadAvatarImage(picBytes);
                    }
                    else
                    {
                        // Không tìm thấy hồ sơ HR -> hiển thị tạm username + ID
                        label_Info.Text = $"{Globals.GlobalUsername}\nID: {Globals.GlobalUserId}";
                        LoadAvatarImage(null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin người dùng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadAvatarImage(null);
            }
            finally
            {
                my_db.closeConnection();
            }
        }

        // Nạp ảnh đại diện của người dùng đang đăng nhập (nếu có) và bo tròn
        private void LoadAvatarImage(byte[]? imageBytes)
        {
            Image baseImage;

            if (imageBytes != null && imageBytes.Length > 0)
            {
                // Có ảnh riêng của HR trong DB -> dùng ảnh đó
                using (MemoryStream ms = new MemoryStream(imageBytes))
                using (Image temp = Image.FromStream(ms))
                {
                    baseImage = new Bitmap(temp); // copy ra để stream có thể đóng an toàn
                }
            }
            else
            {
                // Không có ảnh riêng -> dùng ảnh mặc định đang gán sẵn trong Designer
                baseImage = pictureBox_Avatar.Image ?? Properties.Resources.icons8_user_100;
            }

            pictureBox_Avatar.Image = GetRoundedImage(
                baseImage,
                pictureBox_Avatar.Width,
                pictureBox_Avatar.Height);
        }

        // Bo tròn ảnh đại diện theo kích thước PictureBox
        private Image GetRoundedImage(Image sourceImage, int width, int height)
        {
            Bitmap rounded = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(rounded))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, width, height);
                    g.SetClip(path);
                    g.DrawImage(sourceImage, 0, 0, width, height);
                }
            }
            return rounded;
        }

        private void label_Info_Click(object sender, EventArgs e)
        {

        }
    }
}