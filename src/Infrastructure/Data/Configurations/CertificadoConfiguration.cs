using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class CertificadoConfiguration : IEntityTypeConfiguration<Certificado>
{
    public void Configure(EntityTypeBuilder<Certificado> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(t => t.Url)
            .HasMaxLength(2000)
            .IsRequired();

    }
}



