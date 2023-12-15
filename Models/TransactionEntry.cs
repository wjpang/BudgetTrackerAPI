using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;  // Required for Sqlite

#pragma warning disable CS8618

namespace BudgetTracker.Models
{
    public class TransactionEntry
    {

        // Properties
        // Id Annotations are required for Sqlite
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Precision(18, 2)]
        public decimal Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        // Navigation properties
        public int UserId { get; set; } // Foreign Key
        public virtual User User { get; set; }
        public int CategoryId { get; set; } // Foreign Key
        public virtual Category Category { get; set; }
    }
}
