﻿using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure.Repositories.Base;
using Shop.Persistence.Contexts.Base;
using Shop.Persistence.Contexts;
using Shop.Persistence.Interceptors;

namespace Shop.Infrastructure.Registration;

public static class ContextRegistration
{
    public static IServiceCollection RegisterContext(this IServiceCollection services)
    {
        services.AddDbContext<ReadOnlyContext>();
        services.AddDbContext<WriteOnlyContext>(o => o.AddInterceptors(new WriteOnlyCommandInterceptor()));
        services.AddTransient<IReadOnlyContext, ReadOnlyContext>();
        services.AddScoped<IWriteOnlyContext, WriteOnlyContext>();
        services.AddScoped<IWriteOnlyUnitOfWork, WriteOnlyUnitOfWork>();
        services.AddScoped<IReadOnlyUnitOfWork, ReadOnlyUnitOfWork>();

        services.AddMemoryCache();
        return services;
    }
}
