using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetLoginAttemptsByUsernameDTO
    {
        public string Username { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}