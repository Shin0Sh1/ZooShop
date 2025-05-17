using ZooShop.Exceptions;

namespace ZooShop.Entities;

public class User : BaseEntity
{
    public string Nickname { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string? Address { get; private set; }

    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();
    private readonly List<Order> _orders = [];

    public User(Guid id, string nickname, string email, string password, string? address) : base(id)
    {
        Nickname = nickname;
        Email = email;
        Password = password;
        Address = address;
    }

    private User() : base(Guid.NewGuid())
    {
    }

    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }

    public void Update(string? nickname, string? email, string? password, string? address)
    {
        if (nickname is not null) Nickname = nickname;

        if (email is not null) Email = email;

        if (password is not null) Password = password;

        if (address is not null) Address = address;
    }

    public void AddOrderItems(Guid orderId, List<OrderItem>? orderItems)
    {
        if (orderItems is not null && orderItems.Count > 0)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId) ??
                        throw new EntityNotFoundException("Заказ не найден");
            order.AddOrderItems(orderItems);
        }
    }

    public void DeleteOrderItems(Guid orderId, List<OrderItem>? orderItems)
    {
        if (orderItems is not null && orderItems.Count > 0)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId) ??
                        throw new EntityNotFoundException("Заказ не найден");

            order.DeleteOrderItems(orderItems);
        }
    }

    public void DeleteOrder(Order order)
    {
        _orders.Remove(order);
    }
}