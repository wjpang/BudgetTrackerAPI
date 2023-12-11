using BudgetTracker.Models;

namespace BudgetTracker.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetAsync(int id);
        Task<Category?> AddAsync(Category category);
        Task DeleteAsync(int id);
        Task UpdateAsync(Category category);
    }
}