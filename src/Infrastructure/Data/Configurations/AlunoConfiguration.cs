using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;
internal class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.Email)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.Senha)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.DtNascimento)
            .IsRequired();
        builder.Property(t => t.NomePai)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.NomeMae)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.CPF)
            .HasMaxLength(13)
            .IsRequired();
        builder.Property(t => t.Telefone)
            .HasMaxLength(11)
            .IsRequired();
        builder.Property(t => t.Celular)
            .HasMaxLength(11)
            .IsRequired();
        builder.Property(t => t.CEP)
            .HasMaxLength(8)
            .IsRequired();
        builder.Property(t => t.Endereco)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.EnderecoNumero)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.Bairro)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.Social)
            .HasMaxLength(100);
        builder.Property(t => t.Status)
            .IsRequired();
        builder.Property(t => t.Habilitado)
            .IsRequired();
    }
}
