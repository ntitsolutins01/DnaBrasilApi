using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class EscolaridadeConfiguration : IEntityTypeConfiguration<Escolaridade>
{
    public void Configure(EntityTypeBuilder<Escolaridade> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(t => t.Status)
            .IsRequired();
        builder.Property(t => t.Descricao)
     .HasMaxLength(100);
    }
}
