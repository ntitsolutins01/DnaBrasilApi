using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.Descricao)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(t => t.DtIni)
            .IsRequired();
        builder.Property(t => t.DtFim)
            .IsRequired();
        builder.Property(t => t.Anexo)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(t => t.Status)
            .IsRequired();
    }
}
