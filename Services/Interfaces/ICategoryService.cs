using BudgetTracker.Models;

namespace BudgetTracker.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category?> Get(int id);
        Task<Category?> Add(Category category);
        Task Delete(int id);
        Task Update(Category category);
    }
}