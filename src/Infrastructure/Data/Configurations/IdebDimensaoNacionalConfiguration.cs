using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class IdebDimensaoNacionalConfiguration : IEntityTypeConfiguration<IdebDimensaoNacional>
{
    public void Configure(EntityTypeBuilder<IdebDimensaoNacional> builder)
    {
        builder.Property(t => t.Ano)
            .HasMaxLength(4);
        builder.Property(t => t.Media).HasPrecision(10, 2);
    }
}
