namespace API_1.Models
{
    public class MessageTemplate
    {
        public int TemplateID { get; set; }
        public string TemplateCode { get; set; } = string.Empty;
        public string TemplateName { get; set; } = string.Empty;
        public string TemplateNameAr { get; set; } = string.Empty;
        public string MessageType { get; set; } = string.Empty;     
        public string? Subject { get; set; }
        public string MessageBody { get; set; } = string.Empty;
        public string MessageBodyAr { get; set; } = string.Empty;
        public string? Parameters { get; set; }     
        public bool IsActive { get; set; } = true;
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
    }
}
