using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateAssetDepreciationDTO
    {
        public int AssetID { get; set; }
        public DateTime DepreciationDate { get; set; }
        public string DepreciationPeriod { get; set; } = string.Empty;
        public int FiscalYear { get; set; }
        public int FiscalMonth { get; set; }
        public int CreatedBy { get; set; }
    }
}