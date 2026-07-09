namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateUserDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int RoleID { get; set; }
        public int CreatedBy { get; set; }
    }
}