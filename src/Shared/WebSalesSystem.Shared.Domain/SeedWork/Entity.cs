namespace WebSalesSystem.Shared.Domain.SeedWork;
public abstract class Entity
{
    private int? _requestedHashCode;
    private int _id;

    public List<DomainEvent> DomainEvents { get; private set; } = [];
    public byte[]? RowVersion { get; private set; }
    public virtual int Id
    {
        get => _id;
        protected set => _id = value;
    }


    public void AddDomainEvent(DomainEvent eventItem)
    {
        DomainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(DomainEvent eventItem)
    {
        if (DomainEvents is null)
        {
            return;
        }

        _ = DomainEvents.Remove(eventItem);
    }

    public bool IsTransient() => Id == default;

    public override bool Equals(object? obj)
    {
        if (obj is null or not Entity)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (GetType() != obj.GetType())
        {
            return false;
        }

        Entity item = (Entity)obj;

        return !item.IsTransient() && !IsTransient() && item.Id == Id;
    }

    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestedHashCode.HasValue)
            {
                _requestedHashCode = Id.GetHashCode() ^ 31;
            }

            return _requestedHashCode.Value;
        }
        else
        {
            return base.GetHashCode();
        }
    }

    public static bool operator ==(Entity left, Entity right) => Equals(left, null) ? Equals(right, null) : left.Equals(right);

    public static bool operator !=(Entity left, Entity right) => !(left == right);
}