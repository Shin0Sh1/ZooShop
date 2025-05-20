using ZooShop.Dtos.ResponseDtos;

namespace ZooShop.Dtos.DeleteDtos;

public class DeleteOrderItemDto
{
    public Guid UserId { get; init; }
    public Guid OrderId { get; init; }
    public List<Guid> OrderItemIds { get; init; }
}