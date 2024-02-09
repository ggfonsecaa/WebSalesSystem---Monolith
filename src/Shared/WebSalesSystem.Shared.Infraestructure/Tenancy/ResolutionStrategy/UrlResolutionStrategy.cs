namespace WebSalesSystem.Shared.Infraestructure.Tenancy.ResolutionStrategy;
public class UrlResolutionStrategy(IHttpContextAccessor httpContext) : ITenantResolutionStrategy
{
    private readonly IHttpContextAccessor _httpContext = httpContext;

    public async Task<string> GetTenantIdentifierAsync(CancellationToken cancellationToken = default) 
        => _httpContext is null
            ? string.Empty
            : await Task.FromResult(_httpContext.HttpContext!.Request.RouteValues.FirstOrDefault(x => x.Key == AppConstants.TENANT_ROUTE).Value!.ToString()!);

    public async Task<int> GetSubTenantIdAsync(CancellationToken cancellationToken = default) 
        => _httpContext is null
            ? default
            : await Task.FromResult(_httpContext.HttpContext!.Request.Headers.First(x => x.Key == AppConstants.SUBTENANT_HEADER).Value.ToString().FromHashId());
}