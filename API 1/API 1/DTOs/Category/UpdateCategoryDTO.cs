namespace API_1.DTOs.Category
{
    public class UpdateCategoryDTO
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryNameAr { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
