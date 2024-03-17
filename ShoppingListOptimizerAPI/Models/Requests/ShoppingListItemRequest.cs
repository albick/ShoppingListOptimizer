namespace ShoppingListOptimizerAPI.Models.Requests
{
    public class ShoppingListItemRequest
    {
        public int Count { get; set; }
        public string ItemId { get; set; }

        public bool IsPriority { get; set; }
    }
}
