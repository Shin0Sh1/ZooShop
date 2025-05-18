namespace ExceptionsLibrary.Exceptions;

/// <summary>
/// Исключение которое используется в случае если какой-либо объект уже существует
/// </summary>
/// <remarks>Status code 409</remarks>
[Serializable]
public class AlreadyExistException : Exception
{
    /// <summary>
    /// Конструктор без параметров для инициализации
    /// </summary>
    public AlreadyExistException()
    {
    }

    /// <summary>
    /// Конструктор с параметром message для вывода сообщения
    /// </summary>
    /// <param name="message">Сообщение для вывода исключения</param>
    public AlreadyExistException(string message) : base(message)
    {
    }

    /// <summary>
    /// Конструктор служит для создания пользовательского исключения с дополнительными деталями о причине ошибки.
    /// </summary>
    /// <param name="message">Сообщение для вывода исключения</param>
    /// <param name="innerException">Вложенное исключение, которое может содержать информацию о предыдущей ошибке, которая вызвала текущее исключение</param>
    public AlreadyExistException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}