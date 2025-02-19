
using Shop.Application.BussinesProcess.ShopStore.Command;
using Shop.Catalogos.Retail.Application.BusinessProcess.Base;
using Shop.Domain.DTOs.Client;
using Shop.Domain.ViewModels;

namespace Shop.Application.Services.Contracts
{
    public interface IClientService
    {
        Task<IEnumerable<ClientViewModel>> GetClientDataAsync();
        Task<ClientViewModel> GetClientByIdAsync(Guid clientId);
        Task<ClientViewModel> PostClient(ClientViewModel client);
        Task<ClientViewModel> UpdateClient(Guid clienId, ClientDTO client);
        Task<bool> DeleteClient(Guid clienId);
        Task<ClientViewModel> PostItemToClient(Guid clientId, Guid itemId);
        Task<ClientViewModel> DeleteItemToClient(Guid clientId, Guid itemId); 

    }
}
