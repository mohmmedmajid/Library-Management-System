namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetBalancesByPeriodDTO
    {
        public int FiscalYear { get; set; }
        public int FiscalMonth { get; set; }
        public int? AccountTypeID { get; set; }
    }
}