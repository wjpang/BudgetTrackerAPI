using BudgetTracker.Models;

namespace BudgetTracker.Services.Interfaces
{
    public interface ITransactionEntryService
    {
        Task<List<TransactionEntry>> GetAll();
        Task<TransactionEntry?> Get(int id);
        Task<List<TransactionEntry>> GetEntriesByUser(int userId);
        Task<TransactionEntry?> Add(TransactionEntry transactionEntry);
        Task Delete(int id);
        Task Update(TransactionEntry transactionEntry);
    }
}