using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class FuncionalidadeConfiguration : IEntityTypeConfiguration<Funcionalidade>
{
    public void Configure(EntityTypeBuilder<Funcionalidade> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(300)
            .IsRequired();
    }
}
