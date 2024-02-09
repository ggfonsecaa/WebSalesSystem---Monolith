namespace WebSalesSystem.Shared.Application.Behaviors;
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IHttpContextAccessor? _httpContextAccessor;
    //private readonly IIdempotencyService _idempotencyService;
    private readonly IValidator<TRequest>? _validator;
    private readonly string? _requestId;

    public ValidationBehavior(IValidator<TRequest>? validator, IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _validator = validator;
        _requestId = _httpContextAccessor?.HttpContext?.Request.Headers.FirstOrDefault(x => x.Key == "Request-Id").Value;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }

        ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        List<Error>? errors = validationResult.Errors.ConvertAll(validationFailure => Error.Validation(
            validationFailure.PropertyName,
            validationFailure.ErrorMessage));

        //if (!string.IsNullOrEmpty(_requestId))
        //{
        //    await _idempotencyService.CreateRequestAsync(ErrorOr<TResponse>.From(errors), cancellationToken);
        //}

        return (dynamic)errors;
    }
}