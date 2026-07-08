using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdatePromotionalOfferDTO
    {
        public int OfferID { get; set; }
        public string OfferName { get; set; } = string.Empty;
        public string OfferNameAr { get; set; } = string.Empty;
        public string OfferType { get; set; } = string.Empty;
        public int BuyQuantity { get; set; }
        public int GetQuantity { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal BundlePrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}