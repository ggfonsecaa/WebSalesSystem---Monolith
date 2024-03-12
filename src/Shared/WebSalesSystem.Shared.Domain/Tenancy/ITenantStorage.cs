namespace WebSalesSystem.Shared.Domain.Tenancy;
public interface ITenantStorage
{
    Task<Tenant> GetTenantAsync(CancellationToken cancellationToken = default);
    Task<SubTenant> GetSubTenantAsync(CancellationToken cancellationToken = default);
}