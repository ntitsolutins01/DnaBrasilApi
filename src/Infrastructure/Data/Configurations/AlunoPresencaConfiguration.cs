using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class AlunoPresencaConfiguration : IEntityTypeConfiguration<AlunoPresenca>
{
    public void Configure(EntityTypeBuilder<AlunoPresenca> builder)
    {
        builder.Property(t => t.Presenca)
            .HasMaxLength(1)
            .IsRequired();
        builder.Property(t => t.Justificativa)
            .HasMaxLength(100);
    }
}
