namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateAuditLogDTO
    {
        public int UserID { get; set; }
        public string Action { get; set; } = string.Empty;
        public string TableName { get; set; } = string.Empty;
        public int RecordID { get; set; }
        public string OldValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;
        public string IPAddress { get; set; } = string.Empty;
    }
}