namespace WebSalesSystem.Admin.Domain.Aggregates.TenantAggregate;
public class Configuration(StorageType storageType, string storageName, bool useSubTenants, bool allowExternalRegister, bool useEmailConfirmation) : ValueObject, ICommonEntity
{
    public StorageType StorageType { get; private set; } = storageType;
    public string StorageName { get; private set; } = storageName;
    public bool UseSubTenants { get; private set; } = useSubTenants;
    public bool AllowExternalRegister { get; private set; } = allowExternalRegister;
    public bool UseEmailConfirmation { get; private set; } = useEmailConfirmation;


    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StorageType;
        yield return StorageName;
        yield return UseSubTenants;
        yield return AllowExternalRegister;
        yield return UseEmailConfirmation;
    }
}