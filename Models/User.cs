namespace BudgetTracker.Models
{
    public class User
    {
        // Properties
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        // Navigation properties
        public virtual ICollection<TransactionEntry>? TransactionEntries { get; set; }
    }
}
