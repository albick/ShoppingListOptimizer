using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShoppingListOptimizerAPI.Requests
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
        public Location Location { get; set; }
    }

    public class Location
    {
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
