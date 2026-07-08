using System;

namespace LibrarySystem.WinForms.Models.Purchasing
{
    public class Coupon
    {
        public int CouponID { get; set; }
        public string CouponCode { get; set; } = string.Empty;
        public string CouponName { get; set; } = string.Empty;
        public string CouponNameAr { get; set; } = string.Empty;
        public string DiscountType { get; set; } = string.Empty;
        public decimal DiscountValue { get; set; }
        public decimal MinimumPurchaseAmount { get; set; } = 0;
        public string ApplicableOn { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public int UsageCount { get; set; } = 0;
        public bool IsPublic { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}