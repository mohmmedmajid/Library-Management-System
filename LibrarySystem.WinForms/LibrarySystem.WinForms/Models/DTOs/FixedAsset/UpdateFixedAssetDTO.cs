using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateFixedAssetDTO
    {
        public int AssetID { get; set; }
        public string AssetName { get; set; } = string.Empty;
        public string AssetNameAr { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public string Location { get; set; } = string.Empty;
        public int ResponsibleEmployee { get; set; }
        public string Status { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public DateTime WarrantyExpiry { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public DateTime NextMaintenanceDate { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}