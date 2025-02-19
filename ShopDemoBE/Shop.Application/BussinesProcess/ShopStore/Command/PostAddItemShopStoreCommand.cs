using MapsterMapper;
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.CrossCutting.Exceptions;
using Shop.Domain.Repositories.Base;
using Shop.Domain.ViewModels;

namespace Shop.Application.BussinesProcess.ShopStore.Command
{
    public class PostAddItemShopStoreCommand(Guid shopId, Guid itemId) : ICommand<ShopStoreViewModel>
    {
        public Guid ItemId { get; set; } = itemId;
        public Guid ShopId { get; set; } = shopId;
    }

    public class PostAddItemShopStoreCommandHandler( 
       IReadOnlyRepository<Guid, Domain.Entities.ShopStore> shopStoreRepository,
       IReadOnlyRepository<Guid, Domain.Entities.Item> itemReadOnlyRepository,
       IWriteOnlyRepository<Guid, Domain.Entities.ShopStoreItem> shopStoreItemWriteRepository,
       IMapper mapper
   ) : ICommandHandler<PostAddItemShopStoreCommand, ShopStoreViewModel>
    {
        public async Task<ShopStoreViewModel> Handle(PostAddItemShopStoreCommand command)
        {
            ArgumentNullException.ThrowIfNull(command);

            var shopStore = await shopStoreRepository.GetAsync(command.ShopId);
            if (shopStore == null)
                throw new NotFoundException("Shop Store not found");

            var item = await itemReadOnlyRepository.GetAsync(command.ItemId);
            if (item == null)
                throw new NotFoundException("Item not found");

            if (shopStore.ShopStoreItems.Any(si => si.ItemId == command.ItemId))
                throw new InvalidOperationException("The item is already in the shop store.");

            var shopStoreItem = new Domain.Entities.ShopStoreItem
            {
                Id = Guid.NewGuid(),
                ShopStoreId = command.ShopId,
                ItemId = command.ItemId,
                DateAdded = DateTime.UtcNow
            };

            await shopStoreItemWriteRepository.AddAsync(shopStoreItem);

            return mapper.Map<ShopStoreViewModel>(shopStore);
        }
    }
}
