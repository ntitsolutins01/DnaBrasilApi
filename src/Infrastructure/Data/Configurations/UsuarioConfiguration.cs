using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;
public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(t => t.AspNetUserId)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Email)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(t => t.Cpf)
            .HasMaxLength(14)
            .IsRequired();
        builder.Property(t => t.AspNetRoleId)
            .HasMaxLength(50)
            .IsRequired();
    }
}
