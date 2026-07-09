namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateUserDTO
    {
        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int RoleID { get; set; }
        public bool IsActive { get; set; } = true;
    }
}