namespace API_1.DTOs.AllInvoices
{
    public class GetAllInvoicesDTO
    {
        public string? InvoiceType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CustomerID { get; set; }
    }
}