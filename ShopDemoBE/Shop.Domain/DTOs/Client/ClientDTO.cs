using Shop.Application.DTOs.Base; 

namespace Shop.Domain.DTOs.Client;

public record ClientDTO : BaseDTO
{ 
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}
