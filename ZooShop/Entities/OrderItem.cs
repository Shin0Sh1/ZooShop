namespace ZooShop.Entities;

public class OrderItem : BaseEntity
{
    public Guid ProductId { get; set; }
    public required Product Product { get; set; }
    public Guid OrderId { get; set; }
    public required Order Order { get; set; }

    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    public OrderItem(Guid id, int quantity, decimal totalPrice) : base(id)
    {
        Quantity = quantity;
        TotalPrice = totalPrice;
    }

    protected OrderItem() : base(Guid.NewGuid())
    {
    }
}