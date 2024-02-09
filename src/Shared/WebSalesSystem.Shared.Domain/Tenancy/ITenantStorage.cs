namespace WebSalesSystem.Shared.Domain.Tenancy;
public interface ITenantStorage<T, S> where T : BaseTenant where S : BaseSubTenant
{
    Task<T> GetTenantAsync(string identifier, CancellationToken cancellationToken = default);
    Task<S> GetSubTenantAsync(string identifier, int id, CancellationToken cancellationToken = default);
}