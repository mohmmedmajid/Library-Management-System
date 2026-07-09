namespace API_1.Models
{
    public class PromotionalOffer
    {
        public int OfferID { get; set; }
        public string OfferName { get; set; } = string.Empty;
        public string OfferNameAr { get; set; } = string.Empty;
        public string OfferType { get; set; } = string.Empty;  
        public int? BuyQuantity { get; set; }
        public int? GetQuantity { get; set; }
        public int? BuyProductID { get; set; }
        public string? BuyProductName { get; set; }
        public int? GetProductID { get; set; }
        public string? GetProductName { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? BundlePrice { get; set; }
        public string ApplicableOn { get; set; } = string.Empty;  
        public int? CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public int Priority { get; set; } = 0;
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
    }
}