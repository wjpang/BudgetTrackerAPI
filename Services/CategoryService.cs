using BudgetTracker.Models;
using BudgetTracker.Data;
using Microsoft.EntityFrameworkCore;
using BudgetTracker.Services.Interfaces;

namespace BudgetTracker.Services;

public class CategoryService : ICategoryService
{
    private readonly BudgetTrackerContext _context;
    public CategoryService(BudgetTrackerContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllAsync() => await _context.Category.ToListAsync();

    public async Task<Category?> GetAsync(int id) => await _context.Category.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<Category?> AddAsync(Category category)
    {
        // Check if existing category has same name
        var existingCategory = await _context.Category.FirstOrDefaultAsync(c => c.Name == category.Name);
        if (existingCategory != null)
            return null;
        _context.Category.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task DeleteAsync(int id)
    {
        var category = await GetAsync(id);
        if (category != null)
        {
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
