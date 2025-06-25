namespace ZooShop.Application.Dtos.DeleteDtos;

public class DeleteOrderItemDto
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public Guid OrderId { get; init; }
    public List<Guid> OrderItemIds { get; init; }
}