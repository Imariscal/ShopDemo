using Shop.Persistence.Contexts.Base;

namespace Shop.Infrastructure.Repositories.Base;

public interface IWriteOnlyUnitOfWork : IReadOnlyUnitOfWork
{
    Task<int> SaveAsync();
    Task BeginTransactionAsync();
    Task RollBackTransactionAsync();
    Task CommitTransactionAsync();
}