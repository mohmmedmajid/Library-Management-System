namespace API_1.Models
{
    public class LoginAttempt
    {
        public int AttemptID { get; set; }
        public string Username { get; set; } = string.Empty;
        public DateTime AttemptDate { get; set; } = DateTime.Now;
        public string? IPAddress { get; set; }
        public bool IsSuccessful { get; set; }
        public string? FailureReason { get; set; }
        public string? UserAgent { get; set; }
        public string? DeviceType { get; set; }
    }
}
