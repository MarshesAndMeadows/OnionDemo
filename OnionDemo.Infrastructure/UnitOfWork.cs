

/* i think this is already coded elsewhere...
using Microsoft.EntityFrameworkCore.Storage;
using OnionDemo.Application.Helpers;

namespace OnionDemo.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookMyHomeContext _db;
        private IDbContextTransaction? _currentTransaction;
        public UnitOfWork(BookMyHomeContext database) 
        {
            _db = database;
        }

        async Task IUnitOfWork.BeginTransactionAsync()
        {
            if (_currentTransaction == null)
                throw new InvalidOperationException("A transaction has already been started.");
            _currentTransaction = await _db.Database.BeginTransactionAsync();
        }

        async Task IUnitOfWork.CommitTransactionAsync()
        {
            if (_currentTransaction == null)
                throw new InvalidOperationException("A transaction has not been started");
            try
            {
                await _currentTransaction.CommitAsync();
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
            catch (Exception ex)
            {
                if (_currentTransaction != null)
                    await _currentTransaction.RollbackAsync();
                throw;
            }
        }
    }
}*/
