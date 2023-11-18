using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class ConsumoAlimentarConfiguration : IEntityTypeConfiguration<ConsumoAlimentar>
{
    public void Configure(EntityTypeBuilder<ConsumoAlimentar> builder)
    {
        builder.Property(t => t.Resposta)
            .HasMaxLength(80)
            .IsRequired();
    }
}
