using System.Text.Json.Serialization;

namespace ShoppingListOptimizerAPI.Responses
{
    public class RegisterResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
