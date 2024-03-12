using WebSalesSystem.Shared.Domain.Aggregates.IdentificationAggregate;

namespace WebSalesSystem.Shared.Domain.Tenancy.Aggregates.SubTenantAggregate;
public class SubTenant : Entity, ITenantEntity, IAuditableEntity, IAggregateRoot
{
    public Identification Identification { get; set; }
    public string Name { get; protected set; }
    public string Email { get; protected set; }
    public string Description { get; protected set; }
    public bool IsActive { get; protected set; }
    public int TenantId { get; set; }
    public Tenant? Tenant { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? LastModifiedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }


#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    public SubTenant() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.

    public SubTenant(IdentificationType identificationType, string identificationNumber, string name, string email, string description, Tenant tenant) 
    {
        Identification = new Identification(identificationType, identificationNumber);
        Name = name;
        Email = email;
        Description = description;
        Tenant = tenant;
        IsActive = true;
    }
}