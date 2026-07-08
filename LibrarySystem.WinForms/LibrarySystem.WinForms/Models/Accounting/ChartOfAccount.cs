using System;

namespace LibrarySystem.WinForms.Models.Accounting
{
    public class ChartOfAccount
    {
        public int AccountID { get; set; }
        public string AccountCode { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string AccountNameAr { get; set; } = string.Empty;
        public int AccountTypeID { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string NormalBalance { get; set; } = string.Empty;
        public int? ParentAccountID { get; set; }
        public string ParentAccountName { get; set; } = string.Empty;
        public int Level { get; set; } = 1;
        public bool IsParent { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public decimal OpeningBalance { get; set; } = 0;
        public decimal CurrentBalance { get; set; } = 0;
        public string CurrencyCode { get; set; } = "JOD";
        public bool AllowPosting { get; set; } = true;
        public string Description { get; set; } = string.Empty;
        public string IndentedName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}