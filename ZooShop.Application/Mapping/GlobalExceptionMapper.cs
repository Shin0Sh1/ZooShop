using ExceptionsLibrary.Interfaces;

namespace ZooShop.Application.Mapping;

public class GlobalExceptionMapper: IGlobalExceptionMapper
{
    public Exception Map(Exception ex)
    {
        return ex;
    }
}