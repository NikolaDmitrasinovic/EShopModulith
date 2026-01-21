using Catalog.Products.Events;

namespace Catalog.Products.EventHandlers;
public class ProductPriceChangedEventHandler(ILogger<ProductPriceChangedEvent> logger)
    : INotificationHandler<ProductPriceChangedEvent>
{
    public Task Handle(ProductPriceChangedEvent notification, CancellationToken cancellationToken)
    {
        // TODO publish product price changed integration event
        logger.LogInformation("Domain Event handled: {DomainEvent", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
