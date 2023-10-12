using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;
public class LocalConfiguration : IEntityTypeConfiguration<Local>
{
    public void Configure(EntityTypeBuilder<Local> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Descricao)
            .HasMaxLength(300)
            .IsRequired();
        builder.Property(t => t.Status)
            .IsRequired();
    }
}
