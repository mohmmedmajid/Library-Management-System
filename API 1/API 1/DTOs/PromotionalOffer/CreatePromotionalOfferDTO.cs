namespace API_1.DTOs.PromotionalOffer
{
    public class CreatePromotionalOfferDTO
    {
        public string OfferName { get; set; } = string.Empty;
        public string OfferNameAr { get; set; } = string.Empty;
        public string OfferType { get; set; } = string.Empty;  
        public int? BuyQuantity { get; set; }
        public int? GetQuantity { get; set; }
        public int? BuyProductID { get; set; }
        public int? GetProductID { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? BundlePrice { get; set; }
        public string ApplicableOn { get; set; } = string.Empty;  
        public int? CategoryID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; } = 0;
        public string? Description { get; set; }
        public int CreatedBy { get; set; }
    }
}