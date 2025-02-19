using MapsterMapper;
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.Domain.Repositories.Base;
using Shop.Domain.ViewModels;

namespace Shop.Application.BussinesProcess.Client.Query
{
    public class GetClientByIdQuery(Guid clientId)
    {
        public Guid ClientId { get; set; } = clientId;
    }

    public class GetClientByIdQueryHandler(IReadOnlyRepository<Guid, Domain.Entities.Client> repository, IMapper mapper)
    : IQueryHandler<GetClientByIdQuery, ClientViewModel>
    {
        public async Task<ClientViewModel> Handle(GetClientByIdQuery query)
        {
            var clients = await repository.GetAllMatchingAsync(c => c.Id == query.ClientId, new[] { "ClientItems", "ClientItems.Item" });
            var client = clients.FirstOrDefault();
            var clientDTO = mapper.Map<ClientViewModel>(client!);
            return clientDTO;
        }
    }
}
