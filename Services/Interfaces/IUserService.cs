using BudgetTracker.Models;

namespace BudgetTracker.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User?> Get(int id);
        Task<User?> Add(User user);
        Task Delete(int id);
        Task Update(User user);
        Task<int?> Login(Login login);
        Task<bool> ResetPassword(ResetPassword resetPassword);
    }
}