namespace API_1.Models
{
    public class ChartOfAccount
    {
        public int AccountID { get; set; }
        public string AccountCode { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string AccountNameAr { get; set; } = string.Empty;
        public int AccountTypeID { get; set; }
        public string? TypeName { get; set; }
        public string? TypeNameAr { get; set; }
        public string? NormalBalance { get; set; }
        public int? ParentAccountID { get; set; }
        public string? ParentAccountName { get; set; }
        public int Level { get; set; } = 1;
        public bool IsParent { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public decimal OpeningBalance { get; set; } = 0;
        public decimal CurrentBalance { get; set; } = 0;
        public string CurrencyCode { get; set; } = "JOD";
        public bool AllowPosting { get; set; } = true;
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }


        public string? Path { get; set; }
        public int Depth { get; set; } = 0;
        public string? IndentedName { get; set; }
    }
}