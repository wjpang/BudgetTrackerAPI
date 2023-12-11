using Microsoft.EntityFrameworkCore;
using BudgetTracker.Data;

namespace BudgetTracker.Models
{
    public static class SeedData
    {
        public static void Initialise(IServiceProvider serviceProvider)
        {
            using (var context = new BudgetTrackerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BudgetTrackerContext>>()))
            {
                // Look for any Categories.
                if (context.Category.Any())
                {
                    return; // Category has been seeded
                }

                context.Category.AddRange(
                    new Category
                    {
                        Name = "Food",
                        IsExpense = true
                    },
                    new Category
                    {
                        Name = "Transportation",
                        IsExpense = true
                    },
                    new Category
                    {
                        Name = "Entertainment",
                        IsExpense = true
                    },
                    new Category
                    {
                        Name = "Shopping",
                        IsExpense = true
                    },
                    new Category
                    {
                        Name = "Utilities",
                        IsExpense = true
                    },
                    new Category
                    {
                        Name = "Rent",
                        IsExpense = true
                    },
                    new Category
                    {
                        Name = "Travel",
                        IsExpense = true
                    },
                    new Category
                    {
                        Name = "Groceries",
                        IsExpense = true
                    },
                    new Category
                    {
                        Name = "Salary",
                        IsExpense = false
                    },
                    new Category
                    {
                        Name = "Other Income",
                        IsExpense = false
                    },
                    new Category
                    {
                        Name = "Other Expense",
                        IsExpense = true
                    }
                );


                // Look for any Users.
                if (context.User.Any())
                {
                    return; // User has been seeded
                }

                context.User.AddRange(
                    new User
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        Username = "admin",
                        Email = "admin@admin.com",
                        Password = "Admin001"
                    }
                );

                // Look for any Transaction entries. (Won't seed any transaction entries)
                // if (context.TransactionEntry.Any())
                // {
                //     return; // Transaction entries has been seeded
                // }
            }
        }
    }
}
