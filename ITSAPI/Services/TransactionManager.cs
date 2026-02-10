using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

public class TransactionManager : IDisposable
{
    private readonly Dictionary<DbContext, IDbContextTransaction> _transactions = new();

    public void BeginTransaction(params DbContext[] dbContexts)
    {
        foreach (var dbContext in dbContexts)
        {
            if (!_transactions.ContainsKey(dbContext))
            {
                var transaction = dbContext.Database.BeginTransaction();
                _transactions.Add(dbContext, transaction);
            }
        }
    }

    public void Commit()
    {
        foreach (var transaction in _transactions.Values)
        {
            transaction.Commit();
        }
    }

    public void Rollback()
    {
        foreach (var transaction in _transactions.Values)
        {
            transaction.Rollback();
        }
    }

    public void Dispose()
    {
        foreach (var transaction in _transactions.Values)
        {
            transaction.Dispose();
        }

        _transactions.Clear();
    }
}
