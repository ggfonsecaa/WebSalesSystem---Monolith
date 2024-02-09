namespace WebSalesSystem.Admin.Domain.Aggregates.TenantAggregate;
public class Tenant : BaseTenant, ICommonEntity, IAuditableEntity, IAggregateRoot
{
    public Configuration Configuration { get; private set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? LastModifiedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }


    private Tenant() { }

    public Tenant(string name, string email, string description, StorageType storageType, string storageName, bool useSubTenants = false, bool allowExternalRegister = false, bool useEmailConfirmation = false)
    {
        Name = name;
        Email = email;
        Description = description;
        Configuration = new(storageType, storageName, useSubTenants, allowExternalRegister, useEmailConfirmation);

        Identifier = Guid.NewGuid();
        IsActive = true;

        //AddDomainEvent(new TenantCreatedEvent(this));
    }


    public void ChangeState()
    {
        IsActive = !IsActive;
        //DomainEvents.Add(new TenantUpdatedEvent(this));
    }
}