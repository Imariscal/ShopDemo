using Microsoft.EntityFrameworkCore;

namespace Shop.Persistence.Contexts.Base;

public interface IReadOnlyUnitOfWork : IDisposable
{
    DbContext Context { get; }
}
