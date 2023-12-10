using BudgetTracker.Models;

namespace BudgetTracker.Services;

public static class UserService
{
    static List<User> Users { get; }
    static int nextId = 1;
    static UserService()
    {
        Users = new List<User>();
    }

    public static List<User> GetAll() => Users;

    public static User? Get(int id) => Users.FirstOrDefault(u => u.Id == id);

    public static User? Add(User user)
    {
        // Check if user email and username already exist
        var existingUser = Users.FirstOrDefault(u => u.Email == user.Email || u.Username == user.Username);
        if (existingUser != null)
            return null;
        user.Id = nextId++;
        Users.Add(user);
        return user;
    }

    public static void Delete(int id)
    {
        var user = Get(id);
        if (user is null)
            return;

        Users.Remove(user);
    }

    public static void Update(User user)
    {
        var index = Users.FindIndex(u => u.Id == user.Id);
        if (index == -1)
            return;

        Users[index] = user;
    }
}
