using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class ControleMaterialConfiguration : IEntityTypeConfiguration<ControleMaterial>
{
    public void Configure(EntityTypeBuilder<ControleMaterial> builder)
    {
        builder.Property(t => t.Descricao)
            .HasMaxLength(500)
            .IsRequired();
        builder.Property(t => t.UnidadeMedida)
            .HasMaxLength(15)
            .IsRequired();
    }
}
