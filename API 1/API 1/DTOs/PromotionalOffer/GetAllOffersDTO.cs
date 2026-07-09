namespace API_1.DTOs.PromotionalOffer
{
    public class GetAllOffersDTO
    {
        public bool? IsActive { get; set; }
        public bool CurrentOnly { get; set; } = false;
    }
}