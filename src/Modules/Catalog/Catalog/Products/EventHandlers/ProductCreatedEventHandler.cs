using Catalog.Products.Events;

namespace Catalog.Products.EventHandlers;
public class ProductCreatedEventHandler(ILogger<ProductCreatedEvent> logger)
    : INotificationHandler<ProductCreatedEvent>
{
    public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handler: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
