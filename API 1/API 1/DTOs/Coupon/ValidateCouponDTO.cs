namespace API_1.DTOs.Coupon
{
    public class ValidateCouponDTO
    {
        public string CouponCode { get; set; } = string.Empty;
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public decimal PurchaseAmount { get; set; }
    }
}