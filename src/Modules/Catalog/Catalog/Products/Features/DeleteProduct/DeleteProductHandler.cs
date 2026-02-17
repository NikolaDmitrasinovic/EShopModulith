namespace Catalog.Products.Features.DeleteProduct;

public record DeleteProductCommand(Guid ProductId)
    :ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);
public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Id is required.");
    }
}

internal class DeleteProductHandler(CatalogDbContext dbContext)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        // delete product form command object
        // save to db
        // return result

        var product = await dbContext.Products
            .FindAsync([command.ProductId], cancellationToken);

        if (product == null)
        {
            throw new ProductNotFoundExcepion(command.ProductId);            
        }

        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync();

        return new DeleteProductResult(true);
    }
}
