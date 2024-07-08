using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class FotoEventoConfiguration : IEntityTypeConfiguration<FotoEvento>
{
    public void Configure(EntityTypeBuilder<FotoEvento> builder)
    {
        builder.Property(t => t.NomeArquivo)
            .HasMaxLength(250)
            .IsRequired();
        builder.Property(t => t.Url)
            .HasMaxLength(500);
    }
}
