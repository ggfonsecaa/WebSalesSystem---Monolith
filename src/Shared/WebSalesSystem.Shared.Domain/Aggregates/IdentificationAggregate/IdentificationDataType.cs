namespace WebSalesSystem.Shared.Domain.Aggregates.IdentificationAggregate;
public class IdentificationDataType(int id, string name) : Enumeration(id, name)
{
    public static IdentificationDataType Alphanumeric = new(1, nameof(Alphanumeric));
    public static IdentificationDataType Alphabetic = new(2, nameof(Alphabetic));
    public static IdentificationDataType Numeric = new(2, nameof(Numeric));
}