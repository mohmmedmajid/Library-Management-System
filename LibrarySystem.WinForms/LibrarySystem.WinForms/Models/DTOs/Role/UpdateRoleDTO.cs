namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateRoleDTO
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}