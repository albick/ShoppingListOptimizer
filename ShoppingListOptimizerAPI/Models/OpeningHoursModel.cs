namespace ShoppingListOptimizerAPI.Models
{
    public class OpeningHoursModel
    {
        public DayOfWeek DayOfWeek { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
