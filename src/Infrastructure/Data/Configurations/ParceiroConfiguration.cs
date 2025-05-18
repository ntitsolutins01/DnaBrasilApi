using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class ParceiroConfiguration : IEntityTypeConfiguration<Parceiro>
{
    public void Configure(EntityTypeBuilder<Parceiro> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Email)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(t => t.TipoPessoa)
            .IsRequired();
        builder.Property(t => t.CpfCnpj)
            .HasMaxLength(19)
            .IsRequired();
        builder.Property(t => t.Telefone)
            .HasMaxLength(14);
        builder.Property(t => t.Celular)
            .HasMaxLength(15);
        builder.Property(t => t.Cep)
            .HasMaxLength(9);
        builder.Property(t => t.Endereco)
            .HasMaxLength(200);
        builder.Property(t => t.Bairro)
            .HasMaxLength(50);
        builder.Property(t => t.RazaoSocial)
            .HasMaxLength(150);
        builder.Property(t => t.NomeContato)
            .HasMaxLength(150);
    }
}
