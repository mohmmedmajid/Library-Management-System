namespace API_1.Models
{
    public class Session
    {
        public int SessionID { get; set; }
        public string SessionToken { get; set; } = string.Empty;
        public int UserID { get; set; }
        public DateTime LoginDate { get; set; } = DateTime.Now;
        public DateTime LastActivityDate { get; set; } = DateTime.Now;
        public DateTime? LogoutDate { get; set; }
        public string? IPAddress { get; set; }
        public string? UserAgent { get; set; }
        public string? DeviceType { get; set; }
        public bool IsActive { get; set; } = true;
        public string? Username { get; set; }
        public string? FullName { get; set; }
        public int? RoleID { get; set; }
        public string? RoleName { get; set; }
        public int? MinutesSinceLastActivity { get; set; }
        public int? SessionDurationMinutes { get; set; }
    }
}
