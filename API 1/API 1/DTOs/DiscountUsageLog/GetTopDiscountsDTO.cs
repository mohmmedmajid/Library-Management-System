namespace API_1.DTOs.DiscountUsageLog
{
    public class GetTopDiscountsDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TopCount { get; set; } = 10;
    }
}