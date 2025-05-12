namespace ZooShop.Entities;

public class User : BaseEntity
{
    public string Nickname { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string? Address { get; private set; }

    public ICollection<Order>? Orders { get; private set; }

    public User(Guid id, string nickname, string email, string password, string? address,
        ICollection<Order>? orders = null) : base(id)
    {
        Nickname = nickname;
        Email = email;
        Password = password;
        Address = address;
        Orders = orders;
    }

    private User() : base(Guid.NewGuid())
    {
    }
}