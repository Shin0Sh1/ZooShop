using ExceptionsLibrary.Interfaces;

namespace ZooShop.Mapping;

public class GlobalExceptionMapper: IGlobalExceptionMapper
{
    public Exception Map(Exception ex)
    {
        return ex;
    }
}