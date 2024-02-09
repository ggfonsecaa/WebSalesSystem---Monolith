namespace WebSalesSystem.Admin.Application.Models;
public class TenantDTO
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
    public Guid Identifier { get; set; }
    public bool IsActive { get; set; }
    public StorageType StorageType { get; set; }
    public string? StorageName { get; set; }
    public bool UseSubTenants { get; set; }
    public bool AllowExternalRegister { get; set; }
    public bool UseEmailConfirmation { get; set; }
}