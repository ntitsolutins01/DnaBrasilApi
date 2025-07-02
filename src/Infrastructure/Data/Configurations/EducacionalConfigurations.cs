using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class EducacionalConfigurations : IEntityTypeConfiguration<Educacional>
{
    public void Configure(EntityTypeBuilder<Educacional> builder)
    {
        builder.Property(t => t.Respostas)
            .HasMaxLength(500);
        builder.Property(t => t.Gabarito)
            .HasMaxLength(3);
        builder.Property(t => t.StatusEducacional)
            .HasMaxLength(1);
    }
}
