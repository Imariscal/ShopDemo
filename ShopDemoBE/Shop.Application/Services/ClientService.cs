
using Catalog.Application.BussinesProcess.Employee;
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.Application.BussinesProcess.Client.Command;
using Shop.Application.BussinesProcess.Client.Query;
using Shop.Application.BussinesProcess.ShopStore.Command;
using Shop.Application.Services.Contracts;
using Shop.Domain.DTOs.Client;
using Shop.Domain.ViewModels;

namespace Shop.Application.Services
{
    public class ClientService(IMediator mediator) : IClientService
    { 
        public async Task<IEnumerable<ClientViewModel>> GetClientDataAsync()
        {
            var handler = mediator.GetQueryHandler<GetClientQuery, IEnumerable<ClientViewModel>>();
            return await handler.Handle(new GetClientQuery());
        }

        public async Task<ClientViewModel> PostClient(ClientViewModel client)
        {
            var handler = mediator.GetCommandHandler<PostClientCommand, ClientViewModel>();
            return await handler.Handle(new PostClientCommand(client));
        }

        public async Task<ClientViewModel> UpdateClient(Guid clienId, ClientDTO client)
        {
            var handler = mediator.GetCommandHandler<PutClientCommand, ClientViewModel>();
            return await handler.Handle(new PutClientCommand(clienId, client));
        }

        public async Task<ClientViewModel> PostItemToClient(Guid clientId, Guid itemId)
        {
            var handler = mediator.GetCommandHandler<PostAddItemClientCommand, ClientViewModel>();
            return await handler.Handle(new PostAddItemClientCommand(clientId, itemId));
        }

        public async Task<ClientViewModel> DeleteItemToClient(Guid clientId, Guid itemId)
        {
            var handler = mediator.GetCommandHandler<DeleteItemFromClientCommand, ClientViewModel>();
            return await handler.Handle(new DeleteItemFromClientCommand(clientId, itemId));
        }

        public async Task<bool> DeleteClient(Guid clienId)
        {
            var handler = mediator.GetCommandHandler<DeleteClientCommand, bool>();
            return await handler.Handle(new DeleteClientCommand(clienId));
        }

        public async Task<ClientViewModel> GetClientByIdAsync(Guid clientId)
        {

            var handler = mediator.GetQueryHandler<GetClientByIdQuery, ClientViewModel>();
            return await handler.Handle(new GetClientByIdQuery(clientId));
        }
    }
}
