using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class ControleMaterialEstoqueSaidaConfiguration : IEntityTypeConfiguration<ControleMaterialEstoqueSaida>
{
    public void Configure(EntityTypeBuilder<ControleMaterialEstoqueSaida> builder)
    {

    }
}
