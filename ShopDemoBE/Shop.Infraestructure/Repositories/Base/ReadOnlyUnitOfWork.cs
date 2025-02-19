﻿using Microsoft.EntityFrameworkCore;
using Shop.Persistence.Contexts.Base;

namespace Shop.Infrastructure.Repositories.Base;

public class ReadOnlyUnitOfWork(IReadOnlyContext context) : IReadOnlyUnitOfWork
{
    private bool _disposed;

    public DbContext Context { get; private set; } = (DbContext)context;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            if (Context != null) Context.Dispose();
        }

        _disposed = true;
    }
}
