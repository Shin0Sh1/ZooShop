using ZooShop.Enums;

namespace ZooShop.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public string? ImageUrl { get; private set; }
    public Categories Category { get; private set; }

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

    public void Update(string? name = null, string? description = null, decimal? price = null, int? quantity = null,
        string? imageUrl = null, Categories? category = null)
    {
        if (name is not null) Name = name;
        if (description is not null) Description = description;
        if (price is not null) Price = price.Value;
        if (quantity is not null) Quantity = quantity.Value;
        if (imageUrl is not null) ImageUrl = imageUrl;
        if (category is not null) Category = category.Value;
    }
}