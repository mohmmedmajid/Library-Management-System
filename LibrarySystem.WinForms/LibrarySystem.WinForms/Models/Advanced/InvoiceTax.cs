using System;

namespace LibrarySystem.WinForms.Models.Advanced
{
    public class InvoiceTax
    {
        public int InvoiceTaxID { get; set; }
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public int TaxTypeID { get; set; }
        public string TaxCode { get; set; } = string.Empty;
        public string TaxName { get; set; } = string.Empty;
        public string TaxCategory { get; set; } = string.Empty;
        public decimal TaxableAmount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}