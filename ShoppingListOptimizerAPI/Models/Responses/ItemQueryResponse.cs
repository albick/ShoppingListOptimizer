using ShoppingListOptimizerAPI.Business.DTOs;

namespace ShoppingListOptimizerAPI.Models.Responses
{
    public class ItemQueryResponse
    {
        public double price { get; set; }
        public DateTime createdAt { get; set; }

        public string itemBarcode { get; set; }
        public string itemName { get; set; }
        public string itemUnit { get; set; }
        public double itemQuantity { get; set; }
        public string shopName { get; set; }
        public double distance { get; set; }
    }
}
