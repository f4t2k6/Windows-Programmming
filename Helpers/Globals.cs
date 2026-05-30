namespace ProjectMonHoc
{
    internal class Globals
    {
        public static int GlobalUserId { get; private set; }
        public static string GlobalUsername { get; set; } = "";
        public static string GlobalRole { get; private set; } = "";
        public static string GlobalEmail { get; private set; } = "";
        public static int GlobalMSSV { get; set; } = 0;

        public static void SetSession(int id, string username, string role, string email)
        {
            GlobalUserId = id;
            GlobalUsername = username;
            GlobalRole = role;
            GlobalEmail = email;
            GlobalMSSV = (role == "Student") ? id : 0; // THÊM DÒNG NÀY
        }

        // Giữ lại để tương thích nếu có chỗ nào đang gọi SetGlobalUserID
        public static void SetGlobalUserID(int UserID)
        {
            GlobalUserId = UserID;
        }

        public static void ClearSession()
        {
            GlobalUserId = 0;
            GlobalUsername = "";
            GlobalRole = "";
            GlobalEmail = "";
        }
    }
}