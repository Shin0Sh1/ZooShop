namespace ZooShop.Dtos.ResponseDtos;

public class OrderItemDto
{
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
    public decimal TotalPrice { get; init; }
}