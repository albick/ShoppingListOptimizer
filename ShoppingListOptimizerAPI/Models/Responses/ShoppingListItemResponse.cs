﻿namespace ShoppingListOptimizerAPI.Models.Responses
{
    public class ShoppingListItemResponse
    {
        public int id { get; set; }
        public string itemId { get; set; }
        public int count { get; set; }
        public string itemName { get; set; }

        public bool isPriority { get; set; }
    }
}
