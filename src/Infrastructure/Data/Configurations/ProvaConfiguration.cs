using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class ProvaConfiguration : IEntityTypeConfiguration<Prova>
{
    public void Configure(EntityTypeBuilder<Prova> builder)
    {
        builder.Property(t => t.Titulo).HasMaxLength(250);
        
    }
}



