using Shop.Domain.DTOs.Client;
using Shop.Domain.DTOs.Item;
using Shop.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.Contracts
{
    public interface IITemService
    {
        Task<IEnumerable<ItemViewModel>> GetItemDataAsync();

        Task<ItemViewModel> GetItemByIdAsync(Guid itemId);

        Task<ItemViewModel> PostItem(ItemDTO item);

        Task<ItemViewModel> UpdteItem(Guid itemId, ItemDTO item);

        Task<bool> DeleteItem(Guid itemId);
    }
}
