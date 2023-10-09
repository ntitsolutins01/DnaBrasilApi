using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;
public class SaudeBucalConfiguration : IEntityTypeConfiguration<SaudeBucal>
{
    public void Configure(EntityTypeBuilder<SaudeBucal> builder)
    {
        builder.Property(t => t.Descricao)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Resposta)
            .HasMaxLength(80)
            .IsRequired();
    }
}
