using ShoppingListOptimizerAPI.Business.DTOs;

namespace ShoppingListOptimizerAPI.Models.Responses
{
    public class ShoppingListResponse
    {
        public int id { get; set; }

        public string name { get; set; }

        public string details { get; set; }

        public DateTime dateModified { get; set; }

        public AccountModel creator { get; set; }

        public List<ShoppingListItemResponse> shoppingListItems { get; set; }
    }
}
