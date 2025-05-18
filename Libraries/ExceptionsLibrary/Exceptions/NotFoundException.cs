namespace ExceptionsLibrary.Exceptions;

/// <summary>
/// Исключение которое используется в случае если какой-либо объект не найден
/// </summary>
/// <remarks>Status code 404</remarks>
[Serializable]
public class NotFoundException : Exception
{
    /// <summary>
    /// Конструктор без параметров для инициализации
    /// </summary>
    public NotFoundException()
    {
    }

    /// <summary>
    /// Конструктор с параметром message для вывода сообщения
    /// </summary>
    /// <param name="message">Сообщение для вывода исключения</param>
    public NotFoundException(string message) : base(message)
    {
    }

    /// <summary>
    /// Конструктор служит для создания пользовательского исключения с дополнительными деталями о причине ошибки.
    /// </summary>
    /// <param name="message">Сообщение для вывода исключения</param>
    /// <param name="innerException">Вложенное исключение, которое может содержать информацию о предыдущей ошибке, которая вызвала текущее исключение</param>
    public NotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}