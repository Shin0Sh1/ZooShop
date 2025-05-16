namespace ZooShop.Entities;

public abstract class BaseEntity(Guid id)
{
    public Guid Id { get; init; } = id;
}