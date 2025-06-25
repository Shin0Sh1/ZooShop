using ZooShop.Enums;

namespace ZooShop.Dtos.ResponseDtos;

public class ProductDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string? Description { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public Categories Category { get; init; }
}