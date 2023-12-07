namespace WebSalesSystem.Shared.Domain.Middleware;
public class MultiTenancyMiddleware<T, S>(RequestDelegate next) where T : BaseTenant where S : BaseSubTenant
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Items.ContainsKey(AppConstants.TENANT_KEY))
        {
            ITenantStorage<T, S> tenantStore = context.RequestServices.GetRequiredService<ITenantStorage<T, S>>();
            ITenantResolutionStrategy resolutionStrategy = context.RequestServices.GetRequiredService<ITenantResolutionStrategy>();

            string identifier = await resolutionStrategy.GetTenantIdentifierAsync();
            T tenant = await tenantStore.GetTenantAsync(identifier);

            context.Items.Add(AppConstants.TENANT_KEY, tenant);
        }

        await _next(context);
    }
}