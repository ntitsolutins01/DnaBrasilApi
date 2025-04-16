using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class ModuloEadConfiguration : IEntityTypeConfiguration<ModuloEad>
{
    public void Configure(EntityTypeBuilder<ModuloEad> builder)
    {
        builder.Property(t => t.Titulo)
            .HasMaxLength(250)
            .IsRequired();
        builder.Property(t => t.Descricao)
            .HasMaxLength(500);
    }
}



