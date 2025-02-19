using MapsterMapper;
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.CrossCutting.Exceptions;
using Shop.Domain.Repositories.Base;
using Shop.Domain.ViewModels;

namespace Shop.Application.BussinesProcess.ShopStore.Command
{
    public class DeleteItemFromShopStoreCommand(Guid shopId, Guid itemId) : ICommand<ShopStoreViewModel>
    {
        public Guid ItemId { get; set; } = itemId;
        public Guid ShopId { get; set; } = shopId;
    }

    public class DeleteItemFromShopStoreCommandHandler(
       IWriteOnlyRepository<Guid, Domain.Entities.ShopStoreItem> shopStoreItemWriteRepository,
       IReadOnlyRepository<Guid, Domain.Entities.ShopStoreItem> shopStoreItemReadOnlyRepository,
       IReadOnlyRepository<Guid, Domain.Entities.ShopStore> shopStoreReadOnlyRepository,
       IMapper mapper
   ) : ICommandHandler<DeleteItemFromShopStoreCommand, ShopStoreViewModel>
    {
        public async Task<ShopStoreViewModel> Handle(DeleteItemFromShopStoreCommand command)
        {
            ArgumentNullException.ThrowIfNull(command);
             
            var shopStoreItem = await shopStoreItemReadOnlyRepository
               .GetAllMatchingAsync(si => si.ShopStoreId == command.ShopId && si.ItemId == command.ItemId);

            if (!shopStoreItem.Any())
                throw new NotFoundException("Item not found in the specified Shop Store.");

            var item = shopStoreItem.FirstOrDefault();
         
            await shopStoreItemWriteRepository.Remove(item);

            var shopStore = await shopStoreReadOnlyRepository.GetAsync(command.ShopId);

            return mapper.Map<ShopStoreViewModel>(shopStore);
        }
    }
}
