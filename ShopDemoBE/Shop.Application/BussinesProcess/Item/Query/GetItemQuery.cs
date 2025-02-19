using MapsterMapper;
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.Domain.DTOs.Client;
using Shop.Domain.DTOs.ShopStore;
using Shop.Domain.Repositories.Base;
using Shop.Domain.ViewModels;

namespace Shop.Application.BussinesProcess.ShopStore.Item
{
    public class GetItemQuery { }

    public class GetItemQueryHandler(IReadOnlyRepository<Guid, Domain.Entities.Item> repository, IMapper mapper)
    : IQueryHandler<GetItemQuery, IEnumerable<ItemViewModel>>
    {
        public async Task<IEnumerable<ItemViewModel>> Handle(GetItemQuery query)
        {
            var items = await repository.GetAllAsync();
            var itemsDTO = mapper.Map<IEnumerable<ItemViewModel>>(items);
            return itemsDTO;
        }
    }
}
