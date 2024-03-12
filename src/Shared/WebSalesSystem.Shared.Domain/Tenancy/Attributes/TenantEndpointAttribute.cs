namespace WebSalesSystem.Shared.Domain.Tenancy.Attributes;
public class TenantEndpointAttribute(bool validateTenant = true) : ActionFilterAttribute
{
    public bool ValidateTenant { get; } = validateTenant;
}