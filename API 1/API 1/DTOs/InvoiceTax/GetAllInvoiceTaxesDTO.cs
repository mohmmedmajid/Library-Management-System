namespace API_1.DTOs.InvoiceTax
{
    public class GetAllInvoiceTaxesDTO
    {
        public int? TaxTypeID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
