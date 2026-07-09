using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class MessageTemplateRepository : IMessageTemplateRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public MessageTemplateRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(MessageTemplate template)
        {
            var parameters = new[]
            {
                new SqlParameter("@TemplateCode", template.TemplateCode),
                new SqlParameter("@TemplateName", template.TemplateName),
                new SqlParameter("@TemplateNameAr", template.TemplateNameAr),
                new SqlParameter("@MessageType", template.MessageType),
                new SqlParameter("@Subject", (object?)template.Subject ?? DBNull.Value),
                new SqlParameter("@MessageBody", template.MessageBody),
                new SqlParameter("@MessageBodyAr", template.MessageBodyAr),
                new SqlParameter("@Parameters", (object?)template.Parameters ?? DBNull.Value),
                new SqlParameter("@Description", (object?)template.Description ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)template.CreatedBy ?? DBNull.Value),
                new SqlParameter("@TemplateID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_MessageTemplates_Insert", parameters);
                return (int)parameters[10].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting message template: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(MessageTemplate template)
        {
            var parameters = new[]
            {
                new SqlParameter("@TemplateID", template.TemplateID),
                new SqlParameter("@TemplateCode", template.TemplateCode),
                new SqlParameter("@TemplateName", template.TemplateName),
                new SqlParameter("@TemplateNameAr", template.TemplateNameAr),
                new SqlParameter("@MessageType", template.MessageType),
                new SqlParameter("@Subject", (object?)template.Subject ?? DBNull.Value),
                new SqlParameter("@MessageBody", template.MessageBody),
                new SqlParameter("@MessageBodyAr", template.MessageBodyAr),
                new SqlParameter("@Parameters", (object?)template.Parameters ?? DBNull.Value),
                new SqlParameter("@Description", (object?)template.Description ?? DBNull.Value),
                new SqlParameter("@IsActive", template.IsActive)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_MessageTemplates_Update", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error updating message template: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int templateId)
        {
            var parameters = new[]
            {
                new SqlParameter("@TemplateID", templateId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_MessageTemplates_Delete", parameters);
            return result > 0;
        }

        public async Task<MessageTemplate?> GetByIdAsync(int templateId)
        {
            var parameters = new[]
            {
                new SqlParameter("@TemplateID", templateId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_MessageTemplates_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToMessageTemplate(dataTable.Rows[0]);
        }

        public async Task<MessageTemplate?> GetByCodeAsync(string templateCode)
        {
            var parameters = new[]
            {
                new SqlParameter("@TemplateCode", templateCode)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_MessageTemplates_GetByCode", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToMessageTemplate(dataTable.Rows[0]);
        }

        public async Task<List<MessageTemplate>> GetAllAsync(string? messageType = null, bool? isActive = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@MessageType", (object?)messageType ?? DBNull.Value),
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_MessageTemplates_GetAll", parameters);

            var templates = new List<MessageTemplate>();
            foreach (DataRow row in dataTable.Rows)
            {
                templates.Add(MapToMessageTemplate(row));
            }

            return templates;
        }

        public async Task<(string ParsedMessage, string ParsedSubject)> ParseMessageAsync(string templateCode, string parametersJson, string language = "Ar")
        {
            var parameters = new[]
            {
                new SqlParameter("@TemplateCode", templateCode),
                new SqlParameter("@ParametersJSON", parametersJson),
                new SqlParameter("@Language", language),
                new SqlParameter("@ParsedMessage", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output },
                new SqlParameter("@ParsedSubject", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_MessageTemplates_ParseMessage", parameters);
                return (
                    parameters[3].Value?.ToString() ?? string.Empty,
                    parameters[4].Value?.ToString() ?? string.Empty
                );
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error parsing message template: {ex.Message}", ex);
            }
        }

        private MessageTemplate MapToMessageTemplate(DataRow row)
        {
            return new MessageTemplate
            {
                TemplateID = Convert.ToInt32(row["TemplateID"]),
                TemplateCode = row["TemplateCode"]?.ToString() ?? string.Empty,
                TemplateName = row["TemplateName"]?.ToString() ?? string.Empty,
                TemplateNameAr = row["TemplateNameAr"]?.ToString() ?? string.Empty,
                MessageType = row["MessageType"]?.ToString() ?? string.Empty,
                Subject = row.Table.Columns.Contains("Subject") && row["Subject"] != DBNull.Value
                                 ? row["Subject"].ToString() : null,
                MessageBody = row.Table.Columns.Contains("MessageBody") && row["MessageBody"] != DBNull.Value
                                 ? row["MessageBody"].ToString() ?? string.Empty : string.Empty,
                MessageBodyAr = row.Table.Columns.Contains("MessageBodyAr") && row["MessageBodyAr"] != DBNull.Value
                                 ? row["MessageBodyAr"].ToString() ?? string.Empty : string.Empty,
                Parameters = row.Table.Columns.Contains("Parameters") && row["Parameters"] != DBNull.Value
                                 ? row["Parameters"].ToString() : null,
                IsActive = row.Table.Columns.Contains("IsActive") && row["IsActive"] != DBNull.Value
                                 && Convert.ToBoolean(row["IsActive"]),
                Description = row.Table.Columns.Contains("Description") && row["Description"] != DBNull.Value
                                 ? row["Description"].ToString() : null,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                                 ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                                 ? Convert.ToInt32(row["CreatedBy"]) : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                                 ? row["CreatedByName"].ToString() : null
            };
        }
    }
}