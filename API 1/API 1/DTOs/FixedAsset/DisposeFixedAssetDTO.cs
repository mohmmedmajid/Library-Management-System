namespace API_1.DTOs.FixedAsset
{
    public class DisposeFixedAssetDTO
    {
        public int AssetID { get; set; }
        public DateTime DisposalDate { get; set; }
        public decimal DisposalValue { get; set; }
        public string? Notes { get; set; }
    }
}
