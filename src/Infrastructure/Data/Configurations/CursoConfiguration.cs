using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class CursoConfiguration : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.Property(t => t.Titulo)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Descricao)
            .HasMaxLength(500)
            .IsRequired();
        builder.Property(t => t.Imagem)
            .HasMaxLength(200);
        builder.Property(t => t.NomeImagem)
            .HasMaxLength(100);
    }
}
