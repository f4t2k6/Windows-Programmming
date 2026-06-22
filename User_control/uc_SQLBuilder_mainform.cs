using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectMonHoc.User_control
{
    public partial class uc_SQLBuilder_mainform : UserControl
    {
        // =============================================
        // KHỞI TẠO
        // =============================================
        public uc_SQLBuilder_mainform()
        {
            InitializeComponent();
        }

        // =============================================
        // PUBLIC API — được gọi từ f_createTB_DB
        // =============================================

        /// <summary>
        /// Đổ dữ liệu vào thẻ chat: hiển thị prompt người dùng và SQL do AI sinh ra.
        /// </summary>
        public void SetData(string userPrompt, string sqlCode)
        {
            lbl_Prompt.Text = "🧑 " + userPrompt;
            txt_SQL.Text    = sqlCode;
        }

        /// <summary>
        /// Khóa nút "Tạo bảng" khi AI trả về lỗi.
        /// </summary>
        public void DisableRunButton()
        {
            btn_RunSQL.Enabled   = false;
            btn_RunSQL.BackColor = Color.FromArgb(180, 180, 180);
            btn_RunSQL.Text      = "Không thể thực thi";
        }

        // =============================================
        // SỰ KIỆN NÚT TẠO BẢNG
        // =============================================
        private void btn_RunSQL_Click(object sender, EventArgs e)
        {
            string sql = txt_SQL.Text.Trim();
            if (string.IsNullOrEmpty(sql))
            {
                MessageBox.Show("Không có câu SQL để thực thi.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Dùng MY_DB đúng theo convention của project
                MY_DB db = new MY_DB();
                db.ExecuteNonQuery(sql);

                MessageBox.Show("✅ Tạo bảng thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                btn_RunSQL.Enabled   = false;
                btn_RunSQL.BackColor = Color.FromArgb(100, 180, 100);
                btn_RunSQL.Text      = "✔ Đã tạo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi thực thi SQL:\n" + ex.Message, "Lỗi SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =============================================
        // SỰ KIỆN NÚT SAO CHÉP
        // =============================================
        private void btn_Copy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_SQL.Text))
            {
                Clipboard.SetText(txt_SQL.Text);
                btn_Copy.Text = "✔ Đã sao chép";

                // Reset lại chữ nút sau 1.5 giây
                var timer = new System.Windows.Forms.Timer { Interval = 1500 };
                timer.Tick += (s, _) =>
                {
                    btn_Copy.Text = "📋 Sao chép";
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
        }
    }
}
