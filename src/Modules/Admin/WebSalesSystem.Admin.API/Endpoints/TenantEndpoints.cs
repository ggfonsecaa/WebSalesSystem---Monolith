using WebSalesSystem.Shared.Domain.Tenancy.Attributes;

namespace WebSalesSystem.Admin.API.Endpoints;
public static class TenantEndpoints
{
    public static RouteGroupBuilder MapTenantEndpoints(this RouteGroupBuilder group)
    {
        _ = group.MapPost("register-tenant", async (IMediator mediator, IMapper mapper, [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow), Required] Request<RegisterTenantRequest> request, CancellationToken cancellationToken = default)
            => await CreateTenant(mediator, mapper, request, cancellationToken))
                .Produces(StatusCodes.Status201Created)
                .ProducesValidationProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status500InternalServerError)
                .WithMetadata(new TenantEndpointAttribute(false));

        return group;
    }


    private static async Task<IResult> CreateTenant(IMediator mediator, IMapper mapper, Request<RegisterTenantRequest> request, CancellationToken cancellationToken)
    {
        ErrorOr<TenantDTO> authResult = await mediator.Send(mapper.Map<RegisterTenantCommand>(request.Data), cancellationToken);
        return authResult.Match(authResult => SuccessResponse.Create(mapper.Map<TenantDTO>(authResult), AdminValidations.TENANT_REGISTRATIONSUCCESS, HttpStatusCode.Created), errors => ValidationProblemResponse.Create(errors, message: AdminValidations.TENANT_REGISTRATIONFAILED));
    }
}