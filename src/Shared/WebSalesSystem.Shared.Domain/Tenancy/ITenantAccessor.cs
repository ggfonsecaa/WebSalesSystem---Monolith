namespace WebSalesSystem.Shared.Domain.Tenancy;
public interface ITenantAccessor
{
    public Tenant? Tenant { get; }
    public SubTenant? SubTenant { get; }


    public Task GetTenantAsync();
    public Task GetSubTenantAsync();
    public string GetConnectionString(string context);
}