namespace ZooShop.Dtos.ResponseDtos;

public class OrderItemDto
{
    public Guid? OrderId { get; init; }
    public ProductDto Product { get; init; }
    public int Quantity { get; init; }
    public decimal TotalPrice { get; init; }
}