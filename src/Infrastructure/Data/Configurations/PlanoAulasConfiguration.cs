using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;
internal class PlanoAulasConfiguration : IEntityTypeConfiguration<PlanoAulas>
{
    public void Configure(EntityTypeBuilder<PlanoAulas> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Grade)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.Url)
            .HasMaxLength(150)
            .IsRequired();
    }
}
