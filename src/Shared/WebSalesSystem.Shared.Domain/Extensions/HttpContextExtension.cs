namespace WebSalesSystem.Shared.Domain.Extensions;
public static class HttpContextExtension
{
    public static T? GetTenant<T>(this HttpContext context) where T : BaseTenant 
        => !context.Items.ContainsKey(AppConstants.TENANT_KEY) ? null : context.Items[AppConstants.TENANT_KEY] as T;

    public static BaseTenant? GetTenant(this HttpContext context) => context.GetTenant<BaseTenant>();

    public static S? GetSubTenant<S>(this HttpContext context) where S : BaseSubTenant
        => !context.Items.ContainsKey(AppConstants.SUBTENANT_KEY) ? null : context.Items[AppConstants.SUBTENANT_KEY] as S;

    public static BaseSubTenant? GetSubTenant(this HttpContext context) => context.GetSubTenant<BaseSubTenant>();
}