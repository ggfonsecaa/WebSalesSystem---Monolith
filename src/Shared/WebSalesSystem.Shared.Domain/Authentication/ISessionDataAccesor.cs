namespace WebSalesSystem.Shared.Domain.Authentication;
public interface ISessionDataAccesor<T>
{
    public T SessionData { get; }
}