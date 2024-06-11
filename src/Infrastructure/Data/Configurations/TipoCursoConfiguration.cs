using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class TipoCursoConfiguration : IEntityTypeConfiguration<TipoCurso>
{
    public void Configure(EntityTypeBuilder<TipoCurso> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
    }
}
