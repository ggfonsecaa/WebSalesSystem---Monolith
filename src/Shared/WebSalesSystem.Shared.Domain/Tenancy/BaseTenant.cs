namespace WebSalesSystem.Shared.Domain.Tenancy;
public abstract class BaseTenant : Entity
{
    public string Name { get; protected set; } = null!;
    public string Email { get; protected set; } = null!;
    public string Description { get; protected set; } = null!;
    public Guid Identifier { get; protected set; }
    public bool IsActive { get; protected set; }
}