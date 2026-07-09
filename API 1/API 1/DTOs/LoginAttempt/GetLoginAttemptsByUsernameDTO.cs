namespace API_1.DTOs.LoginAttempt
{
    public class GetLoginAttemptsByUsernameDTO
    {
        public string Username { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
