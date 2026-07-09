namespace API_1.Models
{
    public class InvoiceSearchResult
    {
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; }
        public int? CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public string InvoiceType { get; set; } = string.Empty;
    }
}