using MapsterMapper;
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.Domain.Repositories.Base;
using Shop.Domain.ViewModels;

namespace Shop.Application.BussinesProcess.ShopStore.Query
{
    public class GetShopStoreQuery : ICommand<IEnumerable<ShopStoreViewModel>> {}

    public class GetShopStoreQueryHandler(IReadOnlyRepository<Guid, Domain.Entities.ShopStore> repository, IMapper mapper)
    : IQueryHandler<GetShopStoreQuery, IEnumerable<ShopStoreViewModel>>
    {
        public async Task<IEnumerable<ShopStoreViewModel>> Handle(GetShopStoreQuery query)
        {
            var shopStores = await repository.GetAllAsync(new[] { "ShopStoreItems", "ShopStoreItems.Item" });
            var shopStoresDTO = mapper.Map<IEnumerable<ShopStoreViewModel>>(shopStores);
            return shopStoresDTO;
        }
    }
}
