using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class ResponsavelConfiguration : IEntityTypeConfiguration<Responsavel>
{
    public void Configure(EntityTypeBuilder<Responsavel> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Cpf)
            .HasMaxLength(14)
            .IsRequired();
        builder.Property(t => t.Telefone)
            .HasMaxLength(20)
            .IsRequired();
        builder.Property(t => t.Email)
            .HasMaxLength(100);
    }
}
