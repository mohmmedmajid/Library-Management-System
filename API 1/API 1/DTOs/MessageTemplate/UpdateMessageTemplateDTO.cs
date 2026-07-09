namespace API_1.DTOs.MessageTemplate
{
    public class UpdateMessageTemplateDTO
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
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
