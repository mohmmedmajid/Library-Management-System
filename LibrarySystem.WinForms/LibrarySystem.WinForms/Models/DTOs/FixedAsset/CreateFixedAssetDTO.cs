using System;

public class CreateFixedAssetDTO
{
    public string AssetName { get; set; } = string.Empty;
    public string AssetNameAr { get; set; } = string.Empty;
    public int CategoryID { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalvageValue { get; set; } = 0;
    public string Location { get; set; } = string.Empty;
    public int? ResponsibleEmployee { get; set; }
    public string SerialNumber { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public DateTime? WarrantyExpiry { get; set; }
    public string Notes { get; set; } = string.Empty;
    public int CreatedBy { get; set; }
}