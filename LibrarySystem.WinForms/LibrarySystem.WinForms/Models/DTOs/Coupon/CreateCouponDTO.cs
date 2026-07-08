using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateCouponDTO
    {
        public string CouponCode { get; set; } = string.Empty;
        public string CouponName { get; set; } = string.Empty;
        public string CouponNameAr { get; set; } = string.Empty;
        public string DiscountType { get; set; } = string.Empty;
        public decimal DiscountValue { get; set; }
        public decimal MinimumPurchaseAmount { get; set; } = 0;
        public decimal MaximumDiscountAmount { get; set; }
        public string ApplicableOn { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public int ProductID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UsageLimit { get; set; }
        public int UsageLimitPerCustomer { get; set; } = 1;
        public bool IsPublic { get; set; } = true;
        public string Description { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
    }
}