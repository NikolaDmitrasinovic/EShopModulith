using Shared.Exceptions;

namespace Catalog.Products.Exceptions;
public class ProductNotFoundExcepion : NotFoundException
{
    public ProductNotFoundExcepion(Guid id) : base("Product", id)
    {
    }
}
