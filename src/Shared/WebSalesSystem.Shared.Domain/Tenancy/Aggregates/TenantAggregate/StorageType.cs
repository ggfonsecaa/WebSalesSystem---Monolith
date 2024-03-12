namespace WebSalesSystem.Shared.Domain.Tenancy.Aggregates.TenantAggregate;
public class StorageType(int id, string name) : Enumeration(id, name)
{
    public static readonly StorageType Shared = new(1, nameof(Shared));
    public static readonly StorageType DedicatedSchema = new(2, nameof(DedicatedDatabase)); 
    public static readonly StorageType DedicatedDatabase = new(3, nameof(DedicatedDatabase));
}