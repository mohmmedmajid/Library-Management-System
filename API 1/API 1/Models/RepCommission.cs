namespace API_1.Models
{
    public class RepCommission
    {
        public int CommissionID { get; set; }
        public int SalesRepID { get; set; }
        public int InvoiceID { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal CommissionPercent { get; set; }
        public decimal CommissionAmount { get; set; }
        public bool IsPaid { get; set; } = false;
        public DateTime? PaidDate { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? RepName { get; set; }
        public string? InvoiceNumber { get; set; }
    }
}