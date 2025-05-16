using Microsoft.Extensions.Options;
using ZooShop.Dtos.ResponseDtos;
using ZooShop.Interfaces;
using ZooShop.Options;

namespace ZooShop.Services;

public class FileService(IOptions<ZooShopOptions> options) : IFileService
{
    public string? GetImageExtension(Guid imageId)
    {
        var filePath = Directory.GetFiles(options.Value.ImageFolderName).SingleOrDefault(c =>
        {
            var extension = Path.GetExtension(c);
            return Path.GetFileName(c) == $"{imageId}{extension}";
        });
        return Path.GetExtension(filePath);
    }

    public async Task<ImageDto> GetImageAsync(string imageName)
    {
        var filePath = Path.Combine($"{options.Value.ImageFolderName}", $"{imageName}");

        if (!Path.Exists(filePath))
        {
            throw new FileNotFoundException("Такой картинки не существует");
        }

        return new ImageDto
        {
            Image = await File.ReadAllBytesAsync(filePath),
            Extension = Path.GetExtension(filePath)
        };
    }

    public async Task<string> SaveImageAsync(IFormFile file)
    {
        var fileName = Guid.NewGuid();
        var fileExtension = Path.GetExtension(file.FileName);
        var filePath = Path.Combine($"{options.Value.ImageFolderName}", $"{fileName}{fileExtension}");
        if (!Directory.Exists(options.Value.ImageFolderName))
        {
            Directory.CreateDirectory(options.Value.ImageFolderName);
        }

        await using var fileStream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(fileStream);

        return $"{options.Value.BaseUrl}{options.Value.ImageFolderName}/{fileName}{fileExtension}";
    }

    public void DeleteImage(string imageName)
    {
        var filePath = Path.Combine($"{options.Value.ImageFolderName}", $"{imageName}");
        if (!Path.Exists(filePath))
        {
            throw new FileNotFoundException("Такой картинки не существует");
        }

        File.Delete(filePath);
    }
}