using BudgetTracker.Data;
using BudgetTracker.Models;
using BudgetTracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.Services;

public class UserService : IUserService
{
    private readonly BudgetTrackerContext _context;

    public UserService(BudgetTrackerContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAll() => await _context.User.ToListAsync();

    public async Task<User?> Get(int id) => await _context.User.FirstOrDefaultAsync(u => u.Id == id);

    public async Task<User?> Add(User user)
    {
        // Check if user email and username already exist
        var existingUser = await _context.User.FirstOrDefaultAsync(u => u.Email == user.Email || u.Username == user.Username);
        if (existingUser != null)
            return null;
        await _context.User.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task Delete(int id)
    {
        var user = await Get(id);
        if (user != null)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(User user)
    {
        var existingUser = await _context.User.FindAsync(user.Id);

        if (existingUser == null)
        {
            // Handle the case where the user doesn't exist
            return;
        }

        // Update the existing entity's properties
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Username = user.Username;
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;

        await _context.SaveChangesAsync();
    }

    public async Task<int?> Login(Login login)
    {
        var user = await _context.User.FirstOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);
        if (user == null)
            return null;
        return user.Id;
    }
}
