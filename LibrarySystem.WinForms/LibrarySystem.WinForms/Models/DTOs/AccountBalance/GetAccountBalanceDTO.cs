namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAccountBalanceDTO
    {
        public int AccountID { get; set; }
        public int FiscalYear { get; set; }
        public int FiscalMonth { get; set; }
    }
}