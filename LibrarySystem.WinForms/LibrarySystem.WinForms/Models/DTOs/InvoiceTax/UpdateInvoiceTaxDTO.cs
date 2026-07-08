namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateInvoiceTaxDTO
    {
        public int InvoiceTaxID { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
    }
}