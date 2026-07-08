namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateAccountTypeDTO
    {
        public int AccountTypeID { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string TypeNameAr { get; set; } = string.Empty;
        public string NormalBalance { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }
}