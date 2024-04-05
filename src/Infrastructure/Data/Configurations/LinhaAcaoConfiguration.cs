using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class LinhaAcaoConfiguration : IEntityTypeConfiguration<LinhaAcao>
{
    public void Configure(EntityTypeBuilder<LinhaAcao> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(300)
            .IsRequired();
        builder.Property(t => t.Status)
            .IsRequired();
    }
}
