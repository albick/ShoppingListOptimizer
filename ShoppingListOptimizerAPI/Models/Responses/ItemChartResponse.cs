namespace ShoppingListOptimizerAPI.Models.Responses
{
    public class ItemChartResponse
    {
        public string name {  get; set; }
        public List<ItemChartSeries>? series { get; set; }
    }
}
