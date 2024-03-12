namespace WebSalesSystem.Shared.Infraestructure.Interceptors;
public class TenantInterceptor(ITenantAccessor tenantAccessor) : SaveChangesInterceptor
{
    private readonly ITenantAccessor _tenantAccessor = tenantAccessor;

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        foreach (EntityEntry item in eventData.Context!.ChangeTracker.Entries().Where(e => e.State == EntityState.Added && e.Entity is ITenantEntity))
        {
            if (_tenantAccessor.Tenant!.IsTransient())
            {
                throw new Exception("Tenant id must be assigned before calling save changes");
            }

            ITenantEntity? entity = item.Entity as ITenantEntity;
            entity!.TenantId = _tenantAccessor.Tenant.Id;
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}