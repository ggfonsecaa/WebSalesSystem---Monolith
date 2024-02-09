namespace WebSalesSystem.Shared.Domain.SeedWork;
public abstract class DomainEvent : INotification, ICommonEntity
{
    public bool IsPublished { get; private set; }
    public DateTimeOffset DateOccurred { get; private set; }


    protected DomainEvent() => DateOccurred = DateTimeOffset.UtcNow;

    public void Publish() => IsPublished = !IsPublished;
}