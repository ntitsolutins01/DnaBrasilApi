using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class ModeloCarteirinhaConfiguration : IEntityTypeConfiguration<ModeloCarteirinha>
{
    public void Configure(EntityTypeBuilder<ModeloCarteirinha> builder)
    {
        builder.Property(t => t.NomeImagemFrente)
            .HasMaxLength(70);
        builder.Property(t => t.UrlImagemFrente)
            .HasMaxLength(150);
        builder.Property(t => t.NomeImagemVerso)
            .HasMaxLength(70);
        builder.Property(t => t.UrlImagemVerso)
            .HasMaxLength(150);
    }
}
