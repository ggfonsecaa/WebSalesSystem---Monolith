using Asp.Versioning.Builder;
using Asp.Versioning;

namespace WebSalesSystem.Admin.API.Endpoints;
public class GroupsRoutes : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        ApiVersionSet apiVersionSet = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1))
            .ReportApiVersions()
            .Build();

        _ = app.MapGroup("api/v{version:apiVersion}/a/{module:regex(admin)}")
            .MapTenantEndpoints()
            .WithApiVersionSet(apiVersionSet)
            .HasApiVersion(1);

        _ = app.MapGroup("{tenant}/api/v{version:apiVersion}/a/{module:regex(admin)}")
            .MapSubTenantEndpoints()
            .WithApiVersionSet(apiVersionSet)
            .HasApiVersion(1);
    }
}