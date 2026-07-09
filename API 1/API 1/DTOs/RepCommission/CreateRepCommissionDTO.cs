namespace API_1.DTOs.RepCommission
{
    public class CreateRepCommissionDTO
    {
        public int SalesRepID { get; set; }
        public int InvoiceID { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal CommissionPercent { get; set; }
        public decimal CommissionAmount { get; set; }
        public bool IsPaid { get; set; } = false;
        public string? Notes { get; set; }
    }
}