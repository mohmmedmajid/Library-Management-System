namespace API_1.Models
{
    public class SaleReturn
    {
        public int SaleReturnID { get; set; }
        public string SaleReturnNumber { get; set; } = string.Empty;
        public int OriginalInvoiceID { get; set; }
        public string? OriginalInvoiceNumber { get; set; }
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public DateTime ReturnDate { get; set; }
        public string RefundMethod { get; set; } = string.Empty;
        public int PaymentMethodID { get; set; }
        public string? MethodNameAr { get; set; }
        public decimal TotalReturnedAmount { get; set; }
        public string? Notes { get; set; }
        public string Status { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}