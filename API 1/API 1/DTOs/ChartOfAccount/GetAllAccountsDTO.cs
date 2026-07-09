namespace API_1.DTOs.ChartOfAccount
{
    public class GetAllAccountsDTO
    {
        public int? AccountTypeID { get; set; }
        public bool? IsActive { get; set; }
        public bool? AllowPosting { get; set; }
    }
}