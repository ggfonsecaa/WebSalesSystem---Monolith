using System.ComponentModel.DataAnnotations.Schema;

namespace WebSalesSystem.Shared.Domain.Tenancy.Aggregates.TenantAggregate;
public class Tenant : Entity, ICommonEntity, IAuditableEntity, IAggregateRoot
{
    public string Name { get; protected set; }
    public string Email { get; protected set; }
    public string Description { get; protected set; }
    public Guid Identifier { get; protected set; }
    public bool IsActive { get; protected set; }
    public DbProvider DbProvider { get; protected set; }
    [NotMapped]
    public Configuration Configuration { get; protected set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? LastModifiedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public ICollection<SubTenant> SubTenants { get; set; } = [];


#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    public Tenant() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.

    public Tenant(string name, string email, string description, StorageType storageType, DbProvider dbProvider, string storageName, bool useSubTenants = false, bool allowExternalRegister = false, bool useEmailConfirmation = false)
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