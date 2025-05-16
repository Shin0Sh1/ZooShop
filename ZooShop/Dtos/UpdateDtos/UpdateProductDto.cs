using ZooShop.Enums;

namespace ZooShop.Dtos.UpdateDtos;

public class UpdateProductDto
{
    public Guid Id { get; set; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public decimal? Price { get; init; }
    public int? Quantity { get; init; }
    public string? ImageUrl { get; init; }
    public Categories? Category { get; init; }
}