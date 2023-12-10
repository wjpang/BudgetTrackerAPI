using BudgetTracker.Models;
using BudgetTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class BudgetController : ControllerBase
{
    public BudgetController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Budget>> GetAll() =>
        BudgetService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Budget> Get(int id)
    {
        var budget = BudgetService.Get(id);

        if (budget is null)
            return NotFound();

        return budget;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Budget budget)
    {
        BudgetService.Add(budget);
        return CreatedAtAction(nameof(Create), new { id = budget.Id }, budget);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Budget budget)
    {
        if (id != budget.Id)
            return BadRequest();

        var existingBudget = BudgetService.Get(id);
        if (existingBudget is null)
            return NotFound();

        BudgetService.Update(budget);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var budget = BudgetService.Get(id);

        if (budget is null)
            return NotFound();

        BudgetService.Delete(id);

        return NoContent();
    }
}
