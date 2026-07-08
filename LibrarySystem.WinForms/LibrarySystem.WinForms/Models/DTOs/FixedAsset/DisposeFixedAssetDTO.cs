using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class DisposeFixedAssetDTO
    {
        public int AssetID { get; set; }
        public DateTime DisposalDate { get; set; }
        public decimal DisposalValue { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}