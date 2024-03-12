namespace WebSalesSystem.Shared.Infraestructure.Extensions.Middleware.MultiTenancy;
public static class MultiTenancyServiceCollectionExtension
{
    public static TenantBuilder AddMultiTenancy(this IServiceCollection services) => new(services);
}