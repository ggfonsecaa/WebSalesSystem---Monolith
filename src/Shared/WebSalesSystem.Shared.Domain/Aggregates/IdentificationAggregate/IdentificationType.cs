namespace WebSalesSystem.Shared.Domain.Aggregates.IdentificationAggregate;
public class IdentificationType : Entity, ISubTenantEntity, IAuditableEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Abbreviation { get; private set; }
    public IdentificationDataType DataType { get; private set; }
    public int MinLength { get; private set; }
    public int MaxLength { get; private set; }
    public int TenantId { get; set; }
    public Tenant? Tenant { get; set; }
    public int SubTenantId { get; set; }
    public SubTenant? SubTenant { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? LastModifiedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }


#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    public IdentificationType() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.

    public IdentificationType(string name, string abbreviation, IdentificationDataType dataType, int minLength, int maxLength)
    {
        Name = name;
        Abbreviation = abbreviation;
        DataType = dataType;
        MinLength = minLength;
        MaxLength = maxLength;
    }
}