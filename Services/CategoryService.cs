using BudgetTracker.Models;

namespace BudgetTracker.Services;

public static class CategoryService
{
    static List<Category> Categories { get; }
    static int nextId = 1;
    static CategoryService()
    {
        Categories = new List<Category>();
    }

    public static List<Category> GetAll() => Categories;

    public static Category? Get(int id) => Categories.FirstOrDefault(c => c.Id == id);

    public static Category? Add(Category category)
    {
        // Check if existing category has same name
        var existingCategory = Categories.FirstOrDefault(c => c.Name == category.Name);
        if (existingCategory != null)
            return null;
        category.Id = nextId++;
        Categories.Add(category);
        return category;
    }

    public static void Delete(int id)
    {
        var category = Get(id);
        if (category is null)
            return;

        Categories.Remove(category);
    }

    public static void Update(Category category)
    {
        var index = Categories.FindIndex(c => c.Id == category.Id);
        if (index == -1)
            return;

        Categories[index] = category;
    }
}