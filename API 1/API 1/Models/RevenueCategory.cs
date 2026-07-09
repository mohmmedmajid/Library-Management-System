namespace API_1.Models
{
    public class RevenueCategory
    {
        public int RevenueCategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryNameAr { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }

        public int RevenueCount { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;
    }
}