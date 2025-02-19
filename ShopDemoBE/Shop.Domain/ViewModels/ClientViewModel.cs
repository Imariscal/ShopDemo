using Shop.Application.DTOs.Base;
using Shop.Domain.DTOs.Client;

namespace Shop.Domain.ViewModels;

public record ClientViewModel : ClientDTO
{
    public Guid Id { get; set; }

    public ICollection<ClientItemViewModel> ClientItem { get; set; } = new List<ClientItemViewModel>();
}
