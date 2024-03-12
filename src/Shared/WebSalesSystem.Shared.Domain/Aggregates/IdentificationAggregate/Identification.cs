namespace WebSalesSystem.Shared.Domain.Aggregates.IdentificationAggregate;
public class Identification(IdentificationType type, string number) : ValueObject, ICommonEntity
{
    public IdentificationType Type { get; set; } = type;
    public string Number { get; set; } = number;
    public DateTime IssuedDate { get; set; }
    public DateTime ExpiryDate { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Type;
        yield return Number;
        yield return IssuedDate;
        yield return ExpiryDate;
    }
}