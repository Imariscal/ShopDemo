using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ViewModels
{
    public class ClientItemViewModel
    {
        public Guid ItemId { get; set; }
        public ItemViewModel Item { get; set; } = null!;
        public DateTime DateAdded { get; set; }
    }
}
