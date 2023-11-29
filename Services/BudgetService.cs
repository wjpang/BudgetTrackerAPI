using BudgetTracker.Models;

namespace BudgetTracker.Services;

public static class BudgetService
{
    static List<Budget> Expenses { get; }
    static int nextId = 1;
    static BudgetService()
    {
        Expenses = new List<Budget>();
    }

    public static List<Budget> GetAll() => Expenses;

    public static Budget? Get(int id) => Expenses.FirstOrDefault(e => e.Id == id);

    public static void Add(Budget expense)
    {
        expense.Id = nextId++;
        Expenses.Add(expense);
    }

    public static void Delete(int id)
    {
        var expense = Get(id);
        if (expense is null)
            return;

        Expenses.Remove(expense);
    }

    public static void Update(Budget expense)
    {
        var index = Expenses.FindIndex(e => e.Id == expense.Id);
        if (index == -1)
            return;

        Expenses[index] = expense;
    }
}