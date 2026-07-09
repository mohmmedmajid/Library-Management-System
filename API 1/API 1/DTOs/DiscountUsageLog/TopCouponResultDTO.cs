namespace API_1.DTOs.DiscountUsageLog
{
    public class TopCouponResultDTO
    {
        public int CouponID { get; set; }
        public string CouponCode { get; set; } = string.Empty;
        public string CouponName { get; set; } = string.Empty;
        public string CouponNameAr { get; set; } = string.Empty;
        public int UsageCount { get; set; }
        public decimal TotalDiscountAmount { get; set; }
    }
}