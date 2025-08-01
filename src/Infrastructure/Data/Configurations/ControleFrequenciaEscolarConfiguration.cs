using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class ControleFrequenciaEscolarConfiguration : IEntityTypeConfiguration<ControleFrequenciaEscolar>
{
    public void Configure(EntityTypeBuilder<ControleFrequenciaEscolar> builder)
    {
        builder.Property(t => t.Controle)
            .HasMaxLength(1)
            .IsRequired();
    }
}
