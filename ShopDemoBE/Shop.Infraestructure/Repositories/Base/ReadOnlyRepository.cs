using Shop.Domain.Entities.Base.Contracts;
using Shop.Domain.Repositories.Base;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shop.Persistence.Contexts.Base;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Shop.Infrastructure.Repositories.Utilities;
using System.Security.Cryptography;
using System.Text;

namespace Shop.Infrastructure.Repositories.Base;

public class ReadOnlyRepository<TKey, TEntity> :
    IReadOnlyRepository<TKey, TEntity> where TEntity : class, IBaseEntity<TKey>, IAuditable<TKey>
{
    protected readonly ILogger<ReadOnlyRepository<TKey, TEntity>> _logger;
    protected readonly IReadOnlyUnitOfWork _uow;
    protected readonly DbSet<TEntity> _dbSet;
    private readonly bool _tracking = false;
    private readonly IMemoryCache _cache;
    private readonly MemoryCacheEntryOptions _cacheOptions;

    public ReadOnlyRepository(
        ILogger<ReadOnlyRepository<TKey, TEntity>> logger,
        IReadOnlyUnitOfWork uow,
        IMemoryCache cache)
    {
        _logger = logger;
        _uow = uow;
        _dbSet = _uow.Context.Set<TEntity>();
        _cache = cache;
        _cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(5))
            .SetAbsoluteExpiration(TimeSpan.FromHours(2));
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {

        _logger.LogInformation("Getting information from database...");

        var query = _dbSet.Where(x => x.Active);
        if (!_tracking) query = query.AsNoTracking();
        var entities = await query.ToListAsync();


        return entities!;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(params string[]? includes)
    {

        _logger.LogInformation("Getting information from database...");

        var query = DoGetAll(includes);
        query = query.Where(x => x.Active);
        if (!_tracking) query = query.AsNoTracking();
        var entities = await query.ToListAsync();


        return entities!;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllMatchingAsync(
        Expression<Func<TEntity, bool>> filter, params string[] includes)
    {
        string filterHash = ComputeFilterHash(filter);
        string includesHash = ComputeIncludesHash(includes);
        _logger.LogInformation("Getting information from database...");
        var query = GetQueryable(filter, includes);
        if (!_tracking) query = query.AsNoTracking();
        var entities = await query.ToListAsync();


        return entities!;
    }

    public async Task<TEntity?> GetAsync(TKey entityId)
    {
        _logger.LogInformation("Getting information from database...");

        var query = _dbSet.Where(e => e.Id!.Equals(entityId) && e.Active);
        if (!_tracking) query = query.AsNoTracking();
        var entity = await query.FirstOrDefaultAsync();
        return entity;
    }

    public async Task<TEntity?> GetAsync(TKey entityId, params string[]? includes)
    {
        _logger.LogInformation("Getting information from database...");

        var query = DoGetAll(includes);
        query = query.Where(e => e.Id!.Equals(entityId) && e.Active);
        if (!_tracking) query = query.AsNoTracking();
        var entity = await query.FirstOrDefaultAsync();

        return entity;
    }

    private IQueryable<TEntity> DoGetAll(params string[]? includes)
    {
        IQueryable<TEntity> items = _uow.Context.Set<TEntity>().AsQueryable();
        if (includes != null && includes.Length != 0)
        {
            foreach (var include in includes.Where(i => i != null))
                items = items.Include(include);
        }
        return items;
    }

    private IQueryable<TEntity> GetQueryable(
        Expression<Func<TEntity, bool>>? filter = null,
        params string[] includes)
    {
        IQueryable<TEntity> items = _uow.Context.Set<TEntity>();
        if (includes != null && includes.Length != 0)
        {
            foreach (var include in includes.Where(i => i != null))
                items = items.Include(include);
        }
        if (filter != null) items = items.Where(filter);
        return items;
    }

    private string ComputeFilterHash(Expression<Func<TEntity, bool>> filter)
    {
        var visitor = new ExpressionStringBuilderVisitor();
        visitor.Visit(filter);
        return ComputeHash(visitor.ToString());
    }

    private string ComputeIncludesHash(string[] includes) =>
        ComputeHash(string.Join("|", includes.OrderBy(i => i)));

    private string ComputeHash(string input)
    {
        var hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        return Convert.ToBase64String(hashBytes);
    }
}