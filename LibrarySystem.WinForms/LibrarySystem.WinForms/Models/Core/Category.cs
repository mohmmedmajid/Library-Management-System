using System;

namespace LibrarySystem.WinForms.Models.Core
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryNameAr { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public int ProductCount { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}