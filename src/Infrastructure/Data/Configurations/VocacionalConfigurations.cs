using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class VocacionalConfigurations : IEntityTypeConfiguration<Vocacional>
{
    public void Configure(EntityTypeBuilder<Vocacional> builder)
    {
        builder.Property(t => t.Respostas)
            .HasMaxLength(500);
        builder.Property(t => t.StatusVocacional)
            .HasMaxLength(1);
    }
}
