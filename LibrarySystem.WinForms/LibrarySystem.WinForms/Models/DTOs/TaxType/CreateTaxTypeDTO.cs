using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateTaxTypeDTO
    {
        public string TaxCode { get; set; } = string.Empty;
        public string TaxName { get; set; } = string.Empty;
        public string TaxNameAr { get; set; } = string.Empty;
        public decimal TaxRate { get; set; }
        public string TaxCategory { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime EffectiveFrom { get; set; }
        public int CreatedBy { get; set; }
    }
}