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

    public async Task<List<TransactionEntry>> GetAllAsync() => await _context.TransactionEntry.ToListAsync();

    public async Task<TransactionEntry?> GetAsync(int id) => await _context.TransactionEntry.FirstOrDefaultAsync(e => e.Id == id);

    public async Task<TransactionEntry?> AddAsync(TransactionEntry transactionEntry)
    {
        _context.TransactionEntry.Add(transactionEntry);
        await _context.SaveChangesAsync();
        return transactionEntry;
    }

    public async Task DeleteAsync(int id)
    {
        var transactionEntry = await GetAsync(id);
        if (transactionEntry != null)
        {
            _context.TransactionEntry.Remove(transactionEntry);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(TransactionEntry transactionEntry)
    {
        _context.Entry(transactionEntry).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
