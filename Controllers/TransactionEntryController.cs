using BudgetTracker.Models;
using BudgetTracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionEntryController : ControllerBase
{
    private readonly ITransactionEntryService _transactionEntryService;

    public TransactionEntryController(ITransactionEntryService transactionEntryService)
    {
        _transactionEntryService = transactionEntryService;
    }

    // GET all action
    [HttpGet]
    public async Task<ActionResult<List<TransactionEntry>>> GetAll() => await _transactionEntryService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public async Task<ActionResult<TransactionEntry>> Get(int id)
    {
        var transactionEntry = await _transactionEntryService.Get(id);

        if (transactionEntry is null)
            return NotFound();

        return transactionEntry;
    }

    // GET by userId action
    [HttpGet("User/{userId}")]
    public async Task<ActionResult<List<TransactionEntry>>> GetByUserId(int userId) => await _transactionEntryService.GetEntriesByUser(userId);

    // POST action
    [HttpPost]
    public async Task<IActionResult> Create(TransactionEntry transactionEntry)
    {
        await _transactionEntryService.Add(transactionEntry);
        return CreatedAtAction(nameof(Create), new { id = transactionEntry.Id }, transactionEntry);
    }

    // PUT action
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TransactionEntry transactionEntry)
    {
        if (id != transactionEntry.Id)
            return BadRequest();

        var existingBudget = await _transactionEntryService.Get(id);
        if (existingBudget is null)
            return NotFound();

        await _transactionEntryService.Update(transactionEntry);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var transactionEntry = await _transactionEntryService.Get(id);

        if (transactionEntry is null)
            return NotFound();

        await _transactionEntryService.Delete(id);

        return NoContent();
    }
}
