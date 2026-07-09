namespace API_1.DTOs.User
{
    public class ChangePasswordDTO
    {
        public int UserID { get; set; }
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
