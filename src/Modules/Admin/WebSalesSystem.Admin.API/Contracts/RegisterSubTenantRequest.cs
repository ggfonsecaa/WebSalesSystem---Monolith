namespace WebSalesSystem.Admin.API.Contracts;
public class RegisterSubTenantRequest
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
}