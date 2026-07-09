namespace API_1.Models
{
    public class InvoiceTax
    {
        public int InvoiceTaxID { get; set; }
        public int InvoiceID { get; set; }
        public int TaxTypeID { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? TaxCode { get; set; }
        public string? TaxName { get; set; }
        public string? TaxCategory { get; set; }
    }
}
