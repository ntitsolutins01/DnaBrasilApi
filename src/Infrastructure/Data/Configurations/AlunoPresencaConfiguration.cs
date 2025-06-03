using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class AlunoPresencaConfiguration : IEntityTypeConfiguration<AlunoPresenca>
{
    public void Configure(EntityTypeBuilder<AlunoPresenca> builder)
    {
        builder.Property(t => t.Presenca)
            .IsRequired();
        builder.Property(t => t.Justificativa)
            .HasMaxLength(100);
    }
}
