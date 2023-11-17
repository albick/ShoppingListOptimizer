
using System.Text.Json.Serialization;

namespace ShoppingListOptimizerAPI.Models.Responses
{
    public class ShopResponse
    {
        
        public int id { get; set; }
        
        public string name { get; set; }
        public string details { get; set; }
        public LocationModel location { get; set; }

        public AccountModel creator { get; set; }
        public AccountModel company { get; set; }
        public ICollection<OpeningHoursModel>? openingHours { get; set; }

        public double distanceFromUser { get; set; } = 0;
    }
}
