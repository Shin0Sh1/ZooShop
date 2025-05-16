namespace ZooShop.Interfaces;

public interface IFileService
{
    Guid SaveFile(IFormFile file);
}