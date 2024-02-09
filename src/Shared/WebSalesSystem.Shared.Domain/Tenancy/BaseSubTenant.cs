namespace WebSalesSystem.Shared.Domain.Tenancy;
public abstract class BaseSubTenant : Entity
{
    public string Name { get; protected set; } = null!;
    public string Email { get; protected set; } = null!;
    public string Description { get; protected set; } = null!;
    public Guid TenantIdentifier { get; protected set; }
    public bool IsActive { get; protected set; }
}