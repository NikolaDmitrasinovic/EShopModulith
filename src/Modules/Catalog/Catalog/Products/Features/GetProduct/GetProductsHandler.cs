namespace Catalog.Products.Features.GetProduct;

public record GetPRoductQuery()
    : IQuery<GetProductResult>;

public record GetProductResult(IEnumerable<ProductDto> Products);

internal class GetProductsHandler(CatalogDbContext dbContext)
    : IQueryHandler<GetPRoductQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetPRoductQuery query, CancellationToken cancellationToken)
    {
        // get products
        // return result

        var products = await dbContext.Products
            .AsNoTracking()
            .OrderBy(p=>p.Name)
            .ToListAsync(cancellationToken);

        var productDtos = products.Adapt<List<ProductDto>>();

        return new GetProductResult(productDtos);
    }
}
