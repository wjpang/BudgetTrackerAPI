using BudgetTracker.Models;
using BudgetTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.Services;

public class BudgetService
{
    private readonly BudgetTrackerContext _context;
    public BudgetService(BudgetTrackerContext context)
    {
        _context = context;
    }

    public async Task<List<Budget>> GetAllAsync() => await _context.Budget.ToListAsync();

    public async Task<Budget?> GetAsync(int id) => await _context.Budget.FirstOrDefaultAsync(e => e.Id == id);

    public async Task<Budget?> AddAsync(Budget expense)
    {
        _context.Budget.Add(expense);
        await _context.SaveChangesAsync();
        return expense;
    }

    public async Task DeleteAsync(int id)
    {
        var expense = await GetAsync(id);
        if (expense != null)
        {
            _context.Budget.Remove(expense);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Budget expense)
    {
        _context.Entry(expense).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
