using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnionDemo.Application.Helpers;
using System.Data;

namespace OnionDemo.Infrastructure
{
    public class UnitOfWork<T> : IUnitOfWork where T : DbContext
    {
        private readonly DbContext _db;
        private IDbContextTransaction? _transaction;
        public UnitOfWork(T db)
        {
            _db = db;
        }
        void IUnitOfWork.BeginTransaction(IsolationLevel isolationLevel)
        {
            if (_db.Database.CurrentTransaction != null) return;
            _transaction = _db.Database.BeginTransaction(isolationLevel);
        }

        void IUnitOfWork.Commit()
        {
            if (_transaction == null)
                throw new InvalidOperationException("no active transaction to commit");
            _transaction.Commit();
            _transaction.Dispose();
        }

        void IUnitOfWork.Rollback()
        {
            if (_transaction == null)
                throw new InvalidOperationException("no active transaction to commit");
            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;
        }
    }
}
