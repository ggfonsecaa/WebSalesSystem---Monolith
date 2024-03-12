namespace WebSalesSystem.Shared.API.Contracts;
public class Response<T>(T? data, HttpStatusCode statusCode, string message)
{
    public HttpStatusCode Status { get; set; } = statusCode;
    public string Message { get; set; } = message;
    public T? Data { get; set; } = data;
}

public class Response(HttpStatusCode statusCode, string? message = null, Question? question = null)
{
    public HttpStatusCode Status { get; set; } = statusCode;
    public string? Message { get; set; } = message;
    public Question? Question { get; set; } = question;
}