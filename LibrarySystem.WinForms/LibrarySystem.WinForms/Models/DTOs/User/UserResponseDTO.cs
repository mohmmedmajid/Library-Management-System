using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UserResponseDTO
    {
        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int RoleID { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}