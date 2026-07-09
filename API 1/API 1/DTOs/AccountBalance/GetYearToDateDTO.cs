namespace API_1.DTOs.AccountBalance
{
    public class GetYearToDateDTO
    {
        public int AccountID { get; set; }
        public int FiscalYear { get; set; }
        public int EndMonth { get; set; }
    }
}