using System;

namespace LibrarySystem.WinForms.Models.Advanced
{
    public class LoginAttempt
    {
        public int AttemptID { get; set; }
        public string Username { get; set; } = string.Empty;
        public DateTime AttemptDate { get; set; } = DateTime.Now;
        public string IPAddress { get; set; } = string.Empty;
        public bool IsSuccessful { get; set; }
        public string FailureReason { get; set; } = string.Empty;
        public string DeviceType { get; set; } = string.Empty;
    }
}