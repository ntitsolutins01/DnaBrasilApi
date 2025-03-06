using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class AlunoCertificadoConfiguration : IEntityTypeConfiguration<AlunoCertificado>
{
    public void Configure(EntityTypeBuilder<AlunoCertificado> builder)
    {
        
    }
}
