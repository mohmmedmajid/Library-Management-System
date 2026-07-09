namespace API_1.DTOs.LateFee
{
    public class GetAllLateFeesDTO
    {
        public string? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}