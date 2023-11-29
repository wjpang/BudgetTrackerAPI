namespace BudgetTracker.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public decimal Amount { get; set; }
        public bool IsExpense { get; set; }
        // public DateTime DateAndTime { get; set; }  // Desired property, but hard to implement at this stage
    }
}
