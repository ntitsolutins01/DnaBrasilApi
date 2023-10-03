using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasil.Infrastructure.Data.Configurations;

public class TipoLaudoConfiguration : IEntityTypeConfiguration<TipoLaudo>
{
    public void Configure(EntityTypeBuilder<TipoLaudo> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(t => t.Descricao)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.IdadeInicial)
            .IsRequired();
        builder.Property(t => t.IdadeFinal)
            .IsRequired();
        builder.Property(t => t.ScoreTotal)
            .IsRequired();
    }
}
