using MapsterMapper;
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.Application.BussinesProcess.ShopStore.Item;
using Shop.Domain.Repositories.Base;
using Shop.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.BussinesProcess.Item.Query
{
    public class GetItemByIdQuery(Guid itemId) : ICommand<ItemViewModel>
    {
        public Guid ItemId { get; set; } = itemId;
    }

    public class GetItemByIdQueryHandler(IReadOnlyRepository<Guid, Domain.Entities.Item> repository, IMapper mapper)
 : IQueryHandler<GetItemByIdQuery, ItemViewModel>
    {
        public async Task<ItemViewModel> Handle(GetItemByIdQuery query)
        {
            var items = await repository.GetAllMatchingAsync(c => c.Id == query.ItemId);
            var item = items.FirstOrDefault();          
            var itemsDTO = mapper.Map<ItemViewModel>(item!);
            return itemsDTO;
        }
    }
}
