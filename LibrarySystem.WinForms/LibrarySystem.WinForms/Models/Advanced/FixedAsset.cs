using System;

namespace LibrarySystem.WinForms.Models.Advanced
{
    public class FixedAsset
    {
        public int AssetID { get; set; }
        public string AssetCode { get; set; } = string.Empty;
        public string AssetName { get; set; } = string.Empty;
        public string AssetNameAr { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalvageValue { get; set; } = 0;
        public decimal DepreciableValue { get; set; }
        public decimal AccumulatedDepreciation { get; set; } = 0;
        public decimal BookValue { get; set; }
        public string Status { get; set; } = "InUse";
        public string Location { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int UsefulLifeYears { get; set; }
        public decimal AnnualDepreciationRate { get; set; }
        public int AgeInMonths { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}