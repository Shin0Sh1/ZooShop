using ZooShop.Exceptions;
using ZooShop.Interfaces;

namespace ZooShop.Services;

public class ConsultantService : IConsultantService
{
    private readonly IConsultantRepository _consultantRepository;

    public ConsultantService(IConsultantRepository consultantRepository)
    {
        _consultantRepository = consultantRepository;
    }

    public async Task<Guid> GetConsultantIdByEmailAsync(string email)
    {
        var id = await _consultantRepository.GetEntityByFilterAndSelectAsync(c => c.Email == email, c => c.Id);
        if (id == Guid.Empty)
        {
            throw new EntityNotFoundException("Такого консультанта не существует");
        }

        return id;
    }
}