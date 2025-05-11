using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZooShop.Entities;

namespace ZooShop.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable(nameof(OrderItem)).HasKey(o => o.Id);
        
        builder.HasOne(o => o.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(o => o.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(o => o.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}