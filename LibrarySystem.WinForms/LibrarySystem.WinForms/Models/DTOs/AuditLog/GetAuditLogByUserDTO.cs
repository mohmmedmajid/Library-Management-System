using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAuditLogByUserDTO
    {
        public int UserID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}