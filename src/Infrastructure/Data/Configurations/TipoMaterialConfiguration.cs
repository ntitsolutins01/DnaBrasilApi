using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class TipoMaterialConfiguration : IEntityTypeConfiguration<TipoMaterial>
{
    public void Configure(EntityTypeBuilder<TipoMaterial> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
    }
}
