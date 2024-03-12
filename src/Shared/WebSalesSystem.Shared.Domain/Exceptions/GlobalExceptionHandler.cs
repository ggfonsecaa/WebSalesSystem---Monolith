namespace WebSalesSystem.Shared.Domain.Exceptions;
public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken) 
    {
        (int statusCode, string message) = exception switch
        {
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, AppValidations.ERROR_SERVERERROR)
        };

        //_logger.LogInformation("{Type}: {StatusCode} with exception {Exception}", "Error", statusCode, message);
        await Results.Problem(exception.Message, statusCode: statusCode, title: message).ExecuteAsync(httpContext);

        return true;
    }
}