namespace WebSalesSystem.Shared.API.Contracts;
public class Response<T>(T? data, string message, HttpStatusCode statusCode)
{
    public HttpStatusCode Status { get; set; } = statusCode;
    public string Message { get; set; } = message;
    public T? Data { get; set; } = data;
}

public class Response(string message, HttpStatusCode statusCode)
{
    public HttpStatusCode Status { get; set; } = statusCode;
    public string Message { get; set; } = message;
}