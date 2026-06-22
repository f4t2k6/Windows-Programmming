namespace ProjectMonHoc
{
    internal class Globals
    {
        public static int    GlobalUserId   { get; private set; }
        public static string GlobalUsername { get; set; }  = "";
        public static string GlobalRole     { get; private set; } = "";
        public static string GlobalEmail    { get; private set; } = "";
        public static int    GlobalMSSV     { get; set; }  = 0;

        /// <summary>
        /// Họ và tên đầy đủ (Fname + Lname) lấy từ bảng HR hoặc Student sau khi đăng nhập.
        /// Lưu vào đây để các Form khác hiển thị mà không cần query DB thêm lần nào.
        /// </summary>
        public static string GlobalFullName { get; set; } = "";

        /// <summary>
        /// Gọi ngay sau khi xác thực tài khoản thành công ở f_Login.
        /// fullName nên được truyền vào sau khi đã query thêm từ bảng HR/Student.
        /// </summary>
        public static void SetSession(int id, string username, string role,
                                      string email, string fullName = "")
        {
            GlobalUserId   = id;
            GlobalUsername = username;
            GlobalRole     = role;
            GlobalEmail    = email;
            GlobalFullName = fullName;
            GlobalMSSV     = (role == "Student") ? id : 0;
        }

        // Giữ lại để tương thích nếu có chỗ nào đang gọi SetGlobalUserID
        public static void SetGlobalUserID(int UserID)
        {
            GlobalUserId = UserID;
        }

        public static void ClearSession()
        {
            // Xóa toàn bộ dữ liệu phiên đăng nhập khỏi RAM (không đụng DB)
            GlobalUserId   = 0;
            GlobalUsername = "";
            GlobalRole     = "";
            GlobalEmail    = "";
            GlobalFullName = "";
            GlobalMSSV     = 0;
        }
    }
}