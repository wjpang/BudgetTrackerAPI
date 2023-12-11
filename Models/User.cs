using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618

namespace BudgetTracker.Models
{
    public class User
    {
        // Properties
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        // Navigation properties
        public virtual ICollection<TransactionEntry>? TransactionEntries { get; set; } = new List<TransactionEntry>();
    }
}
