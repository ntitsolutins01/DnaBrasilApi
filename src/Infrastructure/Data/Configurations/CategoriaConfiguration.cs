using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.Property(t => t.Codigo)
            .HasMaxLength(10)
            .IsRequired();
        builder.Property(t => t.Nome)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(t => t.IdadeInicial)
            .IsRequired();
        builder.Property(t => t.IdadeFinal)
            .IsRequired();
        builder.Property(t => t.Descricao)
            .HasMaxLength(500);

    }
}



