namespace Basket.Basket.Features.AdItemToBasket;

public record AddItemToBasketRequest(string UserName, ShoppingCartItemDto ShoppingCart);
public record AddItemToBasketResponse(Guid Id);

public class AddItemToBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket/{userName}/items",
                async ([FromRoute] string userName, [FromBody] AddItemToBasketRequest request, ISender sender) =>
                {
                    var command = new AddItemIntoBasketCommand(userName, request.ShoppingCart);

                    var result = await sender.Send(command);

                    var response = result.Adapt<AddItemToBasketResponse>();

                    return Results.Created($"/basket/{response.Id}", response);
                })
            .WithName("AddItemToBasket")
            .Produces<AddItemToBasketResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Add Item to Basket")
            .WithDescription(("Add Item to Basket"));
    }
}