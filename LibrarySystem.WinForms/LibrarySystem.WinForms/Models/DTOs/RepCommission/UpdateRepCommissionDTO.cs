namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateRepCommissionDTO
    {
        public int CommissionID { get; set; }
        public decimal CommissionAmount { get; set; }
        public bool IsPaid { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}