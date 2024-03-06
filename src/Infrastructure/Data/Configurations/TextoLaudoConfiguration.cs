using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class TextoLaudoConfiguration : IEntityTypeConfiguration<TextoLaudo>
{
    public void Configure(EntityTypeBuilder<TextoLaudo> builder)
    {
        builder.Property(t => t.Aviso).HasMaxLength(100); 
        builder.Property(t => t.Texto).HasMaxLength(500); 
        builder.Property(t => t.Classificacao).HasMaxLength(100);
        builder.Property(t => t.PontoInicial).HasPrecision(10, 2);
        builder.Property(t => t.PontoFinal).HasPrecision(10, 2);
    }
}
