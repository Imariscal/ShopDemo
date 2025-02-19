
using Catalog.Application.BussinesProcess.Employee;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.Application.BussinesProcess.Client.Command;
using Shop.Application.BussinesProcess.Client.Query;
using Shop.Application.BussinesProcess.Item.Command;
using Shop.Application.BussinesProcess.Item.Query;
using Shop.Application.BussinesProcess.ShopStore.Command;
using Shop.Application.BussinesProcess.ShopStore.Item;
using Shop.Application.BussinesProcess.ShopStore.Query;
using Shop.Domain.DTOs.ShopStore;
using Shop.Domain.ViewModels;

namespace Shop.Application.Registration
{
    public static class BusinessProcessRegistration
    {
        public static IServiceCollection RegisterBusinessProcess(this IServiceCollection services)
        {
            //Client
            services.AddTransient<IQueryHandler<GetClientQuery, IEnumerable<ClientViewModel>>, GetClientQueryHandler>();
            services.AddTransient<IQueryHandler<GetClientByIdQuery, ClientViewModel>, GetClientByIdQueryHandler>();
            services.AddTransient<ICommandHandler<PostClientCommand, ClientViewModel>, PostClientCommandHandler>();
            services.AddTransient<ICommandHandler<PutClientCommand, ClientViewModel>, PutClientCommandHandler>();
            services.AddTransient<ICommandHandler<PostAddItemClientCommand, ClientViewModel>, PostAddItemClientCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteItemFromClientCommand, ClientViewModel>, DeleteItemFromClientCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteClientCommand, bool>, DeleteClientCommandHandler>();

            //Shop
            services.AddTransient<IQueryHandler<GetShopStoreQuery, IEnumerable<ShopStoreViewModel>>, GetShopStoreQueryHandler>();
            services.AddTransient<IQueryHandler<GetShopStoreByIdQuery, ShopStoreViewModel>, GetShopStoreByIdQueryHandler>();
            services.AddTransient<ICommandHandler<PostShopStoreCommand, ShopStoreViewModel>, PostShopStoreCommandHandler>();
            services.AddTransient<ICommandHandler<PutShopStoreCommand, ShopStoreViewModel>, PutShopStoreCommandHandler>();
            services.AddTransient<ICommandHandler<PostAddItemShopStoreCommand, ShopStoreViewModel>, PostAddItemShopStoreCommandHandler>(); 
            services.AddTransient<ICommandHandler<DeleteItemFromShopStoreCommand, ShopStoreViewModel>, DeleteItemFromShopStoreCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteShopStoreCommand, bool>, DeleteShopStoreCommandHandler>();

            //Item
            services.AddTransient<IQueryHandler<GetItemQuery, IEnumerable<ItemViewModel>>, GetItemQueryHandler>();
            services.AddTransient<IQueryHandler<GetItemByIdQuery, ItemViewModel>, GetItemByIdQueryHandler>();
            services.AddTransient<ICommandHandler<PostItemCommand, ItemViewModel>, PostItemCommandHandler>();
            services.AddTransient<ICommandHandler<PutItemCommand, ItemViewModel>, PutItemCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteItemCommand, bool>, DeleteItemCommandHandler>();
            return services;
        }
    }
}
