namespace API_1.DTOs.User
{
    public class UpdateUserDTO
    {
        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
