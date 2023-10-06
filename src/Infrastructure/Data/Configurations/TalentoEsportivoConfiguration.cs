using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasil.Infrastructure.Data.Configurations;
public class TalentoEsportivoConfiguration : IEntityTypeConfiguration<TalentoEsportivo>
{
    public void Configure(EntityTypeBuilder<TalentoEsportivo> builder)
    {
        builder.Property(t => t.Flexibilidade)
            .IsRequired();
        builder.Property(t => t.PreensaoManual)
            .IsRequired();
        builder.Property(t => t.Agilidade)
            .IsRequired();
        builder.Property(t => t.Velocidade)
            .IsRequired();
        builder.Property(t => t.Abdominal)
            .IsRequired();
        builder.Property(t => t.AptidaoFisica)
            .IsRequired();
        builder.Property(t => t.ImpulsaoHorizontal)
            .IsRequired();
    }
}
