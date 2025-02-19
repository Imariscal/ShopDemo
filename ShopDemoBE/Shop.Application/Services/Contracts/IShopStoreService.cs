 
using Shop.Domain.DTOs.Client;
using Shop.Domain.DTOs.ShopStore;
using Shop.Domain.ViewModels;

namespace Shop.Application.Services.Contracts
{
    public interface IShopStoreService
    {
        Task<IEnumerable<ShopStoreViewModel>> GetShopStoreDataAsync();
        Task<ShopStoreViewModel> GetShopStoreByIdAsync(Guid shopId);

        Task<ShopStoreViewModel> PostShopStore(ShopStoreDTO shop);

        Task<ShopStoreViewModel> PutShopStore(Guid shopId, ShopStoreDTO shop);

        Task<bool> DeleteShopStore(Guid shopId);

        Task<ShopStoreViewModel> PostItemToShopStore(Guid shopId, Guid itemId);

        Task<ShopStoreViewModel> DeleteItemToShopStore(Guid shopId, Guid itemId);
    }
}
