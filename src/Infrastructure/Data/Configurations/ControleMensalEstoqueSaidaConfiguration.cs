using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class ControleMaterialEstoqueSaidaConfiguration : IEntityTypeConfiguration<ControleMaterialEstoqueSaida>
{
    public void Configure(EntityTypeBuilder<ControleMaterialEstoqueSaida> builder)
    {
        builder.Property(t => t.Solicitante)
            .HasMaxLength(150);
    }
}
