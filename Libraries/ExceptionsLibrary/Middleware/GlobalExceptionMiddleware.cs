using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using ExceptionsLibrary.Dto;
using ExceptionsLibrary.Exceptions;
using ExceptionsLibrary.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ExceptionsLibrary.Middleware;

/// <summary>
/// Мидлвар для обрабротки исключений
/// </summary>
public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IGlobalExceptionMapper _exceptionMapper;

    /// <summary>
    /// Конструктор ExceptionHandler
    /// </summary>
    /// <param name="exceptionMapper">Маппер исключений</param>
    /// <param name="next">Делегат для обработки HTTP запроса</param>
    public GlobalExceptionMiddleware(IGlobalExceptionMapper exceptionMapper, RequestDelegate next)
    {
        _next = next;
        _exceptionMapper = exceptionMapper;
    }

    /// <summary>
    /// Обработать исключение
    /// </summary>
    /// <param name="context">Контекст, который инкапсулирует всю информацию об отдельном http запросе и ответе</param>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            var mapException = _exceptionMapper.Map(ex);
            if (mapException is Refit.ApiException { Content: not null } refitException)
            {
                context.Response.StatusCode = (int)refitException.StatusCode;
                await SendMessageAsync(refitException.Content, context);
                return;
            }

            var errorResponse = new ErrorResponse
            {
                Message = mapException.Message,
                ExceptionType = mapException.GetType().ToString(),
                Data = mapException.Data,
                StackTrace = mapException.StackTrace ?? mapException.InnerException?.StackTrace
            };

            var errorResponseJson = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });

            context.Response.StatusCode = (int)MapStatusCode(mapException);
            await SendMessageAsync(errorResponseJson, context);
        }
    }

    private static HttpStatusCode MapStatusCode(Exception exception)
    {
        return exception switch
        {
            ArgumentException => HttpStatusCode.BadRequest,
            AlreadyExistException => HttpStatusCode.Conflict,
            NotFoundException => HttpStatusCode.NotFound,

            _ => HttpStatusCode.InternalServerError
        };
    }

    private static async Task SendMessageAsync(string message, HttpContext context)
    {
        context.Response.ContentType = "application/json; charset=utf-8";
        await context.Response.WriteAsync(message);
    }
}