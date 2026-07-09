namespace API_1.DTOs.ReturnTransaction
{
    public class UpdateReturnTransactionDTO
    {
        public int ReturnID { get; set; }
        public DateTime ReturnDate { get; set; }
        public int ActualDaysUsed { get; set; }
        public int LateDays { get; set; }
        public decimal LateFeeAmount { get; set; }
        public decimal RefundAmount { get; set; }
        public string? Notes { get; set; }
    }
}