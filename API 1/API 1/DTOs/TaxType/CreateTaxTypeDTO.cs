namespace API_1.DTOs.TaxType
{
    public class CreateTaxTypeDTO
    {
        public string TaxCode { get; set; } = string.Empty;
        public string TaxName { get; set; } = string.Empty;
        public string TaxNameAr { get; set; } = string.Empty;
        public decimal TaxRate { get; set; }
        public string TaxCategory { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public int? CreatedBy { get; set; }
    }
}
