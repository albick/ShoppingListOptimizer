namespace ShoppingListOptimizerAPI.Models.Responses
{
    public class ShopOptimizationItemResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public double priceSum { get; set; }
        public int count { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
        public bool isPriority { get; set; }
    }
}
