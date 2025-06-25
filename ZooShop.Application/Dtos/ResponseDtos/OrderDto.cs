namespace ZooShop.Application.Dtos.ResponseDtos;

public class OrderDto
{
    public required Guid Id { get; init; }
    public required List<OrderItemDto> OrderItems { get; init; }
    public required String Status { get; init; }
}