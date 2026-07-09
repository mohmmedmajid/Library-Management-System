namespace API_1.DTOs.Session
{
    public class CreateSessionDTO
    {
        public int UserID { get; set; }
        public string? IPAddress { get; set; }
        public string? UserAgent { get; set; }
        public string? DeviceType { get; set; }
    }
}
