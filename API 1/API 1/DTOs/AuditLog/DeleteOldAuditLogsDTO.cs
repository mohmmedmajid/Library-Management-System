namespace API_1.DTOs.AuditLog
{
    public class DeleteOldAuditLogsDTO
    {
        public int DaysToKeep { get; set; } = 90;
    }
}
