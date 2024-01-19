using ShoppingListOptimizerAPI.Business.DTOs;

namespace ShoppingListOptimizerAPI.Models
{
    public class AccountModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public LocationModel Location { get; set; }
    }
}
