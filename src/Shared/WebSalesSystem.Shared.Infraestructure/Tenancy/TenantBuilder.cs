namespace WebSalesSystem.Shared.Infraestructure.Tenancy;
public class TenantBuilder(IServiceCollection services)
{
    private readonly IServiceCollection _services = services;

    public TenantBuilder WithResolutionStrategy<V>(ServiceLifetime lifetime = ServiceLifetime.Scoped) where V : ITenantResolutionStrategy
    {
        _services.Add(ServiceDescriptor.Describe(typeof(ITenantResolutionStrategy), typeof(V), lifetime));
        return this;
    }

    public TenantBuilder WithStore<V>(ServiceLifetime lifetime = ServiceLifetime.Scoped) where V : ITenantStorage
    {
        _services.Add(ServiceDescriptor.Describe(typeof(ITenantStorage), typeof(V), lifetime));
        return this;
    }
}