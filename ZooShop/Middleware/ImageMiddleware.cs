using System.Net.Mime;
using ZooShop.Interfaces;

namespace ZooShop.Middleware;

public class ImageMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, IFileService fileService)
    {
        if (!context.Request.Path.StartsWithSegments("/Images", out var remainingPath))
        {
            await next(context);
            return;
        }

        var imageName = remainingPath.Value?.TrimStart('/');
        if (string.IsNullOrEmpty(imageName))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("Некорректный imageId");
            return;
        }

        try
        {
            var image = await fileService.GetImageAsync(imageName);


            var contentType = Path.GetExtension(imageName) switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                _ => MediaTypeNames.Application.Octet
            };

            context.Response.ContentType = contentType;
            await context.Response.Body.WriteAsync(image.Image);
        }
        catch (FileNotFoundException)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync("Такой картинки не существует");
        }
    }
}