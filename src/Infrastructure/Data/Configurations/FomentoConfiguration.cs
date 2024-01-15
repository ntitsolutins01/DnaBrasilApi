using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class FomentoConfiguration : IEntityTypeConfiguration<Fomentu>
{
    public void Configure(EntityTypeBuilder<Fomentu> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(300)
            .IsRequired();
        builder.Property(t => t.Codigo)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(t => t.DtIni)
            .IsRequired();
        builder.Property(t => t.DtFim)
            .IsRequired();
    }
}
