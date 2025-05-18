using System.Collections;

namespace ExceptionsLibrary.Dto;

/// <summary>
/// Данные для формирования текста ошибки
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// Сообщение исключения
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Тип исключения
    /// </summary>
    public string ExceptionType { get; set; } = null!;

    /// <summary>
    /// Хранит дополнительную информацию связанную с исключением
    /// </summary>
    public IDictionary Data { get; set; } = null!;

    /// <summary>
    /// Трассировка стека
    /// </summary>
    public string? StackTrace { get; set; }
}