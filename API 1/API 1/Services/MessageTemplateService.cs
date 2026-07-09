using API_1.DTOs.MessageTemplate;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class MessageTemplateService : IMessageTemplateService
    {
        private readonly IMessageTemplateRepository _templateRepository;

        public MessageTemplateService(IMessageTemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public async Task<int> CreateAsync(CreateMessageTemplateDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.TemplateCode))
                throw new ArgumentException("Template code is required");

            if (string.IsNullOrWhiteSpace(dto.TemplateName))
                throw new ArgumentException("Template name is required");

            var validTypes = new[] { "SMS", "Email", "WhatsApp", "Notification" };
            if (!validTypes.Contains(dto.MessageType.Trim()))
                throw new ArgumentException($"Invalid message type. Must be one of: {string.Join(", ", validTypes)}");

            if (string.IsNullOrWhiteSpace(dto.MessageBody))
                throw new ArgumentException("Message body is required");

            if (dto.MessageType.Trim() == "Email" && string.IsNullOrWhiteSpace(dto.Subject))
                throw new ArgumentException("Subject is required for email templates");

            var template = new MessageTemplate
            {
                TemplateCode = dto.TemplateCode.Trim().ToUpper(),
                TemplateName = dto.TemplateName.Trim(),
                TemplateNameAr = dto.TemplateNameAr?.Trim() ?? string.Empty,
                MessageType = dto.MessageType.Trim(),
                Subject = dto.Subject?.Trim(),
                MessageBody = dto.MessageBody.Trim(),
                MessageBodyAr = dto.MessageBodyAr?.Trim() ?? string.Empty,
                Parameters = dto.Parameters?.Trim(),
                Description = dto.Description?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _templateRepository.InsertAsync(template);
        }

        public async Task<bool> UpdateAsync(UpdateMessageTemplateDTO dto)
        {
            if (dto.TemplateID <= 0)
                throw new ArgumentException("Invalid template ID");

            if (string.IsNullOrWhiteSpace(dto.TemplateCode))
                throw new ArgumentException("Template code is required");

            if (string.IsNullOrWhiteSpace(dto.TemplateName))
                throw new ArgumentException("Template name is required");

            var validTypes = new[] { "SMS", "Email", "WhatsApp", "Notification" };
            if (!validTypes.Contains(dto.MessageType.Trim()))
                throw new ArgumentException($"Invalid message type. Must be one of: {string.Join(", ", validTypes)}");

            if (string.IsNullOrWhiteSpace(dto.MessageBody))
                throw new ArgumentException("Message body is required");

            if (dto.MessageType.Trim() == "Email" && string.IsNullOrWhiteSpace(dto.Subject))
                throw new ArgumentException("Subject is required for email templates");

            var existing = await _templateRepository.GetByIdAsync(dto.TemplateID);
            if (existing == null)
                throw new InvalidOperationException("Message template not found");

            var template = new MessageTemplate
            {
                TemplateID = dto.TemplateID,
                TemplateCode = dto.TemplateCode.Trim().ToUpper(),
                TemplateName = dto.TemplateName.Trim(),
                TemplateNameAr = dto.TemplateNameAr?.Trim() ?? string.Empty,
                MessageType = dto.MessageType.Trim(),
                Subject = dto.Subject?.Trim(),
                MessageBody = dto.MessageBody.Trim(),
                MessageBodyAr = dto.MessageBodyAr?.Trim() ?? string.Empty,
                Parameters = dto.Parameters?.Trim(),
                Description = dto.Description?.Trim(),
                IsActive = dto.IsActive
            };

            return await _templateRepository.UpdateAsync(template);
        }

        public async Task<bool> DeleteAsync(int templateId)
        {
            if (templateId <= 0)
                throw new ArgumentException("Invalid template ID");

            var existing = await _templateRepository.GetByIdAsync(templateId);
            if (existing == null)
                throw new InvalidOperationException("Message template not found");

            return await _templateRepository.DeleteAsync(templateId);
        }

        public async Task<MessageTemplate?> GetByIdAsync(int templateId)
        {
            if (templateId <= 0)
                throw new ArgumentException("Invalid template ID");

            return await _templateRepository.GetByIdAsync(templateId);
        }

        public async Task<MessageTemplate?> GetByCodeAsync(GetTemplateByCodeDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.TemplateCode))
                throw new ArgumentException("Template code is required");

            return await _templateRepository.GetByCodeAsync(dto.TemplateCode.Trim().ToUpper());
        }

        public async Task<List<MessageTemplate>> GetAllAsync(GetAllMessageTemplatesDTO dto)
        {
            return await _templateRepository.GetAllAsync(dto.MessageType, dto.IsActive);
        }

        public async Task<(string ParsedMessage, string ParsedSubject)> ParseMessageAsync(ParseMessageTemplateDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.TemplateCode))
                throw new ArgumentException("Template code is required");

            if (string.IsNullOrWhiteSpace(dto.ParametersJSON))
                throw new ArgumentException("Parameters JSON is required");

            var validLanguages = new[] { "Ar", "En" };
            if (!validLanguages.Contains(dto.Language.Trim()))
                throw new ArgumentException("Language must be 'Ar' or 'En'");

            var template = await _templateRepository.GetByCodeAsync(dto.TemplateCode.Trim().ToUpper());
            if (template == null)
                throw new InvalidOperationException("Message template not found");

            return await _templateRepository.ParseMessageAsync(
                dto.TemplateCode.Trim().ToUpper(),
                dto.ParametersJSON.Trim(),
                dto.Language.Trim()
            );
        }
    }
}