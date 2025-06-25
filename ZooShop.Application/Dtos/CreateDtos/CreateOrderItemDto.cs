namespace ZooShop.Application.Dtos.CreateDtos;

public class CreateOrderItemDto
{
    public Guid UserId { get; init; }
    public Guid? OrderId { get; init; }
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
    public decimal TotalPrice { get; init; }
}