using BudgetTracker.Models;
using BudgetTracker.Data;
using Microsoft.EntityFrameworkCore;
using BudgetTracker.Services.Interfaces;

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
        _context.Entry(transactionEntry).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
