using ExceptionsLibrary.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZooShop.Entities;
using ZooShop.Interfaces;

namespace ZooShop.Configurations;

public class IdentityDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
    }

    public async Task SeedIdentityDataAsync(IServiceProvider serviceProvider,
        IConsultantRepository consultantRepository, IHashService hashService)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        if (!await roleManager.RoleExistsAsync("Consultant"))
        {
            await roleManager.CreateAsync(new IdentityRole("Consultant"));
        }

        if (!await roleManager.RoleExistsAsync("User"))
        {
            await roleManager.CreateAsync(new IdentityRole("User"));
        }

        const string email = "consultant@gmail.com";
        const string password = "12345Kalitero$";
        if (await userManager.FindByEmailAsync(email) == null)
        {
            var user = new IdentityUser
            {
                UserName = email,
                Email = email,
            };
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Consultant");
            }
        }

        if (!await consultantRepository.AnyByFilterAsync(c => c.Email == email))
        {
            var findByEmailAsync = await userManager.FindByEmailAsync(email) ??
                                   throw new NotFoundException("Такого консультанта не существует");
            await consultantRepository.AddAsync(new Consultant(Guid.NewGuid(), "TEst123", "Ivan", "Karaush", null,
                DateTime.UtcNow, email, findByEmailAsync.PasswordHash ?? hashService.Hash(password)));
            await consultantRepository.SaveChangesAsync();
        }
    }
}