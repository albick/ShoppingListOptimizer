using ShoppingListOptimizerAPI.Business.DTOs;
using ShoppingListOptimizerAPI.Data.Models;

namespace ShoppingListOptimizerAPI.Models.Requests
{
    public class ItemRequest
    {
        public string Barcode { get; set; }

        public string Name { get; set; }
        public string Details { get; set; }

        public double Quantity { get; set; }

        public string Unit { get; set; }
    }
}
