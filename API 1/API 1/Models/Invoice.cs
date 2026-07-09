namespace API_1.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public int InvoiceTypeID { get; set; }
        public int? CustomerID { get; set; }
        public int PaymentMethodID { get; set; }
        public string PaymentType { get; set; } = "Cash"; 
        public int? SalesRepID { get; set; }
        public decimal SubTotal { get; set; } = 0;
        public decimal DiscountAmount { get; set; } = 0;
        public decimal DiscountPercent { get; set; } = 0;
        public decimal TaxAmount { get; set; } = 0;
        public decimal TaxPercent { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;
        public decimal PaidAmount { get; set; } = 0;
        public decimal RemainingAmount { get; set; } = 0;
        public string? Notes { get; set; }
        public string Status { get; set; } = "Completed";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }

        
        public string? TypeName { get; set; }
        public string? TypeNameAr { get; set; }
        public string? CustomerName { get; set; }
        public string? MethodName { get; set; }
        public string? MethodNameAr { get; set; }
        public string? CreatedByName { get; set; }
    }
}