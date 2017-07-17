using System;
using System.Transactions;

namespace Example.Domain.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;

        void SaveChange();

        void Commit();

        void BeginTransaction(IsolationLevel isolationLevel);
    }
}
