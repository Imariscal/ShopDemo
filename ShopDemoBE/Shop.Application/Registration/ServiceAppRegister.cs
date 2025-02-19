
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure.Registration;
using Shop.Domain.BusinessRules.Base;
using Shop.Application.BussinesProcess.Base.Contracts;
using FluentValidation; 
using Shop.Catalogos.Retail.Application.BusinessProcess.Base;
using Shop.Catalogos.Retail.Application.Services.Base;
using Shop.Domain.BusinessRules.Client;
using Shop.Application.Services.Contracts;
using Shop.Domain.DTOs.Client;
using Shop.Application.Services;
using Shop.Domain.DTOs.ShopStore;
using Shop.Domain.BusinessRules.ShopStore;
using Shop.Retail.Domain.BusinessRules.Base;
using Shop.Domain.DTOs.Item;
using Shop.Domain.BusinessRules.Item;


namespace Shop.Application.Registration;

public static class ServiceAppRegister
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        //  Mapper
        services.AddMapster();

        //  Register contexts and repositories
        services.RegisterContext();
        services.RegisterRepositories();

        // Business Process
        services.RegisterBusinessProcess();
   
        services.AddScoped<IMediator, Mediator>();
        services.AddTransient(typeof(IValidationStrategy<>), typeof(FluentValidationStrategy<>));

        //  Validators
        //  Client
        services.AddTransient<IValidator<ClientDTO>, AddClientValidator>();
        services.AddTransient<IValidator<ClientDTO>, UpdateClientValidator>();

        // Shop Store
        services.AddTransient<IValidator<ShopStoreDTO>, AddShopStoreValidator>();
        services.AddTransient<IValidator<ShopStoreDTO>, UpdateShopStoreValidator>();

        // Item 
        services.AddTransient<IValidator<ItemDTO>, AddItemValidator>();
        services.AddTransient<IValidator<ItemDTO>, UpdateItemValidator>();

        //  Application services registration
        services.AddTransient(typeof(IBaseCrudApplicationService<,>), typeof(BaseCrudApplicationService<,>));
        services.AddTransient<IClientService, ClientService>();
        services.AddTransient<IShopStoreService, ShopService>();
        services.AddTransient<IITemService, ItemService>();

        return services;
    }
}
