namespace WebSalesSystem.Shared.Domain.Tenancy;
public abstract class BaseTenant : Entity
{
    public string Name { get; protected private set; } = null!;
    public string Email { get; protected private set; } = null!;
    public string Description { get; protected private set; } = null!;
    public Guid Identifier { get; protected private set; }
    public bool IsActive { get; protected private set; }
}