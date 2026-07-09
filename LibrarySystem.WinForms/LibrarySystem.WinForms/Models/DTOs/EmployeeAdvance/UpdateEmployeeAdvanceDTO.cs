namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateEmployeeAdvanceDTO
    {
        public int AdvanceID { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
        public int InstallmentMonths { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}