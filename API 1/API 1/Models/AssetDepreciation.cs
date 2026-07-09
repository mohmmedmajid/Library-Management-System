namespace API_1.Models
{
    public class AssetDepreciation
    {
        public int DepreciationID { get; set; }
        public int AssetID { get; set; }
        public DateTime DepreciationDate { get; set; }
        public string DepreciationPeriod { get; set; } = string.Empty;  
        public int FiscalYear { get; set; }
        public int? FiscalMonth { get; set; }
        public decimal DepreciationAmount { get; set; }
        public decimal AccumulatedDepreciation { get; set; }
        public decimal BookValue { get; set; }
        public int? JournalEntryID { get; set; }
        public string Status { get; set; } = "Draft";          
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? AssetCode { get; set; }
        public string? AssetName { get; set; }
        public string? JournalEntryNumber { get; set; }
        public string? CreatedByName { get; set; }
    }
}
