namespace API_1.Models
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public string DiscountName { get; set; } = string.Empty;
        public string DiscountNameAr { get; set; } = string.Empty;
        public string DiscountType { get; set; } = string.Empty;  
        public decimal DiscountValue { get; set; }
        public decimal MinimumPurchaseAmount { get; set; } = 0;
        public decimal? MaximumDiscountAmount { get; set; }
        public string ApplicableOn { get; set; } = string.Empty;  
        public int? CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public int? ProductID { get; set; }
        public string? ProductName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public int? UsageLimit { get; set; }
        public int UsageCount { get; set; } = 0;
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
    }
}