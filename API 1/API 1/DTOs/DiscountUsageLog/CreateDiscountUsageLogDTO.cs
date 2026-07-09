namespace API_1.DTOs.DiscountUsageLog
{
    public class CreateDiscountUsageLogDTO
    {
        public string UsageType { get; set; } = string.Empty;  
        public int? DiscountID { get; set; }
        public int? CouponID { get; set; }
        public int? OfferID { get; set; }
        public int InvoiceID { get; set; }
        public int? CustomerID { get; set; }
        public int? ProductID { get; set; }
        public decimal OriginalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public string? Notes { get; set; }
    }
}