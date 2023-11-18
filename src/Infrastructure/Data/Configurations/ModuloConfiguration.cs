using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class ModuloConfiguration : IEntityTypeConfiguration<Modulo>
{
    public void Configure(EntityTypeBuilder<Modulo> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(50)
            .IsRequired();
    }
}
