using BudgetTracker.Models;

namespace BudgetTracker.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetAsync(int id);
        Task<User?> AddAsync(User user);
        Task DeleteAsync(int id);
        Task UpdateAsync(User user);
    }
}