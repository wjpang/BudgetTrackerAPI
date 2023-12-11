using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BudgetTracker.Models
{
    public class Budget
    {
        // Properties
        public int Id { get; set; }
        public string? Description { get; set; }
        [Precision(18, 2)]
        public decimal Amount { get; set; }
        public bool IsExpense { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        // Navigation properties
        public int UserId { get; set; } // Foreign Key
        public virtual User? User { get; set; }
        public int CategoryId { get; set; } // Foreign Key
        public Category? Category { get; set; }
    }
}
