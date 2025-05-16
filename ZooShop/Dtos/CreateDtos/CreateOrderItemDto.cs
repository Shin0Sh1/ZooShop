namespace ZooShop.Dtos.CreateDtos;

public class CreateOrderItemDto
{
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
    public decimal TotalPrice { get; init; }
}