using Carter;

namespace WebSalesSystem.Admin.API.Endpoints;
public class AdminEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        _ = app.MapGet("api/products", GetProducts);
        _ = app.MapGet("api/products/{productId}",GetProduct).Produces(StatusCodes.Status404NotFound);
        _ = app.MapPost("api/products",CreateProduct).Produces(StatusCodes.Status201Created).ProducesValidationProblem();
    }

    private async Task<IResult> GetProducts() => Results.Ok();

    private async Task<IResult> GetProduct(int productId) => Results.Ok();

    private async Task<IResult> CreateProduct() => Results.Created($"api/products/", null);
}