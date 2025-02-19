using Shop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class ShopStoreItem : Auditable<Guid>
    {
        public Guid ShopStoreId { get; set; }
        public virtual ShopStore? ShopStore { get; set; }

        public Guid ItemId { get; set; }
        public virtual Item? Item { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
