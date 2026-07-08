using System.Text.Json.Serialization;

public class SaveCouponResponse
{
    [JsonPropertyName("CouponId")]
    public int CouponId { get; set; }

    [JsonPropertyName("Message")]
    public string Message { get; set; }
}