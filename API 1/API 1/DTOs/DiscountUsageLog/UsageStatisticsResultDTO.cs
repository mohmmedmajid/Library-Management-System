namespace API_1.DTOs.DiscountUsageLog
{
    public class UsageStatisticsResultDTO
    {
        public string UsageType { get; set; } = string.Empty;
        public int UsageCount { get; set; }
        public decimal TotalDiscountAmount { get; set; }
        public decimal AvgDiscountAmount { get; set; }
        public decimal TotalOriginalAmount { get; set; }
        public decimal TotalFinalAmount { get; set; }
    }
}