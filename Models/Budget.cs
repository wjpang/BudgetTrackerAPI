namespace BudgetTracker.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public Category? ExpenseCategory { get; set; }
        public decimal Amount { get; set; }
        public bool IsExpense { get; set; }
        public DateOnly Date { get; set; }
    }
}
