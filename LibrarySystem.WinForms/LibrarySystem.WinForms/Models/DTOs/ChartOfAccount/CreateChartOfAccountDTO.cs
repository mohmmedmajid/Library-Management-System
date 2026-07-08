namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateChartOfAccountDTO
    {
        public string AccountCode { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string AccountNameAr { get; set; } = string.Empty;
        public int AccountTypeID { get; set; }
        public int ParentAccountID { get; set; }
        public int Level { get; set; } = 1;
        public bool IsParent { get; set; } = false;
        public decimal OpeningBalance { get; set; } = 0;
        public string CurrencyCode { get; set; } = "JOD";
        public bool AllowPosting { get; set; } = true;
        public string Description { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
    }
}