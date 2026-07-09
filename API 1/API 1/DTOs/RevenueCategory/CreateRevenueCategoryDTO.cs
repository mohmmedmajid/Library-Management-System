namespace API_1.DTOs.RevenueCategory
{
    public class CreateRevenueCategoryDTO
    {
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryNameAr { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int CreatedBy { get; set; }
    }
}