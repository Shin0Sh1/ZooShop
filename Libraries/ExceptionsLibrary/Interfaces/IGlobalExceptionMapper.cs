namespace ExceptionsLibrary.Interfaces;

public interface IGlobalExceptionMapper
{
    Exception Map(Exception ex);
}