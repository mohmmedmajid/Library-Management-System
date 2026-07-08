using System;

namespace LibrarySystem.WinForms.Models.Core
{
    public class AuditLog
    {
        public int AuditID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string TableName { get; set; } = string.Empty;
        public int RecordID { get; set; }
        public string OldValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;
        public string IPAddress { get; set; } = string.Empty;
        public DateTime ActionDate { get; set; } = DateTime.Now;
    }
}