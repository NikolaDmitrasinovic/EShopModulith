using Shared.DDD;

namespace Catalog.Books.Models;
public class Book : Entity<Guid>
{
    public string Title { get; set; } = default!;
    public List<string> Category { get; set; } = [];
    public string Description { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public decimal Score { get; set; }

    // Create method fir initializin Book
    // Property setters private
    // Update method
}
