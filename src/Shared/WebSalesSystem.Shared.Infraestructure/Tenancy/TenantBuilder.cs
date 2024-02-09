﻿namespace WebSalesSystem.Shared.Infraestructure.Tenancy;
public class TenantBuilder<T, S>(IServiceCollection services) where T : BaseTenant where S : BaseSubTenant
{
    private readonly IServiceCollection _services = services;

    public TenantBuilder<T, S> WithResolutionStrategy<V>(ServiceLifetime lifetime = ServiceLifetime.Scoped) where V : ITenantResolutionStrategy
    {
        _services.Add(ServiceDescriptor.Describe(typeof(ITenantResolutionStrategy), typeof(V), lifetime));
        return this;
    }

    public TenantBuilder<T, S> WithStore<V>(ServiceLifetime lifetime = ServiceLifetime.Scoped) where V : ITenantStorage<T, S>
    {
        _services.Add(ServiceDescriptor.Describe(typeof(ITenantStorage<T, S>), typeof(V), lifetime));
        return this;
    }
}