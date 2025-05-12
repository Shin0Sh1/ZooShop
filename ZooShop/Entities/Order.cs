namespace ZooShop.Entities;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; private set; }
    public Guid UserId { get; private set; }

    public ICollection<OrderItem> OrderItems { get; set; }

    public Order(Guid id, DateTime orderDate, ICollection<OrderItem> orderItems) : base(id)
    {
        Id = id;
        OrderDate = orderDate;
        OrderItems = orderItems;
    }

    private Order() : base(Guid.NewGuid())
    {
    }
}