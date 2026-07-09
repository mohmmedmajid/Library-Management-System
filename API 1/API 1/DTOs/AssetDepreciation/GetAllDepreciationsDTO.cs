namespace API_1.DTOs.AssetDepreciation
{
    public class GetAllDepreciationsDTO
    {
        public int? FiscalYear { get; set; }
        public int? FiscalMonth { get; set; }
        public string? Status { get; set; }
    }
}
