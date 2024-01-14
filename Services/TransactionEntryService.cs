using BudgetTracker.Data;
using BudgetTracker.Models;
using BudgetTracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.Services;

public class TransactionEntryService : ITransactionEntryService
{
    private readonly BudgetTrackerContext _context;
    public TransactionEntryService(BudgetTrackerContext context)
    {
        _context = context;
    }

    public async Task<List<TransactionEntry>> GetAll() => await _context.TransactionEntry.ToListAsync();

    public async Task<TransactionEntry?> Get(int id) => await _context.TransactionEntry.FirstOrDefaultAsync(e => e.Id == id);

    public async Task<List<TransactionEntry>> GetEntriesByUser(int userId) => await _context.TransactionEntry.Where(e => e.UserId == userId).ToListAsync();

    public async Task<TransactionEntry?> Add(TransactionEntry transactionEntry)
    {
        await _context.TransactionEntry.AddAsync(transactionEntry);
        await _context.SaveChangesAsync();
        return transactionEntry;
    }

    public async Task Delete(int id)
    {
        var transactionEntry = await Get(id);
        if (transactionEntry != null)
        {
            _context.TransactionEntry.Remove(transactionEntry);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(TransactionEntry transactionEntry)
    {
        var existingEntry = await _context.TransactionEntry.FindAsync(transactionEntry.Id);

        if (existingEntry == null)
        {
            // Handle the case where the category doesn't exist
            return;
        }

        // Update the existing entity's properties
        existingEntry.Description = transactionEntry.Description;
        existingEntry.Amount = transactionEntry.Amount;
        existingEntry.Date = transactionEntry.Date;

        await _context.SaveChangesAsync();
    }
}
