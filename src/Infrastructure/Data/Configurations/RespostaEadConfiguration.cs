using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class RespostaEadConfiguration : IEntityTypeConfiguration<RespostaEad>
{
    public void Configure(EntityTypeBuilder<RespostaEad> builder)
    {
        builder.Property(t => t.TipoResposta)
            .HasMaxLength(1)
            .IsRequired();
        builder.Property(t => t.TipoAlternativa)
            .HasMaxLength(6);
        builder.Property(t => t.Resposta)
            .HasMaxLength(1000)
            .IsRequired();
        builder.Property(t => t.ValorPesoResposta).HasPrecision(10, 2);
    }
}
