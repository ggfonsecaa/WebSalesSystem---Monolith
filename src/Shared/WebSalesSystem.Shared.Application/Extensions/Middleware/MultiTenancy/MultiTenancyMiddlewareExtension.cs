namespace WebSalesSystem.Shared.Application.Extensions.Middleware.MultiTenancy;
public static class MultiTenancyMiddlewareExtension
{
    public static IApplicationBuilder UseMultiTenancy<T, S>(this IApplicationBuilder builder) where T : BaseTenant where S : BaseSubTenant => builder.UseMiddleware<MultiTenancyMiddleware<T, S>>();

    public static IApplicationBuilder UseMultiTenancy(this IApplicationBuilder builder) => builder.UseMiddleware<MultiTenancyMiddleware<BaseTenant, BaseSubTenant>>();
}