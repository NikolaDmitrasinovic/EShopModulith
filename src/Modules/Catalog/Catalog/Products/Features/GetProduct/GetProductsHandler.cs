

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

        var productDtos = ProjectToProductDto(products);

        return new GetProductResult(productDtos);
    }

    private List<ProductDto> ProjectToProductDto(List<Product> products)
    {
        foreach (var product in products)
        {

        }
        return [];
    }
}
