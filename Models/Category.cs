namespace BudgetTracker.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsExpense { get; set; }
    }
}
