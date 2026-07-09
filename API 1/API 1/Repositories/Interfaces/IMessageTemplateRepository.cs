using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IMessageTemplateRepository
    {
        Task<int> InsertAsync(MessageTemplate template);
        Task<bool> UpdateAsync(MessageTemplate template);
        Task<bool> DeleteAsync(int templateId);
        Task<MessageTemplate?> GetByIdAsync(int templateId);
        Task<MessageTemplate?> GetByCodeAsync(string templateCode);
        Task<List<MessageTemplate>> GetAllAsync(string? messageType = null, bool? isActive = null);
        Task<(string ParsedMessage, string ParsedSubject)> ParseMessageAsync(string templateCode, string parametersJson, string language = "Ar");
    }
}
