namespace WebSalesSystem.Shared.Application.Extensions.Middleware.MultiTenancy;
public static class MultiTenancyServiceCollectionExtension
{
    public static TenantBuilder<T, S> AddMultiTenancy<T, S>(this IServiceCollection services) where T : BaseTenant where S : BaseSubTenant => new(services);

    public static TenantBuilder<BaseTenant, BaseSubTenant> AddMultiTenancy(this IServiceCollection services) => new(services);
}