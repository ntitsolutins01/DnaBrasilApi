using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class SaudeConfiguration : IEntityTypeConfiguration<Saude>
{
    public void Configure(EntityTypeBuilder<Saude> builder)
    {
        builder.Property(t => t.Altura).HasPrecision(10, 2);
        builder.Property(t => t.Massa).HasPrecision(10, 2);
        builder.Property(t => t.Envergadura).HasPrecision(10, 2);
        builder.Property(t => t.StatusSaude).HasMaxLength(1);
    }
}
