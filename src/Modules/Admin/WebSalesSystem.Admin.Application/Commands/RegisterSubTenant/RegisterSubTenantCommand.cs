namespace WebSalesSystem.Admin.Application.Commands.RegisterSubTenant;
public class RegisterSubTenantCommand : IRequest<ErrorOr<SubTenantDTO>>
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Description { get; set; } = null!;
}