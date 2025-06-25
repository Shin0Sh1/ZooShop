using ExceptionsLibrary.Exceptions;

namespace ZooShop.Domain.Exceptions;

public class EntityNotFoundException : NotFoundException
{
    public EntityNotFoundException(string message) : base(message)
    {
        
    }
}