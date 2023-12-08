using BudgetTracker.Models;
using BudgetTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    public CategoryController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Category>> GetAll() =>
        CategoryService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Category> Get(int id)
    {
        var category = CategoryService.Get(id);

        if (category is null)
            return NotFound();

        return category;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Category category)
    {
        var newCategory = CategoryService.Add(category);
        if (newCategory is null)
            return BadRequest();
        return CreatedAtAction(nameof(Create), new { id = category.Id }, category);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Category category)
    {
        if (id != category.Id)
            return BadRequest();

        var existingCategory = CategoryService.Get(id);
        if (existingCategory is null)
            return NotFound();

        CategoryService.Update(category);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var category = CategoryService.Get(id);

        if (category is null)
            return NotFound();

        CategoryService.Delete(id);

        return NoContent();
    }
}