using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class ControleMensalEstoqueConfiguration : IEntityTypeConfiguration<ControleMensalEstoque>
{
    public void Configure(EntityTypeBuilder<ControleMensalEstoque> builder)
    {
        builder.Property(t => t.JustificativaDanificadosExtraviados)
            .HasMaxLength(250);
    }
}
