using Shop.Application.DTOs.Base;

namespace Shop.Domain.DTOs.Item;

public record ItemDTO : BaseDTO
{ 
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Prize { get; set; }
    public string Image { get; set; } = string.Empty;
    public int Stock { get; set; }
}


