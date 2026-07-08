using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAllAuditLogsDTO
    {
        public string Action { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Top { get; set; } = 100;
    }
}