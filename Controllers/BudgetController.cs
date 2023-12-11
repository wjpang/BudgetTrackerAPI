using BudgetTracker.Models;
using BudgetTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class BudgetController : ControllerBase
{
    private readonly BudgetService _budgetService;

    public BudgetController(BudgetService budgetService)
    {
        _budgetService = budgetService;
    }

    // GET all action
    [HttpGet]
    public async Task<ActionResult<List<Budget>>> GetAll() => await _budgetService.GetAllAsync();

    // GET by Id action
    [HttpGet("{id}")]
    public async Task<ActionResult<Budget>> Get(int id)
    {
        var budget = await _budgetService.GetAsync(id);

        if (budget is null)
            return NotFound();

        return budget;
    }

    // POST action
    [HttpPost]
    public async Task<IActionResult> Create(Budget budget)
    {
        await _budgetService.AddAsync(budget);
        return CreatedAtAction(nameof(Create), new { id = budget.Id }, budget);
    }

    // PUT action
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Budget budget)
    {
        if (id != budget.Id)
            return BadRequest();

        var existingBudget = await _budgetService.GetAsync(id);
        if (existingBudget is null)
            return NotFound();

        await _budgetService.UpdateAsync(budget);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var budget = await _budgetService.GetAsync(id);

        if (budget is null)
            return NotFound();

        await _budgetService.DeleteAsync(id);

        return NoContent();
    }
}
