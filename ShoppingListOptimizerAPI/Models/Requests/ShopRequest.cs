

namespace ShoppingListOptimizerAPI.Models.Requests
{
    public class ShopRequest
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string CompanyName { get; set; }
        public LocationModel Location { get; set; }
        public ICollection<OpeningHoursModel>? OpeningHours { get; set;}
    }
}
