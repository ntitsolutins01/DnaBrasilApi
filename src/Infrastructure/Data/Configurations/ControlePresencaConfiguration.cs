using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class ControlePresencaConfiguration : IEntityTypeConfiguration<ControlePresenca>
{
    public void Configure(EntityTypeBuilder<ControlePresenca> builder)
    {
        builder.Property(t => t.Controle)
            .HasMaxLength(1);
        builder.Property(t => t.Justificativa)
            .HasMaxLength(500);
        builder.Property(t => t.Status)
            .IsRequired();
    }
}
