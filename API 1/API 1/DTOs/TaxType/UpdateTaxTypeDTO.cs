namespace API_1.DTOs.TaxType
{
    public class UpdateTaxTypeDTO
    {
        public int TaxTypeID { get; set; }
        public string TaxCode { get; set; } = string.Empty;
        public string TaxName { get; set; } = string.Empty;
        public string TaxNameAr { get; set; } = string.Empty;
        public decimal TaxRate { get; set; }
        public string TaxCategory { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public bool IsActive { get; set; }
    }
}
