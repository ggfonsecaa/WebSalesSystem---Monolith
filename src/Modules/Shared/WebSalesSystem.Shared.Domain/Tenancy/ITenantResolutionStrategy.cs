namespace WebSalesSystem.Shared.Domain.Tenancy;
public interface ITenantResolutionStrategy
{
    Task<string> GetTenantIdentifierAsync();
}