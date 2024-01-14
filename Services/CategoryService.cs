using BudgetTracker.Data;
using BudgetTracker.Models;
using BudgetTracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.Services;

public class CategoryService : ICategoryService
{
    private readonly BudgetTrackerContext _context;
    public CategoryService(BudgetTrackerContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAll() => await _context.Category.ToListAsync();

    public async Task<Category?> Get(int id) => await _context.Category.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<Category?> Add(Category category)
    {
        // Check if existing category has same name
        var existingCategory = await _context.Category.FirstOrDefaultAsync(c => c.Name == category.Name);
        if (existingCategory != null)
            return null;
        await _context.Category.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task Delete(int id)
    {
        var category = await Get(id);
        if (category != null)
        {
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(Category category)
    {
        var existingCategory = await _context.Category.FindAsync(category.Id);

        if (existingCategory == null)
        {
            // Handle the case where the category doesn't exist
            return;
        }

        // Update the existing entity's properties
        existingCategory.Name = category.Name;
        existingCategory.IsExpense = category.IsExpense;

        await _context.SaveChangesAsync();
    }
}
