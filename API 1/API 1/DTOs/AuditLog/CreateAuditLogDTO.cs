namespace API_1.DTOs.AuditLog
{
    public class CreateAuditLogDTO
    {
        public int? UserID { get; set; }
        public string Action { get; set; } = string.Empty;
        public string? TableName { get; set; }
        public int? RecordID { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public string? IPAddress { get; set; }
    }
}
