using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZooShop.Domain.Entities;

namespace ZooShop.Infrastructure.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product)).HasKey(p => p.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();
    }
}