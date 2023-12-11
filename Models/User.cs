namespace BudgetTracker.Models
{
    public class User
    {
        // Properties
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        // Navigation properties
        public virtual ICollection<TransactionEntry>? TransactionEntries { get; set; }
    }
}
