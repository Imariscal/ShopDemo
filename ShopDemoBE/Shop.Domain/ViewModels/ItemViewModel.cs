using Shop.Application.DTOs.Base;
using Shop.Domain.DTOs.Item;

namespace Shop.Domain.ViewModels;

public record ItemViewModel : ItemDTO
{
    public Guid Id { get; set; }
}


