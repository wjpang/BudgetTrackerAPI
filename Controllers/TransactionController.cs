using BudgetTracker.Models;
using BudgetTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionEntryController : ControllerBase
{
    private readonly TransactionEntryService _transactionEntryService;

    public TransactionEntryController(TransactionEntryService transactionEntryService)
    {
        _transactionEntryService = transactionEntryService;
    }

    // GET all action
    [HttpGet]
    public async Task<ActionResult<List<TransactionEntry>>> GetAll() => await _transactionEntryService.GetAllAsync();

    // GET by Id action
    [HttpGet("{id}")]
    public async Task<ActionResult<TransactionEntry>> Get(int id)
    {
        var transactionEntry = await _transactionEntryService.GetAsync(id);

        if (transactionEntry is null)
            return NotFound();

        return transactionEntry;
    }

    // POST action
    [HttpPost]
    public async Task<IActionResult> Create(TransactionEntry transactionEntry)
    {
        await _transactionEntryService.AddAsync(transactionEntry);
        return CreatedAtAction(nameof(Create), new { id = transactionEntry.Id }, transactionEntry);
    }

    // PUT action
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TransactionEntry transactionEntry)
    {
        if (id != transactionEntry.Id)
            return BadRequest();

        var existingBudget = await _transactionEntryService.GetAsync(id);
        if (existingBudget is null)
            return NotFound();

        await _transactionEntryService.UpdateAsync(transactionEntry);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var transactionEntry = await _transactionEntryService.GetAsync(id);

        if (transactionEntry is null)
            return NotFound();

        await _transactionEntryService.DeleteAsync(id);

        return NoContent();
    }
}
