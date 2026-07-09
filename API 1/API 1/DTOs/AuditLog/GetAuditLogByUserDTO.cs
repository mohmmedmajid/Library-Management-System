namespace API_1.DTOs.AuditLog
{
    public class GetAuditLogByUserDTO
    {
        public int UserID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
