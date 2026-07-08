using System;

namespace LibrarySystem.WinForms.Models.Advanced
{
    public class Session
    {
        public int SessionID { get; set; }
        public string SessionToken { get; set; } = string.Empty;
        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public DateTime LoginDate { get; set; } = DateTime.Now;
        public DateTime LastActivityDate { get; set; } = DateTime.Now;
        public string IPAddress { get; set; } = string.Empty;
        public string DeviceType { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public int SessionDurationMinutes { get; set; }
    }
}