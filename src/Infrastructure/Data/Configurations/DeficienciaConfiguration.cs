using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class DeficienciaConfiguration : IEntityTypeConfiguration<Deficiencia>
{
    public void Configure(EntityTypeBuilder<Deficiencia> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.Status)
            .IsRequired();
    }
}
