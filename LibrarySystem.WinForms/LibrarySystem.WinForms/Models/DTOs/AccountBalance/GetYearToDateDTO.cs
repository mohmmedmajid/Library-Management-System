namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetYearToDateDTO
    {
        public int AccountID { get; set; }
        public int FiscalYear { get; set; }
        public int EndMonth { get; set; }
    }
}