namespace ShoppingListOptimizerAPI.Models.Requests
{
    public class ShopRequest
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string CompanyId { get; set; }
        public LocationModel Location { get; set; }
        public string OpeningHours{ get; set;}
    }
}
