using Microsoft.EntityFrameworkCore;
using BudgetTracker.Models;

namespace BudgetTracker.Data
{
    public class BudgetTrackerContext : DbContext
    {
        public BudgetTrackerContext(DbContextOptions<BudgetTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<TransactionEntry> TransactionEntry { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
    }
}
