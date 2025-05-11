using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZooShop.Entities;

namespace ZooShop.Configurations;

public class ConsultantConfiguration : IEntityTypeConfiguration<Consultant>
{
    public void Configure(EntityTypeBuilder<Consultant> builder)
    {
        builder.ToTable(nameof(Consultant)).HasKey(c => c.Id);
    }
}