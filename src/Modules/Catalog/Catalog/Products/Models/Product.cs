namespace Catalog.Books.Models;
public class Product : Entity<Guid>
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

        var book = new Product
        {
            Id = id,
            Name = title,
            Category = category,
            ImageFile = imageFile,
            Price = score
        };

        return book;
    }
    
    public void Update(string title, List<string> category, string description, string imageFile, decimal score)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(score);

        Name = title;
        Category = category;
        Description = description;
        ImageFile = imageFile;
        Price = score;

        // TODO: if score changed, rase domain event
    }
}
