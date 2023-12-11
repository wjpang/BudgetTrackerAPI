using BudgetTracker.Models;
using BudgetTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.Services;

public class UserService
{
    private readonly BudgetTrackerContext _context;
    public UserService(BudgetTrackerContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllAsync() => await _context.User.ToListAsync();

    public async Task<User?> GetAsync(int id) => await _context.User.FirstOrDefaultAsync(u => u.Id == id);

    public async Task<User?> AddAsync(User user)
    {
        // Check if user email and username already exist
        var existingUser = await _context.User.FirstOrDefaultAsync(u => u.Email == user.Email || u.Username == user.Username);
        if (existingUser != null)
            return null;
        _context.User.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task DeleteAsync(int id)
    {
        var user = await GetAsync(id);
        if (user != null)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
