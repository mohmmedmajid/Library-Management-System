namespace API_1.DTOs.RevenueCategory
{
    public class UpdateRevenueCategoryDTO
    {
        public int RevenueCategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryNameAr { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}