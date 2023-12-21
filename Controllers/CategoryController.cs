using BudgetTracker.Models;
using BudgetTracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // GET all action
    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetAll() => await _categoryService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> Get(int id)
    {
        var category = await _categoryService.Get(id);

        if (category is null)
            return NotFound();

        return category;
    }

    // POST action
    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
        var newCategory = await _categoryService.Add(category);
        if (newCategory is null)
            return BadRequest();
        return CreatedAtAction(nameof(Create), new { id = category.Id }, category);
    }

    // PUT action
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Category category)
    {
        if (id != category.Id)
            return BadRequest();

        var existingCategory = await _categoryService.Get(id);
        if (existingCategory is null)
            return NotFound();

        await _categoryService.Update(category);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _categoryService.Get(id);

        if (category is null)
            return NotFound();

        await _categoryService.Delete(id);

        return NoContent();
    }
}
