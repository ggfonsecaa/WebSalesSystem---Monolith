namespace WebSalesSystem.Shared.Domain.Tenancy;
public interface ITenantAccessor<T, S> where T : BaseTenant where S : BaseSubTenant
{
    public T? Tenant { get; }
    public S? SubTenant { get; }
}