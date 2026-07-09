namespace API_1.Models
{
    public class AccountType
    {
        public int AccountTypeID { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string TypeNameAr { get; set; } = string.Empty;
        public string NormalBalance { get; set; } = string.Empty; 
        public string? Description { get; set; }
        public int DisplayOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}