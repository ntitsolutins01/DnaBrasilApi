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
            .IsRequired()
            .HasColumnOrder(1);
        builder.Property(t => t.Descricao)
            .HasMaxLength(150)
            .IsRequired()
            .HasColumnOrder(2);
        builder.Property(t => t.IdadeInicial)
            .IsRequired()
            .HasColumnOrder(3);
        builder.Property(t => t.IdadeFinal)
            .IsRequired()
            .HasColumnOrder(4);
        builder.Property(t => t.ScoreTotal)
            .IsRequired()
            .HasColumnOrder(5);
        builder.Property(t => t.Status)
            .IsRequired()
            .HasColumnOrder(6);
    }
}
