namespace API_1.Models
{
    public class FixedAssetCategory
    {
        public int CategoryID { get; set; }
        public string CategoryCode { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryNameAr { get; set; } = string.Empty;
        public string DepreciationMethod { get; set; } = string.Empty;  
        public int UsefulLifeYears { get; set; }
        public decimal AnnualDepreciationRate { get; set; }
        public decimal SalvageValuePercent { get; set; } = 0;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
    }
}
