using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;
internal class ParceiroConfiguration : IEntityTypeConfiguration<Parceiro>
{
    public void Configure(EntityTypeBuilder<Parceiro> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Email)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.TipoPessoa)
            .IsRequired();
        builder.Property(t => t.CpfCnpj)
            .HasMaxLength(18)
            .IsRequired();
        builder.Property(t => t.Telefone)
            .HasMaxLength(11);
        builder.Property(t => t.Celular)
            .HasMaxLength(11);
        builder.Property(t => t.CEP)
            .HasMaxLength(9);
        builder.Property(t => t.Endereco)
            .HasMaxLength(200);
        builder.Property(t => t.Numero)
            .HasMaxLength(80);
        builder.Property(t => t.Bairro)
            .HasMaxLength(80);
    }
}
