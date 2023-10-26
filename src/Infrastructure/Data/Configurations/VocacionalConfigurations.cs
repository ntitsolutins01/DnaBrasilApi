using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;
public class VocacionalConfigurations : IEntityTypeConfiguration<Vocacional>
{
    public void Configure(EntityTypeBuilder<Vocacional> builder)
    {
        builder.Property(t => t.Resposta)
            .HasMaxLength(80)
            .IsRequired();
    }
}
