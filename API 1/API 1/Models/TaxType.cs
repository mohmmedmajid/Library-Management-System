    namespace API_1.Models
{
    public class TaxType
    {
        public int TaxTypeID { get; set; }
        public string TaxCode { get; set; } = string.Empty;
        public string TaxName { get; set; } = string.Empty;
        public string TaxNameAr { get; set; } = string.Empty;
        public decimal TaxRate { get; set; }                         
        public string TaxCategory { get; set; } = string.Empty;     
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime EffectiveFrom { get; set; } = DateTime.Now;
        public DateTime? EffectiveTo { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }        
        public string? CreatedByName { get; set; }
    }
}
