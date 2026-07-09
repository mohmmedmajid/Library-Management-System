namespace API_1.DTOs.Bonus
{
    public class GetBonusesByEmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string? BonusType { get; set; }
        public bool? IsPaid { get; set; }
    }
}