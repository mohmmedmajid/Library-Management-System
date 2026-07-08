using System;
namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateBonusDTO
    {
        public int BonusID { get; set; }
        public DateTime BonusDate { get; set; }
        public string BonusType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public bool IsPaid { get; set; }
    }
}