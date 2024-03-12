namespace WebSalesSystem.Shared.API.Contracts;
public class Request<T>
{
    public T? Data { get; set; }
    public Question? Question { get; set; }
    public string Event { get; set; } = null!;
}