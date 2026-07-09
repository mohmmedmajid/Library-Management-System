namespace API_1.Models
{
    public class AuditLog
    {
        public int AuditID { get; set; }
        public int? UserID { get; set; }
        public string? UserName { get; set; }
        public string Action { get; set; } = string.Empty;
        public string? TableName { get; set; }
        public int? RecordID { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public string? IPAddress { get; set; }
        public DateTime ActionDate { get; set; } = DateTime.Now;
    }
}
