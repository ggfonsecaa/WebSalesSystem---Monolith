namespace WebSalesSystem.Shared.API.Helpers;
public class SuccessResponse
{
    public static IResult Create(string message, HttpStatusCode statusCode = HttpStatusCode.OK)
        => statusCode switch
            {
                HttpStatusCode.OK => Results.Ok(new Response(statusCode, message)),
                HttpStatusCode.NoContent => Results.NoContent(),
                HttpStatusCode.Accepted => Results.Accepted(),
                HttpStatusCode.Created => Results.Created(string.Empty, new Response(statusCode, message)),
                _ => Results.StatusCode((int)statusCode),
            };



    public static IResult Create<T>(T data, string message, HttpStatusCode statusCode = HttpStatusCode.OK) => Results.Json(new Response<T>(data, statusCode, message), statusCode: (int) statusCode);
}