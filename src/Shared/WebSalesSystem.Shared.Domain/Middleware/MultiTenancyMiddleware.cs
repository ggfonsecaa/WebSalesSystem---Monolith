using WebSalesSystem.Shared.Domain.Tenancy.Attributes;

namespace WebSalesSystem.Shared.Domain.Middleware;
public class MultiTenancyMiddleware(IFeatureManager featureManager, ITenantAccessor tenantAccessor) : IMiddleware
{
    private readonly IFeatureManager _featureManager = featureManager;
    private readonly ITenantAccessor _tenantAccessor = tenantAccessor;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.GetEndpoint()!.Metadata.GetMetadata<TenantEndpointAttribute>()!.ValidateTenant && await IsMultiTenancyEnabled(context))
        {
            await _tenantAccessor.GetTenantAsync();

            if (_tenantAccessor.Tenant is null)
            {
                await Results.Problem(AppValidations.ERROR_TENANTNOTPROVIDED, statusCode: 500, title: AppValidations.ERROR_SERVERERROR).ExecuteAsync(context);
                return;
            }

            await _tenantAccessor.GetSubTenantAsync();

            if (_tenantAccessor.Tenant.Configuration.UseSubTenants && _tenantAccessor.SubTenant is null)
            {
                await Results.Problem(AppValidations.ERROR_SUBTENANTNOTPROVIDED, statusCode: 500, title: AppValidations.ERROR_SERVERERROR).ExecuteAsync(context);
                return;
            }
        }

        await next(context);
    }

    private async Task<bool> IsMultiTenancyEnabled(HttpContext context)
    {
        string module = context.Request.RouteValues.FirstOrDefault(x => x.Key == "module").Value!.ToString()!;

        return module is not null && await _featureManager.IsEnabledAsync("MultiTenant", new FeatureFilterContext { Module = module });
    }
}