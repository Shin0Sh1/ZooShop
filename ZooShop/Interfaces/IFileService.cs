using ZooShop.Dtos.ResponseDtos;

namespace ZooShop.Interfaces;

public interface IFileService
{
    string? GetImageExtension(Guid imageId);
    Task<ImageDto> GetImageAsync(string imageName);
    Task<string> SaveImageAsync(IFormFile file);
    void DeleteImage(string imageName);
}