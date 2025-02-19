
using Shop.Domain.DTOs.ShopStore;

namespace Shop.Domain.ViewModels;

public record ShopStoreViewModel : ShopStoreDTO
{
    public Guid Id { get; set; }

    public ICollection<ShopStoreItemViewModel> ShopStoreItems { get; set; } = new List<ShopStoreItemViewModel>();
}
