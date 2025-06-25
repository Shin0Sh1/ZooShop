namespace ZooShop.Domain.Entities;

public class OrderItem : BaseEntity
{
    public Guid ProductId { get; private set; } 
    public Product Product { get; private set; }
    public Guid OrderId { get; private set; }
    public int Quantity { get; private set; }
    public decimal TotalPrice { get; private set; }

    public OrderItem(Guid id, int quantity, decimal totalPrice) : base(id)
    {
        Quantity = quantity;
        TotalPrice = totalPrice;
    }

    protected OrderItem() : base(Guid.NewGuid())
    {
    }

    public void Update(int? quantity, decimal? totalPrice)
    {
        if (quantity is not null) Quantity = quantity.Value;
        if (totalPrice is not null) TotalPrice = totalPrice.Value;
    }
}