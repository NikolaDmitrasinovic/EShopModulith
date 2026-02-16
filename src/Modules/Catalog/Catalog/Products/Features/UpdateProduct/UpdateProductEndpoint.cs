namespace Catalog.Products.Features.UpdateProduct;

public record UpdateProductRequest(ProductDto Product);
public record UpdateProductResponse(bool IsSuccess);
public class UpdateProudctCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProudctCommandValidator()
    {
        RuleFor(x => x.Product.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.Product.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Product.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
    }
}

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateProductCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateProductResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateProduct")
        .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Update Product")
        .WithDescription("Update Product");
    }
}
