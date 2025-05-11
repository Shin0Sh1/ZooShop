namespace ZooShop.Entities;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; set; }
    public required User User { get; set; }
    
    public ICollection<OrderItem> OrderItems { get; set; }
}