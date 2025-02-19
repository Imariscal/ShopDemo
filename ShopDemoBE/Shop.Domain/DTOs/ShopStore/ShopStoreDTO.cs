using Shop.Application.DTOs.Base;
using Shop.Domain.DTOs.Item;

namespace Shop.Domain.DTOs.ShopStore;

public record ShopStoreDTO : BaseDTO
{ 
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

}

