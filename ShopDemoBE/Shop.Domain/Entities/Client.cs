using Shop.Domain.Entities.Base;
namespace Shop.Domain.Entities;

public class Client : Auditable<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public virtual ICollection<ClientItem> ClientItems { get; set; } = new List<ClientItem>();
}
