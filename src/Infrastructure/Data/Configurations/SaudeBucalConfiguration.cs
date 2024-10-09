using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class SaudeBucalConfiguration : IEntityTypeConfiguration<SaudeBucal>
{
    public void Configure(EntityTypeBuilder<SaudeBucal> builder)
    {
        builder.Property(t => t.Respostas)
            .HasMaxLength(500)
            .IsRequired(); 
        builder.Property(t => t.StatusSaudeBucal)
            .HasMaxLength(1);
    }
}
