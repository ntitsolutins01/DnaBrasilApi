using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasil.Infrastructure.Data.Configurations;

public class SerieConfiguration : IEntityTypeConfiguration<Serie>
{
    public void Configure(EntityTypeBuilder<Serie> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(t => t.Descricao)
            .HasMaxLength(200)
            .IsRequired();
    }
}
