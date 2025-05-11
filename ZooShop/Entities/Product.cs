using ZooShop.Enums;

namespace ZooShop.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string? Image { get; set; }
    public Categories Category { get; set; }
    
    public ICollection<OrderItem> OrderItems { get; set; }
}