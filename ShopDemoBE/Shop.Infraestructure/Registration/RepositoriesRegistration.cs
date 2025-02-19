using Shop.Infrastructure.Repositories.Base;
using Microsoft.Extensions.DependencyInjection; 
using Shop.Domain.Repositories.Base; 
 

namespace Shop.Infrastructure.Registration;

public static class RepositoriesRegistration
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IReadOnlyRepository<,>), typeof(ReadOnlyRepository<,>));
        services.AddScoped(typeof(IWriteOnlyRepository<,>), typeof(WriteOnlyRepository<,>));

        return services;
    }
}
