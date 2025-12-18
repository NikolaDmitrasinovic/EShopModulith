namespace Catalog.Products.Events;

public record ProudctPriceChangedEvent(Product Product)
    : IDomainEvent;
