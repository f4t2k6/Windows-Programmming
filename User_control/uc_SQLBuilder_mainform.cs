using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMonHoc.User_control
{
    public partial class uc_SQLBuilder_mainform : UserControl
    {
        public uc_SQLBuilder_mainform()
        {
            InitializeComponent();

            // Cơ chế tự đẩy các thành phần xuống khi câu hỏi dài làm lbl_Prompt phình to
            lbl_Prompt.SizeChanged += (s, e) =>
            {
                txt_SQLResult.Top = lbl_Prompt.Bottom + 10;
                btn_RunSQL.Top = txt_SQLResult.Bottom + 10;
                this.Height = btn_RunSQL.Bottom + 15; // Tự co giãn tổng chiều cao thẻ chat
            };
        }
        // Hàm đổ dữ liệu từ Form chính sang
        public void SetData(string prompt, string sqlCode)
        {
            lbl_Prompt.Text = prompt;
            txt_SQLResult.Text = sqlCode;
        }

        // Hàm khóa nút nếu AI trả về lỗi mạng/API
        public void DisableRunButton()
        {
            btn_RunSQL.Enabled = false;
        }

        // SỰ KIỆN CLICK: THỰC THI TẠO BẢNG XUỐNG DATABASE
        private void btn_RunSQL_Click(object sender, EventArgs e)
        {
            string sqlCode = txt_SQLResult.Text.Trim();
            string sqlUpper = sqlCode.ToUpper();

            // 1. Kiểm tra an toàn (Chống Prompt Injection phá hoại DB)
            string[] blacklist = { "DROP", "DELETE", "TRUNCATE", "UPDATE", "ALTER" };
            foreach (string word in blacklist)
            {
                if (sqlUpper.Contains(word))
                {
                    MessageBox.Show($"Cảnh báo bảo mật: Phát hiện từ khóa nguy hiểm [{word}] bị cấm!",
                                    "Ngăn chặn hành vi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 2. Ép luật nghiêm ngặt: Phải là lệnh tạo bảng
            if (!sqlUpper.StartsWith("CREATE TABLE"))
            {
                MessageBox.Show("Hệ thống chỉ cho phép thực thi lệnh [CREATE TABLE] bằng ngôn ngữ tự nhiên!",
                                "Sai cấu trúc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Thực thi trực tiếp vào Database
            // Lưu ý: Thay MY_DB bằng class kết nối database thực tế trong dự án của bạn
            MY_DB my_db = new MY_DB();
            try
            {
                SqlCommand cmd = new SqlCommand(sqlCode, my_db.conn);
                my_db.openConnection();
                cmd.ExecuteNonQuery();

                MessageBox.Show("🎉 Tuyệt vời! Bảng mới đã được cấu trúc thành công trên SQL Server!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btn_RunSQL.Enabled = false; // Tạo xong thì khóa nút lại chống bấm liên tục
                btn_RunSQL.Text = "✓ Đã tạo bảng";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi SQL: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                my_db.closeConnection();
            }
        }
    }
}
