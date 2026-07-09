namespace API_1.DTOs.InvoiceTax
{
    public class CreateInvoiceTaxDTO
    {
        public int InvoiceID { get; set; }
        public int TaxTypeID { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
    }
}
