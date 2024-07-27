using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class EventoConfiguration : IEntityTypeConfiguration<Evento>
{
    public void Configure(EntityTypeBuilder<Evento> builder)
    {
        builder.Property(t => t.Titulo)
            .HasMaxLength(250)
            .IsRequired();
        builder.Property(t => t.Descricao)
            .HasMaxLength(500);
    }
}
