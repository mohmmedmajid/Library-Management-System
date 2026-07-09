namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateSessionDTO
    {
        public int UserID { get; set; }
        public string IPAddress { get; set; } = string.Empty;
        public string UserAgent { get; set; } = string.Empty;
        public string DeviceType { get; set; } = string.Empty;
    }
}