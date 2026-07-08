namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateLateFeeDTO
    {
        public int LateFeeID { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public string Status { get; set; } = "Pending";
        public string Notes { get; set; } = string.Empty;
    }
}