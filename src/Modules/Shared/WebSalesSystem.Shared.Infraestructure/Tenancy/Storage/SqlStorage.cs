namespace WebSalesSystem.Shared.Infraestructure.Tenancy.Storage;
public class SqlStorage<TDbContext>(TDbContext dbContext, IMemoryCache cache) : ITenantStorage<BaseTenant, BaseSubTenant> where TDbContext : DbContext
{
    private readonly TDbContext _dbContext = dbContext;
    private readonly IMemoryCache _cache = cache;

    public async Task<BaseTenant> GetTenantAsync(string identifier, CancellationToken cancellationToken = default)
    {
        string cacheKey = $"CacheTenant_{identifier}";
        BaseTenant? tenant = _cache.Get<BaseTenant>(cacheKey);

        if (tenant is null)
        {
            Type entityType = _dbContext.Model.GetEntityTypes().Select(t => t.ClrType).FirstOrDefault(t => t.Name == "Tenants")!;

            if (entityType != null)
            {
                MethodInfo setMethodInfo = _dbContext.GetType().GetMethod("Set")!;
                MethodInfo genericSetMethod = setMethodInfo!.MakeGenericMethod(entityType);
                object entitySet = genericSetMethod.Invoke(_dbContext, null)!;

                IQueryable<object> query = (IQueryable<object>)entitySet!;
                query = query.Where(e => EF.Property<string>(e, "Identifier") == identifier);

                List<object> results = await query.ToListAsync(cancellationToken);
                tenant = (BaseTenant)results.FirstOrDefault()!;
            }

            _ = _cache.Set(cacheKey, tenant);
        }

        return tenant!;
    }

    public async Task<BaseSubTenant> GetSubTenantAsync(string identifier, int id, CancellationToken cancellationToken = default)
    {
        string cacheKey = $"CacheSubtenant_{identifier}_{id}";
        BaseSubTenant? subTenant = _cache.Get<BaseSubTenant>(cacheKey);

        if (subTenant is null)
        {
            Type entityType = _dbContext.Model.GetEntityTypes().Select(t => t.ClrType).FirstOrDefault(t => t.Name == "SubTenants")!;

            if (entityType != null)
            {
                MethodInfo setMethodInfo = _dbContext.GetType().GetMethod("Set")!;
                MethodInfo genericSetMethod = setMethodInfo!.MakeGenericMethod(entityType);
                object entitySet = genericSetMethod.Invoke(_dbContext, null)!;

                IQueryable<object> query = (IQueryable<object>)entitySet!;
                query = query.Where(e => EF.Property<string>(e, "TenantIdentifier") == identifier && EF.Property<int>(e, "Id") == id);

                List<object> results = await query.ToListAsync(cancellationToken);
                subTenant = (BaseSubTenant)results.FirstOrDefault()!;
            }

            _ = _cache.Set(cacheKey, subTenant);
        }

        return subTenant!;
    }
}