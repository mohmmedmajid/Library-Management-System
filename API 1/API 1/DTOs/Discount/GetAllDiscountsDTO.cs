namespace API_1.DTOs.Discount
{
    public class GetAllDiscountsDTO
    {
        public bool? IsActive { get; set; }
        public bool CurrentOnly { get; set; } = false;
    }
}