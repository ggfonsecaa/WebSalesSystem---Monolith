namespace WebSalesSystem.Shared.Domain.Middleware;
public class MultiTenancyMiddleware<T, S>(RequestDelegate next, IFeatureManager featureManager) where T : BaseTenant where S : BaseSubTenant
{
    private readonly RequestDelegate _next = next;
    private readonly IFeatureManager _featureManager = featureManager;

    public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
    {
        if (!await IsMultiTenantEnabled(context)) 
        { 
            await _next(context);
            return;
        }

        ITenantStorage<T, S> tenantStorage = serviceProvider.GetRequiredService<ITenantStorage<T, S>>();
        ITenantResolutionStrategy tenantResolutionStrategy = serviceProvider.GetRequiredService<ITenantResolutionStrategy>();

        if (!context.Items.ContainsKey(AppConstants.TENANT_KEY))
        {
            string identifier = await tenantResolutionStrategy.GetTenantIdentifierAsync(default);
            T tenant = await tenantStorage.GetTenantAsync(identifier, default);
            context.Items.Add(AppConstants.TENANT_KEY, tenant);
        }

        if (!context.Items.ContainsKey(AppConstants.SUBTENANT_KEY))
        {
            if (context.Items.TryGetValue(AppConstants.TENANT_KEY, out object? tenantObj) && tenantObj is T tenant)
            {
                int subTenantId = await tenantResolutionStrategy.GetSubTenantIdAsync(default);
                S subTenant = await tenantStorage.GetSubTenantAsync(tenant.Identifier.ToString(), subTenantId, default);
                context.Items.Add(AppConstants.SUBTENANT_KEY, subTenant);
            }
        }

        await _next(context);
    }

    private async Task<bool> IsMultiTenantEnabled(HttpContext context)
    {
        string module = context.Request.RouteValues.FirstOrDefault(x => x.Key == "module").Value!.ToString()!;

        return module is not null && await _featureManager.IsEnabledAsync("MultiTenant", new FeatureFilterContext { Module = module });
    }
}