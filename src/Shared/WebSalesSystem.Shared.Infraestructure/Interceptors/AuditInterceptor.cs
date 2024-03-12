namespace WebSalesSystem.Shared.Infraestructure.Interceptors;
public class AuditInterceptor(ITenantAccessor tenantAccessor) : SaveChangesInterceptor
{
    private readonly ITenantAccessor _tenantAccessor = tenantAccessor; //Cambiar por el user accesor

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        foreach (EntityEntry<IAuditableEntity> entry in eventData.Context!.ChangeTracker.Entries<IAuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _tenantAccessor.Tenant!.Id;
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = _tenantAccessor.Tenant!.Id; ;
                    entry.Entity.LastModifiedAt = DateTime.UtcNow;
                    break;
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}