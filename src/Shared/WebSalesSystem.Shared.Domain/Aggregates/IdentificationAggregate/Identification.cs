namespace WebSalesSystem.Shared.Domain.Aggregates.IdentificationAggregate;
public class Identification : ValueObject, ICommonEntity
{
    public IdentificationType Type { get; set; }
    public string Number { get; set; }
    public DateTime IssuedDate { get; set; }
    public DateTime ExpiryDate { get; set; }

    public Identification(IdentificationType type, string number)
    {
        Type = type;
        Number = number;
    }

    public Identification() { }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Type;
        yield return Number;
        yield return IssuedDate;
        yield return ExpiryDate;
    }
}