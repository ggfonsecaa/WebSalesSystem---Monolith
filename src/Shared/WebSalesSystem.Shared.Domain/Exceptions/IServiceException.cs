namespace WebSalesSystem.Shared.Domain.Exceptions;
public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}