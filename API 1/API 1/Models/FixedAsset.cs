namespace API_1.Models
{
    public class FixedAsset
    {
        public int AssetID { get; set; }
        public string AssetCode { get; set; } = string.Empty;
        public string AssetName { get; set; } = string.Empty;
        public string AssetNameAr { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalvageValue { get; set; } = 0;
        public decimal DepreciableValue { get; set; }         
        public decimal AccumulatedDepreciation { get; set; } = 0;
        public decimal BookValue { get; set; }                   
        public string Status { get; set; } = "InUse";            
        public string? Location { get; set; }
        public int? ResponsibleEmployee { get; set; }
        public string? SerialNumber { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public DateTime? WarrantyExpiry { get; set; }
        public DateTime? LastMaintenanceDate { get; set; }
        public DateTime? NextMaintenanceDate { get; set; }
        public DateTime? DisposalDate { get; set; }
        public decimal? DisposalValue { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? CategoryName { get; set; }
        public string? EmployeeName { get; set; }
        public string? CreatedByName { get; set; }
        public int? UsefulLifeYears { get; set; }
        public decimal? AnnualDepreciationRate { get; set; }
        public int? AgeInMonths { get; set; }
    }
}
