namespace WebSalesSystem.Shared.API.Helpers;
public class ProblemResponse
{
    public static IResult Create(int? statusCode = StatusCodes.Status500InternalServerError, string? message = "Ocurrio un error inesperado") => Results.Problem(message, statusCode: statusCode, title: "Excepción");
}