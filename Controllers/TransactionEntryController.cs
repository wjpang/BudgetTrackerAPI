using BudgetTracker.Models;
using BudgetTracker.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
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
    [EnableCors("AllowAll")]
    public async Task<ActionResult<List<TransactionEntry>>> GetAll() => await _transactionEntryService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    [EnableCors("AllowAll")]
    public async Task<ActionResult<TransactionEntry>> Get(int id)
    {
        var transactionEntry = await _transactionEntryService.Get(id);

        if (transactionEntry is null)
            return NotFound();

        return transactionEntry;
    }

    // POST action
    [HttpPost]
    [EnableCors("AllowAll")]
    public async Task<IActionResult> Create(TransactionEntry transactionEntry)
    {
        await _transactionEntryService.Add(transactionEntry);
        return CreatedAtAction(nameof(Create), new { id = transactionEntry.Id }, transactionEntry);
    }

    // PUT action
    [HttpPut("{id}")]
    [EnableCors("AllowAll")]
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
    [EnableCors("AllowAll")]
    public async Task<IActionResult> Delete(int id)
    {
        var transactionEntry = await _transactionEntryService.Get(id);

        if (transactionEntry is null)
            return NotFound();

        await _transactionEntryService.Delete(id);

        return NoContent();
    }
}
