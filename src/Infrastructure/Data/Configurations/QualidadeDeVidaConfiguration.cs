using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class QualidadeDeVidaConfiguration : IEntityTypeConfiguration<QualidadeDeVida>
{
    public void Configure(EntityTypeBuilder<QualidadeDeVida> builder)
    {
        builder.Property(t => t.Respostas)
            .HasMaxLength(500);
        builder.Property(t => t.StatusQualidadeDeVida)
            .HasMaxLength(1);
    }
}
