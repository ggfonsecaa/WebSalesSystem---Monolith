namespace WebSalesSystem.Shared.API.Helpers;
public class ValidationProblemResponse
{
    public static IResult Create(List<Error> errors, int? statusCode = null, string? message = null)
    {
        statusCode ??= StatusCodeConversion(errors);
        message ??= AppValidations.ERROR_VALIDATIONFAILED;

        if (errors.Count == 1 && errors.All(error => error.Type != ErrorType.Validation))
        {
            return Results.Problem(detail: errors.FirstOrDefault().Description, statusCode: statusCode, title: message);
        }

        Dictionary<string, string[]> modelDictionary = [];

        foreach (Error error in errors)
        {
            if (modelDictionary.TryGetValue(JsonNamingPolicy.CamelCase.ConvertName(error.Code), out string[]? value))
            {
                modelDictionary[JsonNamingPolicy.CamelCase.ConvertName(error.Code)] = [.. value, .. new[] { error.Description }];
            }
            else
            {
                modelDictionary.Add(JsonNamingPolicy.CamelCase.ConvertName(error.Code), [error.Description]);
            }
        }

        return Results.ValidationProblem(modelDictionary, statusCode: statusCode, title: AppValidations.ERROR_VALIDATIONFAILED);
    }

    private static int StatusCodeConversion(List<Error> errors) 
        => errors.All(error => error.Type == ErrorType.Conflict) ? StatusCodes.Status409Conflict
            : errors.All(error => error.Type == ErrorType.NotFound) ? StatusCodes.Status404NotFound : StatusCodes.Status400BadRequest;
}