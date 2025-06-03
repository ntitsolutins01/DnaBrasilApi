using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class ConsumoAlimentarConfiguration : IEntityTypeConfiguration<ConsumoAlimentar>
{
    public void Configure(EntityTypeBuilder<ConsumoAlimentar> builder)
    {
        builder.Property(t => t.Respostas)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.StatusConsumoAlimentar)
            .HasMaxLength(1);
    }
}
