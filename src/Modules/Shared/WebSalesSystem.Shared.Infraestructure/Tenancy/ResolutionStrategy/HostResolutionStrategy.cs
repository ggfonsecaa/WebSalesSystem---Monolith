namespace WebSalesSystem.Shared.Infraestructure.Tenancy.ResolutionStrategy;
public class HostResolutionStrategy(IHttpContextAccessor httpContext) : ITenantResolutionStrategy
{
    private readonly IHttpContextAccessor _httpContext = httpContext;

    public async Task<string> GetTenantIdentifierAsync() => _httpContext is null ? string.Empty : await Task.FromResult(_httpContext.HttpContext!.Request.Host.Host);
}