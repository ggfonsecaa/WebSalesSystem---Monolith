namespace WebSalesSystem.Admin.Application.Models;
public class TenantDTO
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
    public Guid Identifier { get; set; }
    public bool IsActive { get; set; }
    public int? StorageType { get; set; }
    public int? DbProvider { get; set; }
    public string? StorageName { get; set; }
    public bool UseSubTenants { get; set; }
    public bool AllowExternalRegister { get; set; }
    public bool UseEmailConfirmation { get; set; }
}