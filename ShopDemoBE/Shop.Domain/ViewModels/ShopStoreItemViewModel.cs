namespace Shop.Domain.ViewModels;

public record ShopStoreItemViewModel
{
    public Guid ItemId { get; set; }
    public ItemViewModel Item { get; set; } = null!;
    public DateTime DateAdded { get; set; }
}
