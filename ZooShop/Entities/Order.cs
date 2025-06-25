using ZooShop.Enums;

namespace ZooShop.Entities;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; private set; }
    public Guid UserId { get; private set; }
    public OrderStatus Status { get; private set; }

    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();
    private readonly List<OrderItem> _orderItems = [];

    public Order(Guid id, DateTime orderDate, OrderStatus status) : base(id)
    {
        Id = id;
        OrderDate = orderDate;
        Status = status;
    }

    private Order() : base(Guid.NewGuid())
    {
    }

    public void Update(OrderStatus status)
    {
        Status = status;
    }
    
    public void AddOrderItem(OrderItem orderItem)
    {
        var existOrderItem = _orderItems.FirstOrDefault(u => u.Product.Id == orderItem.Product.Id);
        if (existOrderItem is null)
        {
            _orderItems.Add(orderItem);
        }
        else
        {
            existOrderItem.Update(orderItem.Quantity, orderItem.TotalPrice);
        }
    }

    public void DeleteOrderItems(List<Guid> orderItemIds)
    {
        if (orderItemIds.Count <= 0) return;
        var orders = _orderItems.Where(u => orderItemIds.Contains(u.Id)).ToList();
        foreach (var order in orders)
        {
            _orderItems.Remove(order);
        }
    }
}