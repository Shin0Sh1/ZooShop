using ZooShop.Enums;

namespace ZooShop.Dtos;

public class GetOrderByFilterDto
{
    public Guid UserId { get; init; }
    public OrderStatus Status { get; init; }
}