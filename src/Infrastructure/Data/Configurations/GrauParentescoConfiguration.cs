using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class GrauParentescoConfiguration : IEntityTypeConfiguration<GrauParentesco>
{
    public void Configure(EntityTypeBuilder<GrauParentesco> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(20)
            .IsRequired();
    }
}
