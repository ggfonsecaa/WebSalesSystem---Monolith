namespace WebSalesSystem.Shared.Domain.Extensions;
public static class HttpContextExtension
{
    public static Tenant? GetTenant(this HttpContext context)
        => !context.Items.ContainsKey(AppConstants.TENANT_KEY) ? null : context.Items[AppConstants.TENANT_KEY] as Tenant;

    public static SubTenant? GetSubTenant(this HttpContext context)
        => !context.Items.ContainsKey(AppConstants.SUBTENANT_KEY) ? null : context.Items[AppConstants.SUBTENANT_KEY] as SubTenant;
}