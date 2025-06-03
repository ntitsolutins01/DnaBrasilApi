using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class ArquivosInventarioConfiguration : IEntityTypeConfiguration<ArquivosInventario>
{
    public void Configure(EntityTypeBuilder<ArquivosInventario> builder)
    {
        builder.Property(t => t.NomeArquivo)
            .HasMaxLength(80);
    }
}
