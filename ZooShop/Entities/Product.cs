using ZooShop.Enums;

namespace ZooShop.Entities;

public class Product  : BaseEntity
{
    public required string Name { get; set; } 
    public string? Description { get; set; } 
    public decimal Price { get; set; } 
    public int Quantity { get; set; } 
    public string? ImageUrl { get; set; } 
    public Categories Category { get; set; } 
    
    public ICollection<OrderItem> OrderItems { get; set; }

    public Product(Guid id, string name, string? description, decimal price, int quantity, string? imageUrl,
        Categories category) : base(id)
    {
        Name = name; 
        Description = description; 
        Price = price; 
        Quantity = quantity; 
        ImageUrl = imageUrl; 
        Category = category; 
    }

    private Product() : base(Guid.NewGuid())
    {
    }
}