using MapsterMapper;
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.Domain.DTOs.ShopStore;
using Shop.Domain.Repositories.Base;
using Shop.Domain.ViewModels;

namespace Shop.Application.BussinesProcess.Client.Query
{
    public class GetClientQuery { }

    public class GetClientQueryHandler(IReadOnlyRepository<Guid, Domain.Entities.Client> repository, IMapper mapper)
    : IQueryHandler<GetClientQuery, IEnumerable<ClientViewModel>>
    {
        public async Task<IEnumerable<ClientViewModel>> Handle(GetClientQuery query)
        {
            var clients = await repository.GetAllAsync(new[] { "ClientItems", "ClientItems.Item" });

            var clientDTO = mapper.Map<IEnumerable<ClientViewModel>>(clients);
            return clientDTO;
        }
    }
}
