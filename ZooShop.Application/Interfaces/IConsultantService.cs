namespace ZooShop.Application.Interfaces;

public interface IConsultantService
{
    Task<Guid> GetConsultantIdByEmailAsync(string email);
}