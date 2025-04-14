using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class ControleFrequenciaConfiguration : IEntityTypeConfiguration<ControleFrequencia>
{
    public void Configure(EntityTypeBuilder<ControleFrequencia> builder)
    {
        builder.Property(t => t.Presenca)
            .HasMaxLength(1);
        builder.Property(t => t.Justificativa)
            .HasMaxLength(500);
        builder.Property(t => t.Status)
            .IsRequired();
    }
}
