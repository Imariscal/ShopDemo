using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.Application.BussinesProcess.Item.Command;
using Shop.Application.BussinesProcess.Item.Query;
using Shop.Application.BussinesProcess.ShopStore.Item;
using Shop.Application.Services.Contracts; 
using Shop.Domain.DTOs.Item; 
using Shop.Domain.ViewModels;
 
namespace Shop.Application.Services
{
    public class ItemService(IMediator mediator) : IITemService
    {    
        public async Task<IEnumerable<ItemViewModel>> GetItemDataAsync()
        {
            var handler = mediator.GetQueryHandler<GetItemQuery, IEnumerable<ItemViewModel>>();
            return await handler.Handle(new GetItemQuery());
        }

        public async Task<ItemViewModel> PostItem(ItemDTO item)
        {
            var handler = mediator.GetCommandHandler<PostItemCommand, ItemViewModel>();
           return await handler.Handle(new PostItemCommand(item));
        }

        public async Task<ItemViewModel> UpdteItem(Guid itemId, ItemDTO item)
        {
            var handler = mediator.GetCommandHandler<PutItemCommand, ItemViewModel>();
            return await handler.Handle(new PutItemCommand(itemId, item));
        }

        public async Task<bool> DeleteItem(Guid itemId)
        {
            var handler = mediator.GetCommandHandler<DeleteItemCommand, bool>();
            return await handler.Handle(new DeleteItemCommand(itemId));
        }

        public async Task<ItemViewModel> GetItemByIdAsync(Guid itemId)
        {
            var handler = mediator.GetQueryHandler<GetItemByIdQuery, ItemViewModel>();
            return await handler.Handle(new GetItemByIdQuery(itemId));
        }
    }
}
