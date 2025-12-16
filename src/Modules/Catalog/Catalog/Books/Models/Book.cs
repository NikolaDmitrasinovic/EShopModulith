using Shared.DDD;

namespace Catalog.Books.Models;
public class Book : Entity<Guid>
{
    public string Title { get; private set; } = default!;
    public List<string> Category { get; private set; } = [];
    public string Description { get; private set; } = default!;
    public string ImageFile { get; private set; } = default!;
    public decimal Score { get; private set; }

    public static Book Create(Guid id, string title, List<string> category, string description, string imageFile, decimal score)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(score);

        var book = new Book
        {
            Id = id,
            Title = title,
            Category = category,
            ImageFile = imageFile,
            Score = score
        };

        return book;
    }
    // Property setters private
    // Update method
}
