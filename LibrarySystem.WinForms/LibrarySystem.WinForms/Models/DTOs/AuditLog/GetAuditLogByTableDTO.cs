using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAuditLogByTableDTO
    {
        public string TableName { get; set; } = string.Empty;
        public int RecordID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}