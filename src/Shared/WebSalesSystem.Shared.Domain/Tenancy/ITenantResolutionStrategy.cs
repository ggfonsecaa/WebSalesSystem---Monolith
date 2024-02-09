namespace WebSalesSystem.Shared.Domain.Tenancy;
public interface ITenantResolutionStrategy
{
    Task<string> GetTenantIdentifierAsync(CancellationToken cancellationToken = default);
    Task<int> GetSubTenantIdAsync(CancellationToken cancellationToken = default);
}