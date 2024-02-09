namespace WebSalesSystem.Shared.Infraestructure.Tenancy.ResolutionStrategy;
public class HostResolutionStrategy(IHttpContextAccessor httpContext) : ITenantResolutionStrategy
{
    private readonly IHttpContextAccessor _httpContext = httpContext;

    public async Task<string> GetTenantIdentifierAsync(CancellationToken cancellationToken = default) 
        => _httpContext is null ? string.Empty : await Task.FromResult(_httpContext.HttpContext!.Request.Host.Host);

    public async Task<int> GetSubTenantIdAsync(CancellationToken cancellationToken = default) 
        => _httpContext is null
            ? default
            : await Task.FromResult(_httpContext.HttpContext!.Request.Headers.First(x => x.Key == AppConstants.SUBTENANT_HEADER).Value.ToString().FromHashId());
}