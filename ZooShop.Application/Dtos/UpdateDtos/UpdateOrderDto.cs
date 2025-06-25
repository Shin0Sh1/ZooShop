using ZooShop.Application.Dtos.CreateDtos;

namespace ZooShop.Application.Dtos.UpdateDtos;

public class UpdateOrderDto
{
    public Guid OrderId { get; init; }
    public Guid UserId { get; init; }
    public List<CreateOrderItemDto>? OrderItems { get; init; }
}