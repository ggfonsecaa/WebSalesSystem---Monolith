namespace WebSalesSystem.Admin.API.Endpoints;
public class AdminEndpoints : ICarterModule
{ 
    public void AddRoutes(IEndpointRouteBuilder app) => app.MapGroup("{tenant}/api/v{version:apiVersion}/a/{module:regex(admin)}").WithApiVersionSet().HasApiVersion(1)
        .MapPost("register-tenant", async (IMediator mediator, IMapper mapper, [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow), Required] RegisterTenantRequest request, CancellationToken cancellationToken = default) 
            => await CreateTenant(mediator, mapper, request, cancellationToken))
                .Produces(StatusCodes.Status201Created)
                .ProducesValidationProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status500InternalServerError);

    private static async Task<IResult> CreateTenant(IMediator mediator, IMapper mapper, RegisterTenantRequest request, CancellationToken cancellationToken)
    {
        ErrorOr<TenantDTO> authResult = await mediator.Send(mapper.Map<RegisterTenantCommand>(request), cancellationToken);
        return authResult.Match(authResult => SuccessResponse.Create(mapper.Map<TenantDTO>(authResult), "Esta bien", HttpStatusCode.Created), errors => ValidationProblemResponse.Create(errors, message: "Algo esta mal"));
    }
}