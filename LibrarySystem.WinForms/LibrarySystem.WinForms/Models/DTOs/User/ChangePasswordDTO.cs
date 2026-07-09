namespace LibrarySystem.WinForms.Models.DTOs
{
    public class ChangePasswordDTO
    {
        public int UserID { get; set; }
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}