using System;

namespace LibrarySystem.WinForms.Models.Sales
{
    public class RepCommission
    {
        public int CommissionID { get; set; }
        public int SalesRepID { get; set; }
        public string RepName { get; set; } = string.Empty;
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public decimal SalesAmount { get; set; }
        public decimal CommissionPercent { get; set; }
        public decimal CommissionAmount { get; set; }
        public bool IsPaid { get; set; } = false;
        public DateTime PaidDate { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
