namespace API_1.DTOs.RepCommission
{
    public class UpdateRepCommissionDTO
    {
        public int CommissionID { get; set; }
        public decimal CommissionAmount { get; set; }
        public bool IsPaid { get; set; }
        public string? Notes { get; set; }
    }
}