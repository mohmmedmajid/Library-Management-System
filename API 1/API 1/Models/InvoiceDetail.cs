namespace API_1.Models
{
    public class InvoiceDetail
    {
        public int InvoiceDetailID { get; set; }
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountAmount { get; set; } = 0;
        public decimal DiscountPercent { get; set; } = 0;
        public decimal TotalPrice { get; set; }
        public string? Notes { get; set; }
        public string? ProductName { get; set; }
        public string? ProductNameAr { get; set; }
        public string? Barcode { get; set; }
        public string? InvoiceNumber { get; set; }
    }
}