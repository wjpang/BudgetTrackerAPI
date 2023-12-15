using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;  // Required for Sqlite

#pragma warning disable CS8618

namespace BudgetTracker.Models
{
    public class Category
    {
        // Id Annotations are required for Sqlite
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsExpense { get; set; }
    }
}
