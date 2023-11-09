using ShoppingListOptimizerAPI.Business.DTOs;
using ShoppingListOptimizerAPI.Data.Models;

namespace ShoppingListOptimizerAPI.Models.Responses
{
    public class ItemResponse
    {
        public string Barcode { get; set; }

        public string Name { get; set; }
        public string Details { get; set; }

        public double Quantity { get; set; }

        public string Unit { get; set; }

        public Account Creator { get; set; }
    }
}
