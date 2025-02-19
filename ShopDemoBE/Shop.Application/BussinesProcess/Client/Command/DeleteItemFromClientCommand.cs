using MapsterMapper;
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.CrossCutting.Exceptions;
using Shop.Domain.Repositories.Base;
using Shop.Domain.ViewModels;

namespace Shop.Application.BussinesProcess.ShopStore.Command
{
    public class DeleteItemFromClientCommand(Guid clientId, Guid itemId) : ICommand<ClientViewModel>
    {
        public Guid ItemId { get; set; } = itemId;
        public Guid ClientId { get; set; } = clientId;
    }

    public class DeleteItemFromClientCommandHandler(
       IWriteOnlyRepository<Guid, Domain.Entities.ClientItem> clientItemWriteRepository,
       IReadOnlyRepository<Guid, Domain.Entities.ClientItem> clientItemReadOnlyRepository, 
       IMapper mapper
   ) : ICommandHandler<DeleteItemFromClientCommand, ClientViewModel>
    {
        public async Task<ClientViewModel> Handle(DeleteItemFromClientCommand command)
        {
            ArgumentNullException.ThrowIfNull(command);

            var clientItems = await clientItemReadOnlyRepository
               .GetAllMatchingAsync(ci => ci.ClientId == command.ClientId && ci.ItemId == command.ItemId);

            if (!clientItems.Any())
                throw new NotFoundException("Item not found in the specified Shop Store.");

            var item = clientItems.FirstOrDefault();

            await clientItemWriteRepository.Remove(item);

            var shopStore = await clientItemReadOnlyRepository.GetAsync(command.ClientId);

            return mapper.Map<ClientViewModel>(shopStore);
        }
    }
}
