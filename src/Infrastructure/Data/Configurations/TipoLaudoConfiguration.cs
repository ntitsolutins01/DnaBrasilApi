using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class TipoLaudoConfiguration : IEntityTypeConfiguration<TipoLaudo>
{
    public void Configure(EntityTypeBuilder<TipoLaudo> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(50)
            .IsRequired()
            .HasColumnOrder(1);
        builder.Property(t => t.Descricao)
            .HasMaxLength(150)
            .IsRequired()
            .HasColumnOrder(2);
    }
}
