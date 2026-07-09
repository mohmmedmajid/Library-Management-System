namespace API_1.DTOs.Invoice
{
    public class GetAllInvoicesDTO
    {
        public int? InvoiceTypeID { get; set; }
        public int? CustomerID { get; set; }
        public string? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}