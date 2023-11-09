using System.Text.Json.Serialization;

namespace ShoppingListOptimizerAPI.Models.Requests
{
    public class RefreshTokenRequest
    {
        [JsonPropertyName("refreshToken")] public string RefreshToken { get; set; }
    }
}
