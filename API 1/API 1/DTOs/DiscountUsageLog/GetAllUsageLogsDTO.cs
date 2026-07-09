namespace API_1.DTOs.DiscountUsageLog
{
    public class GetAllUsageLogsDTO
    {
        public string? UsageType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}