using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class RespostaEadConfiguration : IEntityTypeConfiguration<RespostaEad>
{
    public void Configure(EntityTypeBuilder<RespostaEad> builder)
    {
        builder.Property(t => t.TipoResposta)
            .HasMaxLength(1)
            .IsRequired();
        builder.Property(t => t.Resposta)
            .HasMaxLength(2000)
            .IsRequired();
        builder.Property(t => t.ValorPesoResposta).HasPrecision(10, 2);
    }
}
