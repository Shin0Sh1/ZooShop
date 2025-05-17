namespace ZooShop.Entities;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; private set; }
    public Guid UserId { get; private set; }

    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();
    private readonly List<OrderItem> _orderItems = [];

    public Order(Guid id, DateTime orderDate, ICollection<OrderItem> orderItems) : base(id)
    {
        Id = id;
        OrderDate = orderDate;
    }

    private Order() : base(Guid.NewGuid())
    {
    }

    public void AddOrderItems(List<OrderItem>? orderItems)
    {
        if (orderItems is not null && orderItems.Count > 0) _orderItems.AddRange(orderItems);
    }

    public void DeleteOrderItems(List<OrderItem>? orderItems)
    {
        if (orderItems is null || orderItems.Count <= 0) return;
        foreach (var orderItem in orderItems) _orderItems.Remove(orderItem);
    }
}