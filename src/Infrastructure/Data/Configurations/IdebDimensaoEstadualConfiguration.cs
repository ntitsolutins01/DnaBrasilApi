using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class IdebDimensaoEstadualConfiguration : IEntityTypeConfiguration<IdebDimensaoEstadual>
{
    public void Configure(EntityTypeBuilder<IdebDimensaoEstadual> builder)
    {
        builder.Property(t => t.Ano)
            .HasMaxLength(4);
        builder.Property(t => t.Media).HasPrecision(10, 2);
    }
}
