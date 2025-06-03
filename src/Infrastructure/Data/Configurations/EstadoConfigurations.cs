using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class EstadoConfigurations : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.Property(t => t.Sigla)
            .HasMaxLength(2)
            .IsRequired();
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
    }
}
