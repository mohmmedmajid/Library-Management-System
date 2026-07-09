using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAllExpensesDTO
    {
        public int ExpenseCategoryID { get; set; }
        public int SupplierID { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}