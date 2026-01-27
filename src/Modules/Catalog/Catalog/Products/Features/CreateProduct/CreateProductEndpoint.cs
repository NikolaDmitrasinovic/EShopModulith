using Carter;
using Microsoft.AspNetCore.Routing;

namespace Catalog.Products.Features.CreateProduct;

public record CreateProductRequest(ProductDto Product);
public record CreateProductResponse(Guid Id);

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        throw new NotImplementedException();
    }
}
