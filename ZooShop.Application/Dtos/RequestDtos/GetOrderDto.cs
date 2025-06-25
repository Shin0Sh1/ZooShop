namespace ZooShop.Application.Dtos.RequestDtos;

public class GetOrderDto
{
    public Guid UserId { get; init; }
    public Guid OrderId { get; init; }
}