namespace API_1.DTOs.LoginAttempt
{
    public class GetAllLoginAttemptsDTO
    {
        public bool? IsSuccessful { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Top { get; set; } = 100;
    }
}
