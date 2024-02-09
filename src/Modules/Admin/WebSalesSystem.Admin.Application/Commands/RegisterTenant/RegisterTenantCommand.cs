namespace WebSalesSystem.Admin.Application.Commands.RegisterTenant;
public class RegisterTenantCommand : IRequest<ErrorOr<TenantDTO>>
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Description { get; set; } = null!;
    public StorageType StorageType { get; set; }
    public string StorageName { get; set; } = null!;
    public bool UseSubTenants { get; set; }
    public bool AllowExternalRegister { get; set; }
    public bool UseEmailConfirmation { get; set; }
}