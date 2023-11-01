using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShoppingListOptimizerAPI.Requests
{
    public class RegisterRequest
    {
        [Required]
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [Required][JsonPropertyName("email")] public string Email { get; set; }

    }
}
