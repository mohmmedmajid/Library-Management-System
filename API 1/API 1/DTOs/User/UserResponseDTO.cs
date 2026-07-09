namespace API_1.DTOs.User
{
    public class UserResponseDTO
    {
        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int RoleID { get; set; }
        public string? RoleName { get; set; }
        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
