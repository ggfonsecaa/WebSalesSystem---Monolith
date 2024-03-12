namespace WebSalesSystem.Shared.Infraestructure.Tenancy.Storage;
public class TenantStorage<TDbContext>(IUnitOfWork<TDbContext> unitOfWork, IMemoryCache cache, ITenantResolutionStrategy tenantResolutionStrategy) : ITenantStorage where TDbContext : DbContext
{
    private readonly ITenantResolutionStrategy _tenantResolutionStrategy = tenantResolutionStrategy;
    private readonly IUnitOfWork<TDbContext> _unitOfWork = unitOfWork;
    private readonly IMemoryCache _cache = cache;
    private Tenant? Tenant { get; set; }
    private SubTenant? SubTenant { get; set; }


    public async Task<Tenant> GetTenantAsync(CancellationToken cancellationToken = default)
    {
        if (Tenant is not null) 
        {
            return Tenant;
        }

        string idTenant = await _tenantResolutionStrategy.GetTenantIdentifierAsync(cancellationToken);
        string cacheKey = $"CacheTenant_{idTenant}";
        Tenant = _cache.Get<Tenant>(cacheKey);

        if (Tenant is null)
        {
            Tenant = (await _unitOfWork.GetRepository<Tenant>().GetByQueryAsync(x => x.Identifier == Guid.Parse(idTenant), cancellationToken: cancellationToken)).FirstOrDefault()!;

            _ = _cache.Set(cacheKey, Tenant);
        }

        return Tenant!;
    }

    public async Task<SubTenant> GetSubTenantAsync(CancellationToken cancellationToken = default)
    {
        if (SubTenant is not null)
        {
            return SubTenant;
        }

        int idSubTenant = await _tenantResolutionStrategy.GetSubTenantIdAsync(cancellationToken);
        string cacheKey = $"CacheSubtenant_{Tenant!.Identifier}_{idSubTenant}";
        SubTenant = _cache.Get<SubTenant>(cacheKey);

        if (SubTenant is null)
        {
            SubTenant = (await _unitOfWork.GetRepository<SubTenant>().GetByQueryAsync(x => x.TenantId == Tenant!.Id && x.Id == idSubTenant, cancellationToken: cancellationToken)).FirstOrDefault();

            _ = _cache.Set(cacheKey, SubTenant);
        }

        return SubTenant!;
    }
}