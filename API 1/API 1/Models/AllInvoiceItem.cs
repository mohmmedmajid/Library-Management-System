namespace API_1.Models
{
    public class AllInvoiceItem
    {
        public int RecordID { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string? TypeNameAr { get; set; }
        public int? CustomerID { get; set; }
        public string? PartyName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}