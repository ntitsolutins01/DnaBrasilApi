using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class GrupoMaterialConfiguration : IEntityTypeConfiguration<GrupoMaterial>
{
    public void Configure(EntityTypeBuilder<GrupoMaterial> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
    }
}
