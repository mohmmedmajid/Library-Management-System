using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class ApiException : Exception
{
    public int StatusCode { get; }
    public string ResponseBody { get; }

    public ApiException(int statusCode, string responseBody, string message)
        : base(message)
    {
        StatusCode = statusCode;
        ResponseBody = responseBody;
    }
}

public class ApiHelper
{
    private static string BaseUrl = "http://localhost:5096/api/";
    private static HttpClient client = new HttpClient();

    private static JsonSerializerOptions JsonOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    private static async Task ThrowIfError(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode) return;

        string body = await response.Content.ReadAsStringAsync();
        string friendlyMessage = body;

        try
        {
            using (var doc = JsonDocument.Parse(body))
            {
                var root = doc.RootElement;

                if (root.TryGetProperty("title", out var titleEl))
                    friendlyMessage = titleEl.GetString();

                if (root.TryGetProperty("message", out var msgEl))
                    friendlyMessage = msgEl.GetString();

                if (root.TryGetProperty("errors", out var errorsEl))
                {
                    var sb = new StringBuilder();
                    foreach (var prop in errorsEl.EnumerateObject())
                    {
                        foreach (var err in prop.Value.EnumerateArray())
                            sb.AppendLine("• " + prop.Name + ": " + err.GetString());
                    }
                    if (sb.Length > 0)
                        friendlyMessage = sb.ToString();
                }
            }
        }
        catch
        {
        
        }

        if (string.IsNullOrWhiteSpace(friendlyMessage))
            friendlyMessage = "(" + (int)response.StatusCode + " " + response.ReasonPhrase + ")";

        throw new ApiException((int)response.StatusCode, body, friendlyMessage);
    }

    public static async Task<T> GetAsync<T>(string endpoint)
    {
        var response = await client.GetAsync(BaseUrl + endpoint);
        await ThrowIfError(response);
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json, JsonOptions);
    }

    public static async Task<T> PostAsync<T>(string endpoint, object data)
    {
        var json = JsonSerializer.Serialize(data, JsonOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(BaseUrl + endpoint, content);
        await ThrowIfError(response);
        var result = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(result)) return default(T);
        return JsonSerializer.Deserialize<T>(result, JsonOptions);
    }

    public static async Task<T> PutAsync<T>(string endpoint, object data)
    {
        var json = JsonSerializer.Serialize(data, JsonOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PutAsync(BaseUrl + endpoint, content);
        await ThrowIfError(response);
        var result = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(result)) return default(T);
        return JsonSerializer.Deserialize<T>(result, JsonOptions);
    }

    public static async Task<bool> DeleteAsync(string endpoint)
    {
        var response = await client.DeleteAsync(BaseUrl + endpoint);
        return response.IsSuccessStatusCode;
    }

    public static async Task<string> GetRawAsync(string endpoint)
    {
        var response = await client.GetAsync(BaseUrl + endpoint);
        await ThrowIfError(response);
        return await response.Content.ReadAsStringAsync();
    }
}