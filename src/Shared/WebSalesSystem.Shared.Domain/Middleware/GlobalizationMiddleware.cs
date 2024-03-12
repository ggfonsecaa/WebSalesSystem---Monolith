namespace WebSalesSystem.Shared.Domain.Middleware;
public class GlobalizationMiddleware(CultureProvider cultureProvider) : IMiddleware
{
    private readonly CultureProvider _cultureProvider = cultureProvider;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next) 
    {
        _cultureProvider.SetCultureInfo(context?.Request.Headers.GetCultureInfo()!);
        await next(context!);
    }  
}