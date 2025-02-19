using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shop.Persistence.Contexts.Base;
using Shop.Persistence.Contexts;
using Shop.Domain.Entities;

namespace Shop.Persistence.Contexts;

public class WriteOnlyContext(DbContextOptions<WriteOnlyContext> options) : DbContext(options), IWriteOnlyContext
{
    public bool IsReadOnly => false;
    public bool IsWriteOnly => true;

    public DbSet<Client> Clients { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ShopStore> ShopStores { get; set; }
    public DbSet<ShopStoreItem> ShopStoreItems { get; set; }
    public DbSet<ClientItem> ClientItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReadOnlyContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("ShopDatabase");
        optionsBuilder.ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        base.OnConfiguring(optionsBuilder);
    }

}
