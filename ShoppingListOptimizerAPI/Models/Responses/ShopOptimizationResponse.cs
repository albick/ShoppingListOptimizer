

using ShoppingListOptimizerAPI.Data.Models;

namespace ShoppingListOptimizerAPI.Models.Responses
{
    public class ShopOptimizationResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public LocationModel location { get; set; }
        public double priceSum { get; set; } = 0;
        public double pricePrioritySum { get; set; } = 0;
        public double distanceFromUser { get; set; } = 0;
        public List<ShopOptimizationItemResponse> items { get; set; }= new List<ShopOptimizationItemResponse>();
    }
}
