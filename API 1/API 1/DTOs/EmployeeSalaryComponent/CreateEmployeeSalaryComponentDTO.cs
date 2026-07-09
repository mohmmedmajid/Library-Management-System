namespace API_1.DTOs.EmployeeSalaryComponent
{
    public class CreateEmployeeSalaryComponentDTO
    {
        public int EmployeeID { get; set; }
        public int ComponentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
    }
}