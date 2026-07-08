namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateChartOfAccountDTO
    {
        public int AccountID { get; set; }
        public string AccountCode { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string AccountNameAr { get; set; } = string.Empty;
        public int AccountTypeID { get; set; }
        public bool AllowPosting { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}