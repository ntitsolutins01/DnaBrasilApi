using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Email)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(t => t.DtNascimento)
            .IsRequired();
        builder.Property(t => t.Sexo)
            .HasMaxLength(1)
            .IsRequired();
        builder.Property(t => t.NomePai)
            .HasMaxLength(150);
        builder.Property(t => t.NomeMae)
            .HasMaxLength(150);
        builder.Property(t => t.Cpf)
            .HasMaxLength(14);
        builder.Property(t => t.Telefone)
            .HasMaxLength(13);
        builder.Property(t => t.Celular)
            .HasMaxLength(13);
        builder.Property(t => t.Cep)
            .HasMaxLength(9);
        builder.Property(t => t.Endereco)
            .HasMaxLength(200);
        builder.Property(t => t.Bairro)
            .HasMaxLength(50);
        builder.Property(t => t.Url)
            .HasMaxLength(200);
        builder.Property(t => t.Etnia)
            .HasMaxLength(10)
            .IsRequired();
        builder.Property(t => t.NomeResponsavel)
            .HasMaxLength(150);
        builder.Property(t => t.NomeResponsavel)
            .HasMaxLength(10);
    }
}
