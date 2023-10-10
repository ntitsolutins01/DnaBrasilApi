using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;
internal class AlunoDeficienciasConfiguration : IEntityTypeConfiguration<AlunoDeficiencias>
{
    public void Configure(EntityTypeBuilder<AlunoDeficiencias> builder)
    {
        builder.Property(t => t.Deficiencia)
            .HasMaxLength(80)
            .IsRequired();
    }
}
