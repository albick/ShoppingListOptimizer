using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Business.JWTInfrastructure
{
    public class JwtAuthResult
    {
        [JsonPropertyName("AccessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("RefreshToken")]
        public RefreshToken RefreshToken { get; set; }

        [JsonPropertyName("Roles")]
        public string[] Roles { get; set; }
    }
}
