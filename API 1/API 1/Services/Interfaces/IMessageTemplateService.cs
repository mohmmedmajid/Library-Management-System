using API_1.DTOs.MessageTemplate;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IMessageTemplateService
    {
        Task<int> CreateAsync(CreateMessageTemplateDTO dto);
        Task<bool> UpdateAsync(UpdateMessageTemplateDTO dto);
        Task<bool> DeleteAsync(int templateId);
        Task<MessageTemplate?> GetByIdAsync(int templateId);
        Task<MessageTemplate?> GetByCodeAsync(GetTemplateByCodeDTO dto);
        Task<List<MessageTemplate>> GetAllAsync(GetAllMessageTemplatesDTO dto);
        Task<(string ParsedMessage, string ParsedSubject)> ParseMessageAsync(ParseMessageTemplateDTO dto);
    }
}
