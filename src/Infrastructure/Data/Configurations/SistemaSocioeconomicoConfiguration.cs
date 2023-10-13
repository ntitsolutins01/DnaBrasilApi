using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;
internal class SistemaSocioeconomicoConfiguration : IEntityTypeConfiguration<SistemaSocioeconomico>
{
    public void Configure(EntityTypeBuilder<SistemaSocioeconomico> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Email)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.TipoPessoa)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.CpfCnpj)
            .HasMaxLength(18)
            .IsRequired();
        builder.Property(t => t.Telefone)
            .HasMaxLength(11);
        builder.Property(t => t.Celular)
            .HasMaxLength(11);
        builder.Property(t => t.CEP)
            .HasMaxLength(8);
        builder.Property(t => t.Endereco)
            .HasMaxLength(80);
        builder.Property(t => t.Numero)
            .HasMaxLength(80);
        builder.Property(t => t.Bairro)
            .HasMaxLength(80);
    }
}
