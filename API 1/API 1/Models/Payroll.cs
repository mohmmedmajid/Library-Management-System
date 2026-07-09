namespace API_1.Models
{
    public class Payroll
    {
        public int PayrollID { get; set; }
        public string PayrollNumber { get; set; } = string.Empty;
        public int PayrollMonth { get; set; }
        public int PayrollYear { get; set; }
        public DateTime PayrollDate { get; set; } = DateTime.Now;
        public int TotalEmployees { get; set; } = 0;
        public decimal TotalBasicSalary { get; set; } = 0;
        public decimal TotalAdditions { get; set; } = 0;
        public decimal TotalDeductions { get; set; } = 0;
        public decimal TotalNetSalary { get; set; } = 0;
        public string Status { get; set; } = "Draft";  
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedBy { get; set; }
        public string? ApprovedByName { get; set; }
        public DateTime? PostedDate { get; set; }
        public int? PostedBy { get; set; }
        public string? PostedByName { get; set; }
        public DateTime? PaidDate { get; set; }
        public int? PaidBy { get; set; }
        public string? PaidByName { get; set; }
        public int? JournalEntryID { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
    }
}