namespace API_1.Models
{
    public class DiscountUsageLog
    {
        public int UsageID { get; set; }
        public string UsageType { get; set; } = string.Empty;  
        public int? DiscountID { get; set; }
        public string? DiscountName { get; set; }
        public int? CouponID { get; set; }
        public string? CouponCode { get; set; }
        public string? CouponName { get; set; }
        public int? OfferID { get; set; }
        public string? OfferName { get; set; }
        public int InvoiceID { get; set; }
        public string? InvoiceNumber { get; set; }
        public int? CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public int? ProductID { get; set; }
        public string? ProductName { get; set; }
        public decimal OriginalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public DateTime UsageDate { get; set; } = DateTime.Now;
        public string? Notes { get; set; }
    }
}