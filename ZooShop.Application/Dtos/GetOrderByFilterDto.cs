using ZooShop.Domain.Enums;

namespace ZooShop.Application.Dtos;

public class GetOrderByFilterDto
{
    public Guid UserId { get; init; }
    public OrderStatus Status { get; init; }
}