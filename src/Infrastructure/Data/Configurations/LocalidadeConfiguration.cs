using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class LocalidadeConfiguration : IEntityTypeConfiguration<Localidade>
{
    public void Configure(EntityTypeBuilder<Localidade> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Descricao)
            .HasMaxLength(300)
            .IsRequired();
        builder.Property(t => t.Status)
            .IsRequired();
    }
}
