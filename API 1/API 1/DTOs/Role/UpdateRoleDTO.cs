namespace API_1.DTOs.Role
{
    public class UpdateRoleDTO
    {
        public int RoleID { get; set; } 
        public string RoleName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true; 
    }
}
