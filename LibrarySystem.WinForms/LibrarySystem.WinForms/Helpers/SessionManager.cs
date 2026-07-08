namespace LibrarySystem.WinForms.Helpers
{
    public static class SessionManager


    {

        public static int UserId { get; set; }
        public static string Username { get; set; } = "";
        public static string FullName { get; set; } = "";
        public static string Role { get; set; } = "";
        public static string Token { get; set; } = "";


        public static bool IsAdmin => Role == "Admin";
        public static bool IsCashier => Role == "Cashier";
        public static bool IsObserver => Role == "Observer";


        public static void Login(int userId, string username, string fullName, string role, string token)
        {
            UserId = userId;
            Username = username;
            FullName = fullName;
            Role = role;
            Token = token;
        }


        public static void Logout()
        {
            UserId = 0;
            Username = "";
            FullName = "";
            Role = "";
            Token = "";
        }

        public static bool IsLoggedIn => UserId > 0;
    }
}