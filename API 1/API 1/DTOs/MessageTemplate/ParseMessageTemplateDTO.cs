namespace API_1.DTOs.MessageTemplate
{
    public class ParseMessageTemplateDTO
    {
        public string TemplateCode { get; set; } = string.Empty;
        public string ParametersJSON { get; set; } = string.Empty;
        public string Language { get; set; } = "Ar";
    }
}
