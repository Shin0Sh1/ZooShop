using ZooShop.Dtos.CreateDtos;

namespace ZooShop.Dtos.ResponseDtos;

public class OrderDto
{
    public required List<CreateOrderItemDto> OrderItems { get; init; }
}