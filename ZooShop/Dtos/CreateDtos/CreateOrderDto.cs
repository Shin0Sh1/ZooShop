using ZooShop.Dtos.ResponseDtos;

namespace ZooShop.Dtos.CreateDtos;

public class CreateOrderDto : OrderDto
{
    public Guid UserId { get; init; }
}