namespace API_1.DTOs.User
{
    public class CreateUserDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; 
        public string FullName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int RoleID { get; set; }
        public int CreatedBy { get; set; }

    }
}
