namespace ZooShop.Entities;

public abstract class BaseEntity(Guid id)
{
    public Guid Id { get; init; } = id;

    public override bool Equals(object? obj)
    {
        if (obj is not BaseEntity entity) return false;

        return entity.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}