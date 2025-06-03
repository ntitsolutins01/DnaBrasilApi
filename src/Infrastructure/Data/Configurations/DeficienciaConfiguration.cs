using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class DeficienciaConfiguration : IEntityTypeConfiguration<Deficiencia>
{
    public void Configure(EntityTypeBuilder<Deficiencia> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.Status)
            .IsRequired();
    }
}
