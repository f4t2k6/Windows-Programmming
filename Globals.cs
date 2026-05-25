namespace ProjectMonHoc
{
    internal class Globals
    {
        public static int GlobalUserId { get; private set; }
        public static string GlobalUsername { get; set; } = "";
        public static string GlobalRole { get; private set; } = "";
        public static string GlobalEmail { get; private set; } = "";

        public static void SetSession(int id, string username, string role, string email)
        {
            GlobalUserId = id;
            GlobalUsername = username;
            GlobalRole = role;
            GlobalEmail = email;
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