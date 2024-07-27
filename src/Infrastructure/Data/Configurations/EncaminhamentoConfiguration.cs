using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class EncaminhamentoConfiguration : IEntityTypeConfiguration<Encaminhamento>
{
    public void Configure(EntityTypeBuilder<Encaminhamento> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Parametro)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Descricao)
            .HasMaxLength(500);
    }
}
