using MapsterMapper;
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.Domain.Repositories.Base;
using Shop.Domain.ViewModels;

namespace Shop.Application.BussinesProcess.ShopStore.Query
{
    public class GetShopStoreByIdQuery(Guid shopId) : ICommand<ShopStoreViewModel>
    {
        public Guid ShopId { get; set; } = shopId;
    }

    public class GetShopStoreByIdQueryHandler(IReadOnlyRepository<Guid, Domain.Entities.ShopStore> repository, IMapper mapper)
   : IQueryHandler<GetShopStoreByIdQuery, ShopStoreViewModel>
    {
        public async Task<ShopStoreViewModel> Handle(GetShopStoreByIdQuery query)
        {
            var shopStores = await repository.GetAllMatchingAsync(s => s.Id == query.ShopId , new[] { "ShopStoreItems", "ShopStoreItems.Item" });
            var shopStoresDTO = mapper.Map<ShopStoreViewModel>(shopStores.FirstOrDefault()!);
            return shopStoresDTO;
        }
    }
}
