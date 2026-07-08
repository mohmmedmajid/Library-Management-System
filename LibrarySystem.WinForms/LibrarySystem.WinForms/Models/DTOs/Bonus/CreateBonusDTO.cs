    using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateBonusDTO
    {
        public int EmployeeID { get; set; }
        public DateTime BonusDate { get; set; } = DateTime.Now;
        public string BonusType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
        public int ApprovedBy { get; set; }
        public string Notes { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
    }
}