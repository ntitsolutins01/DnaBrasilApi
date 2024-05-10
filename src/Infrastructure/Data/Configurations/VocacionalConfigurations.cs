using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class VocacionalConfigurations : IEntityTypeConfiguration<Vocacional>
{
    public void Configure(EntityTypeBuilder<Vocacional> builder)
    {
        builder.Property(t => t.Resposta)
            .HasMaxLength(500);
        builder.Property(t => t.StatusVocacionail)
            .HasMaxLength(1);
    }
}
