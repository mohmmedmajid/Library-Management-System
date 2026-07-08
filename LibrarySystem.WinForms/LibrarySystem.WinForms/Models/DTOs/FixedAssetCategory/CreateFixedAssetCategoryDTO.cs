namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateFixedAssetCategoryDTO
    {
        public string CategoryCode { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryNameAr { get; set; } = string.Empty;
        public string DepreciationMethod { get; set; } = string.Empty;
        public int UsefulLifeYears { get; set; }
        public decimal AnnualDepreciationRate { get; set; }
        public decimal SalvageValuePercent { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
    }
}