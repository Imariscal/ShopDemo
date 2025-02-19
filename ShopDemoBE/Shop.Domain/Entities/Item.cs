
using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities
{
    public class Item : Auditable<Guid>
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Prize { get; set; }  
        public string Image { get; set; } = string.Empty;
        public int Stock { get; set; }
        public virtual ICollection<ShopStoreItem> ShopStoreItems { get; set; } = new List<ShopStoreItem>();
    }
}
