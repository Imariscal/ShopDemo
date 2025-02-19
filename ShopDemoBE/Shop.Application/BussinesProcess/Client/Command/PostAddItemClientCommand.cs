using MapsterMapper;
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.CrossCutting.Exceptions;
using Shop.Domain.Repositories.Base;
using Shop.Domain.ViewModels;


namespace Shop.Application.BussinesProcess.Client.Command
{
    public class PostAddItemClientCommand(Guid clientId, Guid itemId) : ICommand<ClientViewModel>
    {
        public Guid ItemId { get; set; } = itemId;
        public Guid ClientId { get; set; } = clientId;
    }

    public class PostAddItemClientCommandHandler(
       IReadOnlyRepository<Guid, Domain.Entities.Client> clientStoreRepository,
       IReadOnlyRepository<Guid, Domain.Entities.Item> itemReadOnlyRepository,
       IWriteOnlyRepository<Guid, Domain.Entities.ClientItem> clientItemWriteRepository,
       IMapper mapper
    ) : ICommandHandler<PostAddItemClientCommand, ClientViewModel>
    {
        public async Task<ClientViewModel> Handle(PostAddItemClientCommand command)
        {
            ArgumentNullException.ThrowIfNull(command);

            var clientStore = await clientStoreRepository.GetAsync(command.ClientId);
            if (clientStore == null)
                throw new NotFoundException("Client not found");

            var item = await itemReadOnlyRepository.GetAsync(command.ItemId);
            if (item == null)
                throw new NotFoundException("Item not found");

            if (clientStore.ClientItems.Any(si => si.ItemId == command.ItemId))
                throw new InvalidOperationException("The item is already in the shop store.");

            var shopStoreItem = new Domain.Entities.ClientItem
            {
                Id = Guid.NewGuid(),
                ClientId = command.ClientId,
                ItemId = command.ItemId,
                DateAdded = DateTime.UtcNow
            };

            await clientItemWriteRepository.AddAsync(shopStoreItem);

            return mapper.Map<ClientViewModel>(clientStore);
        }
    }
}

   
 
