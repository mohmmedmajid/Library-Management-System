namespace API_1.DTOs.AuditLog
{
    public class GetAllAuditLogsDTO
    {
        public string? Action { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Top { get; set; } = 100;
    }
}
