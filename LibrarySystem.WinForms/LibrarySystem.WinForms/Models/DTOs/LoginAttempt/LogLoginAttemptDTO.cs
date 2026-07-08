namespace LibrarySystem.WinForms.Models.DTOs
{
    public class LogLoginAttemptDTO
    {
        public string Username { get; set; } = string.Empty;
        public string IPAddress { get; set; } = string.Empty;
        public bool IsSuccessful { get; set; }
        public string FailureReason { get; set; } = string.Empty;
        public string UserAgent { get; set; } = string.Empty;
        public string DeviceType { get; set; } = string.Empty;
    }
}