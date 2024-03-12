using WebSalesSystem.Shared.Domain.Globalization.Resources.Validations;

namespace WebSalesSystem.Shared.API.Helpers;
public class ProblemResponse
{
    public static IResult Create(int? statusCode = StatusCodes.Status500InternalServerError, string? message = null) 
        => Results.Problem(message ?? AppValidations.ERROR_SERVERERROR, statusCode: statusCode, title: AppValidations.ERROR_EXCEPTION);
}