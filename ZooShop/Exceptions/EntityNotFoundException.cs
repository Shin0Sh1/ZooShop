using ExceptionsLibrary.Exceptions;

namespace ZooShop.Exceptions;

public class EntityNotFoundException : NotFoundException
{
    public EntityNotFoundException(string message) : base(message)
    {
        
    }
}