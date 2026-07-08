using System;

namespace LibrarySystem.WinForms.Models
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public string DiscountName { get; set; } = string.Empty;
        public string DiscountNameAr { get; set; } = string.Empty;
        public string DiscountType { get; set; } = string.Empty;
        public decimal DiscountValue { get; set; }
        public decimal MinimumPurchaseAmount { get; set; } = 0;
        public decimal? MaximumDiscountAmount { get; set; }
        public string ApplicableOn { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public int UsageCount { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}