using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.Application.BussinesProcess.ShopStore.Command;
using Shop.Application.BussinesProcess.ShopStore.Query;
using Shop.Application.Services.Contracts;
using Shop.Domain.DTOs.ShopStore;
using Shop.Domain.ViewModels;

namespace Shop.Application.Services
{
    public class ShopService(IMediator mediator) : IShopStoreService
    {
        public async Task<ShopStoreViewModel> GetShopStoreByIdAsync(Guid shopId)
        {
            var handler = mediator.GetQueryHandler<GetShopStoreByIdQuery, ShopStoreViewModel>();
            return await handler.Handle(new GetShopStoreByIdQuery(shopId));
        }

        public async Task<IEnumerable<ShopStoreViewModel>> GetShopStoreDataAsync()
        {
            var handler = mediator.GetQueryHandler<GetShopStoreQuery, IEnumerable<ShopStoreViewModel>>();
            return await handler.Handle(new GetShopStoreQuery());
        }

        public async Task<ShopStoreViewModel> PostShopStore(ShopStoreDTO shop)
        {
            var handler = mediator.GetCommandHandler<PostShopStoreCommand, ShopStoreViewModel>();
            return await handler.Handle(new PostShopStoreCommand(shop));
        }

        public async Task<ShopStoreViewModel> PutShopStore(Guid shopId, ShopStoreDTO shop)
        {
            var handler = mediator.GetCommandHandler<PutShopStoreCommand, ShopStoreViewModel>();
            return await handler.Handle(new PutShopStoreCommand(shopId, shop));
        }

        public async Task<ShopStoreViewModel> PostItemToShopStore(Guid shopId, Guid itemId)
        {
            var handler = mediator.GetCommandHandler<PostAddItemShopStoreCommand, ShopStoreViewModel>();
            return await handler.Handle(new PostAddItemShopStoreCommand(shopId, itemId));
        }

        public async Task<ShopStoreViewModel> DeleteItemToShopStore(Guid shopId, Guid itemId)
        {
            var handler = mediator.GetCommandHandler<DeleteItemFromShopStoreCommand, ShopStoreViewModel>();
            return await handler.Handle(new DeleteItemFromShopStoreCommand(shopId, itemId));
        }

        public async Task<bool> DeleteShopStore(Guid shopId)
        {
            var handler = mediator.GetCommandHandler<DeleteShopStoreCommand, bool>();
            return await handler.Handle(new DeleteShopStoreCommand(shopId));
        }

    }
}
