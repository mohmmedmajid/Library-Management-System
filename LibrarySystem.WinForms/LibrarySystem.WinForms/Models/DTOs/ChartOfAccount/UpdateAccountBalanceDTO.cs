namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateAccountBalanceDTO
    {
        public int AccountID { get; set; }
        public decimal Amount { get; set; }
        public bool IsDebit { get; set; }
    }
}