using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShoppingListOptimizerAPI.Models.Requests
{
    public class RegisterShopRequest
    {
        [Required]
        public string Company { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public LocationModel Location { get; set; }
    }

    
}
