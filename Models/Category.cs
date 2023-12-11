using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618

namespace BudgetTracker.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsExpense { get; set; }
    }
}
