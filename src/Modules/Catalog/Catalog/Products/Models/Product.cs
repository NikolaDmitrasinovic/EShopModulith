using Catalog.Products.Events;

namespace Catalog.Books.Models;
public class Product : Aggregate<Guid>
{
    public string Name { get; private set; } = default!;
    public List<string> Category { get; private set; } = [];
    public string Description { get; private set; } = default!;
    public string ImageFile { get; private set; } = default!;
    public decimal Price { get; private set; }

    public static Product Create(Guid id, string title, List<string> category, string description, string imageFile, decimal score)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(score);

        var product = new Product
        {
            Id = id,
            Name = title,
            Category = category,
            ImageFile = imageFile,
            Price = score
        };

        product.AddDomainEvent(new ProductCreatedEvent(product));

        return product;
    }
    
    public void Update(string title, List<string> category, string description, string imageFile, decimal price)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        Name = title;
        Category = category;
        Description = description;
        ImageFile = imageFile;

        if (Price != price)
        {
            Price = price;
            AddDomainEvent(new ProductPriceChangedEvent(this));
        }
    }
}
