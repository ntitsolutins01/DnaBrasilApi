using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class TalentoEsportivoConfiguration : IEntityTypeConfiguration<TalentoEsportivo>
{
    public void Configure(EntityTypeBuilder<TalentoEsportivo> builder)
    {
        builder.Property(t => t.Flexibilidade).HasPrecision(10, 2);
        builder.Property(t => t.PreensaoManual).HasPrecision(10, 2);
        builder.Property(t => t.Velocidade).HasPrecision(10, 2);
        builder.Property(t => t.Abdominal).HasPrecision(10, 2);
        builder.Property(t => t.AptidaoFisica).HasPrecision(10, 2);
        builder.Property(t => t.ImpulsaoHorizontal).HasPrecision(10, 2);
    }
}
