using System.Text.Json.Serialization;

namespace API_1.Models
{
    public class AccountBalance
    {
        [JsonPropertyName("BalanceID")]
        public int BalanceID { get; set; }
        [JsonPropertyName("AccountID")]
        public int AccountID { get; set; }
        public string? AccountCode { get; set; }
        public string? AccountName { get; set; }
        public string? AccountNameAr { get; set; }
        public string? AccountType { get; set; }
        public int FiscalYear { get; set; }
        public int FiscalMonth { get; set; }
        public decimal OpeningBalance { get; set; } = 0;
        public decimal DebitTotal { get; set; } = 0;
        public decimal CreditTotal { get; set; } = 0;
        public decimal ClosingBalance { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}