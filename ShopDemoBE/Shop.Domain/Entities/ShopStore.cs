using Shop.Domain.Entities.Base;
namespace Shop.Domain.Entities;

public class ShopStore : Auditable<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public virtual ICollection<ShopStoreItem> ShopStoreItems { get; set; } = new List<ShopStoreItem>();
}

