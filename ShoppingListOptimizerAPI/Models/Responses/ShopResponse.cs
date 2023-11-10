
namespace ShoppingListOptimizerAPI.Models.Responses
{
    public class ShopResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public LocationModel Location { get; set; }

        public AccountModel Creator { get; set; }
        public AccountModel Company { get; set; }
        public ICollection<OpeningHoursModel>? OpeningHours { get; set; }
    }
}
