namespace API_1.DTOs.LoginAttempt
{
    public class LogLoginAttemptDTO
    {
        public string Username { get; set; } = string.Empty;
        public string? IPAddress { get; set; }
        public bool IsSuccessful { get; set; }
        public string? FailureReason { get; set; }
        public string? UserAgent { get; set; }
        public string? DeviceType { get; set; }
    }
}
