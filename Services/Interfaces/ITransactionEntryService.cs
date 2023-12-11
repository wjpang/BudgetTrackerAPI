using BudgetTracker.Models;

namespace BudgetTracker.Services.Interfaces
{
    public interface ITransactionEntryService
    {
        Task<List<TransactionEntry>> GetAllAsync();
        Task<TransactionEntry?> GetAsync(int id);
        Task<TransactionEntry?> AddAsync(TransactionEntry transactionEntry);
        Task DeleteAsync(int id);
        Task UpdateAsync(TransactionEntry transactionEntry);
    }
}