using Shop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class ClientItem : Auditable<Guid>
    {
        public Guid ClientId { get; set; }
        public virtual Client? Client { get; set; }

        public Guid ItemId { get; set; }
        public virtual Item? Item { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
