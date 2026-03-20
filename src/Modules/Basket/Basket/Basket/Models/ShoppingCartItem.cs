using Shared.DDD;
using System.Diagnostics.CodeAnalysis;

namespace Basket.Basket.Models;

public class ShoppingCartItem : Entity<Guid>
{
    public Guid ShoppingCardId { get; private set; } = default!;
    public Guid ProductId { get; private set; } = default!;
    public int Quantity { get; internal set; } = default!;
    public string Color { get; private set; } = default!;

    public decimal Price { get; private set; } = default;
    public string ProductName { get; private set; } = default!;

    [SetsRequiredMembers]
    internal ShoppingCartItem(Guid shoppingCardId, Guid productId, int quantity, string color, decimal price, string productName)
    {
        ShoppingCardId = shoppingCardId;
        ProductId = productId;
        Quantity = quantity;
        Color = color;
        Price = price;
        ProductName = productName;
    }
}