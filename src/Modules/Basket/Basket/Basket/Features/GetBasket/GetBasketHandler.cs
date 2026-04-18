namespace Basket.Basket.Features.GetBasket;

public record GetBasketRequest(string UserName)
    : IQuery<GetBasketResponse>;

public record GetBasketResponse(ShoppingCartDto ShoppingCart);

internal class GetBasketHandler(BasketDbContext dbContext)
    : IQueryHandler<GetBasketRequest, GetBasketResponse>
{
    public async Task<GetBasketResponse> Handle(GetBasketRequest query, CancellationToken cancellationToken)
    {
        var basket = await dbContext.ShoppingCarts
            .AsNoTracking()
            .Include(x => x.Items)
            .SingleOrDefaultAsync(x => x.UserName == query.UserName, cancellationToken);

        if (basket is null)
        {
            throw new BasketNotFoundException(query.UserName);
        }

        var basketDto = basket.Adapt<ShoppingCartDto>();

        return new GetBasketResponse(basketDto);
    }
}
