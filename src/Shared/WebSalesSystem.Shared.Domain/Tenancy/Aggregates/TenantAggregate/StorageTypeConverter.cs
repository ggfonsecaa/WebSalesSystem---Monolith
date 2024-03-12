namespace WebSalesSystem.Shared.Domain.Tenancy.Aggregates.TenantAggregate;
public class StorageTypeConverter : ValueConverter<StorageType, int>
{
    public StorageTypeConverter() : base(x => x.Id, x => Enumeration.FromId<StorageType>(x)!) { }
}
