using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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
            .HasMaxLength(18)
            .IsRequired();
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
    }
}
