using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class ProfissionalConfigurations : IEntityTypeConfiguration<Profissional>
{
    public void Configure(EntityTypeBuilder<Profissional> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Email)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Sexo)
            .HasMaxLength(1);
        builder.Property(t => t.CpfCnpj)
            .HasMaxLength(14)
            .IsRequired();
        builder.Property(t => t.Telefone)
            .HasMaxLength(14);
        builder.Property(t => t.Celular)
            .HasMaxLength(14);
        builder.Property(t => t.Endereco)
            .HasMaxLength(250);
        builder.Property(t => t.Bairro)
            .HasMaxLength(100);
        builder.Property(t => t.Cep)
            .HasMaxLength(9);
        builder.Property(t => t.Status)
            .IsRequired();
    }
}
