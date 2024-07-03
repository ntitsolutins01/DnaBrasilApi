using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class TipoLaudoConfiguration : IEntityTypeConfiguration<TipoLaudo>
{
    public void Configure(EntityTypeBuilder<TipoLaudo> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(t => t.Descricao)
            .HasMaxLength(300);
    }
}
