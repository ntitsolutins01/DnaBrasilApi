using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class TipoParceriaConfiguration : IEntityTypeConfiguration<TipoParceria>
{
    public void Configure(EntityTypeBuilder<TipoParceria> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Status)
            .IsRequired();
    }
}
