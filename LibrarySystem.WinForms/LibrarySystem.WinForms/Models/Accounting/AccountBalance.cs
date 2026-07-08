using System;

namespace LibrarySystem.WinForms.Models.Accounting
{
    public class AccountBalance
    {
        public int BalanceID { get; set; }
        public int AccountID { get; set; }
        public string AccountCode { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string AccountNameAr { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public int FiscalYear { get; set; }
        public int FiscalMonth { get; set; }
        public decimal OpeningBalance { get; set; } = 0;
        public decimal DebitTotal { get; set; } = 0;
        public decimal CreditTotal { get; set; } = 0;
        public decimal ClosingBalance { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}