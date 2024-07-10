using WebSalesSystem.Shared.Domain.Aggregates.IdentificationAggregate;

namespace WebSalesSystem.Admin.Application.Commands.RegisterSubTenant;
public class RegisterSubTenantCommand : IRequest<ErrorOr<SubTenantDTO>>
{
    public IdentificationType IdentificationType { get; set; } = null!;
    public string IdentificationNumber { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Description { get; set; } = null!;
}