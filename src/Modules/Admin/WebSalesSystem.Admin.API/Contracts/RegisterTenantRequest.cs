namespace WebSalesSystem.Admin.API.Contracts;
public class RegisterTenantRequest
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
    public StorageType StorageType { get; set; }
    public string? StorageName { get; set; }
    public bool UseSubTenants { get; set; }
    public bool AllowExternalRegister { get; set; }
    public bool UseEmailConfirmation { get; set; }
}