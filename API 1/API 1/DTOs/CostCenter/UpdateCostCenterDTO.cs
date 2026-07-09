namespace API_1.DTOs.CostCenter
{
    public class UpdateCostCenterDTO
    {
        public int CostCenterID { get; set; }
        public string CostCenterCode { get; set; } = string.Empty;
        public string CostCenterName { get; set; } = string.Empty;
        public string CostCenterNameAr { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}