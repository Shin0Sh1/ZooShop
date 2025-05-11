using Microsoft.EntityFrameworkCore;
using ZooShop.Entities;

namespace ZooShop.Configurations;

public class ZooShopContext : DbContext
{
    public DbSet<User> Clients { get; set; }
    public DbSet<Consultant> Consultants { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public ZooShopContext(DbContextOptions<ZooShopContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ConsultantConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}