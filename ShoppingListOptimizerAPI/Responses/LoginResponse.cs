using System.Text.Json.Serialization;

namespace ShoppingListOptimizerAPI.Responses
{
    public class LoginResponse
    {
        [JsonPropertyName("username")] public string UserName { get; set; }

        [JsonPropertyName("role")] public string Role { get; set; }

        [JsonPropertyName("originalUserName")] public string OriginalUserName { get; set; }

        [JsonPropertyName("accessToken")] public string AccessToken { get; set; }

        [JsonPropertyName("refreshToken")] public string RefreshToken { get; set; }

        [JsonPropertyName("email")] public string Email { get; set; }
    }
}
