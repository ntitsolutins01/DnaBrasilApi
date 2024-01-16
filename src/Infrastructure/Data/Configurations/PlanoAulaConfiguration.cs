using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class PlanoAulaConfiguration : IEntityTypeConfiguration<PlanoAula>
{
    public void Configure(EntityTypeBuilder<PlanoAula> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Modalidade)
            .HasMaxLength(50);
        builder.Property(t => t.TipoEscolaridade)
            .HasMaxLength(50);
        builder.Property(t => t.Url)
            .HasMaxLength(500);
    }
}
