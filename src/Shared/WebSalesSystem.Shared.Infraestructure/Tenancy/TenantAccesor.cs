namespace WebSalesSystem.Shared.Infraestructure.Tenancy;
public class TenantAccessor<T, S>(IHttpContextAccessor contextAccessor, IServiceProvider serviceProvider/*, ConsumeContext consumeContext*/) : ITenantAccessor<T, S> where T : BaseTenant where S : BaseSubTenant
{
    private readonly IHttpContextAccessor _contextAccessor = contextAccessor;
    private readonly ITenantStorage<T, S> _tenantStore = serviceProvider.GetRequiredService<ITenantStorage<T, S>>();
    private readonly ITenantResolutionStrategy _resolutionStrategy = serviceProvider.GetRequiredService<ITenantResolutionStrategy>();

    public T? Tenant 
    { 
        get 
        {
            T? tenantFromContext = _contextAccessor.HttpContext?.GetTenant() as T;

            if (tenantFromContext is not null)
            {
                return tenantFromContext;
            }
            else 
            {
                string? identifier = _resolutionStrategy.GetTenantIdentifierAsync().GetAwaiter().GetResult();
                //identifier ??= consumeContext.Headers.FirstOrDefault(x => x.Key == AppConstants.TENANT_HEADER).Value.ToString();
                T tenant = _tenantStore.GetTenantAsync(identifier!).GetAwaiter().GetResult();
                _contextAccessor.HttpContext?.Items.Add(AppConstants.TENANT_KEY, tenant);

                return tenant;
            };
        }
    }
    public S? SubTenant
    {
        get
        {
            S? subTenantFromContext = _contextAccessor.HttpContext?.GetSubTenant() as S;

            if (subTenantFromContext is not null)
            {
                return subTenantFromContext;
            }
            else 
            {
                int? id = _resolutionStrategy.GetSubTenantIdAsync().GetAwaiter().GetResult();
                //id ??= consumeContext.Headers.FirstOrDefault(x => x.Key == AppConstants.SUBTENANT_HEADER).Value.ToString()!.FromHashId();
                S subTenant = _tenantStore.GetSubTenantAsync(Tenant!.Identifier.ToString(), id.Value).GetAwaiter().GetResult();
                _contextAccessor.HttpContext?.Items.Add(AppConstants.SUBTENANT_KEY, subTenant);

                return subTenant;
            }
        } 
    }
}