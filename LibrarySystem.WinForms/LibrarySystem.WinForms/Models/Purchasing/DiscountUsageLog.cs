using System;

namespace LibrarySystem.WinForms.Models.Purchasing
{
    public class DiscountUsageLog
    {
        public int UsageID { get; set; }
        public string UsageType { get; set; } = string.Empty;
        public string DiscountName { get; set; } = string.Empty;
        public string CouponCode { get; set; } = string.Empty;
        public string OfferName { get; set; } = string.Empty;
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal OriginalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public DateTime UsageDate { get; set; } = DateTime.Now;
    }
}