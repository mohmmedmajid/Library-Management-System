namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateCostCenterDTO
    {
        public string CostCenterCode { get; set; } = string.Empty;
        public string CostCenterName { get; set; } = string.Empty;
        public string CostCenterNameAr { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
    }
}