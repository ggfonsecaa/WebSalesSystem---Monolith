namespace WebSalesSystem.Shared.Infraestructure.Extensions.Middleware.MultiTenancy;
public static class MultiTenancyMiddlewareExtension
{
    public static IApplicationBuilder UseMultiTenancy(this IApplicationBuilder builder) => builder.UseMiddleware<MultiTenancyMiddleware>();
}