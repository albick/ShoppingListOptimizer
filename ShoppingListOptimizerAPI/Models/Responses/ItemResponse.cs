using ShoppingListOptimizerAPI.Business.DTOs;
using ShoppingListOptimizerAPI.Data.Models;

namespace ShoppingListOptimizerAPI.Models.Responses
{
    public class ItemResponse
    {
        public string barcode { get; set; }

        public string name { get; set; }
        public string details { get; set; }

        public double quantity { get; set; }

        public string unit { get; set; }

        public Account creator { get; set; }
    }
}
