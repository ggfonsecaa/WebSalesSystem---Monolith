namespace WebSalesSystem.Shared.Infraestructure.Extensions.Middleware.Globalization;
public static class GlobalizationMiddlewareExtension
{
    public static IApplicationBuilder UseGlobalization(this IApplicationBuilder builder) => builder.UseMiddleware<GlobalizationMiddleware>();
}
