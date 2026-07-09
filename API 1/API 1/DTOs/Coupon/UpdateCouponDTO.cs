namespace API_1.DTOs.Coupon
{
    public class UpdateCouponDTO
    {
        public int CouponID { get; set; }
        public string CouponCode { get; set; } = string.Empty;
        public string CouponName { get; set; } = string.Empty;
        public string CouponNameAr { get; set; } = string.Empty;
        public string DiscountType { get; set; } = string.Empty;
        public decimal DiscountValue { get; set; }
        public decimal MinimumPurchaseAmount { get; set; }
        public decimal? MaximumDiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? UsageLimit { get; set; }
        public int UsageLimitPerCustomer { get; set; }
        public bool IsPublic { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}