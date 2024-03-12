using WebSalesSystem.Admin.Application.Commands.RegisterSubTenant;
using WebSalesSystem.Shared.Domain.Tenancy.Attributes;

namespace WebSalesSystem.Admin.API.Endpoints;
public static class SubTenantEndpoints
{
    public static RouteGroupBuilder MapSubTenantEndpoints(this RouteGroupBuilder group)
    {
        _ = group.MapPost("register-subtenant", async (IMediator mediator, IMapper mapper, [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow), Required] Request<RegisterSubTenantRequest> request, CancellationToken cancellationToken = default)
            => await CreateSubTenant(mediator, mapper, request, cancellationToken))
                .Produces(StatusCodes.Status201Created)
                .ProducesValidationProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status500InternalServerError)
                .WithMetadata(new TenantEndpointAttribute());

        return group;
    }


    private static async Task<IResult> CreateSubTenant(IMediator mediator, IMapper mapper, Request<RegisterSubTenantRequest> request, CancellationToken cancellationToken)
    {
        ErrorOr<SubTenantDTO> authResult = await mediator.Send(mapper.Map<RegisterSubTenantCommand>(request.Data), cancellationToken);
        return authResult.Match(authResult => SuccessResponse.Create(mapper.Map<SubTenantDTO>(authResult), AdminValidations.SUBTENANT_REGISTRATIONSUCCESS, HttpStatusCode.Created), errors => ValidationProblemResponse.Create(errors, message: AdminValidations.SUBTENANT_REGISTRATIONFAILED));
    }
}
