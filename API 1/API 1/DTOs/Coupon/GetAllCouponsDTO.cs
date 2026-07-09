namespace API_1.DTOs.Coupon
{
    public class GetAllCouponsDTO
    {
        public bool? IsActive { get; set; }
        public bool CurrentOnly { get; set; } = false;
    }
}